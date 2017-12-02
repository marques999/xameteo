using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    internal class Places
    {
        /// <summary>
        /// </summary>
        private readonly HashSet<PlacesAdapter> _places = new HashSet<PlacesAdapter>();

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<PlacesAdapter> Get()
        {
            return _places.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(PlacesAdapter adapter)
        {
            return _places.Add(adapter);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(PlacesAdapter adapter)
        {
            return _places.Remove(adapter);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            Xameteo.Settings.Places = JsonConvert.SerializeObject(_places.ToList(), Formatting.None, _settings);
        }

        /// <summary>
        /// </summary>
        /// <param name="jsonData"></param>
        public Places(string jsonData)
        {
            _places.UnionWith(JsonConvert.DeserializeObject<IEnumerable<PlacesAdapter>>(jsonData, _settings));
        }
    }
}