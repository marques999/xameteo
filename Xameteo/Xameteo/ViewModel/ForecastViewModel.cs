using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xameteo.Model;

namespace Xameteo.ViewModel
{
    internal class ForecastViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ApixuForecast _forecast;

        /// <summary>
        /// </summary>
        public ForecastViewModel(ApixuForecast forecast)
        {
            _forecast = forecast;

            var today = _forecast.Current;

            InsertTable1("FORECAST_LAST_UPDATED", today.LastUpdated.ToString("g"));
            InsertTable1("FORECAST_CONDITION", Xameteo.Localization.GetCondition(today.Condition.Id));
            InsertTable1("FORECAST_TEMPERATURE", Xameteo.Settings.Temperature.Current.ToString(today.Temperature));
            InsertTable1("FORECAST_FEELS_LIKE", Xameteo.Settings.Temperature.Current.ToString(today.FeelsLike));
            InsertTable1("FORECAST_HUMIDITY", today.Humidity + "%");
            InsertTable1("FORECAST_IS_DAY", today.IsDay ? "true" : "false");
            InsertTable1("FORECAST_WIND_VELOCITY", Xameteo.Settings.Velocity.Current.ToString(today.WindVelocity));
            InsertTable1("FORECAST_WIND_DEGREE", today.WindDegree + " deg");
            InsertTable1("FORECAST_WIND_DIRECTION", today.WindDirection);
            InsertTable1("FORECAST_PRESSURE", Xameteo.Settings.Pressure.Current.ToString(today.Pressure));
            InsertTable1("FORECAST_PRECIPITATION", Xameteo.Settings.Precipitation.Current.ToString(today.Precipitation));
            InsertTable1("FORECAST_CLOUD", today.Cloud.ToString());
            InsertTable1("FORECAST_VISIBILITY", Xameteo.Settings.Distance.Current.ToString(today.Visibility));

            var location = _forecast.Location;

            InsertTable2("LOCATION_NAME", location.Name);
            InsertTable2("LOCATION_REGION", location.Region);
            InsertTable2("LOCATION_COUNTRY", location.Country);
            InsertTable2("LOCATION_LATITUDE", location.Latitude.ToString());
            InsertTable2("LOCATION_LONGITUDE", location.Longitude.ToString());
            InsertTable2("LOCATION_TIMEZONE", location.TimeZone);
            InsertTable2("LOCATION_LOCAL_TIME", location.LocalTime.ToString("g"));
        }

        public void SelectedItemCommand(object sender, EventArgs args)
        {
        }

        private void InsertTable1(string localeKey, string value)
        {
            Table1.Add(new Tuple<string, string>(Xameteo.Localization.Get(localeKey), value));
        }

        private void InsertTable2(string localeKey, string value)
        {
            Table2.Add(new Tuple<string, string>(Xameteo.Localization.Get(localeKey), value));
        }

        public List<Tuple<string, string>> Table1
        {
            get;
        } = new List<Tuple<string, string>>();

        public List<Tuple<string, string>> Table2
        {
            get;
        } = new List<Tuple<string, string>>();

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