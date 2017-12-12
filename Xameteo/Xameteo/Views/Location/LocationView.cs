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
        /// <summary>
        /// </summary>
        /// <param name="apixuForecast"></param>
        public LocationView(ApixuForecast apixuForecast)
        {
            try
            {
                Title = apixuForecast.Location.ToString();
                Children.Add(new CurrentlyPage(apixuForecast.Current));
                Children.Add(new DetailsView(apixuForecast.Location));

                var days = apixuForecast.Forecast.Days;

                if (days.Count > 0)
                {
                    Children.Add(new TodayPage(days[0]));

                    if (days.Count > 1)
                    {
                        Children.Add(new ForecastPage(apixuForecast.Forecast));
                    }
                }

                Children.Add(new HistoryPage(apixuForecast.Forecast.Days[2]));
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
        }
    }
}