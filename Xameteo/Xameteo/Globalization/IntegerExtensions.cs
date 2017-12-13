using Xameteo.Model;

namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class CompassConverter : AbstractConverter<int>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public CompassConverter() : base(XameteoL10N.ShortCompass)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ConditionConverter : AbstractConverter<Condition>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ConditionConverter() : base(XameteoL10N.GetCondition)
        {
        }
    }
}