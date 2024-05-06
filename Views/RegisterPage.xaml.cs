using System.Text.RegularExpressions;

namespace TouristNavigationApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        string cedula = txtCedula.Text;
        string nombre = txtNombres.Text;
        string correo = txtCorreo.Text;
        string direccion = txtDireccion.Text;
        string telefono = txtTelefono.Text;
        string contrasenia = txtContrasenia.Text;
        try
        {
            if (!string.IsNullOrEmpty(cedula) || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(correo) || !string.IsNullOrEmpty(direccion) || !string.IsNullOrEmpty(telefono) || !string.IsNullOrEmpty(contrasenia))
            {
                if (EsEmailValido(correo))
                {
                    if (ValidarContrasenia(contrasenia))
                    {
                        //Hacer CRUD -> falta modelos
                    }
                    else
                    {
                        DisplayAlert("Error", "La contrase�a debe tener 8 caracteres, al menos una letra y al menos un n�mero!", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Correo electr�nico inv�lido!", "Cerrar");
                }
            }
            else
            {
                // La entrada est� vac�a
                DisplayAlert("Error", "No est�n completos todos los campos!", "Cerrar");
            }
        }
        catch
        {
            DisplayAlert("Alerta", "Usuario o contrase�a incorrectos!", "Cerrar");
            txtContrasenia.Text = "";
            txtCorreo.Text = "";
        }
    }
    private bool EsEmailValido(string email)
    {
        string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(@"
                            + @"(([-a-z0-9]|(?<!\.)\.)*\.)+[a-z]{2,})$";
        Regex regex = new Regex(emailPattern, RegexOptions.IgnoreCase);
        return regex.IsMatch(email);
    }

    private bool ValidarContrasenia(string password)
    {
        Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8}$");
        return regex.IsMatch(password);
    }
}