using System.Reflection;
using System.Runtime.InteropServices;

using Android.App;

[assembly: ComVisible(false)]
[assembly: AssemblyCulture("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCompany("FEUP")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyTitle("Xameteo.Android")]
[assembly: AssemblyProduct("Xameteo.Android")]
[assembly: AssemblyDescription("Xameteo.Android")]

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

[assembly: UsesFeature("android.hardware.location", Required = false)]
[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
[assembly: UsesFeature("android.hardware.location.network", Required = false)]