using System.Net;

namespace Xameteo.API
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class LocationAdapter : PlaceAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="query"></param>
        public LocationAdapter(string query) : base(WebUtility.UrlEncode(query))
        {
        }
    }
}