namespace MessagingCenterSample;

public partial class SendPage : ContentPage
{
	public SendPage()
	{
		InitializeComponent();
	}

    //send
    private void Button_Clicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<Page, DateTime>(this, "tick", DateTime.Now);
    }

    //close
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}