namespace TouristNavigationApp.Views;

public partial class NavigationPage : ContentPage
{
	public NavigationPage()
	{
		InitializeComponent();
	}

    private async void InicioButton_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "INICIO", "OK");
    }

    private async void IAButton_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "INTELIGENCIA ARTIFICIAL", "OK");
    }

    private async void PerfilButton_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "PERFIL", "OK");
    }


  



    
}