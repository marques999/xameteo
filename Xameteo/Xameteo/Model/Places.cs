using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;

using Xameteo.Adapters;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal class Places
    {
        /// <summary>
        /// </summary>
        private readonly HashSet<ApixuAdapter> _places = new HashSet<ApixuAdapter>();

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// </summary>
        /// <param name="jsonData"></param>
        public Places(string jsonData)
        {
            _places.UnionWith(JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(jsonData, _settings));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<ApixuAdapter> Get()
        {
            return _places.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(ApixuAdapter adapter) => _places.Add(adapter);

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(ApixuAdapter adapter) => _places.Remove(adapter);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public void Save() => Xameteo.Settings.Places = JsonConvert.SerializeObject(_places.ToList(), Formatting.None, _settings);
    }
}