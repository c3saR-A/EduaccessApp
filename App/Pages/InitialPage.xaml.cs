using App.DataAccess;

namespace App;

public partial class InitialPage : ContentPage
{
	public InitialPage()
	{
		InitializeComponent();
	}

	private async void GoLoginPage(object sender, EventArgs e)
	{
        var dbcontext = new AppDbContext();
        await Navigation.PushAsync(new LoginPage(dbcontext));
	}

	private async void GoSignPage(object sender, EventArgs e)
	{
        var dbcontext = new AppDbContext();
        await Navigation.PushAsync(new SignPage(dbcontext));
	}
}