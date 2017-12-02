using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xameteo.API;
using Xameteo.Model;
using Xameteo.Adapters;
using Xameteo.Globalization;
using Xameteo.Helpers;

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
            MyPlaces = new Places(Settings.Places);
            Dialogs = new Dialogs(UserDialogs.Instance);
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
        public static ApixuApi Weather(ApixuAdapter adapter) => new ApixuApi(Settings.ApiKey, adapter);
    }
}