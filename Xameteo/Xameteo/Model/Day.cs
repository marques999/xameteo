using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Day
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

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"
  Maximum = {Maximum}
  Minimum = {Minimum}
  Average = {Average}
  WindVelocity = {WindVelocity}
  Precipitation = {Precipitation}
  Visibility = {Visibility}
  Humidity = {Humidity}
  Ultraviolet = {Ultraviolet}
  Condition = {Condition}
";
    }
}