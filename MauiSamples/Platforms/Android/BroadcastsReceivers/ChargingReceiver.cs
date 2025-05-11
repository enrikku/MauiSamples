using Android.App;
using Android.Content;
using Android.Widget;
using System;

namespace MauiSamples.Platforms.Android.BroadcastsReceivers
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new[] {
    Intent.ActionPowerConnected,
    Intent.ActionPowerDisconnected
})]
    public class ChargingReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            string action = intent.Action;
            if (action == Intent.ActionPowerConnected)
                Toast.MakeText(context, "Charging", ToastLength.Short).Show();
            else if (action == Intent.ActionPowerDisconnected)
                Toast.MakeText(context, "Not Charging", ToastLength.Short).Show();
        }
    }

}
