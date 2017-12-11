using Xameteo.API;
using Xameteo.Google;
using Xameteo.Helpers;
using Xameteo.Globalization;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

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
            Apixu = new ApixuApi();
            Geocoding = new GoogleApi();
            Places = new Places(Settings.Places);
        }

        /// <summary>
        /// </summary>
        public static Places Places { get; private set; }

        /// <summary>
        /// </summary>
        public static ApixuApi Apixu { get; private set; }

        /// <summary>
        /// </summary>
        public static GoogleApi Geocoding { get; private set; }

        /// <summary>
        /// </summary>
        public static Events Events { get; } = new Events();

        /// <summary>
        /// </summary>
        public static L10N Localization { get; } = new L10N();

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
        public static IGeolocator Geolocator { get; } = CrossGeolocator.Current;
    }
}