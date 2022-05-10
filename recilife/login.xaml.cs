using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }

        private async void BtnAbrir_Clicked(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string clave = TxtPass.Text;
            if (usuario == "abc" && clave == "12345")
            {
                await Navigation.PushAsync(new home(TxtUsuario.Text));

            }
            else
            {
                //string fecha=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                await DisplayAlert("Error","Usuario Incorrecto" , "Aceptar");
            }
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registrarse());

        }

        private void BtnGoogle_Clicked(object sender, EventArgs e)
        {

        }

        /*private async void BtnAbrir_Clicked(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string clave = TxtPass.Text;
            if (usuario == "estudiante2021" && clave == "uisrael2021")
            {
                //await Navigation.PushAsync(new login(TxtUsuario.Text, TxtPass.Text));
            }
            else
            {
                DisplayAlert("Error", "Usuario Incorrecto", "Aceptar");
            }
        }*/

    }
}