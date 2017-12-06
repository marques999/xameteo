using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Astrology
    {
        /// <summary>
        /// Sunrise time (12 hours)
        /// </summary>
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        /// <summary>
        /// Sunset time (12 hours)
        /// </summary>
        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        /// <summary>
        /// Moonrise time (12 hours)
        /// </summary>
        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        /// <summary>
        /// Moonset time (12 hours)
        /// </summary>
        [JsonProperty("moonset")]
        public string Moonset { get; set; }
    }
}