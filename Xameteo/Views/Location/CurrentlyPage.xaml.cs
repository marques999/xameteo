using System;
using System.Collections.Generic;

using Xameteo.API;
using Xameteo.Model;

using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentlyPage
    {
        /// <summary>
        /// </summary>
        public Current Weather { get; }

        /// <summary>
        /// </summary>
        public DateTime LastUpdated { get; }

        /// <summary>
        /// </summary>
        public List<TableGroup> Items { get; } = new List<TableGroup>();

        /// <summary>
        /// </summary>
        public CurrentlyPage(ApixuForecast forecast)
        {
            Weather = forecast.Current;
            LastUpdated = forecast.Location.LocalTime;
            Items.Add(forecast.Current.GenerateTable());
            Items.Add(forecast.Forecast.Days[0].Astro.GenerateTable());
            Items.Add(forecast.Forecast.Days[0].Day.GenerateTable());
            Items.Add(forecast.Location.GenerateTable());
            InitializeComponent();
            BindingContext = this;
        }
    }
}