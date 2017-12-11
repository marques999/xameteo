using System;
using System.Diagnostics;

using Xameteo.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewDetail : IEventObject
    {
        /// <summary>
        /// </summary>
        private bool _isRefreshing;

        /// <summary>
        /// </summary>
        private Command _refreshComand;

        /// <summary>
        /// </summary>
        private readonly MainDetailViewModel _viewModel;

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
        private async void ExecuteRefresh()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            RefreshCommand.ChangeCanExecute();
            await _viewModel.InitializeList();
            IsRefreshing = false;
            RefreshCommand.ChangeCanExecute();
        }

        /// <summary>
        /// </summary>
        public MainViewDetail()
        {
            _viewModel = new MainDetailViewModel();
            BindingContext = _viewModel;
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void DeleteClicked(object sender, EventArgs args)
        {
            if (sender is Button button && button.CommandParameter is MainDetailModel model)
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
            if (sender is MenuItem menuItem && menuItem.CommandParameter is MainDetailModel model)
            {
                Xameteo.Events.View(this, model.Adapter);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ItemClicked(object sender, ItemTappedEventArgs args)
        {
            if (args.Item is MainDetailModel model)
            {
                Debug.WriteLine(model.Adapter.Parameters);
                Xameteo.Events.View(this, model.Adapter);
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override async void OnAppearing()
        {
            try
            {
                await _viewModel.InitializeList();
            }
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
            }
        }
    }
}