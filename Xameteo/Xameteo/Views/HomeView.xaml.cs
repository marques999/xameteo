using System;

using Xameteo.API;
using Xameteo.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : IEventObject
    {
        /// <summary>
        /// </summary>
        private bool _isRefreshing;

        /// <summary>
        /// </summary>
        private Command _refreshComand;

        /// <summary>
        /// </summary>
        private readonly HomeViewModel _viewModel;

        /// <summary>
        /// </summary>
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                if (_isRefreshing == value)
                {
                    return;
                }

                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        /// <summary>
        /// </summary>
        private void InsertLocation(object sender, EventArgs eventArgs) => _viewModel.InsertLocation();

        /// <summary>
        /// </summary>
        public Command RefreshCommand => _refreshComand ?? (_refreshComand = new Command(ExecuteRefresh, () => IsRefreshing == false));

        /// <summary>
        /// </summary>
        private void ExecuteRefresh()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            RefreshCommand.ChangeCanExecute();
            Xameteo.RefreshPlaces();
            IsRefreshing = false;
            RefreshCommand.ChangeCanExecute();
        }

        /// <summary>
        /// </summary>
        public HomeView()
        {
            _viewModel = new HomeViewModel();
            BindingContext = _viewModel;
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DeleteClicked(object sender, EventArgs args)
        {
            if (sender is Button button && button.CommandParameter is ApixuPlace model)
            {
                _viewModel.RemoveItem(model);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ViewClicked(object sender, EventArgs args)
        {
            if (sender is MenuItem menuItem && menuItem.CommandParameter is ApixuPlace model)
            {
                Xameteo.Events.View(this, model);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ItemClicked(object sender, ItemTappedEventArgs args)
        {
            if (args.Item is ApixuPlace model)
            {
                Xameteo.Events.View(this, model);
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}