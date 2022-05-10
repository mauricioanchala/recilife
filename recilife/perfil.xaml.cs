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


namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class perfil : ContentPage
    {
        private const string Url = "https://emma.apis.guabastudio.com/api/users/";
        private readonly HttpClient usuario = new HttpClient();
        private ObservableCollection<recilife.DatosUser> _user;
        

        public perfil(string strUsuario)
        {
            InitializeComponent();
            TxtUsuario.Text = strUsuario;


        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new home(TxtUsuario.Text));
        }

        private async void BtnMostrar_Clicked(object sender, EventArgs e)
        {
            //var content = await usuario.GetStringAsync(Url);
            //List<recilife.DatosUser> posts = JsonConvert.DeserializeObject<List<recilife.DatosUser>>(content);
            //_user = new ObservableCollection<recilife.DatosUser>(posts);
            TxtNombre.Text = "Hola";
        }
    }
}