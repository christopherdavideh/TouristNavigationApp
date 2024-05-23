using Newtonsoft.Json;
using System.Text;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class SitePage : ContentPage
{
    private readonly HttpClient _httpClient;
    private const string URL = "http://localhost:8080/api/v1/comments";
    public SitePage(string title)
	{
		InitializeComponent();
		lblTituloSitio.Text = title;
        _httpClient = new HttpClient();
    }

    private async void btnAgregarComentario_Clicked(object sender, EventArgs e)
    {
		try
		{
            Usuarios usuarioComment = new()
            {
                useId = 1,
                useName = "Daniel",
                useEmail = "correo@gmail.com",
                useAddress = "Direccion de",
                usePhone = "0998776655",
                usePassword = "danig163",
                useCi = "1750819094"
            };

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
                comScore = 5,
                fkUser = usuarioComment,
                fkPlace = lugarComment
            };

            var json = JsonConvert.SerializeObject(comentario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(URL, content);
            response.EnsureSuccessStatusCode();
            //DisplayAlert("Información", "Comentario agregado correctamente!", "Cerrar");
            //txtComentario.Text = "";
        }
		catch (Exception ex)
		{
			DisplayAlert("Error", ex.Message, "Cerrar");
		}
    }
}