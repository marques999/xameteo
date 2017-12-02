using System;

using Plugin.Settings;
using Plugin.Settings.Abstractions;

using Xameteo.Constants;

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
        private const string TemperatureUnitsKey = "temperature";

        /// <summary>
        /// </summary>
        public Temperature TemperatureUnits
        {
            get => ReadEnum(TemperatureUnitsKey, Temperature.Celsius);
            set => WriteEnum(TemperatureUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string PressureUnitsKey = "pressure";

        /// <summary>
        /// </summary>
        public Pressure PressureUnits
        {
            get => ReadEnum(PressureUnitsKey, Pressure.Milibars);
            set => WriteEnum(PressureUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string PrecipitationUnitsKey = "precipitation";

        /// <summary>
        /// </summary>
        public Precipitation PrecipitationUnits
        {
            get => ReadEnum(PrecipitationUnitsKey, Precipitation.Milimeters);
            set => WriteEnum(PrecipitationUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string DistanceUnitsKey = "distance";

        /// <summary>
        /// </summary>
        public Distance DistanceUnits
        {
            get => ReadEnum(DistanceUnitsKey, Distance.Kilometers);
            set => WriteEnum(DistanceUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string ClockUnitsKey = "clock";

        /// <summary>
        /// </summary>
        public Clock ClockUnits
        {
            get => ReadEnum(ClockUnitsKey, Clock.TwentyFour);
            set => WriteEnum(ClockUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string VelocityUnitsKey = "velocity";

        /// <summary>
        /// </summary>
        public Velocity VelocityUnits
        {
            get => ReadEnum(VelocityUnitsKey, Velocity.KilometersPerHour);
            set => WriteEnum(VelocityUnitsKey, value);
        }

        /// <summary>
        /// </summary>
        private const string LanguageKey = "language";

        /// <summary>
        /// </summary>
        public string Language
        {
            get => SettingsManager.GetValueOrDefault(LanguageKey, "en-US");
            set => SettingsManager.AddOrUpdateValue(LanguageKey, value);
        }

        /// <summary>
        /// </summary>
        private const string PlacesKey = "places";

        /// <summary>
        /// </summary>
        public string Places
        {
            get => SettingsManager.GetValueOrDefault(PlacesKey, "[]");
            set => SettingsManager.AddOrUpdateValue(PlacesKey, value);
        }
    }
}