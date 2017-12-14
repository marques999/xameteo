using System;
using System.Globalization;

using Xamarin.Forms.Xaml;

using Xameteo.API;
using Xameteo.Globalization;

namespace Xameteo.Views.Location
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage
    {
        /// <summary>
        /// </summary>
        private readonly ApixuAdapter _adapter;

        /// <summary>
        /// </summary>
        private DateTime _selected = DateTime.MinValue;

        /// <summary>
        /// </summary>
        public string Selected => _selected == DateTime.MinValue ? Resx.Resources.History_Prompt : XameteoL10N.LongDate(_selected);

        /// <summary>
        /// </summary>
        public HistoryPage(ApixuAdapter apixuAdapter)
        {
            _adapter = apixuAdapter;
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void SelectClicked(object sender, EventArgs args)
        {
            try
            {
                var dateTime = DateTime.Now;
                var dialogResult = await XameteoDialogs.DatePicker(dateTime.AddDays(-30), dateTime.AddDays(-1));

                if (dialogResult.Ok == false)
                {
                    return;
                }

                XameteoDialogs.ShowLoading();
                _selected = dialogResult.SelectedDate;
                OnPropertyChanged(nameof(Selected));

                var parsed = _selected.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                var history = (await XameteoApp.Instance.Apixu.History(_adapter, parsed)).Forecast.Days;

                if (history.Count > 0)
                {
                    HistoryView.Content = new HistoryView(history[0]);
                }

                XameteoDialogs.HideLoading();
            }
            catch (Exception exception)
            {
                XameteoDialogs.HideLoading();
                XameteoDialogs.Alert(exception);
            }
        }
    }
}