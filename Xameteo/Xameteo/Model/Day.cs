using Newtonsoft.Json;

using Xameteo.Resx;
using Xameteo.Globalization;

using Xamarin.Forms;

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
        public string Image => Condition.Image(true);

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public ImageSource ImageResource => Condition.ImageResource(true);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup(Resources.Tab_Today)
        {
            new TableItem(Resources.Forecast_Precipitation, XameteoApp.Instance.Precipitation.Convert(Precipitation)),
            new TableItem(Resources.Forecast_Wind_Velocity, XameteoApp.Instance.Velocity.Convert(WindVelocity)),
            new TableItem(Resources.Forecast_Humidity, XameteoL10N.Percentage(Humidity)),
            new TableItem(Resources.Forecast_Visibility, XameteoApp.Instance.Distance.Convert(Visibility)),
            new TableItem(Resources.Forecast_Ultraviolet, Ultraviolet.ToString()),
            Condition.GenerateTable(),
            new TableItem(Resources.Forecast_Average, XameteoApp.Instance.Temperature.Convert(Average)),
            new TableItem(Resources.Forecast_Minimum, XameteoApp.Instance.Temperature.Convert(Minimum)),
            new TableItem(Resources.Forecast_Maxmum, XameteoApp.Instance.Temperature.Convert(Maximum))
        };
    }
}