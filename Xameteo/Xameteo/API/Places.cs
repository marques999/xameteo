using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using Xameteo.Model;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    internal class Places
    {
        /// <summary>
        /// </summary>
        public List<PlaceAdapter> List { get; }

        /// <summary>
        /// </summary>
        private readonly HashSet<PlaceAdapter> _duplicates = new HashSet<PlaceAdapter>();

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Task<ApixuCurrent> Current(int index)
        {
            return index < List.Count ? Xameteo.Api.Current(List[index]) : null;
        }

        public Task<ApixuForecast> Forecast(int index)
        {
            return index < List.Count ? Xameteo.Api.Forecast(List[index], 15) : null;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(PlaceAdapter adapter)
        {
            var operationResult = _duplicates.Add(adapter);

            if (operationResult)
            {
                List.Add(adapter);
            }

            return operationResult;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(PlaceAdapter adapter)
        {
            var operationResult = _duplicates.Remove(adapter);

            if (operationResult)
            {
                List.Remove(adapter);
            }

            return operationResult;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task<ApixuCurrent>> Current()
        {
            return _duplicates.Select(it => Xameteo.Api.Current(it));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            Xameteo.Settings.Places = JsonConvert.SerializeObject(_duplicates.ToList(), Formatting.None, _settings);
        }

        /// <summary>
        /// </summary>
        /// <param name="jsonData"></param>
        public Places(string jsonData)
        {
            _duplicates.UnionWith(JsonConvert.DeserializeObject<IEnumerable<PlaceAdapter>>(jsonData, _settings));
            List = new List<PlaceAdapter>(_duplicates);
        }
    }
}