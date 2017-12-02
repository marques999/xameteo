using System;
using System.Threading.Tasks;

using Acr.UserDialogs;

using Xamarin.Forms;

namespace Xameteo.Helpers
{
    /// <summary>
    /// </summary>
    internal class Dialogs
    {
        /// <summary>
        /// </summary>
        private readonly IUserDialogs _instance;

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        public Dialogs(IUserDialogs instance)
        {
            _instance = instance;
        }

        /// <summary>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public Task Alert(Page page, Exception exception) => _instance.AlertAsync(
            exception.Message,
            exception.GetType().Name
        );

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IProgressDialog InfiniteProgress => _instance.Progress(new ProgressDialogConfig
        {
            AutoShow = true, IsDeterministic = false
        });
    }
}