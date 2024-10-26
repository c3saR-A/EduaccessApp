using App.DataAccess; // Asegúrate de que esta referencia esté presente
using Microsoft.EntityFrameworkCore;
using App.Pages.Temas.Matematica;
using Microsoft.Maui.Controls;

namespace App.Pages
{
    public partial class Temas_matematicas : ContentPage
    {
        public Temas_matematicas()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
            CargarTemas(); // Llama al método para cargar los temas desde la base de datos
        }

        private async void CargarTemas()
        {
            using (var context = new AppDbContext())
            {
                // Carga los temas desde la base de datos
                var clases = await context.Clases
                    .Include(c => c.Materia)
                    .Where(c => c.IdMateria == 4) // Ajusta el IdMateria según tus necesidades
                    .ToListAsync();

                // Crea un nuevo Picker
                Picker temaPicker = new Picker
                {
                    Title = "TEMAS",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 25
                };

                // Agrega los temas al Picker
                foreach (var clase in clases)
                {
                    temaPicker.Items.Add(clase.Contenido);
                }

                // Agrega el Picker al StackLayout (asegúrate de que PickerstackLayoutmate esté definido en tu XAML)
                PickerstackLayoutmate.Children.Add(temaPicker);

                // Asocia el evento SelectedIndexChanged al Picker
                temaPicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
            }
        }

        private async void OnContinuarClicked(object sender, EventArgs e)
        {
            // Verifica si hay un tema seleccionado en el Picker
            if (PickerstackLayoutmate.Children.Count > 0 && PickerstackLayoutmate.Children[0] is Picker temaPicker)
            {
                var temaSeleccionado = temaPicker.SelectedItem?.ToString();

                // Navega a la página correspondiente según el tema seleccionado
                switch (temaSeleccionado)
                {
                    case "Clasifiquemos por su color":
                        await Navigation.PushAsync(new temamate1());
                        break;
                    case "Identifiquemos el grande y el pequeño":
                        await Navigation.PushAsync(new temamate2());
                        break;
                    case "Identifiquemos el mediano":
                        await Navigation.PushAsync(new temamate3());
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

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            // Puedes manejar la lógica si necesitas hacer algo cuando se cambia la selección
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            // Aquí puedes agregar lógica adicional si es necesario
        }

        private async void BackMatematicasPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Navega a la página anterior
        }
    }
}