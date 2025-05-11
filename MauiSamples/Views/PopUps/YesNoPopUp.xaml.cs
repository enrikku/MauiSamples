namespace MauiSamples.Views.PopUps;

public partial class YesNoPopUp : Popup
{
    public YesNoPopUp()
    {
        InitializeComponent();
    }

    private void btnYes_Clicked(object sender, EventArgs e)
    {
        try
        {
            Close(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void btnNo_Clicked(object sender, EventArgs e)
    { 
        try
        {
            Close(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}