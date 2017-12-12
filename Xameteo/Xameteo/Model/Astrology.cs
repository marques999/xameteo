using Newtonsoft.Json;

using Xameteo.Resx;
using Xameteo.Globalization;

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
            new TableItem(Resources.Astro_Sunrise, XameteoL10N.ShortTime(XameteoL10N.ParseTime(Sunrise))),
            new TableItem(Resources.Astro_Sunset, XameteoL10N.ShortTime(XameteoL10N.ParseTime(Sunset))),
            new TableItem(Resources.Astro_Moonrise, XameteoL10N.ShortTime(XameteoL10N.ParseTime(Moonrise))),
            new TableItem(Resources.Astro_Moonset, XameteoL10N.ShortTime(XameteoL10N.ParseTime(Moonset)))
        };
    }
}