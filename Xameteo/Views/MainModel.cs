using System;
using Xameteo.API;
using Xamarin.Forms;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public ImageSource Icon { get; set; }

        /// <summary>
        /// </summary>
        public ApixuPlace ViewModel { get; set; }

        /// <summary>
        /// </summary>
        public Type TargetType { get; set; } = typeof(HomeView);
    }
}