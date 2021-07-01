using System;
using System.Collections.Generic;

namespace OrdenesSadm2.Controllers
{
    public class MunicipioModel
    {
        public class Data
        {
            public string COD_DEPTO { get; set; }
            public string NOM_DEPTO { get; set; }

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