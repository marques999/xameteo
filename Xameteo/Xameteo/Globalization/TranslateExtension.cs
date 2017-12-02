using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        /// <summary>
        /// </summary>
        public string Text { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider provider) => Text == null ? null : Xameteo.Localization.Get(Text);
    }
}