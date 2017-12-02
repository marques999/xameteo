using System;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime date, DateTime start, DateTime end)
        {
            return start < date && date < end;
        }

        /// <summary>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool IsOutside(this DateTime date, DateTime start, DateTime end)
        {
            return start > date || date > end;
        }
    }
}