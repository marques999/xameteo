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
        private readonly MainViewModel _viewModel = new MainViewModel();

        /// <summary>
        /// </summary>
        public MainViewMaster()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            ListView = MenuItemsListView;
            XameteoApp.Instance.Events.SubscribeView((source, args) => ListView.SelectedItem = _viewModel.FindModel(args));
            XameteoApp.Instance.Events.SubscribeRefresh((source, args) => ListView.SelectedItem = _viewModel.RefreshView(args));
        }
    }
}