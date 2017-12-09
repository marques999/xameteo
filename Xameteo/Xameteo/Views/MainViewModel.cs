using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;
using Xameteo.API;
using Xameteo.Views.Location;
using Xameteo.Views.Settings;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class MainViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        public ObservableCollection<MainModel> MenuItems
        {
            get;
            set;
        } = new ObservableCollection<MainModel>();

        /// <summary>
        /// </summary>
        /// <param name="adapter"></param>
        public void InsertLocation(ApixuAdapter adapter)
        {
            MenuItems.Add(new MainModel
            {
                Location = adapter,
                Title = adapter.Parameters,
                TargetType = typeof(LocationView)
            });
        }
        
        /// <summary>
        /// </summary>
        public MainViewModel()
        {
            MenuItems.Add(new MainModel
            {
                Location = null,
                Title = "Home",
                TargetType = typeof(MainViewDetail)
            });

            MenuItems.Add(new MainModel
            {
                Location = null,
                Title = "Settings",
                TargetType = typeof(SettingsView)
            });

            Xameteo.MyPlaces.List.ForEach(InsertLocation);
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}