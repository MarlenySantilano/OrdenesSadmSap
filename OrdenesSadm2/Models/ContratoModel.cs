using System.Collections.Generic;

namespace OrdenesSadm2.Controllers
{
    public class ContratoModel
    {
        public class Data
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Partner { get; set; }
            public string Vkont { get; set; }
            public string NIS { get; set; }
            public string Vencimiento { get; set; }
            public string Nir { get; set; }
            public string Fecha_Venc { get; set; }
            public string v_totaladeu { get; set; }

        }
        public class Response
        {
            public Data data { get; set; }

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