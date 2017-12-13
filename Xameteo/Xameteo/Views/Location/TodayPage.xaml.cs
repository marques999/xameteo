using Xameteo.Model;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using SkiaSharp.Views.Forms;
using Xameteo.API;
using Xameteo.Globalization;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayPage
    {
        /// <summary>
        /// </summary>
        public List<TableGroup> Items { get; } = new List<TableGroup>();

        private SkiaGraph _graph;

        /// <summary>
        /// </summary>
        public TodayPage(ForecastDaily forecast)
        {
            Items.Add(forecast.Astro.GenerateTable());

            var graphPoints = new List<GraphIndex>();

            foreach (var hour in forecast.Hours)
            {
                Items.Add(hour.GenerateTable());

                graphPoints.Add(new GraphIndex
                {
                    Hide = hour.Date.Hour % 3 != 1,
                    Label = XameteoL10N.OnlyHour(hour.Date),
                    ImageId = hour.Condition.Image(hour.IsDay),
                    Y = (float) hour.Temperature
                });
            }

            _graph = new SkiaGraph(graphPoints);
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDrawGraph(object sender, SKPaintSurfaceEventArgs e)
        {
            _graph.DrawGraph(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }
    }
}