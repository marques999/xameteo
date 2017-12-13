using System;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    internal static class XameteoGlobals
    {
        /// <summary>
        /// </summary>
        public const string PropertyDays = "days";

        /// <summary>
        /// </summary>
        public const string PropertyPlaces = "places";

        /// <summary>
        /// </summary>
        public const string PropertyApixuKey = "apixu";

        /// <summary>
        /// </summary>
        public const string PropertyGoogleKey = "google";

        /// <summary>
        /// </summary>
        public const string ApixuKey = "7e4b1cf5c63a4a2e876183000173011";

        /// <summary>
        /// </summary>
        public const string GoogleKey = "AIzaSyC7BMV163HG2n8_Wo4Esn5VEjCxLkaSbmc";

        /// <summary>
        /// </summary>
        public static TimeSpan AsyncTimeout { get; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// </summary>
        public static Uri ApixuBaseUrl { get; } = new Uri("http://api.apixu.com/v1");

        /// <summary>
        /// </summary>
        public static Uri GoogleBaseUrl { get; } = new Uri("https://maps.googleapis.com/maps/api");
    }
}