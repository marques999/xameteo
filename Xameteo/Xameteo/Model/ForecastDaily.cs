using System;
using System.Text;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class ForecastDaily
    {
        /// <summary>
        /// Contains the forecast date
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Contains temperatures, wind speed and precipitation
        /// </summary>
        [JsonProperty("day")]
        public Day Day { get; set; }

        /// <summary>
        /// Contains sunrise, sunset, moonrise and moonset data
        /// </summary>
        [JsonProperty("astro")]
        public Astrology Astro { get; set; }

        /// <summary>
        /// Contains hour by hour weather forecast information
        /// </summary>
        [JsonProperty("hour")]
        public List<Hour> Hours { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("\n+============+\n| ");
            builder.Append(Date.ToString("d"));
            builder.Append(" |");
            builder.Append("\n+============+\n");
            builder.Append("\nDay {");
            builder.Append(Day);
            builder.Append("}\n\nAstro {");
            builder.Append(Astro);
            builder.Append("}\n");

            foreach (var hour in Hours)
            {
                builder.Append("\n[");
                builder.Append(hour.Date.ToString("t"));
                builder.Append("] {");
                builder.Append(hour);
                builder.Append("}\n");
            }

            return builder.ToString();
        }
    }
}