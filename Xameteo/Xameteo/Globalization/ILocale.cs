using System;
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

    /// <summary>
    /// </summary>
    public class PlatformCulture
    {
        /// <summary>
        /// </summary>
        public string LocaleCode { get; }

        /// <summary>
        /// </summary>
        public string LanguageCode { get; }

        /// <summary>
        /// </summary>
        public string PlatformString { get; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => PlatformString;

        /// <summary>
        /// </summary>
        /// <param name="platformCultureString"></param>
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                platformCultureString = "en";
            }

            PlatformString = platformCultureString.Replace("_", "-");

            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);

            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }
    }
}