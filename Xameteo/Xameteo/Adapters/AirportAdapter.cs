using Xameteo.Constants;

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
        public AirportAdapter(Airports query) : base("iata:" + query.ToString().ToUpper())
        {
        }
    }
}