using System.Net;

namespace TouristNavigationApp.Views;

public partial class SitePage : ContentPage
{
	public SitePage(string title)
	{
		InitializeComponent();
		lblTituloSitio.Text = title;
	}

    private void btnAgregarComentario_Clicked(object sender, EventArgs e)
    {
		try
		{
            DateTime fechaActual = DateTime.Now;
            String fechaComentario = fechaActual.ToString("yyyy-MM-dd"); ;
            WebClient usuario = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("DetalleComentario", txtComentario.Text);
            parametros.Add("FechaComentario", fechaComentario);
            usuario.UploadValues("http://localhost/appmovil/postcoment.php", "POST", parametros);
            DisplayAlert("Información", "Comentario agregado correctamente!", "Cerrar");
            txtComentario.Text = "";
        }
		catch (Exception ex)
		{
			DisplayAlert("Error", ex.Message, "Cerrar");
		}
    }
}