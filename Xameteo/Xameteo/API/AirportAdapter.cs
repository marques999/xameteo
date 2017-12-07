using Xameteo.Model;

namespace Xameteo.API
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class AirportAdapter : PlaceAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="airport"></param>
        public AirportAdapter(Airport airport) : base("iata:" + airport.Code)
        {
        }
    }
}