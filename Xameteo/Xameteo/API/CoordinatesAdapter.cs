namespace Xameteo.API
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class CoordinatesAdapter : PlaceAdapter
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public CoordinatesAdapter(double latitude, double longitude) : base(latitude + "," + longitude)
        {
        }
    }
}