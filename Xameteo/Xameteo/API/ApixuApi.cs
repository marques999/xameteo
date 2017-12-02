using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xameteo.Adapters;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    internal class ApixuApi
    {
        /// <summary>
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// </summary>
        private readonly string _parameters;

        /// <summary>
        /// </summary>
        private const string ApiUrl = "http://api.apixu.com/v1";

        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="adapter"></param>
        public ApixuApi(string apiKey, ApixuAdapter adapter)
        {
            _apiKey = apiKey;
            _parameters = adapter.Parameters;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Task<ApixuCurrent> Current() => HttpGetAsync<ApixuCurrent>(
            $"{ApiUrl}/current.json?key={_apiKey}&q={_parameters}"
        );

        /// <summary>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Task<ApixuHistory> History(DateTime start, DateTime end) => HttpGetAsync<ApixuHistory>(
            $"{ApiUrl}/history.json?key={_apiKey}&q={_parameters}&dt={start:d}&end_dt={end:d}"
        );

        /// <summary>
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public Task<ApixuForecast> Forecast(int days) => HttpGetAsync<ApixuForecast>(
            $"{ApiUrl}/forecast.json?key={_apiKey}&q={_parameters}&days={days}"
        );

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static async Task<T> HttpGetAsync<T>(string uri)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;

            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response = await request.GetResponseAsync())
            {
                if (!(response is HttpWebResponse httpResponse))
                {
                    return default(T);
                }

                var statusCode = httpResponse.StatusCode;

                if (statusCode != HttpStatusCode.OK)
                {
                    return default(T);
                }

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
                }
            }
        }
    }
}