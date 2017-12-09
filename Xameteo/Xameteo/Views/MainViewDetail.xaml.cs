using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xameteo.Helpers;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewDetail : IEventObject
    {
        /// <summary>
        /// </summary>
        private readonly MainDetailViewModel _viewModel;

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
        private void InsertLocation(object sender, EventArgs args) => _viewModel.InsertLocation();

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ButtonClicked(object sender, EventArgs args)
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
        private void ListItemClicked(object sender, ItemTappedEventArgs args)
        {
            if (args.Item is MainDetailModel model)
            {
                Xameteo.Events.View(this, model.Adapter);
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override async void OnAppearing()
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                try
                {
                    progressDialog.Show();
                    _viewModel.InitializeList();
                }
                catch (Exception exception)
                {
                    await Xameteo.Dialogs.Alert(exception);
                }
                finally
                {
                    progressDialog.Hide();
                }
            }
        }
    }
}