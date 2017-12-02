using Xameteo.Model;
using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    internal class ApixuCurrent
    {
        /// <summary>
        /// </summary>
        [JsonProperty("current")]
        public Current Current { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"
Current {{
{Current}
}}

Location {{
{Location}
}}";
    }
}