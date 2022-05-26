using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registrarse : ContentPage
    {
        private String fecha = DateTime.Now.ToString("yyyy-MM-dd");

        public registrarse()
        {
            InitializeComponent();
        }

        private async void BtnInsertar_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                WebClient usuario = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("id", "1");
                parametros.Add("name", TxtNombre.Text);
                parametros.Add("last_name", TxtApellido.Text);
                parametros.Add("email", TxtCorreo.Text);
                parametros.Add("password", TxtClave.Text);
                parametros.Add("created", fecha);
                parametros.Add("active","true");
                parametros.Add("id_session_type","1");
                parametros.Add("id_user_type","2");
                parametros.Add("imagen","0");
                parametros.Add("bussines_name","");
                parametros.Add("identifiacion_ruc",TxtIdentificacion.Text);
                parametros.Add("telephone",TxtTelefono.Text);
                parametros.Add("mobile_number",TxtTelefono.Text);
                parametros.Add("calification","5");
                parametros.Add("update", fecha);
                parametros.Add("user_id",TxtUsuario.Text);
                parametros.Add("token","12345");
                parametros.Add("field1","");
                parametros.Add("field2","");
                usuario.UploadValues("https://emma.apis.guabastudio.com/api/users", "POST",parametros);
                await DisplayAlert("Alerta","Usuario Registrado","OK");
                await Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta","Error: " + ex.Message, "OK");
            }

        }

        private async void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}