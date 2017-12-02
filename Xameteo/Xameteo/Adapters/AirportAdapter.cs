using Xameteo.Globalization;

namespace Xameteo.Adapters
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class AirportAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="query"></param>
        public AirportAdapter(Localization query) : base("iata:" + query.Id)
        {
        }
    }
}