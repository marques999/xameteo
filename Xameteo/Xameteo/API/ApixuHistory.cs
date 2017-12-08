﻿using Xameteo.Model;
using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class ApixuHistory
    {
        /// <summary>
        /// </summary>
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}