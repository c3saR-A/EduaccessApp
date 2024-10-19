using App.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App;

public partial class SignPage : ContentPage
{
	public SignPage()
	{
		InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);
    }

	private async void CreateUser(object sender, EventArgs e)
	{
		// Tomar los datos de los entry
		var Usuario = UsuarioEntry.Text;
		var Password = ContraseñaEntry.Text;
		var Confirmacion = ConfirmacionEntry.Text;
        var Nivel = "Primer Grado";

        // Verificación datos no sean vacios
        if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Confirmacion))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        // Verificación contraseña
        if (Password != Confirmacion)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        //Crear Usuario
        var NuevoUsuario = new Usuario
        {
            Nombre = Usuario,
            Password = Password,
            Nivel = Nivel,
        };

        //Guardar Datos
        using (var Db = new AppDbContext())
        {
            Db.Usuarios.Add(NuevoUsuario);
            Db.SaveChanges();
        }

        await DisplayAlert("Éxito", "Usuario creado exitosamente.", "OK");
    }
}