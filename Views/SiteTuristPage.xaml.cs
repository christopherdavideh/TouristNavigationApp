using Newtonsoft.Json;
using System.Text;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class SiteTuristPage : ContentPage
{
    private readonly HttpClient _httpClient;
    private const string URL = "http://172.19.144.1:8080/api/v1/comments";
    private const string URLUse = "http://172.19.144.1:8080/api/v1/users/email/";
    private string usuarioLoggeado;
    public SiteTuristPage(string title, string email)
	{
		InitializeComponent();
		lblTituloSitio.Text = title;
        _httpClient = new HttpClient();
        usuarioLoggeado = email;
    }

    private async void btnAgregarComentario_Clicked(object sender, EventArgs e)
    {
		try
		{
            var contentUse = await _httpClient.GetStringAsync(URLUse+usuarioLoggeado);
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
                comDetail = txtComentario.Text,
                comScore = int.Parse(txtCalificacion.Text),
                fkUser = usuarioActual,
                fkPlace = lugarComment
            };

            var json = JsonConvert.SerializeObject(comentario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(URL, content);
            response.EnsureSuccessStatusCode();
            DisplayAlert("Información", "Comentario agregado correctamente!", "Cerrar");
            txtComentario.Text = "";
            txtCalificacion.Text = "";
        }
		catch (Exception ex)
		{
			DisplayAlert("Error", ex.Message, "Cerrar");
		}
    }
}