using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using TouristNavigationApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TouristNavigationApp.Views;

public partial class LoginPage : ContentPage
{
    private const string URL = "http://localhost/appmovil/post.php";
    private readonly HttpClient cliente = new HttpClient();
    Dictionary<string, string> Credenciales = new Dictionary<string, string>();
    public LoginPage()
	{
		InitializeComponent();
        //ObtenerUsuarios();
	}
    public async void ObtenerUsuarios()
    {
        var content = await cliente.GetStringAsync(URL);
        List<Usuarios> mostrarUsuarios = JsonConvert.DeserializeObject<List<Usuarios>>(content);
        Credenciales = mostrarUsuarios.ToDictionary(usuario => usuario.CorreoUsuario, usuario => usuario.ContraseniaUsuario);
    }
    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DashboardPage("danielrepreuno@gmail.com"));
        /*
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
        */
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