using Xameteo.Resx;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Day : ITableProvider
    {
        /// <summary>
        /// </summary>
        [JsonProperty("maxtemp_c")]
        public double Maximum { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("mintemp_c")]
        public double Minimum { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("avgtemp_c")]
        public double Average { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("maxwind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("totalprecip_mm")]
        public double Precipitation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("avgvis_km")]
        public double Visibility { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("avghumidity")]
        public double Humidity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("uv")]
        public double Ultraviolet { get; set; }

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public ImageSource Image => Condition.Image(true);

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