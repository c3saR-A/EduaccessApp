namespace App;

public partial class SocialesPage : ContentPage
{
    public SocialesPage()
    {
        InitializeComponent();
        //Hacer invisible la barra de navegación
        Shell.SetNavBarIsVisible(this, false);
    }
    //Método para volver a menu o MainPage
    private async void BackMainPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}