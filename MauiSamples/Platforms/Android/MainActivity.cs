using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Widget;
using MauiSamples.Platforms.Android.BroadcastsReceivers;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;

namespace MauiSamples
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        ConnectivityReceiver _connectivityReceiver;
        ChargingReceiver _chargingReceiver;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CrossCurrentActivity.Current.Init(this.Application);
            CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity);
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (_connectivityReceiver == null) _connectivityReceiver = new ConnectivityReceiver();
            if (_chargingReceiver == null) _chargingReceiver = new ChargingReceiver();

            RegisterReceiver(_connectivityReceiver, new IntentFilter(ConnectivityManager.ConnectivityAction));
            RegisterReceiver(_chargingReceiver, new IntentFilter(Intent.ActionPowerConnected));
            RegisterReceiver(_chargingReceiver, new IntentFilter(Intent.ActionPowerDisconnected));

            var batteryStatus = RegisterReceiver(null, new IntentFilter(Intent.ActionBatteryChanged));
            int level = batteryStatus.GetIntExtra(BatteryManager.ExtraLevel, -1);
            int scale = batteryStatus.GetIntExtra(BatteryManager.ExtraScale, -1);
            int batteryPct = (int)((level / (float)scale) * 100);
            Toast.MakeText(this, $"Battery: {batteryPct}%", ToastLength.Short).Show();
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (_connectivityReceiver != null) UnregisterReceiver(_connectivityReceiver);
            if (_chargingReceiver != null) UnregisterReceiver(_chargingReceiver);
        }
    }

}
