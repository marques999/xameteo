using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class Forecast
    {
        /// <summary>
        /// </summary>
        [JsonProperty("forecastday")]
        public List<ForecastDaily> Days { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var day in Days)
            {
                builder.Append(day);
            }

            return builder.ToString();
        }
    }
}