using System;
using Xameteo.Resx;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Current : ITableProvider
    {
        /// <summary>
        /// Cloud cover as percentage
        /// </summary>
        [JsonProperty("cloud")]
        public int Cloud { get; set; }

        /// <summary>
        /// Whether to show day condition icon or night icon
        /// </summary>
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }

        /// <summary>
        /// Humidity as percentage
        /// </summary>
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// Weather condition information
        /// </summary>
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Feels like temperature in celcius
        /// </summary>
        [JsonProperty("feelslike_c")]
        public double FeelsLike { get; set; }

        /// <summary>
        /// Atmospheric pressure in millibars
        /// </summary>
        [JsonProperty("pressure_mb")]
        public double Pressure { get; set; }

        /// <summary>
        /// Temperature in celsius
        /// </summary>
        [JsonProperty("temp_c")]
        public double Temperature { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("vis_km")]
        public double Visibility { get; set; }

        /// <summary>
        /// Precipitation amount in millimeters
        /// </summary>
        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }

        /// <summary>
        /// Wind direction in degrees
        /// </summary>
        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        /// <summary>
        /// Wind speed in kilometer per hour
        /// </summary>
        [JsonProperty("wind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// Local time when the real time data was updated.
        /// </summary>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup("Current")
        {
            new TableItem(Resources.Forecast_Last_Updated, Xameteo.Localization.LongDateTime(LastUpdated)),
            Condition.GenerateTable(),
            new TableItem(Resources.Forecast_Temperature, Xameteo.Settings.Temperature.Convert(Temperature)),
            new TableItem(Resources.Forecast_Feels_Like, Xameteo.Settings.Temperature.Convert(FeelsLike)),
            new TableItem(Resources.Forecast_Humidity, Xameteo.Localization.Percentage(Humidity)),
            new TableItem(Resources.Forecast_Wind_Velocity, Xameteo.Settings.Velocity.Convert(WindVelocity)),
            new TableItem(Resources.Forecast_Wind_Direction, Xameteo.Localization.LongCompass(WindDegree)),
            new TableItem(Resources.Forecast_Pressure, Xameteo.Settings.Pressure.Convert(Pressure)),
            new TableItem(Resources.Forecast_Precipitation,Xameteo.Settings.Precipitation.Convert(Precipitation)),
            new TableItem(Resources.Forecast_Visibility,Xameteo.Settings.Distance.Convert(Visibility))
        };
    }
}