using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xameteo.API;

namespace Xameteo
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail
    {
        /// <summary>
        /// </summary>
        public MainPageDetail()
        {
            InitializeComponent();
            MyListView.ItemsSource = Items;
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<ApixuCurrent> Items
        {
            get;
        } = new ObservableCollection<ApixuCurrent>();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override async void OnAppearing()
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();
                (await Task.WhenAll(Xameteo.MyPlaces.Current())).ForEach(it => Items.Add(it));
                progressDialog.Hide();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ApixuCurrent weather)
            {
                await DisplayAlert("Item Tapped", weather.Current.ToString(), "OK");
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}