using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Semana6_rtipantuñatarea.Models;

namespace Semana6_rtipantuñatarea.Views;

public partial class vActElim : ContentPage
{
    private readonly HttpClient _httpClient;
    private object data;

    public vActElim(Rol datos)
    {
        InitializeComponent();
        _httpClient = new HttpClient();


        // Envio los datos
        txtCodigo.Text = datos.idrol.ToString();
        txtNombre.Text = datos.nombrerol.ToString();
        txtDescripcion.Text = datos.descripcion.ToString();
        txtStatus.Text = datos.status.ToString();
        int id = int.Parse(txtCodigo.Text); // id del registro a actualizar
        var data = new
        {
            nombrerol = txtNombre.Text,
            descripcion = txtDescripcion.Text,
            status = txtStatus.Text
        };

    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        int id = int.Parse(txtCodigo.Text);
        var data = new
        {
            nombrerol = txtNombre.Text,
            descripcion = txtDescripcion.Text,
            status = txtStatus.Text
        };
        try
        {
            string url = $"https://credp-s.net.ec/api.php?table=rol&{GetPrimaryKeyParamName()}={id}";

            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Éxito", "Registro actualizado correctamente.", "OK");
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"Error al actualizar: {errorResponse}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
        await Navigation.PushAsync(new vEstudiante());
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Eliminar", "¿Está seguri que desea eliminar este elemento?", "Eliminar", "Cancelar");
        {
            if (result)
            {
                try
                {
                    WebClient client = new WebClient();
                    string urldelete = "http://192.168.100.46/uisrael/estudiante.php?codigo=" + txtCodigo.Text;

                    client.UploadValues(urldelete, "DELETE", new System.Collections.Specialized.NameValueCollection());

                    await DisplayAlert("Éxito", "Eliminado correctamente", "Aceptar");

                    await Navigation.PushAsync(new vEstudiante());


                }
                catch (Exception ex)
                {

                    await DisplayAlert("Error", "Ocurrió un error al eliminar: " + ex.Message, "Aceptar");
                }
                await DisplayAlert("Eliminar", "Eliminado correctamente", "Aceptar");
            }
        }
    }
    private string GetPrimaryKeyParamName()
    {
        return "idrol"; // Cambia esto si tu clave primaria es diferente
    }

}