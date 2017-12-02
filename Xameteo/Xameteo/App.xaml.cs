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
            MainPage = new MainPage();
        }

        /// <summary>
        /// </summary>
        protected override void OnStart()
        {
            Xameteo.Initialize();
        }

        /// <summary>
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}