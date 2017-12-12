using Xameteo.Resx;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Xameteo.Model
{
    /// <summary>
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// </summary>
        [JsonProperty("code")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("text")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="isDay"></param>
        /// <returns></returns>
        public ImageSource Image(bool isDay) => Xameteo.Localization.GetDrawable(
            isDay ? $"day_{Id}.png" : $"night_{Id}.png"
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableItem GenerateTable() => new TableItem(
            Resources.Forecast_Condition, Xameteo.Localization.GetCondition(this)
        );
    }
}