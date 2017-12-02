using System;
using System.Collections.Generic;

using Xameteo.Constants;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal static class Units
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private delegate double FormulaDelegate(double value);

        /// <summary>
        /// </summary>
        private static readonly Dictionary<Temperature, FormulaDelegate> TemperatureTable = new Dictionary<Temperature, FormulaDelegate>
        {
            {
                Temperature.Kelvin, value => value + 273.15
            },
            {
                Temperature.Fahrenheit, value => 32 + 1.8 * value
            }
        };

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Convert(Temperature units, double value) => TemperatureTable.TryGetValue(units, out var delegateFunction) ? delegateFunction(value) : value;

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(Temperature units, double value) => $"{Convert(units, value):0.###} {Xameteo.Localization.GetUni(units)}";

        /// <summary>
        /// </summary>
        private static readonly Dictionary<Distance, FormulaDelegate> DistanceTable = new Dictionary<Distance, FormulaDelegate>
        {
            {
                Distance.Meters, value => value * 1000
            },
            {
                Distance.Inches, value => value * 39370
            },
            {
                Distance.Miles, value => value * 0.62137
            }
        };

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Convert(Distance units, double value) => DistanceTable.TryGetValue(units, out var delegateFunction) ? delegateFunction(value) : value;

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(Distance units, double value) => $"{Convert(units, value):0.###} {Xameteo.Localization.GetUni(units)}";

        /// <summary>
        /// 
        /// </summary>
        private static readonly Dictionary<Pressure, FormulaDelegate> PressureTable = new Dictionary<Pressure, FormulaDelegate>
        {
            {
                Pressure.KPa, value => value * 0.1
            },
            {
                Pressure.Psi, value => value * 0.014503773773022
            },
            {
                Pressure.Torr, value => value * 0.75006375541921
            },
            {
                Pressure.Atmosphere, value => value * 0.00098692326671601
            },
        };

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Convert(Pressure units, double value) => PressureTable.TryGetValue(units, out var delegateFunction) ? delegateFunction(value) : value;

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(Pressure units, double value) => $"{Convert(units, value):0.###} {Xameteo.Localization.GetUni(units)}";

        /// <summary>
        /// </summary>
        private static readonly Dictionary<Velocity, FormulaDelegate> VelocityTable = new Dictionary<Velocity, FormulaDelegate>
        {
            {
                Velocity.Knots, value => value * 0.53996
            },
            {
                Velocity.MilesPerHour, value => value * 0.621388
            },
            {
                Velocity.MetersPerSecond, value => value * 0.277777
            }
        };

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Convert(Velocity units, double value) => VelocityTable.TryGetValue(units, out var delegateFunction) ? delegateFunction(value) : value;

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(Velocity units, double value) => $"{Convert(units, value):0.###} {Xameteo.Localization.GetUni(units)}";

        /// <summary>
        /// </summary>
        private static readonly Dictionary<Precipitation, FormulaDelegate> PrecipitationTable = new Dictionary<Precipitation, FormulaDelegate>
        {
            {
                Precipitation.Centimeters, value => value * 0.1
            },
            {
                Precipitation.Inches, value => value * 0.039370
            }
        };

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Convert(Precipitation units, double value) => PrecipitationTable.TryGetValue(units, out var delegateFunction) ? delegateFunction(value) : value;

        /// <summary>
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(Precipitation units, double value) => $"{Convert(units, value):0.###} {Xameteo.Localization.GetUni(units)}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="units"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Convert(Clock units, DateTime value) => value.ToString(units == Clock.Twelve ? "h:mm tt" : "HH:mm");
    }
}