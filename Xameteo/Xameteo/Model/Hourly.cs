using System;
using Xameteo.Resx;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Hour : ITableProvider
    {
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
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }

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
        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("wind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("time")]
        public DateTime Date { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("chance_of_rain")]
        public double RainProbability { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("chance_of_snow")]
        public double SnowProbability { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup(Xameteo.Localization.ShortTime(Date))
        {
            new TableItem(Resources.Forecast_Temperature, Xameteo.Settings.Temperature.Convert(Temperature)),
            new TableItem(Resources.Forecast_Feels_Like, Xameteo.Settings.Temperature.Convert(FeelsLike)),
            new TableItem(Resources.Forecast_Humidity, Xameteo.Localization.Percentage(Humidity)),
            new TableItem(Resources.Forecast_Pressure, Xameteo.Settings.Pressure.Convert(Pressure)),
            new TableItem(
                Resources.Forecast_Visibility,
                Xameteo.Settings.Distance.Convert(Visibility)
            ),
            TableItem.Precipitation(Precipitation),
            TableItem.RainProbability(RainProbability),
            TableItem.SnowProbability(SnowProbability),
            TableItem.WindVelocity(WindVelocity),
            TableItem.WindDegree(WindDegree)
        };
    }
}