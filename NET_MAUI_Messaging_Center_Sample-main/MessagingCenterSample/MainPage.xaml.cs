using System.Collections.ObjectModel;

namespace MessagingCenterSample
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<Page, DateTime>(this, "tick", (p, datetime) =>
            {
                Messages.Add($"Messagge received at {datetime}");
            });
        }
        //go to page
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendPage());
        }
    }
}
