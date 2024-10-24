using App.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace App;

public partial class LoginPage : ContentPage
{
    private readonly AppDbContext _dbcontext;
    public LoginPage(AppDbContext dbcontext)
	{
        _dbcontext = dbcontext;
        InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);
    }

	private async void Login(object sender, EventArgs e)
	{
        var Usuario = UsuarioEntry.Text;
        var Password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Password))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        var user = await _dbcontext.Usuarios.FirstOrDefaultAsync(u => u.Nombre == Usuario && u.Password == Password );

        if (user != null)
        {
            await DisplayAlert("Éxito", $"Bienvenido, {user.Nombre}.", "OK");

            await Navigation.PushAsync(new MainPage(user.Id));
        }
        else
        {
            await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos.", "OK");
        }
    }
}