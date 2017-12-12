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
        private readonly XameteoApp _xameteoApp;

        /// <summary>
        /// </summary>
        /// <param name="xameteoApp"></param>
        public ApixuApi(XameteoApp xameteoApp)
        {
            _xameteoApp = xameteoApp;
        }

        /// <summary>
        /// </summary>
        private readonly IApuxApi _api = RestService.For<IApuxApi>(new HttpClient(new NativeMessageHandler())
        {
            Timeout = XameteoGlobals.AsyncTimeout,
            BaseAddress = XameteoGlobals.ApixuBaseUrl
        });

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuForecast> Forecast(ApixuAdapter adapter)
        {
            return await _api.GetForecast(_xameteoApp.ApixuKey, adapter.Parameters, _xameteoApp.ForecastDays);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public async Task<ApixuHistory> History(ApixuAdapter adapter, DateTime start, DateTime? end)
        {
            return await _api.GetHistory(_xameteoApp.ApixuKey, adapter.Parameters, start, end);
        }
    }
}