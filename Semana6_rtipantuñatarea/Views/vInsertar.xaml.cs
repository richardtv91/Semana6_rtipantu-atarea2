using System.Net;

namespace Semana6_rtipantuñatarea.Views;

public partial class vInsertar : ContentPage
    {
        public vInsertar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Protocolo seguro
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.100.6/uisrael/estudiante.php",
                                      "POST",
                                      parametros);
                //Abre la nueva ventana

                Navigation.PushAsync(new vEstudiante());
            }
            catch (Exception ex)
            {

                DisplayAlert("ERROR", ex.Message, "Cerrar");
            }
        }
    }