using Newtonsoft.Json;
using recilife.Ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly WebClient cliente = new WebClient();

        private const string Url = "https://emma.apis.guabastudio.com/api/login";

        private const int UserType = 2;
        public Login()
        {
            InitializeComponent();
        }

        private async void BtnAbrir_Clicked(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string clave = TxtPass.Text;

            try
            {
                NameValueCollection parametros = new NameValueCollection
                {
                    { "email", usuario },
                    { "password", clave },
                    { "userType", UserType.ToString() }
                };

                byte[] bytes = cliente.UploadValues(Url, "POST", parametros);
                
                string respuesta = Encoding.Default.GetString(bytes);

                RespuestaGenerica respuestaGenerica = JsonConvert.DeserializeObject<RespuestaGenerica>(respuesta);


                if (respuestaGenerica.State == 1)
                {
                    await Navigation.PushAsync(new home(usuario));

                }
                else
                {
                    await DisplayAlert("Error", "Usuario Incorrecto", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "OK");
            }
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registrarse());

        }

        private void BtnGoogle_Clicked(object sender, EventArgs e)
        {

        }

    }
}