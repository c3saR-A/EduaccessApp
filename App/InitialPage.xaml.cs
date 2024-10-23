namespace App;

public partial class InitialPage : ContentPage
{
    public InitialPage()
    {
        InitializeComponent();
    }

    private async void GoLoginPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void GoSignPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignPage());
    }
}