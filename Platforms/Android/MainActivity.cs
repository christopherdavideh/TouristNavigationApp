using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui.Controls.Maps;

namespace TouristNavigationApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", Label = "TouristNavigationApp", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
