using System.Net.Http;
using System.Threading.Tasks;

using Refit;
using ModernHttpClient;

using Xameteo.API;

namespace Xameteo.Google
{
    /// <summary>
    /// </summary>
    public class GoogleApi
    {
        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<GoogleGeocoding> Get(string address) => _api.Get(Xameteo.Settings.GoogleKey, address);

        /// <summary>
        /// </summary>
        private readonly IGoogleApi _api = RestService.For<IGoogleApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = Xameteo.Globals.AsyncTimeout,
            BaseAddress = Xameteo.Globals.GoogleBaseUrl
        });
    }
}