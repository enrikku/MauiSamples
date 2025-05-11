using MauiSamples.Views.Barcode;
using Org.Apache.Http.Cookie.Params;
using System.Data.Common;

namespace MauiSamples;

public partial class pageBarcode : ContentPage
{
    public pageBarcode()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BarcodeFormatsList.ItemsSource = BarcodeFormats.SupportedFormats;
    }

    private async void btnRead_Clicked(object sender, EventArgs e)
    {
        try
        {
            PermissionStatus cameraPermission = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (cameraPermission != PermissionStatus.Granted)
            {
                cameraPermission = await Permissions.RequestAsync<Permissions.Camera>();

                if (cameraPermission != PermissionStatus.Granted)
                {
                    await DisplayAlert("Alert", "Camera permission not granted", "OK");
                    return;
                }
            }

            Navigation.PushModalAsync(new pageReadBarcode());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushModalAsync(new pageCreateBarcode());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}