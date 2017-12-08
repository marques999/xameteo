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
        private readonly ISettings _settingsManager = CrossSettings.Current;

        /// <summary>
        /// </summary>
        public string Places
        {
            get => _settingsManager.GetValueOrDefault("places", "[]");
            set => _settingsManager.AddOrUpdateValue("places", value);
        }

        /// <summary>
        /// </summary>
        public string ApixuKey
        {
            get => _settingsManager.GetValueOrDefault("apixu", Xameteo.Globals.ApixuKey);
            set => _settingsManager.AddOrUpdateValue("apixu", value);
        }

        /// <summary>
        /// </summary>
        public string GoogleKey
        {
            get => _settingsManager.GetValueOrDefault("google", Xameteo.Globals.GoogleKey);
            set => _settingsManager.AddOrUpdateValue("google", value);
        }

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get => Distance.From(_settingsManager.GetValueOrDefault(nameof(Distance), 0));
            set => _settingsManager.AddOrUpdateValue(nameof(Distance), value.Id);
        }

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get => Precipitation.From(_settingsManager.GetValueOrDefault(nameof(Precipitation), 0));
            set => _settingsManager.AddOrUpdateValue(nameof(Precipitation), value.Id);
        }

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get => Pressure.From(_settingsManager.GetValueOrDefault(nameof(Pressure), 0));
            set => _settingsManager.AddOrUpdateValue(nameof(Pressure), value.Id);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get => Temperature.From(_settingsManager.GetValueOrDefault(nameof(Temperature), 0));
            set => _settingsManager.AddOrUpdateValue(nameof(Temperature), value.Id);
        }

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get => Velocity.From(_settingsManager.GetValueOrDefault(nameof(Velocity), 0));
            set => _settingsManager.AddOrUpdateValue(nameof(Velocity), value.Id);
        }
    }
}