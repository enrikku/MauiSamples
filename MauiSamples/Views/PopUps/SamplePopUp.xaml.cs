namespace MauiSamples.Views;

public partial class SamplePopUp : Popup
{
    public SamplePopUp()
    {
        InitializeComponent();
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}