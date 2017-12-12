using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;

using Xameteo.API;
using Xameteo.Google;
using Xameteo.Helpers;
using Xameteo.Globalization;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    internal class Xameteo
    {
        /// <summary>
        /// </summary>
        public static async void Initialize()
        {
            try
            {
                Apixu = new ApixuApi();
                Geocoding = new GoogleApi();
                Places.AddRange(JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(Settings.Places));
            }
            catch (Exception exception)
            {
                await Dialogs.Alert(exception);
            }
        }

        /// <summary>
        /// </summary>
        public static ApixuApi Apixu { get; private set; }

        /// <summary>
        /// </summary>
        public static GoogleApi Geocoding { get; private set; }

        /// <summary>
        /// </summary>
        public static Events Events { get; } = new Events();

        /// <summary>
        /// </summary>
        public static Localization Localization { get; } = new Localization();

        /// <summary>
        /// </summary>
        public static Dialogs Dialogs { get; } = new Dialogs();

        /// <summary>
        /// </summary>
        public static Globals Globals { get; } = new Globals();

        /// <summary>
        /// </summary>
        public static Settings Settings { get; } = new Settings();

        /// <summary>
        /// </summary>
        public static IGeolocator Geolocator { get; } = CrossGeolocator.Current;

        /// <summary>
        /// </summary>
        public static List<ApixuAdapter> Places { get; } = new List<ApixuAdapter>();

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public static bool InsertPlace(ApixuAdapter adapter)
        {
            if (Places.FirstOrDefault(it => it.Parameters == adapter.Parameters) != null)
            {
                return false;
            }

            Places.Add(adapter);
            Settings.Places = JsonConvert.SerializeObject(Places, Formatting.None);

            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public static bool RemovePlace(ApixuAdapter adapter)
        {
            if (Places.Remove(adapter))
            {
                Settings.Places = JsonConvert.SerializeObject(Places, Formatting.None);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}