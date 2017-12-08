using System;
using System.Collections.Generic;

using Xameteo.API;
using Xameteo.Resx;
using Xameteo.Model;

namespace Xameteo.ViewModel
{
    internal class ForecastViewModel
    {
        /// <summary>
        /// </summary>
        private readonly ApixuForecast _forecast;

        /// <summary>
        /// </summary>
        private Current Now => _forecast.Current;

        /// <summary>
        /// </summary>
        private Location Location => _forecast.Location;

        /// <summary>
        /// </summary>
        private Coordinates Coordinates => new Coordinates(Location.Latitude, Location.Longitude);

        /// <summary>
        /// </summary>
        public ForecastViewModel(ApixuForecast forecast)
        {
            _forecast = forecast;
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Last_Updated, Xameteo.Localization.LongDateTime(Now.LastUpdated)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Condition, Xameteo.Localization.GetCondition(Now.Condition.Id)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Temperature, Xameteo.Settings.Temperature.Convert(Now.Temperature)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Feels_Like, Xameteo.Settings.Temperature.Convert(Now.FeelsLike)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Humidity, Xameteo.Localization.Percentage(Now.Humidity)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Is_Day, Xameteo.Localization.Boolean(Now.IsDay)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Wind_Velocity, Xameteo.Settings.Velocity.Convert(Now.WindVelocity)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Wind_Degree, Xameteo.Localization.Degrees(Now.WindDegree)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Wind_Direction, Xameteo.Localization.LongCompass(Compass.Get(Now.WindDirection))));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Pressure, Xameteo.Settings.Pressure.Convert(Now.Pressure)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Precipitation, Xameteo.Settings.Precipitation.Convert(Now.Precipitation)));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Cloud, Now.Cloud.ToString()));
            Table1.Add(new Tuple<string, string>(Resources.Forecast_Visibility, Xameteo.Settings.Distance.Convert(Now.Visibility)));
            Table2.Add(new Tuple<string, string>(Resources.Location_Name, Location.Name));
            Table2.Add(new Tuple<string, string>(Resources.Location_Region, Location.Region));
            Table2.Add(new Tuple<string, string>(Resources.Location_Country, Location.Country));
            Table2.Add(new Tuple<string, string>(Resources.Location_Latitude, Coordinates.StandardizeLatitude()));
            Table2.Add(new Tuple<string, string>(Resources.Location_Longitude, Coordinates.StandardizeLongitude()));
            Table2.Add(new Tuple<string, string>(Resources.Location_Timezone, Location.TimeZone));
            Table2.Add(new Tuple<string, string>(Resources.Location_Local_Time, Xameteo.Localization.ShortTime(Location.LocalTime)));
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SelectedItemCommand(object sender, EventArgs args)
        {
        }

        /// <summary>
        /// </summary>
        public List<Tuple<string, string>> Table1 { get; } = new List<Tuple<string, string>>();

        /// <summary>
        /// </summary>
        public List<Tuple<string, string>> Table2 { get; } = new List<Tuple<string, string>>();

        /// <summary>
        /// </summary>
        public Current Today => _forecast.Current;

        /// <summary>
        /// </summary>
        public List<ForecastDaily> Days => _forecast.Forecast.Days;

        /// <summary>
        /// </summary>
        public List<Hour> Hourly => Days.Count > 0 ? Days[0].Hours : new List<Hour>();

        /// <summary>
        /// </summary>
        public Astrology Astrology => Days.Count > 0 ? Days[0].Astro : new Astrology();
    }
}