using Android.Widget;

namespace MauiSamples.Views.Barcode;

public partial class pageReadBarcode : ContentPage
{
    public pageReadBarcode()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            zxingCamera.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
                Formats = ZXing.Net.Maui.BarcodeFormats.All,
                AutoRotate = true,
                Multiple = false,
                TryHarder = true,
                TryInverted = true
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void zxingCamera_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        try
        {
            foreach (var barcode in e.Results)
            {
                Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

                
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Toast.MakeText(Android.App.Application.Context, $"Barcodes: {barcode.Format} -> {barcode.Value}", ToastLength.Long).Show();
                });

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}