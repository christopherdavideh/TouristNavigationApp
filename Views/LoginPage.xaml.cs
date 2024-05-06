namespace TouristNavigationApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Dictionary<string, string> Credenciales = new Dictionary<string, string>();
        Credenciales.Add("daniel@gmail.com", "12345");

        string usuario = txtCorreo.Text;
        string clave = txtContrasenia.Text;
        try
        {
            if (clave == Credenciales[usuario])
            {
                //Iniciar sesión a la página respectiva
            }
            else
            {
                DisplayAlert("Alerta", "Usuario o contraseña incorrectos!", "Cerrar");
                txtContrasenia.Text = "";
                txtCorreo.Text = "";
            }
        }
        catch
        {
            DisplayAlert("Alerta", "Usuario o contraseña incorrectos!", "Cerrar");
            txtContrasenia.Text = "";
            txtCorreo.Text = "";
        }
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.RegisterPage());
    }
}