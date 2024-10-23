using App.Models;
using App.DataAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Maui.Graphics.Text;

namespace App;

public partial class SignPage : ContentPage
{
    
    private readonly AppDbContext _dbcontext;

    public SignPage(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
       
    }


	private async void CreateUser(object sender, EventArgs e)
	{
		// Tomar los datos de los entry
		var Usuario = UsuarioEntry.Text;
		var Password = Contrase�aEntry.Text;
		var Confirmacion = ConfirmacionEntry.Text;
        var Nivel = "Primer Grado";

        // Verificaci�n datos no sean vacios
        if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Confirmacion))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        // Verificaci�n contrase�a
        if (Password != Confirmacion)
        {
            await DisplayAlert("Error", "Las contrase�as no coinciden.", "OK");
            return;
        }

        //Crear Usuario
        var NuevoUsuario = new Usuario
        {
            Nombre = Usuario,
            Password = Password,
            Nivel = Nivel,
        };
        // Guardar datos
        _dbcontext.Usuarios.Add(NuevoUsuario);
        _dbcontext.SaveChangesAsync();

        await DisplayAlert("�xito", "Usuario creado exitosamente.", "Ok");
        await Navigation.PushAsync(new MainPage());
    }
}