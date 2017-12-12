using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        /// <summary>
        /// </summary>
        public string Source { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Source == null ? null : ImageSource.FromFile(Device.RuntimePlatform == Device.iOS ? "Images/" + Source : Source);
        }
    }
}