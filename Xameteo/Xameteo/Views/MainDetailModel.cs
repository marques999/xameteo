using Xameteo.API;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    public class MainDetailModel
    {
        /// <summary>
        /// </summary>
        public ApixuAdapter Adapter { get; }

        /// <summary>
        /// </summary>
        public ApixuCurrent Weather { get; }

        /// <summary>
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="adapter"></param>
        public MainDetailModel(ApixuCurrent weather, ApixuAdapter adapter)
        {
            Adapter = adapter;
            Weather = weather;
        }
    }
}