using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {

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


                cliente.UploadValues("http://192.168.1.43/moviles/post.php","POST", parametro);
                //await DisplayAlert("Alerta", "Ingreso Exitoso", "Ok");
                var mensaje = "Dato ingresado Exitosamnte";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                // Limpiar textos
                txtCodigo.Text = "";
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
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "Error" );
                DependencyService.Get<Mensaje>().ShortAlert("Error");
            }



        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}