using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xameteo.API;
using Xameteo.Google;
using Xameteo.Helpers;
using Xameteo.Globalization;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    internal class Xameteo
    {
        /// <summary>
        /// </summary>
        public static void Initialize()
        {
            Api = new ApixuApi(Settings.ApixuKey);
            MyPlaces = new Places(Settings.Places);
        }

        /// <summary>
        /// </summary>
        public static ApixuApi Api { get; private set; }

        /// <summary>
        /// </summary>
        public static Places MyPlaces { get; private set; }

        /// <summary>
        /// </summary>
        public static Dialogs Dialogs { get; } = new Dialogs();

        /// <summary>
        /// </summary>
        public static Globals Globals { get; } = new Globals();

        /// <summary>
        /// </summary>
        public static Settings Settings { get; } = new Settings();

        /// <summary>
        /// </summary>
        public static GoogleApi Geocoding { get; } = new GoogleApi();

        /// <summary>
        /// </summary>
        public static Localization Localization { get; } = new Localization();

        /// <summary>
        /// </summary>
        public static IGeolocator Geolocator { get; } = CrossGeolocator.Current;
    }
}