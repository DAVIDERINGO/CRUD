using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        private const string Url = "http://192.168.1.43/moviles/post.php";
        public Eliminar()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {

            


            int Id = Convert.ToInt32(txtCodigo.Text);

                HttpClient cliento = new HttpClient();
                var resultado = await cliento.DeleteAsync(String.Concat("http://192.168.1.43/moviles/post.php", txtCodigo.Text));
               if (resultado.IsSuccessStatusCode)
            {
                await DisplayAlert("Exitoooo", "Registro eliminado", "Ok");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}