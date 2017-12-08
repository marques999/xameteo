using Xamarin.Forms;
using Xameteo.API;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LocationView : TabbedPage
    {
        /// <summary>
        /// </summary>
        public void Initialize(ApixuForecast forecast)
        {
            BindingContext = new LocationViewModel(forecast);
            Children.Add(new CurrentlyPage { Title = Resx.Resources.Tab_Now });
            Children.Add(new TodayPage { Title = Resx.Resources.Tab_Today });
            Children.Add(new ForecastPage { Title = Resx.Resources.Tab_Forecast });
            Children.Add(new HistoryPage { Title = Resx.Resources.Tab_History });
        }
    }
}