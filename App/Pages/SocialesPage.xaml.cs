using App.Pages;

namespace App;

public partial class SocialesPage : ContentPage
{
    public SocialesPage()
    {
        InitializeComponent();
        //Hacer invisible la barra de navegaci�n
        Shell.SetNavBarIsVisible(this, false);
    }
    //M�todo para volver a menu o MainPage
    private async void BackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void GoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PruebasSociales());
    }
}