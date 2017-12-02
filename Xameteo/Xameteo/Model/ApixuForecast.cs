using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class ApixuForecast
    {
        /// <summary>
        /// </summary>
        [JsonProperty("current")]
        public Current Current { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"
Current {{{Current}}}

Location {{{Location}}}
            
{Forecast}";
    }
}