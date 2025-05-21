using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Semana6_rtipantuñatarea.Models;

namespace Semana6_rtipantuñatarea.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "https://credp-s.net.ec/api.php?table=rol";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Rol> estud;

    public vEstudiante()
    {
        InitializeComponent();
        mostrar();
    }

    public async void mostrar()
    {
        var content = await cliente.GetStringAsync(Url);

        var mostrarEst = JsonConvert.DeserializeObject<List<Rol>>(content) ?? new();
        estud = new ObservableCollection<Rol>(mostrarEst);

        lvEstudiantes.ItemsSource = estud;
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vInsertar());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       var objEstudiante = (Rol)e.SelectedItem;
        Navigation.PushAsync(new Views.vActElim(objEstudiante));
    }
}
