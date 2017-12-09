using Acr.UserDialogs;

using Android.OS;
using Android.App;
using Android.Content.PM;

using Plugin.Permissions;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xameteo.Droid
{
    /// <summary>
    /// </summary>
    [Activity(Label = "Xameteo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        /// <summary>
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
            LoadApplication(new App());
        }

        /// <summary>
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}