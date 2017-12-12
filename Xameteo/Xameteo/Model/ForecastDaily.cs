using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class ForecastDaily
    {
        /// <summary>
        /// </summary>
        [JsonProperty("day")]
        public Day Day { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("astro")]
        public Astrology Astro { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("hour")]
        public List<Hour> Hours { get; set; }
    }
}