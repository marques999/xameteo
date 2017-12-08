using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xameteo.Views;

namespace Xameteo
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster
    {
        /// <summary>
        /// </summary>
        public ListView ListView;

        /// <summary>
        /// </summary>
        public MainPageMaster()
        {
            InitializeComponent();
            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        private class MainPageMasterViewModel : INotifyPropertyChanged
        {
            /// <summary>
            /// </summary>
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            /// <summary>
            /// </summary>
            public MainPageMasterViewModel()
            {
                var i = 0;
                var locations = Xameteo.MyPlaces.List;

                MenuItems = new ObservableCollection<MainPageMenuItem>();

                for (; i < locations.Count; i++)
                {
                    MenuItems.Add(new MainPageMenuItem
                    {
                        Id = i,
                        Title = locations[i].Parameters,
                        TargetType = typeof(LocationTabsPage)
                    });
                }

                MenuItems.Add(new MainPageMenuItem
                {
                    Id = i++,
                    Title = "Settings",
                    TargetType = typeof(OptionsPage)
                });

                MenuItems.Add(new MainPageMenuItem
                {
                    Id = i,
                    Title = "Home,",
                    TargetType = typeof(MainPageDetail)
                });
            }

            /// <summary>
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// </summary>
            /// <param name="propertyName"></param>
            public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}