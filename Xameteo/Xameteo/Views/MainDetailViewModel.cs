using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Acr.UserDialogs;

using Xameteo.API;
using Xameteo.Resx;
using Xameteo.Model;
using Xameteo.Helpers;

namespace Xameteo.Views
{
    /// <summary>
    /// </summary>
    internal class MainDetailViewModel : IEventObject
    {
        /// <summary>
        /// </summary>
        private readonly List<ActionSheetOption> _options = new List<ActionSheetOption>();

        /// <summary>
        /// </summary>
        public ObservableCollection<MainDetailModel> Items { get; } = new ObservableCollection<MainDetailModel>();

        /// <summary>
        /// </summary>
        public MainDetailViewModel()
        {
            _options.Add(new ActionSheetOption(Resources.Source_Device, LocationByDevice));
            _options.Add(new ActionSheetOption(Resources.Source_Airport, LocationByAirport));
            _options.Add(new ActionSheetOption(Resources.Source_Geolocation, LocationByGeocoding));
        }

        /// <summary>
        /// </summary>
        private void LocationByGeocoding() => Xameteo.Dialogs.Prompt(
            Resources.Geolocation_Title, Resources.Geolocation_Message, string.Empty, GeolocationHandler
        );

        /// <summary>
        /// </summary>
        private void LocationByAirport() => Xameteo.Dialogs.ActionSheet(Airport.Instances.Select(
            airport => new ActionSheetOption(airport.ToString(), () => SaveLocation(new AirportAdapter(airport)))
        ).ToList(), Resources.Prompt_Airport);

        /// <summary>
        /// </summary>
        public void InsertLocation() => Xameteo.Dialogs.ActionSheet(_options, Resources.Prompt_Source);

        /// <summary>
        /// </summary>
        public async void InitializeList()
        {
            foreach (var adapter in Xameteo.MyPlaces.List)
            {
                Items.Add(new MainDetailModel(await Xameteo.Api.Current(adapter), adapter));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        private async void GeolocationHandler(PromptResult result)
        {
            if (Xameteo.Dialogs.ValidatePrompt(result) == false)
            {
                return;
            }

            using (var progressDialog = Xameteo.Dialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    var response = await Xameteo.Geocoding.Get(result.Text);

                    if (response.Status != "OK")
                    {
                        throw new InvalidOperationException(string.Format(Resources.Geolocation_Error, response.Status));
                    }

                    var geocodingResults = response.Results;

                    if (geocodingResults.Count < 1)
                    {
                        throw new InvalidOperationException(Resources.Geolocation_Zero);
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
                        ).ToList(), Resources.Geolocation_Multiple);
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
                try
                {
                    progressDialog.Show();

                    if (Xameteo.MyPlaces.Insert(apixuAdapter))
                    {
                        Xameteo.Events.Insert(this, apixuAdapter);
                        Items.Add(new MainDetailModel(await Xameteo.Api.Current(apixuAdapter), apixuAdapter));
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
        /// <param name="model"></param>
        public async void RemoveItem(MainDetailModel model)
        {
            if (await Xameteo.Dialogs.PromptYesNo(Resources.Remove_Title, string.Format(Resources.Remove_Message, model.Weather.Location)))
            {
                if (Xameteo.MyPlaces.Remove(model.Adapter))
                {
                    Items.Remove(model);
                    Xameteo.Events.Remove(this, model.Adapter);
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
    }
}