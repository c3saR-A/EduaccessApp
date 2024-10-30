using App.DataAccess;
using App.Models;

namespace App.Pages.Temas.Ciencia;

public partial class temaciencia1 : ContentPage
{
	public temaciencia1()
	{
		InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);

    }   

    private async void FinalizarClase(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
    }

    private async void BackCienciaPage(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}