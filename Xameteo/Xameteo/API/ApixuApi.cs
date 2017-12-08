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
        private readonly string _apiKey;

        /// <summary>
        /// </summary>
        private readonly IBlobCache _cache = BlobCache.LocalMachine;

        /// <summary>
        /// </summary>
        private readonly DateTimeOffset _expires = Xameteo.Globals.CacheInvalidate;

        /// <summary>
        /// </summary>
        private readonly IApuxApi _api = RestService.For<IApuxApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = Xameteo.Globals.AsyncTimeout,
            BaseAddress = Xameteo.Globals.ApixuBaseUrl
        });

        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        public ApixuApi(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuCurrent> Current(ApixuAdapter adapter)
        {
            return await _cache.GetOrFetchObject("current_" + adapter.Parameters, () => _api.GetCurrent(_apiKey, adapter.Parameters), _expires);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(ApixuAdapter adapter, int days)
        {
            return await _cache.GetOrFetchObject("forecast_" + adapter.Parameters, () => _api.GetForecast(_apiKey, adapter.Parameters, days), _expires);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(ApixuAdapter adapter, DateTime start, DateTime? end)
        {
            return await _cache.GetOrFetchObject("history_" + adapter.Parameters, () => _api.GetHistory(_apiKey, adapter.Parameters, start, end), _expires);
        }
    }
}