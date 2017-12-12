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
        /// <summary>
        /// </summary>
        [JsonProperty("airport")]
        public Airport Airport { get; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="airport"></param>
        public AirportAdapter(Airport airport)
        {
            Airport = airport;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [JsonIgnore]
        public override string Icon => "icon_plane.png";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [JsonIgnore]
        public override string Parameters => "iata:" + Airport.Code;
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class CoordinatesAdapter : ApixuAdapter
    {
        /// <summary>
        /// </summary>
        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="coordinates"></param>
        public CoordinatesAdapter(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [JsonIgnore]
        public override string Icon => "icon_compass.png";

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        [JsonIgnore]
        public override string Parameters => Coordinates.ToString();
    }
}