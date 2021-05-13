using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
namespace CRUD
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.43/moviles/crud.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<CRUD.CRUDS.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }




       


        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<CRUD.CRUDS.Datos> posts = JsonConvert.DeserializeObject<List<CRUD.CRUDS.Datos>>(content);
            _post = new ObservableCollection<CRUD.CRUDS.Datos>(posts);

            MyListView.ItemsSource = _post;

        }


       




        private async void btnValidar_Clicked(object sender, EventArgs e)
        {

            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://192.168.1.43/moviles/crud.php");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<CRUD.CRUDS.Datos>>(content);

            }
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actualizar());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eliminar());
        }
    }
}
