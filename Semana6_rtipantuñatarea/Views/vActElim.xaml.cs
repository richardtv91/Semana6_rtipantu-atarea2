using System.Net;
using Semana6_rtipantuñatarea.Models;

namespace Semana6_rtipantuñatarea.Views;

public partial class vActElim : ContentPage
{
    public vActElim(Estudiante datos)
    {
        InitializeComponent();

        // Envio los datos
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtDescripcion.Text = datos.apellido.ToString();
        txtStatus.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        WebClient client = new WebClient();
        var parametros = new System.Collections.Specialized.NameValueCollection();
        parametros.Add("nombrerol", txtNombre.Text);
        parametros.Add("descripcion", txtDescripcion.Text);
        parametros.Add("status", txtStatus.Text);
        string urlput = "http://credp-s.net.ec/api.php?table=rol&idrol=" + "&nombre=" + txtNombre.Text + "&descripcon=" + "&descripcon=" + "&edad=" + txtStatus.Text;
        client.UploadValues(urlput, "PUT", parametros);
        await Navigation.PushAsync(new vEstudiante());
        await DisplayAlert("Exito", "Actualizado correctamente", "Aceptar");
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

}