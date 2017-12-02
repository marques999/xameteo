using System;

namespace Xameteo
{
    /// <summary>
    /// </summary>
    public class MainPageMenuItem
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// </summary>
        public MainPageMenuItem()
        {
            TargetType = typeof(MainPageDetail);
        }
    }
}