using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class ProfilePage : ContentPage
{
    private readonly HttpClient _httpClient;
    private const string URLComment = "http://localhost:8080/api/v1/comments/user/";
    private const string URLUse = "http://localhost:8080/api/v1/users/email/";
    private ObservableCollection<Comentarios> comentario;
    private string usuarioLoggeado;
    private int idUsuario;
    public ProfilePage(string correo)
	{
		InitializeComponent();
        _httpClient = new HttpClient();
        usuarioLoggeado = correo;
        ObtenerComentarios();
	}
    public async void ObtenerComentarios()
    {
        await ObtenerUsuario();
        var content = await _httpClient.GetStringAsync(URLComment+idUsuario.ToString());
        List<Comentarios> mostrarComentario = JsonConvert.DeserializeObject<List<Comentarios>>(content);
        comentario = new ObservableCollection<Comentarios>(mostrarComentario);
        listaComentarios.ItemsSource = mostrarComentario;
    }
    public async Task ObtenerUsuario()
    {
        var contentUse = await _httpClient.GetStringAsync(URLUse + usuarioLoggeado);
        Usuarios usuarioActual = JsonConvert.DeserializeObject<Usuarios>(contentUse);
        txtCorreo.Text = usuarioActual.useEmail;
        txtNombres.Text = usuarioActual.useName;
        idUsuario = usuarioActual.useId;
    }
    private void listaComentarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objcomentario = (Comentarios)e.SelectedItem;
        Navigation.PushAsync(new UpdateCommentPage(objcomentario, usuarioLoggeado));
    }

    private void btnUpdateProfile_Clicked(object sender, EventArgs e)
    {

    }
}