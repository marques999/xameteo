namespace Xameteo.Globalization
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class ShortCompassConverter : AbstractConverter<string>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public ShortCompassConverter() : base(Xameteo.Localization.ShortCompass)
        {
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class LongCompassConverter : AbstractConverter<string>
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public LongCompassConverter() : base(Xameteo.Localization.LongCompass)
        {
        }
    }
}