using System.Collections.Generic;
using System.Linq;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xameteo.Model;
using Xamarin.Forms.Xaml;
using Xameteo.API;
using Xameteo.Globalization;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastPage
    {
        /// <summary>
        /// </summary>
        private readonly SkiaGraph _graph;

        /// <summary>
        /// </summary>
        public List<ForecastDaily> Items { get; }

        /// <summary>
        /// </summary>
        public ForecastPage(Forecast forecast)
        {
            _graph = new SkiaGraph(forecast.Days.Select(hour => new GraphIndex
            {
                Hide = false,
                Y = (float)hour.Day.Average,
                ImageId = hour.Day.Condition.Image(true),
                Label = XameteoL10N.OnlyDayMonth(hour.Date)     
            }).Take(5).ToList());

            Items = forecast.Days;
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ShowModal(object sender, ItemTappedEventArgs e)
        {
            if ((sender as ListView)?.SelectedItem != null)
            {
                //await Navigation.PushModalAsync(new ForecastPage(Items[0]));
            }
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