using Xamarin.Forms;

using Xameteo.Model;
using Xameteo.ViewModel;

using Application = Xameteo.Resx.Application;

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
            Children.Add(new TodayCurrentPage { Title = Application.Tab_Now });
            Children.Add(new TodayHourlyPage { Title = Application.Tab_Today });
            Children.Add(new WeekForecastPage { Title = Application.Tab_Forecast });
            Children.Add(new WeekForecastPage { Title = Application.Tab_History });
        }
    }
}