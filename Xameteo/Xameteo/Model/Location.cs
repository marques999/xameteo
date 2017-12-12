using System;

using Xameteo.Resx;
using Xameteo.Globalization;

using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Location : ITableProvider
    {
        /// <summary>
        /// Location name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Location region or state
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Location country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Latitude in decimal degrees
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in decimal degrees
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Time zone name
        /// </summary>
        [JsonProperty("tz_id")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Local date and time
        /// </summary>
        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string AppendNotNull(string value)
        {
            return value.Length > 0 ? value + ", " : string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return AppendNotNull(Name) + AppendNotNull(Region) + Country;
        }

        /// <summary>
        /// </summary>
        private Coordinates Coordinates => new Coordinates(Latitude, Longitude);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup("Location")
        {
            new TableItem(Resources.Location_Name, Name),
            new TableItem(Resources.Location_Region, Region),
            new TableItem(Resources.Location_Country, Country),
            new TableItem(Resources.Location_Timezone, TimeZone),
            new TableItem(Resources.Location_Latitude, Coordinates.StandardizeLatitude()),
            new TableItem(Resources.Location_Longitude, Coordinates.StandardizeLongitude()),
            new TableItem(Resources.Location_Local_Time, XameteoL10N.ShortTime(LocalTime))
        };
    }
}