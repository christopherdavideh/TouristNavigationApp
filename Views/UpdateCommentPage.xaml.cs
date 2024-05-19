using System.Net;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class UpdateCommentPage : ContentPage
{
    private Comentarios comentarioActualizar;
    private string usuarioLoggeado;
    public UpdateCommentPage(Comentarios comentario, string correo)
    {
        InitializeComponent();
        txtComentario.Text = comentario.DetalleComentario;
        comentarioActualizar = comentario;
        usuarioLoggeado = correo;
    }

    private void btnActualizarComentario_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime fechaActual = DateTime.Now;
            String fechaComentario = fechaActual.ToString("yyyy-MM-dd");
            string comentario = txtComentario.Text;
            int id = comentarioActualizar.IdComentario;
            WebClient usuario = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            usuario.UploadValues("http://localhost/appmovil/postcoment.php?IdComentario=" + id + "&DetalleComentario="
                + comentario + "&FechaComentario=" + fechaComentario, "PUT", parametros);
            Navigation.PushAsync(new ProfilePage(usuarioLoggeado));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private void btnEliminarComentario_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            int id = comentarioActualizar.IdComentario;
            cliente.UploadValues("http://localhost/appmovil/postcoment.php?IdComentario=" + id, "DELETE", parametros);
            Navigation.PushAsync(new ProfilePage(usuarioLoggeado));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}