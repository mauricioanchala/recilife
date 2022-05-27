using System;
using System.Collections.Generic;
using System.Text;

namespace recilife.Ws
{
    internal class DatosSolicitud
    {
        public string amount { get; set; }
        public int calification { get; set; }
        public string commentary { get; set; }
        //public DateTime created { get; set; }
        public string distance { get; set; }
        public int id { get; set; }
        //public int id_state { get; set; }
        public string stateuser { get; set; }
        //public int id_state_recycler { get; set; }
        //public int staterecycler { get; set; }
        //public int id_user_recycler { get; set; }
        public int id_user_request { get; set; }
        //public DateTime updated { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
    }

}