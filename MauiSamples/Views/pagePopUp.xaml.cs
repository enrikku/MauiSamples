using MauiSamples.Views.PopUps;

namespace MauiSamples.Views;

public partial class pagePopUp : ContentPage
{
    public pagePopUp()
    {
        InitializeComponent();
    }

    private void btnPopUp1_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new SamplePopUp();
            this.ShowPopup(popup);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void btnPopUpYesNo_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new YesNoPopUp();
            var result = await this.ShowPopupAsync(popup);

            if (result is bool && (bool)result == true) btnPopUpYesNo.Text = "You clicked Yes";
            else btnPopUpYesNo.Text = "You clicked No";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void btnPopUpForm_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new FormPopUp();
            var result = await this.ShowPopupAsync(popup);

            if (result is string name)
            {
                btnPopUpForm.Text = $"¡Hi, {name}!";
            }
            else
            {
                btnPopUpForm.Text = "Canceled form";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void btnPopUpLoading_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new LoadingPopUp();
            this.ShowPopup(popup);
            await Task.Delay(3000);
            popup.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}