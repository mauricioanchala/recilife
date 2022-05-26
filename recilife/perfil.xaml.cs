using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Specialized;
using recilife.Ws;
using Newtonsoft.Json.Linq;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class perfil : ContentPage
    {
        private DatosUser usuario;

        public perfil(string strUsuario)
        {
            InitializeComponent();

            usuario = new DatosUser();

            LoadUserByMail(strUsuario);

        }

        public async void LoadUserByMail(string strUsuario)
        {
            WebClient cliente = new WebClient();

            string Url = "https://emma.apis.guabastudio.com/api/usersByEmail";

            try
            {

                NameValueCollection parametros = new NameValueCollection
                {
                    { "email", strUsuario }
                };

                byte[] bytes = cliente.UploadValues(Url, "POST", parametros);

                string respuesta = Encoding.Default.GetString(bytes);

                JObject jsonInfo = JObject.Parse(respuesta);

                usuario = JsonConvert.DeserializeObject<DatosUser>(jsonInfo["message"][0].ToString());

                TxtUsuario.Text = usuario.user_id;
                TxtNombre.Text = usuario.name;
                TxtApellido.Text = usuario.last_name;
                TxtCorreo.Text = usuario.email;
                TxtTelefono.Text = usuario.telephone;
                TxtIdentificacion.Text = usuario.identification_ruc;
                TxtClave.Text = usuario.password;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "OK");
            }

        }

        public async void UpdateUser(DatosUser usuario)
        {
            HttpClient cliente = new HttpClient();

            string Url = "https://emma.apis.guabastudio.com/api/usersUpdate";

            try
            {
                var json = JsonConvert.SerializeObject(usuario);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(Url, data);

                await DisplayAlert("Actualización", "Registro Actualizado Correctamente", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "OK");
            }

        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            usuario.user_id = TxtUsuario.Text;
            usuario.name = TxtNombre.Text;
            usuario.last_name = TxtApellido.Text;
            usuario.email = TxtCorreo.Text;
            usuario.telephone = TxtTelefono.Text;
            usuario.identification_ruc = TxtIdentificacion.Text;
            usuario.password = TxtClave.Text;

            UpdateUser(usuario);


        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home(TxtCorreo.Text));
        }

        private void BtnMostrar_Clicked(object sender, EventArgs e)
        {
            TxtNombre.Text = "Hola";
        }
    }
}