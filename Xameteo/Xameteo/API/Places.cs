using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using Xameteo.Model;

namespace Xameteo.API
{
    /// <summary>
    /// </summary>
    public class Places
    {
        /// <summary>
        /// </summary>
        public List<ApixuAdapter> List { get; } = new List<ApixuAdapter>();

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
            var notFound = List.FirstOrDefault(it => it.Parameters == adapter.Parameters) == null;

            if (notFound)
            {
                List.Add(adapter);
                SerializePlaces();
            }

            return notFound;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool Remove(ApixuAdapter adapter)
        {
            var itemFound = List.Remove(adapter);

            if (itemFound)
            {
                SerializePlaces();
            }

            return itemFound;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Task<ApixuCurrent>> Current()
        {
            return List.Select(it => Xameteo.Api.Current(it));
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private void SerializePlaces()
        {
            Xameteo.Settings.Places = JsonConvert.SerializeObject(List, Formatting.None, _settings);
        }

        /// <summary>
        /// </summary>
        /// <param name="jsonData"></param>
        public Places(string jsonData)
        {
            try
            {
                Insert(new AirportAdapter(Airport.Instances[5]));
                Insert(new GeolocationAdapter("Valongo, Porto"));
                Insert(new CoordinatesAdapter(new Coordinates(35.6732619, 139.5703036)));
                List.AddRange(JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(jsonData, _settings));
            }
            catch (Exception exception)
            {
                Xameteo.Dialogs.Alert(exception);
            }
        }
    }
}