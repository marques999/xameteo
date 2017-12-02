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
        public TemperatureUnits TemperatureUnits
        {
            get;
        } = new TemperatureUnits();

        /// <summary>
        /// </summary>
        public Unit Temperature
        {
            get => TemperatureUnits.Load(SettingsManager);
            set => TemperatureUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        public PressureUnits PressureUnits
        {
            get;
        } = new PressureUnits();

        /// <summary>
        /// </summary>
        public Unit Pressure
        {
            get => PressureUnits.Load(SettingsManager);
            set => PressureUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        public PrecipitationUnits PrecipitationUnits
        {
            get;
        } = new PrecipitationUnits();

        /// <summary>
        /// </summary>
        public Unit Precipitation
        {
            get => PrecipitationUnits.Load(SettingsManager);
            set => PrecipitationUnits.Save(SettingsManager, value);
        }

        /// <summary>
        /// </summary>
        public DistanceUnits DistanceUnits
        {
            get;
        } = new DistanceUnits();

        /// <summary>
        /// </summary>
        public Unit Distance
        {
            get => DistanceUnits.Load(SettingsManager);
            set => DistanceUnits.Save(SettingsManager, value);
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
        public VelocityUnits VelocityUnits
        {
            get;
        } = new VelocityUnits();

        /// <summary>
        /// </summary>
        public Unit Velocity
        {
            get => VelocityUnits.Load(SettingsManager);
            set => VelocityUnits.Save(SettingsManager, value);
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