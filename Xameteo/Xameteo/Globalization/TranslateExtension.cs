using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Condition = Xameteo.Model.Condition;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ConditionConverter : AbstractConverter<Condition>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ConditionConverter() : base(Xameteo.Localization.GetCondition)
        {
        }
    }

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