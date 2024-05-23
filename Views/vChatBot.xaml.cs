using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TouristNavigationApp.Views;

public partial class vChatBot : ContentPage
{

    private const string urlBase = "http://127.0.0.1/appTurismo/post.php";
    private readonly HttpClient cliente = new HttpClient();
    public ObservableCollection<ChatMessage> ChatMessages { get; set; } = new ObservableCollection<ChatMessage>();
    public vChatBot()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string pregunta = entryPregunta.Text;

        if (string.IsNullOrEmpty(pregunta))
        {
            await DisplayAlert("Error", "Por favor, ingrese una pregunta.", "OK");
            return;
        }

        // Limpia la colección de mensajes antes de añadir los nuevos
        ChatMessages.Clear();

        // Agrega la pregunta ingresada al chat
        ChatMessages.Add(new ChatMessage { Message = pregunta, IsUserMessage = true });

        // Llama a ObtenerRespuesta con la pregunta ingresada
        await ObtenerRespuesta(pregunta);
    }

   
    public async Task ObtenerRespuesta(string chatPregunta)

    {

        try
        {
            string requestUrl = $"{urlBase}?pregunta={Uri.EscapeDataString(chatPregunta)}"; // Endpoint para obtener la respuesta de una pregunta específica
            var content = await cliente.GetStringAsync(requestUrl); // Solicitud HTTP GET

            if (string.IsNullOrWhiteSpace(content))
            {
                await DisplayAlert("Error", "No se recibió una respuesta válida del servidor", "OK");
                return;
            }

            if (content.Trim().StartsWith("["))
            {
                List<Consultas> respuestas = JsonConvert.DeserializeObject<List<Consultas>>(content);

                if (respuestas == null || respuestas.Count == 0)
                {
                    await DisplayAlert("Información", "No se encontró una respuesta para la pregunta especificada", "OK");
                    return;
                }

                // Buscar la respuesta correspondiente a la pregunta seleccionada
                var respuesta = respuestas.Find(r => r.chatPregunta == chatPregunta);
                if (respuesta != null)
                {
                    ChatMessages.Add(new ChatMessage { Message = respuesta.chatRespuesta, IsUserMessage = false });
                }
                else
                {
                    await DisplayAlert("Información", "No se encontró una respuesta para la pregunta especificada", "OK");
                }
            }
            else
            {
                // Deserialización de un objeto Consultas
                Consultas respuesta = JsonConvert.DeserializeObject<Consultas>(content);

                if (respuesta == null)
                {
                    await DisplayAlert("Información", "No se encontró una respuesta para la pregunta especificada", "OK");
                    return;
                }

                ChatMessages.Add(new ChatMessage { Message = respuesta.chatRespuesta, IsUserMessage = false });
            }
            chatCollectionView.IsVisible = true; // Mostrar el CollectionView de respuesta
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("Error", $"Error al realizar la solicitud HTTP: {ex.Message}", "OK");
        }
        catch (JsonException ex)
        {
            await DisplayAlert("Error", $"Error al deserializar el JSON: {ex.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error inesperado: {ex.Message}", "OK");
        }
    }


    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void searchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}