using System.Collections.Generic;

using Xameteo.Model;
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
        public List<ForecastDaily> Days { get; }

        /// <summary>
        /// </summary>
        public ForecastPage(Forecast forecast)
        {
            InitializeComponent();
            Days = forecast.Days;
            BindingContext = this;
        }
    }
}