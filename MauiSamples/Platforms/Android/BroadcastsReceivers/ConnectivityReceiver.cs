using Android.Content;
using Android.Net;
using Android.Widget;
using System;

namespace MauiSamples.Platforms.Android.BroadcastsReceivers
{
    public  class ConnectivityReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var connectivityManager = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            var networkInfo = connectivityManager?.ActiveNetworkInfo;

            bool isConnected = networkInfo != null && networkInfo.IsConnected;

            Toast.MakeText(context, $"Connected: {isConnected}", ToastLength.Short).Show();
        }
    }
}
