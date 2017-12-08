using System.Net.Http;
using System.Threading.Tasks;

using Refit;
using ModernHttpClient;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GoogleApi
    {
        /// <summary>
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<GoogleGeocoding> Get(string address) => _api.Get(_apiKey, address);

        /// <summary>
        /// </summary>
        private readonly IGoogleApi _api = RestService.For<IGoogleApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = Xameteo.Globals.AsyncTimeout,
            BaseAddress = Xameteo.Globals.GoogleBaseUrl
        });

        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        public GoogleApi(string apiKey)
        {
            _apiKey = apiKey;
        }
    }
}