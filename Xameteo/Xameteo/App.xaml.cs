using Xameteo.Views;

namespace Xameteo
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// </summary>
        public App()
        {
            InitializeComponent();
            Xameteo.Initialize();
            MainPage = new MainView();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}