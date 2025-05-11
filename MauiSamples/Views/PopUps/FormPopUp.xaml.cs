namespace MauiSamples.Views.PopUps;

public partial class FormPopUp : Popup
{
    public FormPopUp()
    {
        InitializeComponent();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(null);
    }

    private void OnSendClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            ErrorLabel.Text = "The name is required.";
            ErrorLabel.IsVisible = true;
            return;
        }

        ErrorLabel.IsVisible = false;
        Close(name);
    }
}