using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xameteo.Views;

namespace Xameteo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();
            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            public MainPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainPageMenuItem>();

                var i = 0;
                var locations = Xameteo.MyPlaces.List;

                for (; i < locations.Count; i++)
                {
                    MenuItems.Add(new MainPageMenuItem
                    {
                        Id = i, Title = locations[i].Parameters, TargetType = typeof(PlacePage)
                    });
                }

                MenuItems.Add(new MainPageMenuItem
                {
                    Id = i++, Title = "Settings", TargetType = typeof(OptionsPage)
                });

                MenuItems.Add(new MainPageMenuItem
                {
                    Id = i, Title = "Home,", TargetType = typeof(PlacesPage)
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}