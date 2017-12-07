using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class ApixuCurrent
    {
        /// <summary>
        /// </summary>
        [JsonProperty("current")]
        public Current Current { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}