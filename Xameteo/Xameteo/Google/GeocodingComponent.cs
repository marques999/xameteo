using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GeocodingComponent
    {
        /// <summary>
        /// </summary>
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}