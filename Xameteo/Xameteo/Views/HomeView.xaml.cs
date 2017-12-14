using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Acr.UserDialogs;

using Xameteo.API;
using Xameteo.Model;

namespace Xameteo.Views
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView
    {
        /// <summary>
        /// </summary>
        public HomeView()
        {
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Device, LocationByDevice));
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Airport, LocationByAirport));
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Geolocation, LocationByGeocoding));
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void DeleteClicked(object sender, EventArgs args)
        {
            if (sender is MenuItem menuItem && menuItem.CommandParameter is ApixuPlace model)
            {
                if (await XameteoDialogs.PromptYesNo(Resx.Resources.Remove_Title, string.Format(Resx.Resources.Remove_Message, model.Forecast.Location)))
                {
                    XameteoApp.Instance.RemovePlace(model);
                }
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
                XameteoApp.Instance.Events.View(model);
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
                XameteoApp.Instance.Events.View(model);
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// </summary>
        private Command _refreshComand;

        /// <summary>
        /// </summary>
        public ObservableCollection<ApixuPlace> Items => XameteoApp.Instance.Places;

        /// <summary>
        /// </summary>
        private readonly List<ActionSheetOption> _options = new List<ActionSheetOption>();

        /// <summary>
        /// </summary>
        public Command RefreshCommand => _refreshComand ?? (_refreshComand = new Command(async () =>
        {
            IsBusy = true;
            await XameteoApp.Instance.RefreshPlaces(0);
            IsBusy = false;
        }));

        /// <summary>
        /// </summary>
        private static async void LocationByGeocoding()
        {
            var dialogResult = await XameteoDialogs.Prompt(Resx.Resources.Geolocation_Title, Resx.Resources.Geolocation_Message, string.Empty);

            if (dialogResult.Ok == false)
            {
                return;
            }

            var userChoice = dialogResult.Text.Trim();

            if (userChoice.Length > 0)
            {
                XameteoDialogs.ShowLoading();

                try
                {
                    var googleResponse = await XameteoApp.Instance.Geocoding.Get(userChoice);

                    if (googleResponse.Status != "OK")
                    {
                        throw new InvalidOperationException(string.Format(Resx.Resources.Geolocation_Error, googleResponse.Status));
                    }

                    var geocodingResults = googleResponse.Results;

                    if (geocodingResults.Count < 1)
                    {
                        throw new InvalidOperationException(Resx.Resources.Geolocation_Zero);
                    }

                    if (geocodingResults.Count == 1)
                    {
                        SaveLocation(new CoordinatesAdapter(googleResponse.Results[0].GeocodingGeometry.Location));
                    }
                    else
                    {
                        XameteoDialogs.ActionSheet(
                            geocodingResults.Select(it => new ActionSheetOption(it.Address, () => SaveLocation(new CoordinatesAdapter(it.GeocodingGeometry.Location)))).ToList(),
                            Resx.Resources.Geolocation_Multiple
                        );
                    }
                }
                catch (Exception exception)
                {
                    XameteoDialogs.Alert(exception);
                }
                finally
                {
                    XameteoDialogs.HideLoading();
                }
            }
            else
            {
                XameteoDialogs.Alert(Resx.Resources.Geolocation_Title, Resx.Resources.Prompt_Error);
            }
        }

        /// <summary>
        /// </summary>
        public void InsertClicked(object sender, EventArgs ags)
        {
            XameteoDialogs.ActionSheet(_options, Resx.Resources.Prompt_Source);
        }

        /// <summary>
        /// </summary>
        private static void LocationByAirport() => XameteoDialogs.ActionSheet(Airport.Instances.Select(
            airport => new ActionSheetOption(airport.ToString(), () => SaveLocation(new AirportAdapter(airport)))
        ).ToList(), Resx.Resources.Prompt_Airport);

        /// <summary>
        /// </summary>
        /// <param name="apixuAdapter"></param>
        private static async void SaveLocation(ApixuAdapter apixuAdapter)
        {
            try
            {
                XameteoDialogs.ShowLoading();

                if (await XameteoApp.Instance.InsertPlace(apixuAdapter) == false)
                {
                    XameteoDialogs.Alert(Resx.Resources.Exists_Title, Resx.Resources.Exists_Message);
                }
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
            finally
            {
                XameteoDialogs.HideLoading();
            }
        }

        /// <summary>
        /// </summary>
        private static async void LocationByDevice()
        {
            try
            {
                XameteoDialogs.ShowLoading();
                SaveLocation(new CoordinatesAdapter(await XameteoApp.Instance.DeviceLocation()));
            }
            catch (Exception exception)
            {
                XameteoDialogs.Alert(exception);
            }
            finally
            {
                XameteoDialogs.HideLoading();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void RefreshClicked(object sender, EventArgs args)
        {
            XameteoDialogs.ShowLoading();
            await XameteoApp.Instance.RefreshPlaces(0);
            XameteoDialogs.HideLoading();
        }
    }
}