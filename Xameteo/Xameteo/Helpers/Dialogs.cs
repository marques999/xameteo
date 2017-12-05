using System;
using System.Threading.Tasks;

using Acr.UserDialogs;

using Xamarin.Forms;
using Xameteo.Units;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    /// <param name="choice"></param>
    /// <returns></returns>
    public delegate void SelectUnitCallback<in T>(T choice) where T : Unit;

    /// <summary>
    /// </summary>
    internal class Dialogs
    {
        /// <summary>
        /// </summary>
        private readonly IUserDialogs _instance = UserDialogs.Instance;

        /// <summary>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task Alert(Page page, Exception exception)
        {
            return _instance.AlertAsync(exception.Message, exception.GetType().Name);
        }

        /// <summary>
        /// </summary>
        /// <param name="decorator"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        public IDisposable SelectUnit<T>(string type, T[] units, SelectUnitCallback<T> generator) where T : Unit
        {
            var locale = Xameteo.Settings.Locale;
            var configuration = new ActionSheetConfig();

            foreach (var unit in units)
            {
                configuration.Add($"{unit.Name} ({unit.Symbol})", () => generator(unit));
            }

            configuration.Title = $"Select {type} units";
            configuration.SetCancel();
            configuration.UseBottomSheet = false;

            return _instance.ActionSheet(configuration);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _instance.Progress(new ProgressDialogConfig
        {
            AutoShow = true,
            IsDeterministic = false
        });
    }
}