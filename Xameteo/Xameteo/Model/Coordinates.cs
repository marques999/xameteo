using Newtonsoft.Json;

using System;
using System.Globalization;

using Plugin.Geolocator.Abstractions;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; }

        /// <summary>
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; }

        /// <summary>
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        [JsonConstructor]
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// </summary>
        /// <param name="geolocator"></param>
        public Coordinates(Position geolocator)
        {
            Latitude = geolocator.Latitude;
            Longitude = geolocator.Longitude;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string StandardizeLatitude()
        {
            var absolute = Math.Abs(Latitude);
            var direction = Latitude < 0 ? "S" : "N";
            var degrees = Math.Truncate(absolute);
            var minutePart = (absolute - degrees) * 60;
            var minutes = Math.Truncate(minutePart);
            var seconds = (minutePart - minutes) * 60;
            return $@"{degrees:N2}º {minutes:N2}' {seconds:N2}"" {direction}";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string StandardizeLongitude()
        {
            var absolute = Math.Abs(Longitude);
            var direction = Longitude < 0 ? "W" : "E";
            var degrees = Math.Truncate(absolute);
            var minutePart = (absolute - degrees) * 60;
            var minutes = Math.Truncate(minutePart);
            var seconds = (minutePart - minutes) * 60;
            return $@"{degrees:N2}º {minutes:N2}' {seconds:N2}"" {direction}";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Latitude.ToString(CultureInfo.InvariantCulture) + "," + Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}