using System.Resources;
using System.Reflection;
using System.Globalization;

using Xamarin.Forms;

namespace Xameteo.Globalization
{
    /// <summary>
    /// </summary>
    internal class L10N
    {
        /// <summary>
        /// 
        /// </summary>
        private const string ResourceId = "Xameteo.Resx.Application";

        /// <summary>
        /// </summary>
        private readonly CultureInfo _cultureInfo = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

        /// <summary>
        /// </summary>
        private readonly ResourceManager _resourceManager = new ResourceManager(ResourceId, typeof(L10N).GetTypeInfo().Assembly);

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _resourceManager.GetString(key, _cultureInfo) ?? key;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetOrDefault(string key, string defaultValue)
        {
            return _resourceManager.GetString(key, _cultureInfo) ?? defaultValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string GetCondition(int condition)
        {
            return _resourceManager.GetString("CONDITION_" + condition, _cultureInfo) ?? condition.ToString();
        }
    }
}