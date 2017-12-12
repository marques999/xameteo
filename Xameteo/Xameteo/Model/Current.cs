using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xameteo.Globalization;
using Xameteo.Resx;
using Xameteo.Helpers;

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
            new TableItem(Resources.Forecast_Feels_Like, XameteoApp.Instance.Temperature.Convert(FeelsLike)),
            new TableItem(Resources.Forecast_Humidity, XameteoL10N.Percentage(Humidity)),
            new TableItem(Resources.Forecast_Wind_Velocity, XameteoApp.Instance.Velocity.Convert(WindVelocity)),
            new TableItem(Resources.Forecast_Wind_Direction, XameteoL10N.LongCompass(WindDegree)),
            new TableItem(Resources.Forecast_Pressure, XameteoApp.Instance.Pressure.Convert(Pressure)),
            new TableItem(Resources.Forecast_Precipitation, XameteoApp.Instance.Precipitation.Convert(Precipitation)),
            new TableItem(Resources.Forecast_Visibility, XameteoApp.Instance.Distance.Convert(Visibility))
        };
    }
}