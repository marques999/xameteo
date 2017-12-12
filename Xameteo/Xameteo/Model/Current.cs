using System;
using Newtonsoft.Json;

using Xameteo.Resx;
using Xamarin.Forms;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Current : ITableProvider
    {
        /// <summary>
        /// </summary>
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("feelslike_c")]
        public double FeelsLike { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("pressure_mb")]
        public double Pressure { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("temp_c")]
        public double Temperature { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("vis_km")]
        public double Visibility { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("wind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public ImageSource Image => Condition.Image(IsDay);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup("Current")
        {
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