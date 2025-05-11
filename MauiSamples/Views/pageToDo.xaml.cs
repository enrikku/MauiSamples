using Android.Media.Metrics;
using Android.Widget;
using MauiSamples.Views.ToDo.Models;
using MauiSamples.Views.ToDo.PopUps;
using SQLite;
using Xamarin.Google.Crypto.Tink.Internal;
using static Android.Provider.ContactsContract.CommonDataKinds;
using ImageButton = Microsoft.Maui.Controls.ImageButton;

namespace MauiSamples.Views;

public partial class pageToDo : ContentPage
{
    private SQLiteAsyncConnection _connection;

    public pageToDo()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db");

            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<ToDoItem>().Wait();

            GetToDoItems();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void GetToDoItems()
    {
        try
        {
            toDoListView.ItemsSource = null;
            var items = await _connection.Table<ToDoItem>().ToListAsync();

            if (items.Count > 0)
            {
                toDoListView.ItemsSource = items;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void btnAddToDoItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new PopUpToDoItem();
            var result = await this.ShowPopupAsync(popup);

            if (result is string toDoName && !string.IsNullOrWhiteSpace(toDoName))
            {
                ToDoItem toDoItem = new ToDoItem();
                toDoItem.Name = toDoName;

                if (await _connection.InsertAsync(toDoItem) > 0)
                {
                    GetToDoItems();
                    Toast.MakeText(Android.App.Application.Context, "ToDo item added successfully", ToastLength.Long).Show();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void chkDone_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            var check = sender as InputKit.Shared.Controls.CheckBox;

            if (check != null)
            {
                var id = check.Key;

                var item = await _connection.Table<ToDoItem>().Where(x => x.Id == id).FirstOrDefaultAsync();

                if (item != null)
                {
                    if (item.Done == check.IsChecked) return; // No update if the value hasn't changed

                    item.Done = check.IsChecked;

                    if (await _connection.UpdateAsync(item) > 0)
                    {
                        Toast.MakeText(Android.App.Application.Context, "Updated", ToastLength.Long).Show();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void OnOptionsClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button && button.BindingContext is ToDoItem item)
        {
            var img = button;
            string action = await DisplayActionSheet("Options", "Cancel", null, "Edit", "Delete");

            if (action == "Edit")
            {
                var ediItem = (ToDoItem)img.BindingContext;

                var popup = new PopUpToDoItem(ediItem);
                var result = await this.ShowPopupAsync(popup);

                if (result != null) 
                {
                    if(result is string)
                    {
                        ediItem.Name = result.ToString();
                        
                        if(await _connection.UpdateAsync((ToDoItem)ediItem) > 0)
                        {
                            Toast.MakeText(Android.App.Application.Context, "Updated", ToastLength.Long).Show();
                        }
                        GetToDoItems();
                    }
                }
            }
            else if (action == "Delete")
            {
                bool confirm = await DisplayAlert("Delete", $"Delete '{item.Name}'?", "Yes", "No");
                if (confirm)
                {
                    await _connection.DeleteAsync(item);
                    GetToDoItems();
                }
            }
        }
    }
}