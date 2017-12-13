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
                RefreshPlaces();
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
        public void ResetSettngs() => _settings.Clear();

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public bool RemovePlace(ApixuPlace adapter) => Places.Remove(adapter) && SavePlaces();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private bool SavePlaces() => _settings.AddOrUpdateValue(
            XameteoGlobals.PropertyPlaces,
            JsonConvert.SerializeObject(Places.Select(it => it.Adapter), _jsonSettings)
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<Coordinates> DeviceLocation() => new Coordinates(
            await Geolocator.GetPositionAsync(XameteoGlobals.AsyncTimeout)
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ApixuAdapter> LoadPlaces() => JsonConvert.DeserializeObject<IEnumerable<ApixuAdapter>>(
            _settings.GetValueOrDefault(XameteoGlobals.PropertyPlaces, "[]"), _jsonSettings
        );

        /// <summary>
        /// </summary>
        public async void RefreshPlaces()
        {
            Places.Clear();

            foreach (var adapter in LoadPlaces())
            {
                Places.Add(new ApixuPlace(adapter, await Apixu.Forecast(adapter)));
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

            var viewModel = new ApixuPlace(adapter, await Apixu.Forecast(adapter));

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