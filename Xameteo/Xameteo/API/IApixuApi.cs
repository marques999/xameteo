using System;
using System.Threading.Tasks;

using Refit;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IApuxApi
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Get("/forecast.json")]
        Task<ApixuForecast> GetForecast(string key, string q, int days);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Get("/history.json")]
        Task<ApixuHistory> GetHistory(string key, string q, [AliasAs("dt")] string start, [AliasAs("dt_end")] string end);
    }
}