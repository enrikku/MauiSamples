using MauiSamples.Platforms.Android;

namespace MauiSamples.Views;

public partial class pageSpeechToText : ContentPage
{
    private SpeechRecognizerHelper _speechHelper;

    public pageSpeechToText()
    {
        InitializeComponent();
    }

    private void btnSpeech_Clicked(object sender, EventArgs e)
    {
        try
        {
            _speechHelper = new SpeechRecognizerHelper(OnSpeechResult);
            _speechHelper.StartListening();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void OnSpeechResult(string result)
    {
        Dispatcher.Dispatch(() =>
        {
            lblText.Text = result; // o añadir a tu ToDo
        });
    }
}