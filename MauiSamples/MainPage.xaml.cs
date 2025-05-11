using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using Android.Content;

namespace MauiSamples
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPopUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new pagePopUp());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnBarcodeScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new pageBarcode());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnToDo_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new pageToDo());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void btnFingerPrint_Clicked(object sender, EventArgs e)
        {
            try
            {
                var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();

                if (!isAvailable)
                {
                    await DisplayAlert("Biometric not available", "Please set up a fingerprint in your device settings.", "OK");

                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.P)
                    {
                        var intent = new Intent(Android.Provider.Settings.ActionFingerprintEnroll);
                        intent.SetFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                    else
                    {
                        var intent = new Intent(Android.Provider.Settings.ActionSecuritySettings);
                        intent.SetFlags(ActivityFlags.NewTask);
                        Android.App.Application.Context.StartActivity(intent);
                    }
                }

                var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
                var result = await CrossFingerprint.Current.AuthenticateAsync(request);
                if (result.Authenticated)
                {
                    // Code
                }
                else
                {
                    // Code
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void btnSpeechToText_Clicked(object sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.RequestAsync<Permissions.Microphone>();

                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Alert", "Microphone permission not granted", "OK");
                    return;
                }


                Navigation.PushModalAsync(new pageSpeechToText());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}