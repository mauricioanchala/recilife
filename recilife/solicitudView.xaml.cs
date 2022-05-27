using Newtonsoft.Json;
using recilife.Ws;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recilife
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class solicitudView : ContentPage
    {

        private ObservableCollection<DatosSolicitud> datos;


        public solicitudView(string strUsuario)
        {
            InitializeComponent();
            LblUser.Text = strUsuario;
        }

        private void BtnConsultar_Clicked(object sender, EventArgs e)
        {
            var person = new recilife.Ws.EmailUser();
            person.email = LblUser.Text;

            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://emma.apis.guabastudio.com/api/RequestInformationProcessEmail/";
            var client = new HttpClient();

            var response = client.PostAsync(url, data);

            string result = response.Result.Content.ReadAsStringAsync().Result;

            List<DatosSolicitud> post = JsonConvert.DeserializeObject<List<DatosSolicitud>>(result);
            datos = new ObservableCollection<DatosSolicitud>(post);

            MyListView.ItemsSource = datos;
        }
    }
}