using System;
using Xameteo.API;
using Xamarin.Forms;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LocationView : TabbedPage
    {
        public LocationView()
        {
            
        }

        public LocationView(ApixuForecast apixuForecast)
        {
            Initialize(apixuForecast);
        }
        /// <summary>
        /// </summary>
        public async void Initialize(ApixuForecast apixuForecast)
        {
            try
            {
                Title = apixuForecast.Location.ToString();
                Children.Add(new CurrentlyPage(apixuForecast));

                var days = apixuForecast.Forecast.Days;

                if (days.Count > 0)
                {
                    Children.Add(new TodayPage(apixuForecast.Forecast.Days[0]));

                    if (days.Count > 1)
                    {
                        Children.Add(new ForecastPage(apixuForecast.Forecast));
                    }
                }

                Children.Add(new HistoryPage());
            }
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
            }
        }
    }
}