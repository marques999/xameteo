﻿using System;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Hour
    {
        /// <summary>
        /// Cloud cover as percentage
        /// </summary>
        [JsonProperty("cloud")]
        public int Cloud { get; set; }

        /// <summary>
        /// Weather condition information
        /// </summary>
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Feels like temperature in celcius
        /// </summary>
        [JsonProperty("feelslike_c")]
        public double FeelsLike { get; set; }

        /// <summary>
        /// Humidity as percentage
        /// </summary>
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// Whether to show day condition icon or night icon
        /// </summary>
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }

        /// <summary>
        /// Precipitation amount in millimeters
        /// </summary>
        [JsonProperty("precip_mm")]
        public double Precipitation { get; set; }

        /// <summary>
        /// Atmospheric pressure in millibars
        /// </summary>
        [JsonProperty("pressure_mb")]
        public double Pressure { get; set; }

        /// <summary>
        /// Temperature in celsius
        /// </summary>
        [JsonProperty("temp_c")]
        public double Temperature { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("vis_km")]
        public double Visibility { get; set; }

        /// <summary>
        /// Wind direction in degrees
        /// </summary>
        [JsonProperty("wind_degree")]
        public int WindDegree { get; set; }

        /// <summary>
        /// Wind speed in kilometer per hour
        /// </summary>
        [JsonProperty("wind_kph")]
        public double WindVelocity { get; set; }

        /// <summary>
        /// Wind direction as sixteen point compass
        /// </summary>
        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("time")]
        public DateTime Date { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("will_it_rain")]
        public bool Rain { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("will_it_snow")]
        public bool Snow { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("windchill_c")]
        public double Windchill { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("heatindex_c")]
        public double HeatIndex { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("dewpoint_c")]
        public double DewPoint { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("chance_of_rain")]
        public double RainProbability { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("chance_of_snow")]
        public double SnowProbability { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"
  Temperature = {Temperature}
  IsDay = {IsDay}
  Condition = {Condition}
  WindVelocity = {WindVelocity}
  WindDegree = {WindDegree}
  WindDirection = {WindDirection}
  Pressure = {Pressure}
  Precipitation = {Precipitation}
  Humidity = {Humidity}
  Cloud = {Cloud}
  FeelsLike = {FeelsLike}
  Windchill = {Windchill}
  HeatIndex = {HeatIndex}
  DewPoint = {DewPoint}
  Rain = {Rain}
  RainProbability = {RainProbability}
  Snow = {Snow}
  SnowProbability = {SnowProbability}
  Visibility = {Visibility}
";
    }
}