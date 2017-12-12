using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Newtonsoft.Json;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xameteo.API;
using Xameteo.Model;
using Xameteo.Units;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    public class XameteoApp
    {
        /// <summary>
        /// </summary>
        private static XameteoApp _instance;

        /// <summary>
        /// </summary>
        public static XameteoApp Instance => _instance ?? (_instance = new XameteoApp());

        /// <summary>
        /// </summary>
        private XameteoApp()
        {
            try
            {
                XameteoDialogs.ShowLoading();
                Apixu = new ApixuApi(this);
                Geocoding = new GoogleApi(this);
                InitializePlaces();
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
            finally
            {
                XameteoDialogs.HideLoading();
            }
        }

        /// <summary>
        /// </summary>
        public void ResetSettngs() => _settings.Clear();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<Coordinates> DeviceLocation() => new Coordinates(
            await Geolocator.GetPositionAsync(XameteoGlobals.AsyncTimeout)
        );

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        private static bool CacheExpired(ApixuPlace viewModel)
        {
            return DateTime.Now > viewModel.Timestamp.Add(XameteoGlobals.CacheInvalidate);
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        private async Task<ApixuPlace> FetchPlace(ApixuAdapter adapter)
        {
            return new ApixuPlace(adapter, await Apixu.Forecast(adapter));
        }

        /// <summary>
        /// </summary>
        private readonly ISettings _settings = CrossSettings.Current;

        /// <summary>
        /// </summary>
        public int ForecastDays
        {
            get => _settings.GetValueOrDefault(XameteoGlobals.PropertyDays, 15);
            set => _settings.AddOrUpdateValue(XameteoGlobals.PropertyDays, value);
        }

        /// <summary>
        /// </summary>
        public string ApixuKey
        {
            get => _settings.GetValueOrDefault(XameteoGlobals.PropertyApixuKey, XameteoGlobals.ApixuKey);
            set => _settings.AddOrUpdateValue(XameteoGlobals.PropertyApixuKey, value);
        }

        /// <summary>
        /// </summary>
        public string GoogleKey
        {
            get => _settings.GetValueOrDefault(XameteoGlobals.PropertyGoogleKey, XameteoGlobals.GoogleKey);
            set => _settings.AddOrUpdateValue(XameteoGlobals.PropertyGoogleKey, value);
        }

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get => Distance.Load(_settings);
            set => value.Save(_settings);
        }

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get => Precipitation.Load(_settings);
            set => value.Save(_settings);
        }

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get => Pressure.Load(_settings);
            set => value.Save(_settings);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get => Temperature.Load(_settings);
            set => value.Save(_settings);
        }

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get => Velocity.Load(_settings);
            set => value.Save(_settings);
        }

        /// <summary>
        /// </summary>
        public ApixuApi Apixu { get; }

        /// <summary>
        /// </summary>
        public GoogleApi Geocoding { get; }

        /// <summary>
        /// </summary>
        public XameteoEvents Events { get; } = new XameteoEvents();

        /// <summary>
        /// </summary>
        public IGeolocator Geolocator { get; } = CrossGeolocator.Current;

        /// <summary>
        /// </summary>
        public ObservableCollection<ApixuPlace> Places
        {
            get;
        } = new ObservableCollection<ApixuPlace>();

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool RemovePlace(ApixuPlace adapter)
        {
            return Places.Remove(adapter) && SavePlaces();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private string LoadPlaces()
        {
            return _settings.GetValueOrDefault(XameteoGlobals.PropertyPlaces, "[]");
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private bool SavePlaces()
        {
            return _settings.AddOrUpdateValue(XameteoGlobals.PropertyPlaces, JsonConvert.SerializeObject(Places, _jsonSettings));
        }

        /// <summary>
        /// </summary>
        private async void InitializePlaces()
        {
            foreach (var place in JsonConvert.DeserializeObject<List<ApixuPlace>>(LoadPlaces(), _jsonSettings))
            {
                Places.Add(CacheExpired(place) ? await FetchPlace(place.Adapter) : place);
            }
        }

        /// <summary>
        /// </summary>
        public async void RefreshPlaces()
        {
            Places.Clear();

            foreach (var place in JsonConvert.DeserializeObject<List<ApixuPlace>>(LoadPlaces(), _jsonSettings))
            {
                Places.Add(await FetchPlace(place.Adapter));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ApixuPlace> InsertPlace(ApixuAdapter adapter)
        {
            if (Places.FirstOrDefault(it => it.Adapter.Parameters == adapter.Parameters) != null)
            {
                return null;
            }

            var viewModel = await FetchPlace(adapter);

            Places.Add(viewModel);
            SavePlaces();

            return viewModel;
        }

        /// <summary>
        /// </summary>
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.Objects
        };
    }
}