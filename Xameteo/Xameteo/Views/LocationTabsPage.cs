using Xamarin.Forms;

using Xameteo.API;
using Xameteo.ViewModel;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LocationTabsPage : TabbedPage
    {
        /// <summary>
        /// </summary>
        public void Initialize(ApixuForecast forecast)
        {
            BindingContext = new LocationViewModel(forecast);
            Children.Add(new LocationCurrentPage { Title = Resx.Resources.Tab_Now });
            Children.Add(new LocationTodayPage { Title = Resx.Resources.Tab_Today });
            Children.Add(new LocationForecastPage { Title = Resx.Resources.Tab_Forecast });
            Children.Add(new LocationHistoryPage { Title = Resx.Resources.Tab_History });
        }
    }
}