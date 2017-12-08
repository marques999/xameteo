using System;

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
            get => SettingsManager.GetValueOrDefault("apikey", Xameteo.Globals.ApixuKey);
            set => SettingsManager.AddOrUpdateValue("apikey", value);
        }

        /// <summary>
        /// </summary>
        public string Places
        {
            get => SettingsManager.GetValueOrDefault("places", "[]");
            set => SettingsManager.AddOrUpdateValue("places", value);
        }

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get => Distance.From(SettingsManager.GetValueOrDefault(nameof(Distance), 0));
            set => SettingsManager.AddOrUpdateValue(nameof(Distance), value.Id);
        }

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get => Precipitation.From(SettingsManager.GetValueOrDefault(nameof(Precipitation), 0));
            set => SettingsManager.AddOrUpdateValue(nameof(Precipitation), value.Id);
        }

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get => Pressure.From(SettingsManager.GetValueOrDefault(nameof(Pressure), 0));
            set => SettingsManager.AddOrUpdateValue(nameof(Pressure), value.Id);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get => Temperature.From(SettingsManager.GetValueOrDefault(nameof(Temperature), 0));
            set => SettingsManager.AddOrUpdateValue(nameof(Temperature), value.Id);
        }

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get => Velocity.From(SettingsManager.GetValueOrDefault(nameof(Velocity), 0));
            set => SettingsManager.AddOrUpdateValue(nameof(Velocity), value.Id);
        }
    }
}