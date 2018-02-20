using Xamarin.Forms;
using System.Globalization;
using Windows.System.UserProfile;

using Xameteo.UWP;
using Xameteo.Globalization;

[assembly: Dependency(typeof(LocaleUwp))]

namespace Xameteo.UWP
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LocaleUwp : ILocale
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public CultureInfo GetCurrentCultureInfo()
        {
            return new CultureInfo(GlobalizationPreferences.Languages[0]);
        }
    }
}