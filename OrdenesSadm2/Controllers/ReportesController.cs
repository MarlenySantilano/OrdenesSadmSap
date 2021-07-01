using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OrdenesSadm2.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetMunicipios()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/SelMunicipios_SAP700");
            var model = JsonConvert.DeserializeObject<MunicipioModel.Application>(json);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetColonias(string CodigoDpto)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/SelColonias_SAP700?municipio=" + CodigoDpto);
            var model = JsonConvert.DeserializeObject<ColoniaModel.Application>(json);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> GetCalles(string Localidad, string CodigoDpto)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/SelCalles_SAP700?colonia=" + Localidad + "&citycode=" + CodigoDpto);
            var model = JsonConvert.DeserializeObject<CalleModel.Application>(json);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> InsertReport(string Sub_Cat, string Municipio, string Colonia, string Calle, string Puerta, string Email, string Comentario)
        {
            var httpClient = new HttpClient();
            var values = new Dictionary<string, string>();
            values.Add("Sub_Cat", Sub_Cat);
            values.Add("Municipio", Municipio);
            values.Add("Colonia", Colonia);
            values.Add("Calle", Calle);
            values.Add("Puerta", Puerta);
            values.Add("Email", Email);
            values.Add("Comentario", Comentario);
            var content = new FormUrlEncodedContent(values);
            // var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/OrdenDeServicioDireccionSAP700?Sub_Cat=" + Sub_Cat + "&Municipio=" + Municipio + "&Colonia=" + "Santa Catarina" + "&Calle=" + "Pedro n Perales" + "&Puerta=" + Puerta + "&Email=" + Email + "&Comentario=" + Comentario);

            var httpResponseMessage = await httpClient.PostAsync("https://ayd.sadm.gob.mx/appiV3/OrdenDeServicioDireccionSAP700?Sub_Cat=" + Sub_Cat + "&Municipio=" + Municipio + "&Colonia=" + Colonia + "&Calle=" + Calle + "&Puerta=" + Puerta + "&Email=" + Email + "&Comentario=" + Comentario, content);
            var content2 = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var model = JsonConvert.DeserializeObject<ResModelReport.Application>(content2);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);

        }
        public async Task<JsonResult> InsertReportNir(string Comentario, string Contrato, string Correo,  string SubCatego)
        {
     
            var httpClient = new HttpClient();
            var values = new Dictionary<string, string>();
            values.Add("Sub_Cat", SubCatego);
            var content = new FormUrlEncodedContent(values);
            // var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/OrdenDeServicioDireccionSAP700?Sub_Cat=" + Sub_Cat + "&Municipio=" + Municipio + "&Colonia=" + "Santa Catarina" + "&Calle=" + "Pedro n Perales" + "&Puerta=" + Puerta + "&Email=" + Email + "&Comentario=" + Comentario);

            var httpResponseMessage = await httpClient.PostAsync("https://ayd.sadm.gob.mx/appiV3/OrdenDeServicioContratoSAP700?Comentario=" + Comentario + "&Contrato=" + Contrato + "&Correo=" + Correo + "&SubCatego=" + SubCatego, content);
            var content2 = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var model = JsonConvert.DeserializeObject<ResModelReport.Application>(content2);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);

        }
        public async Task<JsonResult> GetContratoDetalle(string contrato)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://ayd.sadm.gob.mx/appiV3/SelSaldosContrato?contrato=" + contrato);
            var model = JsonConvert.DeserializeObject<ContratoModel.Application>(json);
            var resultados = model.Response.data;
            return this.Json(resultados, JsonRequestBehavior.AllowGet);
        }
    }
}