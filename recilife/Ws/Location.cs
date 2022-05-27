using System;
using System.Collections.Generic;
using System.Text;

namespace recilife.Ws
{
    public class Location
    {
        //public int id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public string description { get; set; }

        public string reference { get; set; }

        public Boolean active { get; set; }
        public DateTime created { get; set; }
    }
}
