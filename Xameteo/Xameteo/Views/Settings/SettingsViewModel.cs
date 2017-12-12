using System;
using System.Linq;
using System.Collections.ObjectModel;

using Acr.UserDialogs;

using Xameteo.Resx;
using Xameteo.Units;

namespace Xameteo.Views.Settings
{
    /// <summary>
    /// </summary>
    public class SettingsViewModel
    {
        /// <summary>
        /// </summary>
        public SettingsViewModel()
        {
            RefreshView();
        }

        /// <summary>
        /// </summary>
        public ObservableCollection<SettingsModel> Items
        {
            get;
        } = new ObservableCollection<SettingsModel>();

        /// <summary>
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="callback"></param>
        private void InsertUnit(Unit unit, Action<SettingsModel> callback) => Items.Add(
            new SettingsModel(string.Format(Resources.Settings_Units, unit.Type), unit.ToString(), callback)
        );

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="units"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public static IDisposable SelectUnit<T>(T[] units, Action<T> generator) where T : Unit => XameteoDialogs.ActionSheet(
            units.Select(unit => new ActionSheetOption(unit.ToString(), () => generator(unit))).ToList(),
            string.Format(Resources.Settings_Units, units[0].Type)
        );

        /// <summary>
        /// </summary>
        private void RefreshView()
        {
            Items.Add(new SettingsModel(Resources.Reset_Title, Resources.Reset_Message, ResetSettings));
            Items.Add(new SettingsModel(Resources.ApixuKey_Title, XameteoApp.Instance.ApixuKey, UpdateApixuKey));
            Items.Add(new SettingsModel(Resources.GoogleKey_Title, XameteoApp.Instance.GoogleKey, UpdateGoogleKey));
            Items.Add(new SettingsModel(Resources.ForecastDays_Title, XameteoApp.Instance.ForecastDays.ToString(), UpdateForecastDays));
            InsertUnit(XameteoApp.Instance.Distance, UpdateDistance);
            InsertUnit(XameteoApp.Instance.Precipitation, UpdatePrecipitation);
            InsertUnit(XameteoApp.Instance.Pressure, UpdatePressure);
            InsertUnit(XameteoApp.Instance.Temperature, UpdateTemperature);
            InsertUnit(XameteoApp.Instance.Velocity, UpdateVelocity);
        }

        /// <summary>
        /// </summary>
        private async void ResetSettings(SettingsModel source)
        {
            if (await XameteoDialogs.PromptYesNo(Resources.Reset_Title, Resources.Reset_Prompt) == false)
            {
                return;
            }

            Items.Clear();
            XameteoApp.Instance.ResetSettngs();
            RefreshView();
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static async void UpdateApixuKey(SettingsModel source)
        {
            var dialogResult = await XameteoDialogs.Prompt(Resources.ApixuKey_Title, Resources.ApixuKey_Message, XameteoApp.Instance.ApixuKey);

            if (dialogResult.Ok == false)
            {
                return;
            }

            var userChoice = dialogResult.Text.Trim();

            if (userChoice.Length > 0)
            {
                source.Value = userChoice;
                XameteoApp.Instance.ApixuKey = userChoice;
            }
            else if (dialogResult.Ok)
            {
                XameteoDialogs.Alert(Resources.ApixuKey_Title, Resources.Prompt_Error);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        public static async void UpdateGoogleKey(SettingsModel source)
        {
            var dialogResult = await XameteoDialogs.Prompt(Resources.GoogleKey_Title, Resources.GoogleKey_Message, XameteoApp.Instance.GoogleKey);

            if (dialogResult.Ok == false)
            {
                return;
            }

            var userChoice = dialogResult.Text.Trim();

            if (userChoice.Length > 0)
            {
                source.Value = userChoice;
                XameteoApp.Instance.GoogleKey = userChoice;
            }
            else
            {
                XameteoDialogs.Alert(Resources.GoogleKey_Title, Resources.Prompt_Error);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        public static async void UpdateForecastDays(SettingsModel source)
        {
            var dialogResult = await XameteoDialogs.PromptNumber(Resources.ForecastDays_Title, Resources.ForecastDays_Message, XameteoApp.Instance.ForecastDays);

            if (dialogResult.Ok == false)
            {
                return;
            }

            var userChoice = dialogResult.Text.Trim();

            if (userChoice.Length > 0)
            {
                try
                {
                    var numberDays = int.Parse(userChoice);

                    if (numberDays > 0 && numberDays <= 30)
                    {
                        source.Value = userChoice;
                        XameteoApp.Instance.ForecastDays = int.Parse(userChoice);
                    }
                    else
                    {
                        XameteoDialogs.Alert(Resources.ForecastDays_Title, Resources.ForecastDays_Error);
                    }
                }
                catch (Exception exception)
                {
                    XameteoDialogs.Alert(exception);
                }
            }
            else
            {
                XameteoDialogs.Alert(Resources.ForecastDays_Title, Resources.Prompt_Error);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateTemperature(SettingsModel source) => SelectUnit(Temperature.Units, result =>
        {
            source.Value = result.ToString();
            XameteoApp.Instance.Temperature = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdatePressure(SettingsModel source) => SelectUnit(Pressure.Units, result =>
        {
            source.Value = result.ToString();
            XameteoApp.Instance.Pressure = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdatePrecipitation(SettingsModel source) => SelectUnit(Precipitation.Units, result =>
        {
            source.Value = result.ToString();
            XameteoApp.Instance.Precipitation = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateDistance(SettingsModel source) => SelectUnit(Distance.Units, result =>
        {
            source.Value = result.ToString();
            XameteoApp.Instance.Distance = result;
        });

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        private static void UpdateVelocity(SettingsModel source) => SelectUnit(Velocity.Units, result =>
        {
            source.Value = result.ToString();
            XameteoApp.Instance.Velocity = result;
        });
    }
}