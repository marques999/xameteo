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
        private ApixuPlace _place;

        /// <summary>
        /// </summary>
        /// <param name="apixuPlace"></param>
        public LocationView(ApixuPlace apixuPlace)
        {
            try
            {
                _place = apixuPlace;
                InitializeView(apixuPlace.Forecast);
                ToolbarItems.Add(new ToolbarItem(Resx.Resources.Button_Refresh, "icon_refresh.png", RefreshPlace));
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
        }

        /// <summary>
        /// </summary>
        public async void RefreshPlace()
        {
            XameteoDialogs.ShowLoading();

            try
            {
                var place = await XameteoApp.Instance.RefreshPlace(_place);

                if (place != null)
                {
                    Children.Clear();
                    _place = place;
                    InitializeView(place.Forecast);
                }

                XameteoDialogs.HideLoading();
            }
            catch (Exception exception)
            {
                XameteoDialogs.HideLoading();
                XameteoDialogs.Alert(exception);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="apixuForecast"></param>
        private void InitializeView(ApixuForecast apixuForecast)
        {
            Title = apixuForecast.Location.Formatted;

            var days = apixuForecast.Forecast.Days;

            if (days.Count > 0)
            {
                Children.Add(new CurrentlyPage(apixuForecast));
                Children.Add(new TodayPage(days[0]));

                if (days.Count > 1)
                {
                    Children.Add(new ForecastPage(apixuForecast.Forecast));
                }
            }

            Children.Add(new HistoryPage(_place.Adapter));
        }
    }
}