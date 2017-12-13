using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

using SkiaSharp.Views.Forms;

using Xameteo.API;
using Xameteo.Model;
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
        private readonly SkiaGraph _graph;

        /// <summary>
        /// </summary>
        public List<TableGroup> Items { get; } = new List<TableGroup>();

        /// <summary>
        /// </summary>
        public TodayPage(ForecastDaily forecast)
        {
            _graph = new SkiaGraph(forecast.Hours.Select(hour => new GraphIndex
            {
                Hide = hour.Date.Hour % 3 != 1,
                Y = (float)hour.Temperature,
                Label = XameteoL10N.OnlyHour(hour.Date),
                ImageId = hour.Condition.Image(hour.IsDay)
            }).ToList());

            forecast.Hours.ForEach(it => Items.Add(it.GenerateTable()));
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