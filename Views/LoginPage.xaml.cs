using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave))
            {
                if (EsEmailValido(usuario))
                {
                    if (clave == Credenciales[usuario])
                    {
                        //Iniciar sesión a la página respectiva
                        txtContrasenia.Text = "";
                        txtCorreo.Text = "";
                    }
                    else
                    {
                        DisplayAlert("Alerta", "Usuario o contraseña incorrectos!", "Cerrar");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Correo electrónico inválido!", "Cerrar");
                }
            }
            else
            {
                DisplayAlert("Error", "No están completos todos los campos!", "Cerrar");
            }
        }
        catch
        {
            DisplayAlert("Alerta", "Usuario o contraseña incorrectos!", "Cerrar");
        }
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.RegisterPage());
    }

    private bool EsEmailValido(string email)
    {
        string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(@"
                            + @"(([-a-z0-9]|(?<!\.)\.)*\.)+[a-z]{2,})$";
        Regex regex = new Regex(emailPattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(email);
    }
}