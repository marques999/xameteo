using Xamarin.Forms;

using Xameteo.API;
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
            Children.Add(new TodayCurrentPage { Title = Resx.Resources.Tab_Now });
            Children.Add(new TodayHourlyPage { Title = Resx.Resources.Tab_Today });
            Children.Add(new WeekForecastPage { Title = Resx.Resources.Tab_Forecast });
            Children.Add(new WeekForecastPage { Title = Resx.Resources.Tab_History });
        }
    }
}