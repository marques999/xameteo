using System;
using System.Threading.Tasks;

using Xameteo.API;
using Xameteo.Resx;
using Xameteo.Model;
using Xameteo.Units;
using Xameteo.Google;

using Acr.UserDialogs;

using Plugin.Geolocator.Abstractions;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Dialogs
    {
        /// <summary>
        /// </summary>
        private readonly IUserDialogs _userDialogs = UserDialogs.Instance;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _userDialogs.Progress(new ProgressDialogConfig
        {
            AutoShow = true,
            IsDeterministic = false,
            Title = Resources.Loading_Title
        });

        /// <summary>
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task Alert(Exception exception)
        {
            return _userDialogs.AlertAsync(exception.Message, exception.GetType().Name);
        }

        /// <summary>
        /// </summary>
        private readonly ActionSheetOption _actionSheetCancel = new ActionSheetOption(Resources.Button_Cancel);

        /// <summary>
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public IDisposable InsertLocation(string[] sources, Action<Source> generator)
        {
            var configuration = new ActionSheetConfig
            {
                UseBottomSheet = false,
                Cancel = _actionSheetCancel,
                Title = "Select location source"
            };

            configuration.SetCancel();
            configuration.Add("Airports", () => generator(Source.Airport));
            configuration.Add("Device", () => generator(Source.Device));
            configuration.Add("Geolocation", () => generator(Source.Geolocation));

            return _userDialogs.ActionSheet(configuration);
        }

        /// <summary>
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="placeholder"></param>
        /// <param name="callback"></param>
        private void GenericPrompt(string title, string message, string placeholder, Action<PromptResult> callback)
        {
            _userDialogs.Prompt(new PromptConfig
            {
                Title = title,
                Message = message,
                OnAction = callback,
                IsCancellable = true,
                Placeholder = placeholder,
                OkText = Resources.Button_OK,
                InputType = InputType.Default,
                CancelText = Resources.Button_Cancel
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void PromptApixuKey(Action<PromptResult> callback) => GenericPrompt(
            "Apixu API",
            "Please enter the assigned Apixu Weather API key. You can generate your by signing up for an account in the official website (https://www.apixu.com/signup.aspx)",
            string.Empty,
            callback
        );

        /// <summary>
        /// </summary>
        /// <param name="callback"></param>
        public void PromptGoogleKey(Action<PromptResult> callback) => GenericPrompt(
            "Geocoding API",
            "Please enter the assigned Google Geocoding API key. You can generate your own using the Google Developer Console (https://console.developers.google.com/apis/credentials)",
            string.Empty,
            callback
        );

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="units"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public IDisposable SelectUnit<T>(T[] units, Action<T> generator) where T : Unit
        {
            var configuration = new ActionSheetConfig
            {
                UseBottomSheet = false,
                Cancel = _actionSheetCancel,
                Title = string.Format(Resources.Dialogs_SelectUnit, units[0].Type)
            };

            configuration.SetCancel();

            foreach (var unit in units)
            {
                configuration.Add($"{unit.Name} ({unit.Symbol})", () => generator(unit));
            }

            return _userDialogs.ActionSheet(configuration);
        }

        /// <summary>
        /// </summary>
        public void InsertLocation()
        {
            var configuration = new ActionSheetConfig
            {
                UseBottomSheet = false,
                Title = "Choose location source"
            };

            configuration.SetCancel(Resources.Button_Cancel);
            configuration.Add("Device", LocationByDevice);
            configuration.Add("Airport", LocationByAirport);
            configuration.Add("Geolocation", LocationByGeocoding);
            _userDialogs.ActionSheet(configuration);
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        private async void GeolocationHandler(PromptResult result)
        {
            using (var progressDialog = InfiniteProgress)
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
                        SaveGeolocation(response.Results[0])();
                    }
                    else
                    {
                        var configuration = new ActionSheetConfig
                        {
                            UseBottomSheet = false,
                            Title = "Multiple locations found"
                        };

                        configuration.SetCancel(Resources.Button_Cancel);

                        foreach (var location in geocodingResults)
                        {
                            configuration.Add(location.Address, SaveGeolocation(location));
                        }

                        _userDialogs.ActionSheet(configuration);
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
        /// <param name="result"></param>
        private static Action SaveGeolocation(GeocodingResult result)
        {
            return () => Xameteo.MyPlaces.Insert(new CoordinatesAdapter(result.GeocodingGeometry.Location));
        }

        /// <summary>
        /// </summary>
        private void LocationByGeocoding() => GenericPrompt(
            "Geolocation",
            "Please enter your address and/or city on the input box below.",
            "e.g. Valongo, Porto",
            GeolocationHandler
        );

        /// <summary>
        /// </summary>
        /// <param name="position"></param>
        private static void SaveDevice(Position position)
        {
            Xameteo.MyPlaces.Insert(new CoordinatesAdapter(new Coordinates(position.Latitude, position.Longitude)));
        }

        /// <summary>
        /// </summary>
        private async void LocationByDevice()
        {
            using (var progressDialog = InfiniteProgress)
            {
                progressDialog.Show();

                try
                {
                    SaveDevice(await Xameteo.Geolocator.GetPositionAsync(Xameteo.Globals.AsyncTimeout));
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
        /// <param name="airport"></param>
        /// <returns></returns>
        private static Action SaveAirport(Airport airport)
        {
            return () => Xameteo.MyPlaces.Insert(new AirportAdapter(airport));
        }

        /// <summary>
        /// </summary>
        private void LocationByAirport()
        {
            var configuration = new ActionSheetConfig
            {
                UseBottomSheet = false,
                Title = "Select an airport"
            };

            configuration.SetCancel(Resources.Button_Cancel);

            foreach (var airport in Airport.Instances)
            {
                configuration.Add($"[{airport.Code}] {airport.Name}", SaveAirport(airport));
            }

            _userDialogs.ActionSheet(configuration);
        }
    }
}