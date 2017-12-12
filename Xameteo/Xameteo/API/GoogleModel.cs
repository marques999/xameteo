using Xameteo.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.API
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
        [JsonProperty("location")]
        public Coordinates Location { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty("bounds")]
        public GeocodingBounds Bounds { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty("viewport")]
        public GeocodingBounds Viewport { get; set; }
    }

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