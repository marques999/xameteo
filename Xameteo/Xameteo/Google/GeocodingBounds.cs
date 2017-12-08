using Xameteo.Model;
using Newtonsoft.Json;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GeocodingBounds
    {
        /// <summary>
        /// </summary>
        [JsonProperty("northeast")]
        public Coordinates Northeast { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("southwest")]
        public Coordinates Southwest { get; set; }
    }
}