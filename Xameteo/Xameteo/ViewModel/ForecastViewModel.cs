using System;
using System.ComponentModel;
using System.Collections.Generic;

using Xameteo.Model;

namespace Xameteo.ViewModel
{
    internal class ForecastViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        private readonly ApixuForecast _forecast;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public ForecastViewModel(ApixuForecast forecast)
        {
            _forecast = forecast;
            FillTable1(_forecast.Current);
            FillTable2(_forecast.Location);
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
        /// <param name="localeKey"></param>
        /// <param name="value"></param>
        private void InsertTable1(string localeKey, string value)
        {
            Table1.Add(new Tuple<string, string>(Xameteo.Localization.Get(localeKey), value));
        }

        /// <summary>
        /// </summary>
        /// <param name="today"></param>
        private void FillTable1(Current today)
        {
            InsertTable1("Forecast_Last_Updated", today.LastUpdated.ToString("g"));
            InsertTable1("Forecast_Condition", Xameteo.Localization.GetCondition(today.Condition.Id));
            InsertTable1("Forecast_Temperature", Xameteo.Settings.Temperature.Convert(today.Temperature));
            InsertTable1("Forecast_Feels_Like", Xameteo.Settings.Temperature.Convert(today.FeelsLike));
            InsertTable1("Forecast_Humidity", today.Humidity + "%");
            InsertTable1("Forecast_Is_Day", today.IsDay ? "true" : "false");
            InsertTable1("Forecast_Wind_Velocity", Xameteo.Settings.Velocity.Convert(today.WindVelocity));
            InsertTable1("Forecast_Wind_Degree", today.WindDegree + " deg");
            InsertTable1("Forecast_Wind_Direction", today.WindDirection);
            InsertTable1("Forecast_Pressure", Xameteo.Settings.Pressure.Convert(today.Pressure));
            InsertTable1("Forecast_Precipitation", Xameteo.Settings.Precipitation.Convert(today.Precipitation));
            InsertTable1("Forecast_Cloud", today.Cloud.ToString());
            InsertTable1("Forecast_Visibility", Xameteo.Settings.Distance.Convert(today.Visibility));
        }

        /// <summary>
        /// </summary>
        /// <param name="location"></param>
        private void FillTable2(Location location)
        {
            InsertTable2("Location_Name", location.Name);
            InsertTable2("Location_Region", location.Region);
            InsertTable2("Location_Country", location.Country);
            InsertTable2("Location_Latitude", location.Latitude.ToString());
            InsertTable2("Location_Longitude", location.Longitude.ToString());
            InsertTable2("Location_Timezone", location.TimeZone);
            InsertTable2("Location_Local_Time", location.LocalTime.ToString("g"));
        }

        /// <summary>
        /// </summary>
        /// <param name="localeKey"></param>
        /// <param name="value"></param>
        private void InsertTable2(string localeKey, string value)
        {
            Table2.Add(new Tuple<string, string>(Xameteo.Localization.Get(localeKey), value));
        }

        /// <summary>
        /// </summary>
        public List<Tuple<string, string>> Table1
        {
            get;
        } = new List<Tuple<string, string>>();

        /// <summary>
        /// </summary>
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