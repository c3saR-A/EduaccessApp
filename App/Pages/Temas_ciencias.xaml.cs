using App.DataAccess;
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
            
            var clases = await context.Clases.Include(c => c.Materia).ToListAsync();

            Picker picker = new Picker { Title = "TEMAS", VerticalOptions = LayoutOptions.CenterAndExpand, FontSize = 25 };

            foreach (var clase in clases)
            {
                picker.Items.Add(clase.Contenido);
            }

            // Reemplaza el Picker en el XAML con el nuevo Picker
            PickerstackLayout.Children.Add(picker);
        }
    }

    private async void BackCienciaPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}