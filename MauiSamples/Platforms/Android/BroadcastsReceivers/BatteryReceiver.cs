using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace MauiSamples.Platforms.Android.BroadcastsReceivers
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new[] { Intent.ActionBatteryChanged })]
    public class BatteryReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            int level = intent.GetIntExtra(BatteryManager.ExtraLevel, -1);
            int scale = intent.GetIntExtra(BatteryManager.ExtraScale, -1);
            int batteryPct = (int)((level / (float)scale) * 100);

            Toast.MakeText(context, $"Battery: {batteryPct}%", ToastLength.Short).Show();
        }
    }
}
