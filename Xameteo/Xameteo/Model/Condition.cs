using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class Condition
    {
        /// <summary>
        /// Weather condition unique code
        /// </summary>
        [JsonProperty("code")]
        public int Id { get; set; }

        /// <summary>
        /// Weather condition text
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Weather icon URL
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}