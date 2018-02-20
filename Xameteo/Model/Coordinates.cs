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
        /// <param name="coordinate"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static string StandardizeCoordinate(double coordinate, char direction)
        {
            var absolute = Math.Abs(coordinate);
            var degrees = Math.Truncate(absolute);
            var minutePart = (absolute - degrees) * 60;
            var minutes = Math.Truncate(minutePart);
            var seconds = (minutePart - minutes) * 60;
            return $@"{degrees:####}º {minutes:####}' {seconds:####}"" {direction} ({coordinate:N} {direction})";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string StandardizeLatitude()
        {
            return StandardizeCoordinate(Latitude, Latitude < 0 ? 'S' : 'N');
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string StandardizeLongitude()
        {
            return StandardizeCoordinate(Longitude, Longitude < 0 ? 'W' : 'E');
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