using Xameteo.Model;
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
        public List<Hour> Hours { get; }

        /// <summary>
        /// </summary>
        public TodayPage(ForecastDaily forecast)
        {
            Hours = forecast.Hours;
            InitializeComponent();
            BindingContext = this;
        }
    }
}