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
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("tz_id")]
        public string TimeZone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }

        /// <summary>
        /// </summary>
        private Coordinates Coordinates => new Coordinates(Latitude, Longitude);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string Formatted => (Name.Length > 0 ? Name + ", " : string.Empty) + (Region.Length > 0 ? Region : Country);

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableGroup GenerateTable() => new TableGroup(Resources.Tab_Location)
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