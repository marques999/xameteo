using System;
using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class ApixuPlace
    {
        /// <summary>
        /// </summary>
        [JsonProperty("adapter")]
        public ApixuAdapter Adapter { get; }

        /// <summary>
        /// </summary>
        [JsonProperty("forecast")]
        public ApixuForecast Forecast { get; }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="forecast"></param>
        public ApixuPlace(ApixuAdapter adapter, ApixuForecast forecast)
        {
            Adapter = adapter;
            Forecast = forecast;
        }
    }
}