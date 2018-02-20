using System.Net.Http;
using System.Threading.Tasks;

using Refit;
using ModernHttpClient;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class GoogleApi
    {
        /// <summary>
        /// </summary>
        private readonly XameteoApp _xameteoApp;

        /// <summary>
        /// </summary>
        /// <param name="xameteoApp"></param>
        public GoogleApi(XameteoApp xameteoApp)
        {
            _xameteoApp = xameteoApp;
        }

        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<GoogleGeocoding> Get(string address) => _api.Get(_xameteoApp.GoogleKey, address);

        /// <summary>
        /// </summary>
        private readonly IGoogleApi _api = RestService.For<IGoogleApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = XameteoGlobals.AsyncTimeout,
            BaseAddress = XameteoGlobals.GoogleBaseUrl
        });
    }
}