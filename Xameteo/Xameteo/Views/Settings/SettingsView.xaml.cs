using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views.Settings
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView
    {
        /// <summary>
        /// </summary>
        public SettingsView()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void HandleClick(object sender, ItemTappedEventArgs args)
        {
            if (args.Item is SettingsModel item)
            {
                item.Handler?.Invoke(item);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}