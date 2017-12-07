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
            Xameteo.Initialize();
            InitializeComponent();
            MainPage = new MainPage();
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