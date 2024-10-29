

namespace App.Pages;

public partial class prueba1ciencias : ContentPage
{
	public prueba1ciencias()
	{
		InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);
    }

	private async void BackPruebasPage(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}