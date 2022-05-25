using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class solicitudAdd : ContentPage
    {
        public solicitudAdd(string strUsuario)
        {
            InitializeComponent();
            LblUser.Text = strUsuario;

        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home(LblUser.Text));
        }

        private  async void BthLocalizar_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable) //Si el servicio existe en el dispositivo
            {
                if (locator.IsGeolocationEnabled) //Si el GP esta activo
                {
                    if (!locator.IsListening) //Comprueba si el dispositivo esta actualmente escuchando el servicio
                    {
                        //await locator.StartListeningAsync();

                        var position = await locator.GetPositionAsync(new TimeSpan(10000)); 

                        TxtLatitud.Text = position.Latitude.ToString();
                        TxtLongitud.Text = position.Longitude.ToString();

                    }
                }
            }
           


        }

       
    }
}