using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Xameteo.Droid
{
    /// <summary>
    /// 
    /// </summary>
    [Activity(Label = "Xameteo.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}