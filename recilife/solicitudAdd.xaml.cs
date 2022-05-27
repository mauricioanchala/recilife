using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net;
using recilife.Ws;
using Newtonsoft.Json.Linq;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class solicitudAdd : ContentPage
    {
        private const string Url = "https://emma.apis.guabastudio.com/api/createRequest";
        private const string UrlPerfil = "https://emma.apis.guabastudio.com/api/usersByEmail";
        private const string UrlLocation = "https://emma.apis.guabastudio.com/api/createLocationuser";
        private string idUser;

        public solicitudAdd(string strUsuario)
        {
            InitializeComponent();
            LblUser.Text = strUsuario;

            loadInformation(LblUser.Text);

        }

        public async void loadInformation(string email)
        {
            HttpClient cliente = new HttpClient();
            var emailUser = new EmailUser();
            emailUser.email = LblUser.Text;

            var json = JsonConvert.SerializeObject(emailUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(UrlPerfil, data);
            string result = response.Content.ReadAsStringAsync().Result;
            JObject jsonInfo = JObject.Parse(result);
            string id = (string)jsonInfo["message"][0]["id"];
            idUser = id;
        }

        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            HttpClient cliente = new HttpClient();
            var datosRequest = new DatosRequest();
            datosRequest.amount = 0;
            datosRequest.calification = 5;
            datosRequest.commentary = TxtCommentary.Text;
            datosRequest.created = DateTime.Now;
            datosRequest.distance = "0";
            datosRequest.id_state = 1;//registro nuevo
            datosRequest.id_user_request = Convert.ToInt16(idUser);
            var json = JsonConvert.SerializeObject(datosRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(Url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home(LblUser.Text));
        }

        private async void BthLocalizar_Clicked(object sender, EventArgs e)
        {
            /*var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable) //Si el servicio existe en el dispositivo
            {
                if (locator.IsGeolocationEnabled) //Si el GP esta activo
                {
                    if (!locator.IsListening) //Comprueba si el dispositivo esta actualmente escuchando el servicio
                    {
                        //await locator.StartListeningAsync();

                        var position = await locator.GetPositionAsync(); 

                        TxtLatitud.Text = position.Latitude.ToString();
                        TxtLongitud.Text = position.Longitude.ToString();

                    }
                }
            }*/
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(null);
            Console.WriteLine("Position Status: {0}", position.Timestamp);
            Console.WriteLine("Position Latitude: {0}", position.Latitude);
            Console.WriteLine("Position Longitude: {0}", position.Longitude);
            TxtLatitud.Text = position.Latitude.ToString();
            TxtLongitud.Text = position.Longitude.ToString();


            /*HttpClient cliente = new HttpClient();
            var location = new Ws.Location();
            location.latitude = TxtLatitud.Text;
            location.longitude = TxtLongitud.Text;
            location.description = "ninguna";
            location.reference = "ninguna";
            location.active = true;
            location.created= DateTime.Now;

            var json = JsonConvert.SerializeObject(location);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync(UrlLocation, data);

            string result = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine();*/



        }


    }
}