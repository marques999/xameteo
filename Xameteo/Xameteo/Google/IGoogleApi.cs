using Refit;
using System.Threading.Tasks;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IGoogleApi
    {
        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [Get("/geocode/json")]
        Task<GoogleGeocoding> Get(string key, string address);
    }
}