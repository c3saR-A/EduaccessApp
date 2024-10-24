using App.ViewModel;

namespace App;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(int UsuarioId)
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel(UsuarioId);

        Shell.SetNavBarIsVisible(this, false);
    }

    private void BackMainPage(object sender, EventArgs e)
    {
        Navigation.PopAsync(); // Para regresar a la página anterior
    }
}