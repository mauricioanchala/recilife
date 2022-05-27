using System;
using System.Collections.Generic;
using System.Text;

namespace recilife.Ws
{
    public class DatosUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        //public DateTime created { get; set; }
        public bool active { get; set; }
        public int id_session_type { get; set; }
        public int id_user_type { get; set; }
        //public string imagen { get; set; }
        //public string bussines_name { get; set; }
        public string identification_ruc { get; set; }
        public string telephone { get; set; }
        public string mobile_number { get; set; }
        public int calification { get; set; }
        //public DateTime updated { get; set; }
        public string user_id   { get; set; }
        //public string token { get; set; }
    }

    public class EmailUser
    {
        public string email { get; set; }
    }

}
