using System.Globalization;

using Xamarin.Forms;
using Xameteo.Droid;
using Xameteo.Globalization;

using Locale = Java.Util.Locale;

[assembly: Dependency(typeof(LocaleAndroid))]

namespace Xameteo.Droid
{
    /// <summary>
    /// </summary>
    public class LocaleAndroid : ILocale
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Locale.Default;
            var netLanguage = ToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));

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
        /// <param name="androidLanguage"></param>
        /// <returns></returns>
        private static string ToDotnetLanguage(string androidLanguage)
        {
            switch (androidLanguage)
            {
            case "in-ID":
                return "id-ID";
            case "gsw-CH":
                return "de-CH";
            case "ms-BN": case "ms-MY": case "ms-SG":
                return "ms";
            default:
                return androidLanguage;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="platformCulture"></param>
        /// <returns></returns>
        private static string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
        {
            return platformCulture.LanguageCode == "gsw" ? "de-CH" : platformCulture.LanguageCode;
        }
    }
}