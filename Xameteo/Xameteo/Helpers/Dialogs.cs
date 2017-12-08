using System;
using System.Threading.Tasks;

using Acr.UserDialogs;

using Xamarin.Forms;
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
        private readonly IUserDialogs _instance = UserDialogs.Instance;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _instance.Progress(new ProgressDialogConfig
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
            return _instance.AlertAsync(exception.Message, exception.GetType().Name);
        }

        /// <summary>
        /// </summary>
        private readonly ActionSheetOption _actionSheetCancel = new ActionSheetOption(Resources.Button_Cancel);

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

            return _instance.ActionSheet(configuration);
        }
    }
}