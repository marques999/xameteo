using Xamarin.Forms.Xaml;
using Xameteo.Model;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage
    {
        /// <summary>
        /// </summary>
        public Day Day { get; }

        /// <summary>
        /// </summary>
        public HistoryPage(ForecastDaily forecast)
        {
            Day = forecast.Day;
            InitializeComponent();
            BindingContext = this;
        }
    }
}