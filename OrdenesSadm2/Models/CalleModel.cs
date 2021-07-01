using System;
using System.Collections.Generic;

namespace OrdenesSadm2.Controllers
{
    public class CalleModel
    {
        public class Data
        {
            public string COD_CALLE { get; set; }
            public string NOM_CALLE { get; set; }
            public string COD_AREA { get; set; } 
            public string COD_LOCAL { get; set; }

        }
        public class Response
        {
            public IList<Data> data { get; set; }

        }
        public class Application
        {
            public bool success { get; set; }
            public bool error { get; set; }
            public string message { get; set; }
            public Response Response { get; set; }

        }
    }
}