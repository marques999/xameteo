using System;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;

using Xameteo.API;
using Xameteo.Model;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentlyPage
    {
        /// <summary>
        /// </summary>
        public CurrentlyPage(ApixuForecast apixuForecast)
        {
            Current = apixuForecast.Current;
            Location = apixuForecast.Location;
            Days = apixuForecast.Forecast.Days;
            Astrology = apixuForecast.Forecast.Days[0].Astro;
            InitializeView();
        }

        /// <summary>
        /// </summary>
        private async void InitializeView()
        {
            try
            {
                InitializeComponent();
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Last_Updated, Xameteo.Localization.LongDateTime(Current.LastUpdated)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Condition, Xameteo.Localization.GetCondition(Current.Condition.Id)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Temperature, Xameteo.Settings.Temperature.Convert(Current.Temperature)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Feels_Like, Xameteo.Settings.Temperature.Convert(Current.FeelsLike)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Humidity, Xameteo.Localization.Percentage(Current.Humidity)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Is_Day, Xameteo.Localization.Boolean(Current.IsDay)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Wind_Velocity, Xameteo.Settings.Velocity.Convert(Current.WindVelocity)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Wind_Degree, Xameteo.Localization.Degrees(Current.WindDegree)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Wind_Direction, Xameteo.Localization.LongCompass(Compass.Get(Current.WindDirection))));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Pressure, Xameteo.Settings.Pressure.Convert(Current.Pressure)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Precipitation, Xameteo.Settings.Precipitation.Convert(Current.Precipitation)));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Cloud, Current.Cloud.ToString()));
                Table1.Add(new Tuple<string, string>(Resx.Resources.Forecast_Visibility, Xameteo.Settings.Distance.Convert(Current.Visibility)));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Name, Location.Name));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Region, Location.Region));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Country, Location.Country));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Latitude, Coordinates.StandardizeLatitude()));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Longitude, Coordinates.StandardizeLongitude()));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Timezone, Location.TimeZone));
                Table2.Add(new Tuple<string, string>(Resx.Resources.Location_Local_Time, Xameteo.Localization.ShortTime(Location.LocalTime)));
                BindingContext = this;
            }
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
            }
        }

        /// <summary>
        /// </summary>
        private Current Current { get; }

        /// <summary>
        /// </summary>
        public Astrology Astrology { get; }

        /// <summary>
        /// </summary>
        public List<ForecastDaily> Days { get; }

        /// <summary>
        /// </summary>
        private Model.Location Location { get; }

        /// <summary>
        /// </summary>
        private Coordinates Coordinates => new Coordinates(Location.Latitude, Location.Longitude);

        /// <summary>
        /// </summary>
        public List<Tuple<string, string>> Table1 { get; } = new List<Tuple<string, string>>();

        /// <summary>
        /// </summary>
        public List<Tuple<string, string>> Table2 { get; } = new List<Tuple<string, string>>();
    }
}