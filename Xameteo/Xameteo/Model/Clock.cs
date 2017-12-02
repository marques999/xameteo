using System;
using Xameteo.Globalization;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    internal static class ClockFactory
    {
        /// <summary>
        /// </summary>
        private static readonly Clock[] Clocks =
        {
            new Clock("HH:mm", new[] { "24-hour", "24 horas" }),
            new Clock("h:mm tt", new[] { "12-hour (AM/PM)", "12 horas (AM/PM)" }),
        };

        /// <summary>
        /// </summary>
        /// <param name="clockId"></param>
        /// <returns></returns>
        public static Clock Get(int clockId) => Clocks[clockId];
    }

    /// <summary>
    /// </summary>
    internal class Clock
    {
        /// <summary>
        /// </summary>
        private readonly string _formatter;

        /// <summary>
        /// </summary>
        private readonly string[] _localizations;

        /// <summary>
        /// </summary>
        /// <param name="formatter"></param>
        /// <param name="localizations"></param>
        public Clock(string formatter, string[] localizations)
        {
            _formatter = formatter;
            _localizations = localizations;
        }

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string Format(DateTime dateTime) => dateTime.ToString(_formatter);

        /// <summary>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string Localize(Locale locale) => _localizations[(int)locale];
    }
}