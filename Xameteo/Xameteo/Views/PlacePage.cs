using Xamarin.Forms;

using Xameteo.Model;
using Xameteo.ViewModel;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class PlacePage : TabbedPage
    {
        /// <summary>
        /// </summary>
        public void Initialize(ApixuForecast forecast)
        {
            BindingContext = new ForecastViewModel(forecast);
            Children.Add(new TodayCurrentPage { Title = "Now" });
            Children.Add(new TodayHourlyPage { Title = "Today" });
            Children.Add(new WeekForecastPage { Title = "Forecast" });
            Children.Add(new WeekForecastPage { Title = "History" });
        }
    }
}