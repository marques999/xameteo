using Xameteo.Model;

namespace Xameteo.API
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class CoordinatesAdapter : PlaceAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="coordinates"></param>
        public CoordinatesAdapter(Coordinates coordinates) : base(coordinates.Latitude + "," + coordinates.Longitude)
        {
        }
    }
}