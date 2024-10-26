using Microsoft.Maui.Controls;

namespace App.Pages.Temas.Ciencia
{
    public partial class temaciencia1 : ContentPage
    {
        public temaciencia1()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
        }

        private async void BackCienciaPage(object sender, EventArgs e)
        {
            // Navegar a la página anterior
            await Navigation.PopAsync();
        }
    }
}