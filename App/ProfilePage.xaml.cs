namespace App;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        //Hacer invisible la barra de navegación
        Shell.SetNavBarIsVisible(this, false);
     
        

    }
    private void BackMainPage(object sender, EventArgs e)
    {
        Navigation.PopAsync(); // Para regresar a la página anterior
    }
    
}