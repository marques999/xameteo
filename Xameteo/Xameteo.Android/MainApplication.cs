using System;

using Android.OS;
using Android.App;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace Xameteo.Droid
{
    /// <summary>
    /// </summary>
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        /// <summary>
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="transer"></param>
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="savedInstanceState"></param>
        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        public void OnActivityDestroyed(Activity activity)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        public void OnActivityPaused(Activity activity)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="outState"></param>
        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        /// <summary>
        /// </summary>
        /// <param name="activity"></param>
        public void OnActivityStopped(Activity activity)
        {
        }
    }
}