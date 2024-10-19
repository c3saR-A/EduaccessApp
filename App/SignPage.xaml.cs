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

        //Guardar Datos
        using (var Db = new AppDbContext())
        {
            Db.Usuarios.Add(NuevoUsuario);
            Db.SaveChanges();
        }

        await DisplayAlert("�xito", "Usuario creado exitosamente.", "OK");
    }
}