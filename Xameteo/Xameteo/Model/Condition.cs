using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// </summary>
        [JsonProperty("code")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}