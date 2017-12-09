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
        private readonly IApuxApi _api = RestService.For<IApuxApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = Xameteo.Globals.AsyncTimeout,
            BaseAddress = Xameteo.Globals.ApixuBaseUrl
        });

        /// <summary>
        /// </summary>
        private readonly IBlobCache _cache = BlobCache.LocalMachine;

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuCurrent> Current(ApixuAdapter adapter) => await _cache.GetOrFetchObject(
            "current_" + adapter.Parameters,
            () => _api.GetCurrent(Xameteo.Settings.ApixuKey, adapter.Parameters),
            Xameteo.Globals.CacheInvalidate
        );

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(ApixuAdapter adapter) => await _cache.GetOrFetchObject(
            "forecast_" + adapter.Parameters,
            () => _api.GetForecast(Xameteo.Settings.ApixuKey, adapter.Parameters, Xameteo.Globals.ForecastDays),
            Xameteo.Globals.CacheInvalidate
        );

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(ApixuAdapter adapter, DateTime start, DateTime? end) => await _cache.GetOrFetchObject(
            "history_" + adapter.Parameters,
            () => _api.GetHistory(Xameteo.Settings.ApixuKey, adapter.Parameters, start, end),
            Xameteo.Globals.CacheInvalidate
        );
    }
}