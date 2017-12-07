using System;
using Humanizer;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Globals
    {
        /// <summary>
        /// </summary>
        public TimeSpan AsyncTimeout { get; } = 10.Seconds();

        /// <summary>
        /// </summary>
        public Uri BaseUrl { get; } = new Uri("http://api.apixu.com/v1");

        /// <summary>
        /// </summary>
        public DateTimeOffset CacheInvalidate { get; } = DateTimeOffset.Now.AddHours(12);
    }
}