using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Acr.UserDialogs;

using Xameteo.API;
using Xameteo.Model;

namespace Xameteo.Views
{
    public class MainDetailModel
    {
        public ApixuCurrent Weather
        {
            get;
        }

        public ApixuAdapter Adapter
        {
            get;

        }

        public MainDetailModel(ApixuCurrent weather, ApixuAdapter adapter)
        {
            Weather = weather;
            Adapter = adapter;
        }
    }
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewDetail
    {
        /// <summary>
        /// </summary>
        public MainViewDetail()
        {
            InitializeComponent();
            BindingContext = this;
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Device, LocationByDevice));
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Airport, LocationByAirport));
            _options.Add(new ActionSheetOption(Resx.Resources.Source_Geolocation, LocationByGeocoding));
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<MainDetailModel> Items
        {
            get;
        } = new ObservableCollection<MainDetailModel>();

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override async void OnAppearing()
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    foreach (var adapter in Xameteo.MyPlaces.List)
                    {
                        Items.Add(new MainDetailModel(await Xameteo.Api.Current(adapter), adapter));
                    }
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

        /// <summary>
        /// </summary>
        private readonly List<ActionSheetOption> _options = new List<ActionSheetOption>();

        /// <summary>
        /// </summary>
        private void InsertLocation(object sender, EventArgs args) => Xameteo.Dialogs.ActionSheet(
            _options, Resx.Resources.Source_Prompt
        );

        /// <summary>
        /// </summary>
        private void LocationByAirport() => Xameteo.Dialogs.ActionSheet(Airport.Instances.Select(
            it => new ActionSheetOption(it.ToString(), () => SaveLocation(new AirportAdapter(it)))
        ).ToList(), "Select an airport");

        /// <summary>
        /// </summary>
        private void LocationByGeocoding() => Xameteo.Dialogs.Prompt(
            Resx.Resources.Prompt_Geolocation_Title,
            Resx.Resources.Prompt_Geolocation_Message,
            string.Empty, GeolocationHandler
        );

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        private async void GeolocationHandler(PromptResult result)
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    var response = await Xameteo.Geocoding.Get(result.Text);

                    if (response.Status != "OK")
                    {
                        throw new InvalidOperationException(response.Status);
                    }

                    var geocodingResults = response.Results;

                    if (geocodingResults.Count < 1)
                    {
                        throw new InvalidOperationException("no results found!");
                    }

                    if (geocodingResults.Count == 1)
                    {
                        SaveLocation(new CoordinatesAdapter(response.Results[0].GeocodingGeometry.Location));
                    }
                    else
                    {
                        Xameteo.Dialogs.ActionSheet(geocodingResults.Select(it => new ActionSheetOption(
                            it.Address,
                            () => SaveLocation(new CoordinatesAdapter(it.GeocodingGeometry.Location)))
                        ).ToList(), "Multiple locations found");
                    }
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

        /// <summary>
        /// </summary>
        /// <param name="apixuAdapter"></param>
        private async void SaveLocation(ApixuAdapter apixuAdapter)
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    Xameteo.MyPlaces.Insert(apixuAdapter);
                    Items.Add(new MainDetailModel(await Xameteo.Api.Current(apixuAdapter), apixuAdapter));
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

        /// <summary>
        /// </summary>
        private async void LocationByDevice()
        {
            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    var position = await Xameteo.Geolocator.GetPositionAsync(Xameteo.Globals.AsyncTimeout);

                    if (position != null)
                    {
                        SaveLocation(new CoordinatesAdapter(new Coordinates(position.Latitude, position.Longitude)));
                    }
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

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void HandleClick(object sender, ItemTappedEventArgs args)
        {
            if (args.Item is MainDetailModel model)
            {
                MessagingCenter.Send<ContentPage, ApixuAdapter>(this, "view_location", model.Adapter);
            }

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void Button_OnClicked(object sender, EventArgs args)
        {
            if (sender is Button button && button.CommandParameter is MainDetailModel model)
            {
                var dialogResult = await Xameteo.Dialogs.PromptYesNo(
                    Resx.Resources.Prompt_Remove_Title,
                    string.Format(Resx.Resources.Prompt_Remove_Message, model.Weather.Location)
                );

                if (dialogResult)
                {
                    Items.Remove(model);
                    Xameteo.MyPlaces.Remove(model.Adapter);
                }
            }
        }
    }
}