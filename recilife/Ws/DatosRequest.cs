using System;
using System.Collections.Generic;
using System.Text;

namespace recilife.Ws
{
    public class DatosRequest
    {
        public decimal amount { get; set; }
        public int calification { get; set; }
        public string commentary { get; set; }
        public DateTime created { get; set; }
        public string distance { get; set; }
        public int id_state { get; set; }
        public int id_user_request { get; set; }

    }
    public class StateRequest
    {

        public int state { get; set; }


    }
}
