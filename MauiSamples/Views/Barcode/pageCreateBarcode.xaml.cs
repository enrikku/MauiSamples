using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MauiSamples.Views.Barcode;

public partial class pageCreateBarcode : ContentPage
{
    private string value = "";
    private string format = "";

    public pageCreateBarcode()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        pickerFormat.ItemsSource = BarcodeFormats.SupportedFormats;
    }

    private void buttonGenerate_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.entryValue.Text) || string.IsNullOrEmpty(this.pickerFormat.SelectedItem.ToString()) || this.pickerFormat.SelectedItem == null) return;

            string entryValue = this.entryValue.Text;
            string selectedFormat = pickerFormat.SelectedItem.ToString();

            BarcodeFormat selectedFormat2 = (BarcodeFormat)Enum.Parse(typeof(BarcodeFormat), selectedFormat);

            barcodeGeneratorView.Value = null; // reset
            barcodeGeneratorView.Format = selectedFormat2;
            barcodeGeneratorView.Value = entryValue;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}