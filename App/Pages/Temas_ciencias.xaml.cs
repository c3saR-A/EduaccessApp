using App.DataAccess;
using App.Pages.Temas.Ciencia;
using Microsoft.EntityFrameworkCore;

namespace App.Pages;

public partial class Temas_ciencias : ContentPage
{
	public Temas_ciencias()
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        CargarTemas();
    }

    private async void CargarTemas()
    {
        using (var context = new AppDbContext())
        {
            
            var clases = await context.Clases.Include(c => c.Materia).Where(c => c.IdMateria == 1).ToListAsync();

            Picker picker = new Picker { Title = "TEMAS", VerticalOptions = LayoutOptions.CenterAndExpand, FontSize = 25 };

            foreach (var clase in clases)
            {
                picker.Items.Add(clase.Contenido);
            }

            // Reemplaza el Picker en el XAML con el nuevo Picker
            PickerstackLayout.Children.Add(picker);
        }
    }

    private async void OnContinuarClicked(object sender, EventArgs e)
    {
        // Verifica si hay un tema seleccionado en el Picker
        if (PickerstackLayout.Children.Count > 0 && PickerstackLayout.Children[0] is Picker temaPicker)
        {
            var temaSeleccionado = temaPicker.SelectedItem?.ToString();

            // Navega a la página correspondiente según el tema seleccionado
            switch (temaSeleccionado)
            {
                case "El reino de los animales":
                    await Navigation.PushAsync(new temaciencia1());
                    break;
                case "El reino de las plantas":
                    await Navigation.PushAsync(new temaciencia2());
                    break;
                case "Los sentidos":
                    await Navigation.PushAsync(new temaciencia3());
                    break;
                default:
                    await DisplayAlert("Error", "Tema no reconocido.", "OK");
                    break;
            }
        }
        else
        {
            await DisplayAlert("Error", "Por favor, selecciona un tema antes de continuar.", "OK");
        }
    }

    private async void BackCienciaPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}