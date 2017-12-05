using Refit;
using Xameteo.Model;
using System.Threading.Tasks;

namespace Xameteo.API
{
    [Headers("Accept: application/json")]
    public interface IApuxApi
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Get("/current.json")]
        Task<ApixuCurrent> GetCurrent(string key, string q);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Get("/forecast.json")]
        Task<ApixuForecast> GetForecast(string key, string q, int days);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Get("/history.json")]
        Task<ApixuHistory> GetHistory(string key, string q, HistoryParameters parameters);
    }
}