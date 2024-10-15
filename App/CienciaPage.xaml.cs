namespace App;
public partial class CienciaPage : ContentPage
{ 
	public CienciaPage()
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