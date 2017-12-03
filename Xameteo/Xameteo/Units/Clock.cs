using System;
using Xameteo.Globalization;

namespace Xameteo.Units
{
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
        public int Id
        {
            get;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formatter"></param>
        /// <param name="localizations"></param>
        public Clock(int id, string formatter, string[] localizations)
        {
            Id = id;
            _formatter = formatter;
            _localizations = localizations;
        }

        /// <summary>
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string Localize(Locale locale) => _localizations[(int)locale];

        /// <summary>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string Format(DateTime dateTime) => dateTime.ToString(_formatter);
    }
}