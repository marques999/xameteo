﻿using System.Threading.Tasks;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using Xameteo.API;
using Xameteo.Helpers;
using Xameteo.Globalization;
using Xameteo.Model;

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
            Localization = new L10N();
            Dialogs = new Dialogs();
            Settings = new Settings();
            Geolocator = CrossGeolocator.Current;
            Api = new ApixuApi(Settings.ApiKey);
            MyPlaces = new Places(Settings.Places);
            MyPlaces.Insert(new AirportAdapter(Airport.Airports[5]));
            MyPlaces.Insert(new LocationAdapter("Valongo, Porto"));
            MyPlaces.Insert(new CoordinatesAdapter(new Coordinates(35.6732619, 139.5703036)));
        }

        /// <summary>
        /// </summary>
        public static ApixuApi Api { get; private set; }

        /// <summary>
        /// </summary>
        public static Places MyPlaces { get; private set; }

        /// <summary>
        /// </summary>
        public static Dialogs Dialogs { get; private set; }

        /// <summary>
        /// </summary>
        public static L10N Localization { get; private set; }

        /// <summary>
        /// </summary>
        public static Settings Settings { get; private set; }

        /// <summary>
        /// </summary>
        public static Globals Globals { get; } = new Globals();

        /// <summary>
        /// </summary>
        public static IGeolocator Geolocator { get; private set; }

        /// <summary>
        /// </summary>
        public static Task<Position> MyLocation => Geolocator.GetPositionAsync(Globals.AsyncTimeout);
    }
}