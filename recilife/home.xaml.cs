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
    public partial class home : ContentPage
    {
        public home(string strUsuario)
        {
            InitializeComponent();
            LblUser.Text = strUsuario;
        }

        private async void BtnPerfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new perfil(LblUser.Text));
        }

        private async void BtnSolicitar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new solicitudAdd(LblUser.Text));
        }

        private async void BtnMisSolicitudes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new solicitudView(LblUser.Text));
        }

        private async void BtnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}