using System;

using Plugin.Settings;
using Plugin.Settings.Abstractions;

using Xameteo.Model;
using Xameteo.Units;
using Xameteo.Globalization;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Settings
    {
        /// <summary>
        /// </summary>
        private static ISettings SettingsManager => CrossSettings.Current;

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="default"></param>
        private static TEnum ReadEnum<TEnum>(string key, TEnum @default) where TEnum : struct => Enum.TryParse<TEnum>(
            SettingsManager.GetValueOrDefault(key, @default.ToString()), out var parsed
        ) ? parsed : @default;

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void WriteEnum(string key, Enum value)
        {
            SettingsManager.AddOrUpdateValue(key, value.ToString());
        }

        /// <summary>
        /// </summary>
        private const string ApiKeyKey = "settings_key";

        /// <summary>
        /// </summary>
        private const string ApiKeyDefault = "7e4b1cf5c63a4a2e876183000173011";

        /// <summary>
        /// </summary>
        public string ApiKey
        {
            get => SettingsManager.GetValueOrDefault(ApiKeyKey, ApiKeyDefault);
            set => SettingsManager.AddOrUpdateValue(ApiKeyKey, value);
        }

        /// <summary>
        /// </summary>
        private readonly TemperatureUnits _temperatureUnits = new TemperatureUnits();

        /// <summary>
        /// </summary>
        public Unit TemperatureFactoryUnits
        {
            get => _temperatureUnits.Load(SettingsManager);
            set => _temperatureUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        private readonly PressureUnits _pressureUnits = new PressureUnits();

        /// <summary>
        /// </summary>
        public Unit PressureUnits
        {
            get => _pressureUnits.Load(SettingsManager);
            set => _pressureUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        private readonly PrecipitationUnits _precipitationUnits = new PrecipitationUnits();

        /// <summary>
        /// </summary>
        public Unit PrecipitationUnits
        {
            get => _precipitationUnits.Load(SettingsManager);
            set => _precipitationUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        private readonly DistanceUnits _distanceUnits = new DistanceUnits();

        /// <summary>
        /// </summary>
        public Unit DistanceUnits
        {
            get => _distanceUnits.Load(SettingsManager);
            set => _distanceUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        public int ClockUnits
        {
            get => SettingsManager.GetValueOrDefault("clock", 0);
            set => SettingsManager.AddOrUpdateValue("clock", value);
        }

        /// <summary>
        /// </summary>
        public Clock Clock => ClockFactory.Get(ClockUnits);

        /// <summary>
        /// </summary>
        private readonly VelocityUnits _velocityUnits = new VelocityUnits();

        /// <summary>
        /// </summary>
        public Unit VelocityUnits
        {
            get => _velocityUnits.Load(SettingsManager);
            set => _velocityUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        public Locale Locale
        {
            get => ReadEnum("language", Locale.English);
            set => WriteEnum("language", value);
        }

        /// <summary>
        /// </summary>
        public string Places
        {
            get => SettingsManager.GetValueOrDefault("places", "[]");
            set => SettingsManager.AddOrUpdateValue("places", value);
        }
    }
}