using App.ViewModel;

namespace App;

public partial class Temas_matematicas : ContentPage
{
	public Temas_matematicas()
	{
		InitializeComponent();

		Shell.SetNavBarIsVisible(this, false);

	}

    private async void BackPage(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}