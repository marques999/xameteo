using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using Xameteo.Views.Location;
using Xameteo.Views.Settings;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// </summary>
        public MainViewModel()
        {
            var i = 0;
            var locations = Xameteo.MyPlaces.List;

            MenuItems = new ObservableCollection<MainModel>();

            for (; i < locations.Count; i++)
            {
                MenuItems.Add(new MainModel
                {
                    Id = i,
                    Title = locations[i].Parameters,
                    TargetType = typeof(LocationView)
                });
            }

            MenuItems.Add(new MainModel
            {
                Id = i++,
                Title = "Settings",
                TargetType = typeof(SettingsView)
            });

            MenuItems.Add(new MainModel
            {
                Id = i,
                Title = "Home,",
                TargetType = typeof(MainViewDetail)
            });
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<MainModel> MenuItems { get; set; }

        /// <inheritdoc />
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