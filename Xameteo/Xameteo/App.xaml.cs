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

        /// <summary>
        /// </summary>
        protected override void OnStart()
        {
            
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