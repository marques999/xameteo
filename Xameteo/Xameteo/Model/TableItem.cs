using Xameteo.Resx;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class TableItem
    {
        /// <summary>
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public TableItem(string title, string description)
        {
            Title = title;
            Description = description.Trim().Length > 0 ? description : "N/A";
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem Precipitation(double value) => new TableItem(
            Resources.Forecast_Precipitation,
            Xameteo.Settings.Precipitation.Convert(value)
        );

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem RainProbability(double value) => new TableItem(
            Resources.Forecast_Rain,
            Xameteo.Localization.Percentage(value)
        );

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem SnowProbability(double value) => new TableItem(
            Resources.Forecast_Snow,
            Xameteo.Localization.Percentage(value)
        );

        /// <summary>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static TableItem Condition(Condition condition) => new TableItem(
            Resources.Forecast_Condition,
            Xameteo.Localization.GetCondition(condition)
        );

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem WindVelocity(double value) => new TableItem(
            Resources.Forecast_Wind_Velocity,
            Xameteo.Settings.Velocity.Convert(value)
        );

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem WindDegree(int value) => new TableItem(
            Resources.Forecast_Wind_Direction,
            Xameteo.Localization.LongCompass(value)
        );

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TableItem Visibility(double value) => new TableItem(
            Resources.Forecast_Visibility,
            Xameteo.Settings.Distance.Convert(value)
        );
    }
}