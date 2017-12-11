using Newtonsoft.Json;
using Xameteo.Resx;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Day : ITableProvider
    {
        /// <summary>
        /// Maximum temperature in celsius for the day.
        /// </summary>
        [JsonProperty("maxtemp_c")]
        public double Maximum { get; set; }

        /// <summary>
        /// Minimum temperature in celsius for the day.
        /// </summary>
        [JsonProperty("mintemp_c")]
        public double Minimum { get; set; }

        /// <summary>
        /// Average temperature in celsius for the day.
        /// </summary>
        [JsonProperty("avgtemp_c")]
        public double Average { get; set; }

        /// <summary>
        /// Maximum wind speed in kilometers per hour.
        /// </summary>
        [JsonProperty("maxwind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// Total precipitation in milimeters.
        /// </summary>
        [JsonProperty("totalprecip_mm")]
        public double Precipitation { get; set; }

        /// <summary>
        /// Average visibility in kilometers.
        /// </summary>
        [JsonProperty("avgvis_km")]
        public double Visibility { get; set; }

        /// <summary>
        /// Average humidity as percentage.
        /// </summary>
        [JsonProperty("avghumidity")]
        public double Humidity { get; set; }

        /// <summary>
        /// Weather condition.
        /// </summary>
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Ultraviolet index
        /// </summary>
        [JsonProperty("uv")]
        public double Ultraviolet { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup(Resources.Group_Temperature)
        {
            new TableItem(Resources.Forecast_Precipitation, Xameteo.Settings.Precipitation.Convert(Precipitation)),
            new TableItem(Resources.Forecast_Wind_Velocity, Xameteo.Settings.Velocity.Convert(WindVelocity)),
            new TableItem(Resources.Forecast_Humidity, Xameteo.Localization.Percentage(Humidity)),
            new TableItem(Resources.Forecast_Visibility, Xameteo.Settings.Distance.Convert(Visibility)),
            new TableItem(Resources.Forecast_Ultraviolet, Xameteo.Localization.FixedPoint(Ultraviolet)),
            Condition.GenerateTable(),
            new TableItem(Resources.Forecast_Average, Xameteo.Settings.Temperature.Convert(Average)),
            new TableItem(Resources.Forecast_Minimum, Xameteo.Settings.Temperature.Convert(Minimum)),
            new TableItem(Resources.Forecast_Maxmum, Xameteo.Settings.Temperature.Convert(Maximum))
        };
    }
}