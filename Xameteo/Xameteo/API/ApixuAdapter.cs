using System.Net;
using System.Globalization;

using Xameteo.Model;

using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class ApixuAdapter
    {
        /// <summary>
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Parameters.GetHashCode();
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class AirportAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="airport"></param>
        public AirportAdapter(Airport airport)
        {
            Parameters = "iata:" + airport.Code;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class CoordinatesAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="coordinates"></param>
        public CoordinatesAdapter(Coordinates coordinates)
        {
            Parameters = coordinates.Latitude.ToString(CultureInfo.InvariantCulture) + "," + coordinates.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class GeolocationAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="query"></param>
        public GeolocationAdapter(string query)
        {
            Parameters = WebUtility.UrlEncode(query);
        }
    }
}