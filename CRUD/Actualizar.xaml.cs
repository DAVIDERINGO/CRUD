using CRUD.CRUDS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class Actualizar : ContentPage
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            /* Datos dat = new Datos
             {
                 codigo = Convert.ToInt32(txtCodigo.Text),
                 nombre = txtNombre.Text,
                 apellido = txtApellido.Text,
                 edad = Convert.ToInt32(txtEdad.Text),
                 direccion = txtDireccion.Text,
                 telefono = txtTelefono.Text,
                 estudio = txtEstudio.Text,
                 fecha = txtFecha.Text,
                 horario = txtHorario.Text,
                 usuario = txtUsuario.Text
             };

             Uri RequestUri = new Uri("http://192.168.1.43/moviles/post.php");
             var client = new HttpClient();
             var json = JsonConvert.SerializeObject(dat);
             var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
             var response = await client.PostAsync(RequestUri, contentJson);
             if (response.StatusCode==System.Net.HttpStatusCode.OK)
             {
                 await DisplayAlert("Datos", "Se actualizo correctamente el registro", "Ok");
                 txtApellido.Text = "";
                 txtNombre.Text = "";
                 txtApellido.Text = "";
                 txtEdad.Text = "";
                 txtDireccion.Text = "";
                 txtTelefono.Text = "";
                 txtEstudio.Text = "";
                 txtFecha.Text = "";
                 txtHorario.Text = "";
                 txtUsuario.Text = "";
             }
             else
             {
                 await DisplayAlert("Datos", "Error", "Ok");
             }*/

            //////metodo 2

            try
            {


                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("codigo", txtCodigo.Text);
                parametro.Add("nombre", txtNombre.Text);
                parametro.Add("apellido", txtApellido.Text);
                parametro.Add("edad", txtEdad.Text);
                parametro.Add("direccion", txtDireccion.Text);
                parametro.Add("telefono", txtTelefono.Text);
                parametro.Add("estudio", txtEstudio.Text);
                parametro.Add("fecha", txtFecha.Text);
                parametro.Add("horario", txtHorario.Text);
                parametro.Add("usuario", txtUsuario.Text);

                
                cliente.UploadValues("http://192.168.1.43/moviles/post.php", "PUT", parametro);

               
                //await DisplayAlert("Alerta", "Ingreso Exitoso", "Ok");
                var mensaje = "Registro modificado exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                


                 
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "Error" );
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);
            }



            ///////metodo 3
            ///

            
        }

        private async  void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}