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
        /// <param name="iataCode"></param>
        public AirportAdapter(string iataCode) : base("iata:" + iataCode)
        {
        }
    }
}