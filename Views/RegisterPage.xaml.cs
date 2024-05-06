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
            if (!string.IsNullOrEmpty(cedula) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(direccion) && !string.IsNullOrEmpty(telefono) && !string.IsNullOrEmpty(contrasenia))
            {
                if (ValidarTelefono(telefono))
                {
                    if (EsEmailValido(correo))
                    {
                        if (ValidarContrasenia(contrasenia))
                        {
                            //Hacer CRUD -> falta modelos
                            Navigation.PushAsync(new Views.LoginPage());
                            txtCedula.Text = "";
                            txtNombres.Text = "";
                            txtCorreo.Text = "";
                            txtDireccion.Text = "";
                            txtTelefono.Text = "";
                            txtContrasenia.Text = "";
                        }
                        else
                        {
                            DisplayAlert("Error", "La contraseña debe tener 8 caracteres, al menos una letra y al menos un número!", "Cerrar");
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Correo electrónico inválido!", "Cerrar");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Teléfono inválido debe tener 10 dígitos y empezar por cero 0!", "Cerrar");
                }
            }
            else
            {
                DisplayAlert("Error", "No están completos todos los campos!", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "Detalle de error: "+ ex.Message, "Cerrar");
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

    private bool ValidarTelefono(string phoneNumber)
    {
        Regex regex = new Regex(@"^0\d{9}$");
        return regex.IsMatch(phoneNumber);
    }
}