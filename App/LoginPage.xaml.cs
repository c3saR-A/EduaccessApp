namespace App;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);
    }

	private async void GoMainPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
	}
}