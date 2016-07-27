using Android.App;
using Android.OS;
using System.Threading;
using Android.Content.PM;

namespace MortgageCalculatorApp.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(typeof(MainActivity));
            // Create your application here
        }

    }
}