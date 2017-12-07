using System;
using System.ComponentModel;
using System.Collections.Generic;

using Xameteo.Resx;
using Xameteo.Model;

namespace Xameteo.ViewModel
{
    internal class ForecastViewModel : INotifyPropertyChanged
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

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public ForecastViewModel(ApixuForecast forecast)
        {
            _forecast = forecast;
            Table1.Add(new Tuple<string, string>(Application.Forecast_Last_Updated, Xameteo.Localization.LongDateTime(Now.LastUpdated)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Condition, Xameteo.Localization.GetCondition(Now.Condition.Id)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Temperature, Xameteo.Settings.Temperature.Convert(Now.Temperature)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Feels_Like, Xameteo.Settings.Temperature.Convert(Now.FeelsLike)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Humidity, Now.Humidity + "%"));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Is_Day, Now.IsDay ? "true" : "false"));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Wind_Velocity, Xameteo.Settings.Velocity.Convert(Now.WindVelocity)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Wind_Degree, Now.WindDegree + " deg"));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Wind_Direction, Now.WindDirection));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Pressure, Xameteo.Settings.Pressure.Convert(Now.Pressure)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Precipitation, Xameteo.Settings.Precipitation.Convert(Now.Precipitation)));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Cloud, Now.Cloud.ToString()));
            Table1.Add(new Tuple<string, string>(Application.Forecast_Visibility, Xameteo.Settings.Distance.Convert(Now.Visibility)));
            Table2.Add(new Tuple<string, string>(Application.Location_Name, Location.Name));
            Table2.Add(new Tuple<string, string>(Application.Location_Region, Location.Region));
            Table2.Add(new Tuple<string, string>(Application.Location_Country, Location.Country));
            Table2.Add(new Tuple<string, string>(Application.Location_Latitude, Location.Latitude.ToString()));
            Table2.Add(new Tuple<string, string>(Application.Location_Longitude, Location.Longitude.ToString()));
            Table2.Add(new Tuple<string, string>(Application.Location_Timezone, Location.TimeZone));
            Table2.Add(new Tuple<string, string>(Application.Location_Local_Time, Xameteo.Localization.ShortTime(Location.LocalTime)));
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

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}