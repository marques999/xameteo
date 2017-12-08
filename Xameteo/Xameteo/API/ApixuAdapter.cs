using System.Net;
using Xameteo.Model;
using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public abstract class ApixuAdapter
    {
        /// <summary>
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="parameters"></param>
        protected ApixuAdapter(string parameters)
        {
            Parameters = parameters;
        }

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
        public AirportAdapter(Airport airport) : base("iata:" + airport.Code)
        {
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
        public CoordinatesAdapter(Coordinates coordinates) : base(coordinates.Latitude + "," + coordinates.Longitude)
        {
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
        public GeolocationAdapter(string query) : base(WebUtility.UrlEncode(query))
        {
        }
    }
}