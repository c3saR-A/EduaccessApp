namespace App.Pages;

public partial class Temas_ciencias : ContentPage
{
	public Temas_ciencias()
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
    }

    private async void BackCienciaPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}