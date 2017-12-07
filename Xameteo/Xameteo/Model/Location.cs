using System;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Location name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Location region or state
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Location country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Latitude in decimal degrees
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Time zone name
        /// </summary>
        [JsonProperty("tz_id")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Local date and time
        /// </summary>
        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string AppendNotNull(string value)
        {
            return value.Length > 0 ? value + ", " : string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AppendNotNull(Name) + AppendNotNull(Region) + Country;
        }
    }
}