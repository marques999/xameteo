﻿using Xameteo.Model;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

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

        /// <summary>
        /// </summary>
        public TodayPage(ForecastDaily forecast)
        {
            Items.Add(forecast.Astro.GenerateTable());

            foreach (var hour in forecast.Hours)
            {
                Items.Add(hour.GenerateTable());
            }

            InitializeComponent();
            BindingContext = this;
        }
    }
}