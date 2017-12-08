using System.Globalization;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    public interface ILocale
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        CultureInfo GetCurrentCultureInfo();
    }
}