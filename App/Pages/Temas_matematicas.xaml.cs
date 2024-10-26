using App.DataAccess;
using App.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace App;

public partial class Temas_matematicas : ContentPage
{
	public Temas_matematicas()
	{
		InitializeComponent();

		Shell.SetNavBarIsVisible(this, false);
        CargarTemas();
	}
    private async void CargarTemas()
    {
        using (var context = new AppDbContext())
        {

            var clases = await context.Clases.Include(c => c.Materia).Where(c => c.IdMateria == 4).ToListAsync();

            Picker picker = new Picker { Title = "TEMAS", VerticalOptions = LayoutOptions.CenterAndExpand, FontSize = 25 };

            foreach (var clase in clases)
            {
                picker.Items.Add(clase.Contenido);
            }

            // Reemplaza el Picker en el XAML con el nuevo Picker
            PickerstackLayout.Children.Add(picker);
        }
    }
    private async void BackPage(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}