﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// </summary>
        [JsonProperty("forecastday")]
        public List<ForecastDaily> Days { get; set; }
    }
}