using Newtonsoft.Json;
using System.Net;
using System.Text;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class UpdateCommentPage : ContentPage
{
    private readonly HttpClient _httpClient;
    private Comentarios comentarioActualizar;
    private string usuarioLoggeado;
    private const string URL = "http://172.19.144.1:8080/api/v1/comments";
    private const string URLUse = "http://172.19.144.1:8080/api/v1/users/email/";
    private int idComentario;
    public UpdateCommentPage(Comentarios comentario, string correo)
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        txtComentario.Text = comentario.comDetail;
        txtCalificacion.Text = comentario.comScore.ToString();
        comentarioActualizar = comentario;
        idComentario = comentario.comId;
        usuarioLoggeado = correo;
    }

    private async void btnActualizarComentario_Clicked(object sender, EventArgs e)
    {
        try
        {
            var contentUse = await _httpClient.GetStringAsync(URLUse + usuarioLoggeado);
            Usuarios usuarioActual = JsonConvert.DeserializeObject<Usuarios>(contentUse);

            Lugares lugarComment = new()
            {
                plaId = 1,
                plaName = "San Francisco",
                plaDetail = "Detalle del sitio",
                plaReference = "Referencia del sitio",
                plaLatitude = 134.0,
                plaLongitude = 456.0,
                plaCity = "Quito",
                plaProvince = "Pichincha"
            };

            Comentarios comentario = new()
            {
                comId = idComentario,
                comDetail = txtComentario.Text,
                comScore = int.Parse(txtCalificacion.Text),
                fkUser = usuarioActual,
                fkPlace = lugarComment
            };

            var json = JsonConvert.SerializeObject(comentario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(URL, content);
            response.EnsureSuccessStatusCode();
            DisplayAlert("Información", "Comentario actualizado correctamente!", "Cerrar");
            Navigation.PushAsync(new ProfilePage(usuarioLoggeado));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

    private async void btnEliminarComentario_Clicked(object sender, EventArgs e)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{URL}/{idComentario}");
            response.EnsureSuccessStatusCode();
            DisplayAlert("Información", "Comentario eliminado correctamente!", "Cerrar");
            Navigation.PushAsync(new ProfilePage(usuarioLoggeado));
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }
}