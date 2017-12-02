using System.Net;

namespace Xameteo.Adapters
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class CityAdapter : ApixuAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="query"></param>
        public CityAdapter(string query) : base(WebUtility.UrlEncode(query))
        {
        }
    }
}