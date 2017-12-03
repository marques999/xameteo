using System;
using System.Threading.Tasks;

using Acr.UserDialogs;

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
            Settings = new Settings();
            Geolocator = CrossGeolocator.Current;
            Dialogs = new Dialogs(UserDialogs.Instance);
            MyPlaces = new Places(Settings.Places);
            Localization = new L10N(Settings.Locale);         
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

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public static ApixuApi Weather(PlacesAdapter adapter) => new ApixuApi(Settings.ApiKey, adapter);
    }
}