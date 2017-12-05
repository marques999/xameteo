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
        private readonly HashSet<PlaceAdapter> _places = new HashSet<PlaceAdapter>();

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<PlaceAdapter> Enumerate()
        {
            return _places.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Insert(PlaceAdapter adapter)
        {
            return _places.Add(adapter);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(PlaceAdapter adapter)
        {
            return _places.Remove(adapter);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task<ApixuCurrent>> Current()
        {
            return _places.Select(it => Xameteo.Api.Current(it));
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
            _places.UnionWith(JsonConvert.DeserializeObject<IEnumerable<PlaceAdapter>>(jsonData, _settings));
        }
    }
}