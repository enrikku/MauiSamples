using MauiSamples.Views.ToDo.Models;

namespace MauiSamples.Views.ToDo.PopUps;

public partial class PopUpToDoItem : Popup
{
    private ToDoItem _item;

    public PopUpToDoItem(ToDoItem item = null)
    {
        InitializeComponent();

        if (item != null)
        {
            entryToDoName.Text = item.Name;
            btnAction.Text = "Update";
            _item = item;
        }
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        string value = entryToDoName.Text?.Trim();

        if (!string.IsNullOrEmpty(value))
            Close(value);
        else
            Close(null);
    }

    private void entryToDoName_Loaded(object sender, EventArgs e)
    {

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(100);
            entryToDoName.Focus();
        });
    }
}