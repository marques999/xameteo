using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Astrology
    {
        /// <summary>
        /// </summary>
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("moonset")]
        public string Moonset { get; set; }
    }
}