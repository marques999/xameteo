using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xameteo.API;
using Xameteo.Views;
using Xameteo.Helpers;
using Xameteo.Globalization;

using Newtonsoft.Json;

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
            using (var progressDialog = Dialogs.InfiniteProgress)
            {
                try
                {
                    progressDialog.Show();
                    Apixu = new ApixuApi();
                    Geocoding = new GoogleApi();

                    foreach (var place in JsonConvert.DeserializeObject<List<ApixuPlace>>(Settings.Places, JsonSettings))
                    {
                        Places.Add(CacheExpired(place) ? await FetchPlace(place.Adapter) : place);
                    }
                }
                catch (Exception exception)
                {
                    await Dialogs.Alert(exception);
                }
                finally
                {
                    progressDialog.Hide();
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private static bool CacheExpired(ApixuPlace viewModel)
        {
            return DateTime.Now > viewModel.Timestamp.Add(Globals.CacheInvalidate);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        private static async Task<ApixuPlace> FetchPlace(ApixuAdapter adapter)
        {
            return new ApixuPlace(adapter, await Apixu.Forecast(adapter));
        }

        /// <summary>
        /// </summary>
        public static ApixuApi Apixu { get; private set; }

        /// <summary>
        /// </summary>
        public static GoogleApi Geocoding { get; private set; }

        /// <summary>
        /// </summary>
        public static ObservableCollection<ApixuPlace> Places
        {
            get;
        } = new ObservableCollection<ApixuPlace>();

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
        public static async void RefreshPlaces()
        {
            Places.Clear();

            foreach (var place in JsonConvert.DeserializeObject<List<ApixuPlace>>(Settings.Places, JsonSettings))
            {
                Places.Add(await FetchPlace(place.Adapter));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public static async Task<ApixuPlace> InsertPlace(ApixuAdapter adapter)
        {
            if (Places.FirstOrDefault(it => it.Adapter.Parameters == adapter.Parameters) != null)
            {
                return null;
            }

            var viewModel = await FetchPlace(adapter);

            Places.Add(viewModel);
            Settings.Places = JsonConvert.SerializeObject(Places, JsonSettings);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.Objects
        };

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public static bool RemovePlace(ApixuPlace adapter)
        {
            if (Places.Remove(adapter))
            {
                Settings.Places = JsonConvert.SerializeObject(Places, JsonSettings);
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}