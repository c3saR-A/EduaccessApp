namespace App;

public partial class MatematicasPage : ContentPage
{
    public MatematicasPage()
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
}