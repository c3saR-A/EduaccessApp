using App.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace App.Pages;

public partial class PruebasMatematicas : ContentPage
{
	public PruebasMatematicas()
	{
		InitializeComponent();

        Shell.SetNavBarIsVisible(this, false);
        CargarPracticas();
    }

    private async void CargarPracticas()
    {
        using (var context = new AppDbContext())
        {

            var practicas = await context.Practicas.Include(c => c.Materia).Where(c => c.IdMateria == 4).ToListAsync();

            Picker picker = new Picker { Title = "PRUEBAS", VerticalOptions = LayoutOptions.CenterAndExpand, FontSize = 25 };

            foreach (var practica in practicas)
            {
                picker.Items.Add(practica.Nombre);
            }

            // Reemplaza el Picker en el XAML con el nuevo Picker
            PickerstackLayout.Children.Add(picker);
        }
    }
    private async void BackMatematicasPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}