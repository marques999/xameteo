using System;
using System.Net.Http;
using System.Threading.Tasks;

using Refit;
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
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(ApixuAdapter adapter) => await _api.GetForecast(
            Xameteo.Settings.ApixuKey, adapter.Parameters, Xameteo.Settings.ForecastDays
        );

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(ApixuAdapter adapter, DateTime start, DateTime? end) => await _api.GetHistory(
            Xameteo.Settings.ApixuKey, adapter.Parameters, start, end
        );
    }
}