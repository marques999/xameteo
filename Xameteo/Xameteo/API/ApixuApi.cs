using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Refit;
using Akavache;
using ModernHttpClient;

using Xameteo.Model;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    internal class ApixuApi
    {
        /// <summary>
        /// </summary>
        private readonly IApuxApi _api;

        /// <summary>
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// </summary>
        private readonly IBlobCache _cache = BlobCache.LocalMachine;

        /// <summary>
        /// </summary>
        private readonly DateTimeOffset _expires = DateTimeOffset.Now.AddHours(12);

        /// <summary>
        /// </summary>
        private readonly HttpClient _client = new HttpClient(new NativeMessageHandler())
        {
            BaseAddress = new Uri("http://api.apixu.com/v1")
        };

        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        public ApixuApi(string apiKey)
        {
            _apiKey = apiKey;
            _api = RestService.For<IApuxApi>(_client);
        }

        /// <summary>
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public async Task<ApixuCurrent> Current(PlaceAdapter place)
        {
            return await _cache.GetOrFetchObject("current_" + place.Parameters, () => _api.GetCurrent(_apiKey, place.Parameters), _expires);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="place"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(PlaceAdapter place, int days)
        {
            return await _cache.GetOrFetchObject("forecast_" + place.Parameters, () => _api.GetForecast(_apiKey, place.Parameters, days), _expires);
        }

        /// <summary>
        /// </summary>
        /// <param name="place"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(PlaceAdapter place, HistoryParameters parameters)
        {
            return await _cache.GetOrFetchObject("history_" + place.Parameters, () => _api.GetHistory(_apiKey, place.Parameters, parameters), _expires);
        }
    }
}