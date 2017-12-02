using System;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class Astrology
    {
        /// <summary>
        /// Sunrise time (12 hours)
        /// </summary>
        [JsonProperty("sunrise")]
        public DateTime Sunrise { get; set; }

        /// <summary>
        /// Sunset time (12 hours)
        /// </summary>
        [JsonProperty("sunset")]
        public DateTime Sunset { get; set; }

        /// <summary>
        /// Moonrise time (12 hours)
        /// </summary>
        [JsonProperty("moonrise")]
        public DateTime Moonrise { get; set; }

        /// <summary>
        /// Moonset time (12 hours)
        /// </summary>
        [JsonProperty("moonset")]
        public DateTime Moonset { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"
  Sunrise = {Sunrise}
  Sunset = {Sunset}
  Moonrise = {Moonrise}
  Moonset = {Moonset}
";
    }
}