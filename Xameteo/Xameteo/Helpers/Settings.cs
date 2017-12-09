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
        private readonly ISettings _instance = CrossSettings.Current;

        /// <summary>
        /// </summary>
        public string Places
        {
            get => _instance.GetValueOrDefault("places", "[]");
            set => _instance.AddOrUpdateValue("places", value);
        }

        /// <summary>
        /// </summary>
        public string ApixuKey
        {
            get => _instance.GetValueOrDefault("apixu", Xameteo.Globals.ApixuKey);
            set => _instance.AddOrUpdateValue("apixu", value);
        }

        /// <summary>
        /// </summary>
        public string GoogleKey
        {
            get => _instance.GetValueOrDefault("google", Xameteo.Globals.GoogleKey);
            set => _instance.AddOrUpdateValue("google", value);
        }

        /// <summary>
        /// </summary>
        public Distance Distance
        {
            get => Distance.From(_instance.GetValueOrDefault("distance", 0));
            set => _instance.AddOrUpdateValue("distance", value.Id);
        }

        /// <summary>
        /// </summary>
        public Precipitation Precipitation
        {
            get => Precipitation.From(_instance.GetValueOrDefault("precipitation", 0));
            set => _instance.AddOrUpdateValue("precipitation", value.Id);
        }

        /// <summary>
        /// </summary>
        public Pressure Pressure
        {
            get => Pressure.From(_instance.GetValueOrDefault("pressure", 0));
            set => _instance.AddOrUpdateValue("pressure", value.Id);
        }

        /// <summary>
        /// </summary>
        public Temperature Temperature
        {
            get => Temperature.From(_instance.GetValueOrDefault("temperature", 0));
            set => _instance.AddOrUpdateValue("temperature", value.Id);
        }

        /// <summary>
        /// </summary>
        public Velocity Velocity
        {
            get => Velocity.From(_instance.GetValueOrDefault("velocity", 0));
            set => _instance.AddOrUpdateValue("velocity", value.Id);
        }
    }
}