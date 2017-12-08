using System;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Refit;
using Akavache;
using ModernHttpClient;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class ApixuApi
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
        private readonly DateTimeOffset _expires = Xameteo.Globals.CacheInvalidate;

        /// <summary>
        /// </summary>
        private readonly HttpClient _client = new HttpClient(new NativeMessageHandler())
        {
            BaseAddress = Xameteo.Globals.BaseUrl,
            Timeout = Xameteo.Globals.AsyncTimeout,
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
        /// <param name="apixu"></param>
        /// <returns></returns>
        public async Task<ApixuCurrent> Current(ApixuAdapter apixu)
        {
            return await _cache.GetOrFetchObject("current_" + apixu.Parameters, () => _api.GetCurrent(_apiKey, apixu.Parameters), _expires);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apixu"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(ApixuAdapter apixu, int days)
        {
            return await _cache.GetOrFetchObject("forecast_" + apixu.Parameters, () => _api.GetForecast(_apiKey, apixu.Parameters, days), _expires);
        }

        /// <summary>
        /// </summary>
        /// <param name="apixu"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(ApixuAdapter apixu, DateTime start, DateTime? end)
        {
            return await _cache.GetOrFetchObject("history_" + apixu.Parameters, () => _api.GetHistory(_apiKey, apixu.Parameters, start, end), _expires);
        }
    }
}