
namespace App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(this, false);
        }
        //Métodos para navegar a las paginas
        private async void GoCienciaPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CienciaPage());
        }

        private async void GoLenguajePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LenguajePage());
        }

        private async void GoSocialesPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SocialesPage());
        }

        private async void GoMatematicasPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MatematicasPage());
        }

        private async void GoProfilePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }

}
