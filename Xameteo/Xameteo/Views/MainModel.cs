using System;
using Xameteo.API;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// </summary>
        public ApixuAdapter Location { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public Type TargetType { get; set; } = typeof(MainViewDetail);
    }
}