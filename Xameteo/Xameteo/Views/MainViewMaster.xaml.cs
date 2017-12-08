using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMaster
    {
        /// <summary>
        /// </summary>
        public ListView ListView;

        /// <summary>
        /// </summary>
        public MainViewMaster()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            ListView = MenuItemsListView;
        }
    }
}