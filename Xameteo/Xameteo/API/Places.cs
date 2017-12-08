using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class Places
    {
        /// <summary>
        /// </summary>
        public List<ApixuAdapter> List { get; }

        /// <summary>
        /// </summary>
        private readonly HashSet<ApixuAdapter> _duplicates = new HashSet<ApixuAdapter>();

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<ApixuCurrent> Current(int index)
        {
            return index < List.Count ? Xameteo.Api.Current(List[index]) : null;
        }

        /// <summary>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task<ApixuForecast> Forecast(int index)
        {
            return index < List.Count ? Xameteo.Api.Forecast(List[index], 15) : null;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(ApixuAdapter adapter)
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
        public bool Remove(ApixuAdapter adapter)
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
            _duplicates.UnionWith(JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(jsonData, _settings));
            List = new List<ApixuAdapter>(_duplicates);
        }
    }
}