using System;
using System.Threading.Tasks;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xameteo.API;
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
            Dialogs = new Dialogs();
            Settings = new Settings();
            Geolocator = CrossGeolocator.Current;
            Api = new ApixuApi(Settings.ApiKey);
            MyPlaces = new Places(Settings.Places);
            MyPlaces.Insert(new AirportAdapter("OPO"));
            MyPlaces.Insert(new CoordinatesAdapter(35.6732619, 139.5703036));
            MyPlaces.Insert(new LocationAdapter("Valongo, Porto"));
            Localization = new L10N(Settings.Locale);
        }

        /// <summary>
        /// </summary>
        public static ApixuApi Api
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static Places MyPlaces
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static Dialogs Dialogs
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static L10N Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static Settings Settings
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static IGeolocator Geolocator
        {
            get;
            private set;
        }

        /// <summary>
        /// </summary>
        public static Task<Position> MyLocation => Geolocator.GetPositionAsync(TimeSpan.FromSeconds(5));
    }
}