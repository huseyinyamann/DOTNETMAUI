using yListesiMaui_SQLite.Data;
using yListesiMaui_SQLite.Models;

namespace yListesiMaui_SQLite.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }
    TodoItemDatabase database;
    public TodoItemPage(TodoItemDatabase todoItemPage)
    {
        InitializeComponent();
        database = todoItemPage;
    }
    private async void OnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            var s = Item;
            if (string.IsNullOrWhiteSpace(Item.Name))
            {
                await DisplayAlert("Name Required", "Please enter a name for the todo item.", "ok");
                return;
            }

            await database.SaveItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }catch (Exception ex)
        {
            await DisplayAlert("",ex.Message, "tamam");
        }
        
    }
    async void OnDelete_Clicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}