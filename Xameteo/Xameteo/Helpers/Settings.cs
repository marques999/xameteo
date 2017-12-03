using System;

using Plugin.Settings;
using Plugin.Settings.Abstractions;

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
        public string ApiKey
        {
            get => SettingsManager.GetValueOrDefault("apikey", "7e4b1cf5c63a4a2e876183000173011");
            set => SettingsManager.AddOrUpdateValue("apikey", value);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get;
        } = new Temperature(SettingsManager);

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get;
        } = new Pressure(SettingsManager);

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get;
        } = new Precipitation(SettingsManager);

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get;
        } = new Distance(SettingsManager);

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get;
        } = new Velocity(SettingsManager);

        /// <summary>
        /// </summary>
        public ClockFactory Clock
        {
            get;
        } = new ClockFactory(SettingsManager);

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