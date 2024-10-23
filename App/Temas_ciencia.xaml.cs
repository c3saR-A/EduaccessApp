namespace App;

public partial class Temas_ciencia : ContentPage
{
    public Temas_ciencia()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);

    }


    private async void BackCienciaPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }



}