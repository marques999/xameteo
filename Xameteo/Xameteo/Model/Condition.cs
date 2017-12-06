using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Weather condition unique code
        /// </summary>
        [JsonProperty("code")]
        public int Id { get; set; }

        /// <summary>
        /// Weather icon URL
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}