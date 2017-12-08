using System;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Globals
    {
        /// <summary>
        /// </summary>
        public TimeSpan AsyncTimeout { get; } = TimeSpan.FromSeconds(10);

        /// <summary>
        /// </summary>
        public readonly string ApixuKey = "7e4b1cf5c63a4a2e876183000173011";

        /// <summary>
        /// </summary>
        public readonly string GoogleKey = "AIzaSyC7BMV163HG2n8_Wo4Esn5VEjCxLkaSbmc";

        /// <summary>
        /// </summary>
        public Uri ApixuBaseUrl { get; } = new Uri("http://api.apixu.com/v1");

        /// <summary>
        /// </summary>
        public Uri GoogleBaseUrl { get; } = new Uri("https://maps.googleapis.com/maps/api");

        /// <summary>
        /// </summary>
        public DateTimeOffset CacheInvalidate { get; } = DateTimeOffset.Now.AddHours(12);
    }
}