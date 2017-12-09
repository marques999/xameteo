using System;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public Type TargetType { get; set; } = typeof(MainViewDetail);
    }
}