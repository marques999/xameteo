using System.Globalization;

using Foundation;
using Xamarin.Forms;

using Xameteo.iOS;
using Xameteo.Globalization;

[assembly: Dependency(typeof(LocaleIos))]

namespace Xameteo.iOS
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LocaleIos : ILocale
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                netLanguage = ToDotnetLanguage(NSLocale.PreferredLanguages[0]);
            }

            CultureInfo ci;

            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    ci = new CultureInfo(ToDotnetFallbackLanguage(new PlatformCulture(netLanguage)));
                }
                catch (CultureNotFoundException)
                {
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        /// <summary>
        /// </summary>
        /// <param name="systemLanguage"></param>
        /// <returns></returns>
        private static string ToDotnetLanguage(string systemLanguage)
        {
            switch (systemLanguage)
            {
            case "ms-MY":
            case "ms-SG":
                return "ms";
            case "gsw-CH":
                return "de-CH";
            default:
                return systemLanguage;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="platformCulture"></param>
        /// <returns></returns>
        private static string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
        {
            switch (platformCulture.LanguageCode)
            {
            case "pt":
                return "pt-PT";
            case "gsw":
                return "de-CH";
            default:
                return platformCulture.LanguageCode;
            }
        }
    }
}