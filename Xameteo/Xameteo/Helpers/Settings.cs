using Plugin.Settings;
using Plugin.Settings.Abstractions;

using Xameteo.Units;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Settings
    {
        /// <summary>
        /// </summary>
        private const string PropertyDays = "days";
        private const string PropertyPlaces = "places";
        private const string PropertyApixuKey = "apixu";
        private const string PropertyGoogleKey = "google";

        /// <summary>
        /// </summary>
        private readonly ISettings _settingsManager = CrossSettings.Current;

        /// <summary>
        /// </summary>
        public int ForecastDays
        {
            get => _settingsManager.GetValueOrDefault(PropertyDays, 15);
            set => _settingsManager.AddOrUpdateValue(PropertyDays, value);
        }

        /// <summary>
        /// </summary>
        public string Places
        {
            get => _settingsManager.GetValueOrDefault(PropertyPlaces, "[]");
            set => _settingsManager.AddOrUpdateValue(PropertyPlaces, value);
        }

        /// <summary>
        /// </summary>
        public string ApixuKey
        {
            get => _settingsManager.GetValueOrDefault(PropertyApixuKey, Xameteo.Globals.ApixuKey);
            set => _settingsManager.AddOrUpdateValue(PropertyApixuKey, value);
        }

        /// <summary>
        /// </summary>
        public string GoogleKey
        {
            get => _settingsManager.GetValueOrDefault(PropertyGoogleKey, Xameteo.Globals.GoogleKey);
            set => _settingsManager.AddOrUpdateValue(PropertyGoogleKey, value);
        }

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get => Distance.Load(_settingsManager);
            set => value.Save(_settingsManager);
        }

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get => Precipitation.Load(_settingsManager);
            set => value.Save(_settingsManager);
        }

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get => Pressure.Load(_settingsManager);
            set => value.Save(_settingsManager);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get => Temperature.Load(_settingsManager);
            set => value.Save(_settingsManager);
        }

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get => Velocity.Load(_settingsManager);
            set => value.Save(_settingsManager);
        }
    }
}