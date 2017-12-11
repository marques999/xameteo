using Xameteo.Resx;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Astrology : ITableProvider
    {
        /// <summary>
        /// </summary>
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("sunset")]
        public string Sunset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("moonset")]
        public string Moonset { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup("Astrology")
        {
            new TableItem(Resources.Astro_Sunrise, Xameteo.Localization.ShortTime(Xameteo.Localization.ParseTime(Sunrise))),
            new TableItem(Resources.Astro_Sunset, Xameteo.Localization.ShortTime(Xameteo.Localization.ParseTime(Sunset))),
            new TableItem(Resources.Astro_Moonrise, Xameteo.Localization.ShortTime(Xameteo.Localization.ParseTime(Moonrise))),
            new TableItem(Resources.Astro_Moonset, Xameteo.Localization.ShortTime(Xameteo.Localization.ParseTime(Moonset)))
        };
    }
}