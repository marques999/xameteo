using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GoogleGeocoding
    {
        /// <summary>
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("results")]
        public List<GeocodingResult> Results { get; set; }
    }
}