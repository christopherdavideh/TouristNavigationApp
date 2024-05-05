namespace TouristNavigationApp.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "Convento de San Francisco", "OK");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "Iglesia de la Compañia de Jesus", "OK");
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Mensaje", "La Plaza Grande", "OK");
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