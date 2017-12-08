using System;
using System.Threading.Tasks;

using Acr.UserDialogs;
using Plugin.Geolocator.Abstractions;

using Xameteo.API;
using Xameteo.Model;
using Xameteo.Resx;
using Xameteo.Units;

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

        public IDisposable InsertLocation(string[] sources, Action<WeatherSource> generator)
        {
            var configuration = new ActionSheetConfig
            {
                UseBottomSheet = false,
                Cancel = _actionSheetCancel,
                Title = "Select location source"
            };

            configuration.SetCancel();
            configuration.Add("Airports", () => generator(WeatherSource.Airport));
            configuration.Add("Device", () => generator(WeatherSource.Device));
            configuration.Add("Geolocation", () => generator(WeatherSource.Geolocation));
            configuration.Add("Coordinates", () => generator(WeatherSource.Coordinates));

            return _userDialogs.ActionSheet(configuration);
        }

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
        /// <param name="promptResult"></param>
        private static void SaveGeolocation(PromptResult promptResult)
        {
            Xameteo.MyPlaces.Insert(new GeolocationAdapter(promptResult.Text));
        }

        /// <summary>
        /// </summary>
        private void LocationByGeocoding()
        {
            _userDialogs.Prompt(new PromptConfig
            {
                OkText = Resources.Button_OK,
                CancelText = Resources.Button_Cancel,
                InputType = InputType.Default,
                IsCancellable = true,
                OnAction = SaveGeolocation,
                Placeholder = "e.g. Valongo, Porto",
                Title = "Geolocation",
                Message = "Please enter your address and/or city on the input box below.",
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="position"></param>
        private static void SaveDevice(Position position)
        {
            Xameteo.MyPlaces.Insert(new CoordinatesAdapter(new Coordinates(position.Latitude, position.Longitude)));
        }

        /// <summary>
        /// </summary>
        private static async void LocationByDevice()
        {
            try
            {
                SaveDevice(await Xameteo.Geolocator.GetPositionAsync(Xameteo.Globals.AsyncTimeout));
            }
            catch (Exception exception)
            {
                await Xameteo.Dialogs.Alert(exception);
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