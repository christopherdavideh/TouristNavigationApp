using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class ProfilePage : ContentPage
{
    private const string Url = "http://localhost/appmovil/postcoment.php";
    private string UrlUsuarioConsulta = "http://localhost/appmovil/post.php?CorreoUsuario=";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Comentarios> comentario;
    private string usuarioLoggeado;
    public ProfilePage(string correo)
	{
		InitializeComponent();
        usuarioLoggeado = correo;
        ObtenerComentarios();
        ObtenerUsuario();
	}
    public async void ObtenerComentarios()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Comentarios> mostrarComentario = JsonConvert.DeserializeObject<List<Comentarios>>(content);
        comentario = new ObservableCollection<Comentarios>(mostrarComentario);
        listaComentarios.ItemsSource = mostrarComentario;
    }
    public async void ObtenerUsuario()
    {
        var contentUsuario = await cliente.GetStringAsync(UrlUsuarioConsulta + usuarioLoggeado);
        Usuarios usuarioPerfil = JsonConvert.DeserializeObject<Usuarios>(contentUsuario);
        txtCorreo.Text = usuarioPerfil.CorreoUsuario;
        txtNombres.Text = usuarioPerfil.NombresUsuario;
    }
    private void listaComentarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objcomentario = (Comentarios)e.SelectedItem;
        Navigation.PushAsync(new UpdateCommentPage(objcomentario, usuarioLoggeado));
    }
}