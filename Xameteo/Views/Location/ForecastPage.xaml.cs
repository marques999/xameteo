﻿using System.Linq;
using System.Collections.Generic;

using Xameteo.API;
using Xameteo.Model;
using Xameteo.Globalization;

using SkiaSharp.Views.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            }).Take(7).ToList());

            Items = forecast.Days;
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ShowModal(object sender, ItemTappedEventArgs args)
        {
            if (sender is ListView listView)
            {
                if (listView.SelectedItem is ForecastDaily forecast)
                {
                    await Navigation.PushModalAsync(new ForecastPopup(forecast));
                }

                listView.SelectedItem = null;
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