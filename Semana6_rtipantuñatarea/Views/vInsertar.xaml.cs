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
                parametros.Add("nombrerol", txtNombre.Text);
                parametros.Add("descripcion", txtDescripcion.Text);
                parametros.Add("status", txtStatus.Text);
                cliente.UploadValues("https://credp-s.net.ec/api.php?table=rol",
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