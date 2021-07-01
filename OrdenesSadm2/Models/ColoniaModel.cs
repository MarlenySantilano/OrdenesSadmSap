using System.Collections.Generic;

namespace OrdenesSadm2.Controllers
{
    public class ColoniaModel
    {
        public class Data
        {
            public string COD_LOCAL { get; set; }
            public string NOM_LOCAL { get; set; }

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