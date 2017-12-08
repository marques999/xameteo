using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GeocodingResult
    {
        /// <summary>
        /// </summary>
        [JsonProperty("place_id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("formatted_address")]
        public string Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("types")]
        public List<string> Types { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("geometry")]
        public GeocodingGeometry GeocodingGeometry { get; set; }
    }
}