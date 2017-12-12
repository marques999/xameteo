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
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    internal class HomeViewModel : IEventObject
    {
        /// <summary>
        /// </summary>
        public ObservableCollection<ApixuPlace> Items = XameteoApp.Instance.Places;

        /// <summary>
        /// </summary>
        private readonly List<ActionSheetOption> _options = new List<ActionSheetOption>();

        /// <summary>
        /// </summary>
        public HomeViewModel()
        {
            _options.Add(new ActionSheetOption(Resources.Source_Device, LocationByDevice));
            _options.Add(new ActionSheetOption(Resources.Source_Airport, LocationByAirport));
            _options.Add(new ActionSheetOption(Resources.Source_Geolocation, LocationByGeocoding));
        }

        /// <summary>
        /// </summary>
        private async void LocationByGeocoding()
        {
            var dialogResult = await XameteoDialogs.Prompt(Resources.Geolocation_Title, Resources.Geolocation_Message, string.Empty);

            if (XameteoDialogs.ValidatePrompt(dialogResult))
            {
                using (var progressDialog = XameteoDialogs.InfiniteProgress)
                {
                    progressDialog.Show();

                    try
                    {
                        var response = await XameteoApp.Instance.Geocoding.Get(dialogResult.Text.Trim());

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
                            XameteoDialogs.ActionSheet(geocodingResults.Select(it => new ActionSheetOption(it.Address, () => SaveLocation(new CoordinatesAdapter(it.GeocodingGeometry.Location)))).ToList(), Resources.Geolocation_Multiple);
                        }
                    }
                    catch (Exception exception)
                    {
                        XameteoDialogs.Alert(exception);
                    }
                    finally
                    {
                        progressDialog.Hide();
                    }
                }
            }
            else
            {
                XameteoDialogs.Alert(Resources.Geolocation_Title, Resources.Prompt_Error);
            }
        }

        /// <summary>
        /// </summary>
        private void LocationByAirport() => XameteoDialogs.ActionSheet(Airport.Instances.Select(
            airport => new ActionSheetOption(airport.ToString(), () => SaveLocation(new AirportAdapter(airport)))
        ).ToList(), Resources.Prompt_Airport);

        /// <summary>
        /// </summary>
        public void InsertLocation() => XameteoDialogs.ActionSheet(_options, Resources.Prompt_Source);

        /// <summary>
        /// </summary>
        /// <param name="apixuAdapter"></param>
        private async void SaveLocation(ApixuAdapter apixuAdapter)
        {
            using (var progressDialog = XameteoDialogs.InfiniteProgress)
            {
                try
                {
                    progressDialog.Show();

                    var viewModel = await XameteoApp.Instance.InsertPlace(apixuAdapter);

                    if (viewModel != null)
                    {
                        XameteoApp.Events.Insert(this, viewModel);
                    }
                }
                catch (Exception exception)
                {
                    XameteoDialogs.Alert(exception);
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
        public async void RemoveItem(ApixuPlace model)
        {
            if (await XameteoDialogs.PromptYesNo(Resources.Remove_Title, string.Format(Resources.Remove_Message, model.Forecast.Location)))
            {
                if (XameteoApp.Instance.Places.Remove(model))
                {
                    XameteoApp.Events.Remove(this, model.Adapter);
                }
            }
        }

        /// <summary>
        /// </summary>
        private async void LocationByDevice()
        {
            using (var progressDialog = XameteoDialogs.InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    SaveLocation(new CoordinatesAdapter(new Coordinates(await XameteoApp.Instance.Geolocator.GetPositionAsync(XameteoGlobals.AsyncTimeout))));
                }
                catch (Exception exception)
                {
                    XameteoDialogs.Alert(exception);
                }
                finally
                {
                    progressDialog.Hide();
                }
            }
        }
    }
}