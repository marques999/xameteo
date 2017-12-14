using Xameteo.Resx;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xameteo.Globalization;

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
        public ImageSource ImageResource(bool isDay) => ImageSource.FromResource(Image(isDay));

        /// <summary>
        /// </summary>
        /// <param name="isDay"></param>
        /// <returns></returns>
        public string Image(bool isDay) => XameteoL10N.GetDrawable(isDay ? $"day_{Id}.png" : $"night_{Id}.png");

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public TableItem GenerateTable() => new TableItem(Resources.Forecast_Condition, XameteoL10N.GetCondition(this));
    }
}