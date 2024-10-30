using App.DataAccess;
using App.Pages.Pruebas.Ciencias;
using App.Pages.Temas.Ciencia;
using Microsoft.EntityFrameworkCore;

namespace App.Pages;

public partial class PruebasCiencias : ContentPage
{
	public PruebasCiencias()
	{
		InitializeComponent();

		Shell.SetNavBarIsVisible(this, false);
        CargarPracticas();
	}

    private async void CargarPracticas()
    {
        using (var context = new AppDbContext())
        {

            var practicas = await context.Practicas.Include(c => c.Materia).Where(c => c.IdMateria == 1).ToListAsync();

            Picker picker = new Picker { Title = "PRUEBAS", VerticalOptions = LayoutOptions.CenterAndExpand, FontSize = 25 };

            foreach (var practica in practicas)
            {
                picker.Items.Add(practica.Nombre);
            }

            // Reemplaza el Picker en el XAML con el nuevo Picker
            PickerstackLayout.Children.Add(picker);
        }
    }

    private async void OnContinuarClicked(object sender, EventArgs e)
    {
        // Verifica si hay una practica seleccionado en el Picker
        if (PickerstackLayout.Children.Count > 0 && PickerstackLayout.Children[0] is Picker temaPicker)
        {
            var temaSeleccionado = temaPicker.SelectedItem?.ToString();

            // Navega a la página correspondiente según lo seleccionado
            switch (temaSeleccionado)
            {
                case "Práctica de Ciencias 1":
                    await Navigation.PushAsync(new prueba1ciencias());
                    break;
                default:
                    await DisplayAlert("Error", "Practica no reconocido.", "OK");
                    break;
            }
        }
        else
        {
            await DisplayAlert("Error", "Por favor, selecciona una practica antes de continuar.", "OK");
        }
    }
    private async void BackCienciaPage(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

}