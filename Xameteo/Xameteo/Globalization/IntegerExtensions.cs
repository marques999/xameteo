using Xameteo.Model;

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
        public ConditionConverter() : base(XameteoL10N.GetCondition)
        {
        }
    }
}