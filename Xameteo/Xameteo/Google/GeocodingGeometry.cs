using Xameteo.Model;
using Newtonsoft.Json;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GeocodingGeometry
    {
        /// <summary>
        /// </summary>
        [JsonProperty("location_type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("bounds")]
        public GeocodingBounds Bounds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("viewport")]
        public GeocodingBounds Viewport { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("location")]
        public Coordinates Location { get; set; }
    }
}