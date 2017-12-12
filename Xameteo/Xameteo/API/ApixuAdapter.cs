using System.Net;
using System.Globalization;

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
        [JsonIgnore]
        public abstract string Icon { get; }

        /// <summary>
        /// </summary>
        [JsonIgnore]
        public abstract string Parameters { get; }

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
            Airport = airport;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("airport")]
        public Airport Airport { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Icon => "fa-plane";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Parameters => "iata:" + Airport.Code;
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
            Coordinates = coordinates;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Icon => "fa-safari";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Parameters
        {
            get => Coordinates.Latitude.ToString(CultureInfo.InvariantCulture) + "," + Coordinates.Longitude.ToString(CultureInfo.InvariantCulture);
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
            Query = query;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Icon => "fa-search";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Parameters => WebUtility.UrlEncode(Query);
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class DeviceAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="coordinates"></param>
        public DeviceAdapter(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Icon => "fa-mobile-phone";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override string Parameters
        {
            get => Coordinates.Latitude.ToString(CultureInfo.InvariantCulture) + "," + Coordinates.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}