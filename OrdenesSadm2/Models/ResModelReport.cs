namespace OrdenesSadm2.Controllers
{
    internal class ResModelReport
    {
        public class Data
        {
            public string folio { get; set; }
            public string CodReturn { get; set; }

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