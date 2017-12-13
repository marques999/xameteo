using System.Collections.Generic;
using System.Linq;

using SkiaSharp.Views.Forms;

using Xameteo.API;
using Xameteo.Globalization;
using Xameteo.Model;

using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryView
    {
        /// <summary>
        /// </summary>
        private readonly SkiaGraph _graph;

        /// <summary>
        /// </summary>
        public List<TableGroup> Items { get; } = new List<TableGroup>();

        /// <summary>
        /// </summary>
        /// <param name="forecast"></param>
        public HistoryView(ForecastDaily forecast)
        {
            _graph = new SkiaGraph(forecast.Hours.Select(hour => new GraphIndex
            {
                Y = (float)hour.Temperature,
                Hide = hour.Date.Hour % 3 != 1,
                Label = XameteoL10N.OnlyHour(hour.Date),
                ImageId = hour.Condition.Image(hour.IsDay)
            }).ToList());

            Items.Add(forecast.Day.GenerateTable());
            Items.Add(forecast.Astro.GenerateTable());
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnDrawGraph(object sender, SKPaintSurfaceEventArgs args)
        {
            _graph.DrawGraph(args.Surface.Canvas, args.Info.Width, args.Info.Height);
        }
    }
}