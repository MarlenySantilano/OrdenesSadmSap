using OrdenesSadm2.Filters;
using OrdenesSadm2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrdenesSadm2.Controllers
{
        public class UsuariosController : Controller
        {

        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            using (OrdenReporteEntities1 entities = new OrdenReporteEntities1())
            {
                List<Usuario> usuario_values = entities.Usuarios.ToList();

                //Add a Dummy Row.
                usuario_values.Insert(0, new Usuario());
                return View(usuario_values.ToList());
            }
        }
      
        [HttpPost]
        public ActionResult  InsertUsuario(Usuarios usuario_values)
        {
            EncryptPassword ep = new EncryptPassword();
            string p = ep.Encrypt(usuario_values.password);
            using (OrdenReporteEntities1 entities = new OrdenReporteEntities1())
            {
                entities.SP_Insert_Usuario(usuario_values.nombre, usuario_values.email,p);
            }

            return new EmptyResult();
        }


        public JsonResult Obtener_Usuarios()

        {
            try
            {
                using (OrdenReporteEntities1 entities = new OrdenReporteEntities1())
                {
                    //   List<TransaccionesHistorial> historialT = new List<TransaccionesHistorial>();


                    var head = entities.SP_Select_Usuarios().ToList();

                    EncryptPassword ep = new EncryptPassword();
                    string pass = "";
                    var res = (from r in head
                               select new

                               {

                                   r.id,
                                   r.nombre,
                                   r.email,
                                   pass = ep.Decrypt(r.password)

                               });

                    return Json(res, JsonRequestBehavior.AllowGet);
                }


            }

            catch (Exception exp)

            {
                throw;
            }

        }


        [HttpPost]
        public ActionResult UpdateUsuario(Usuario user_values)
        {
            EncryptPassword ep = new EncryptPassword();
            string p = ep.Encrypt(user_values.password);

            using (OrdenReporteEntities1 entities = new OrdenReporteEntities1())
            {
                entities.SP_Update_Usuario(user_values.id, user_values.nombre, user_values.email, p);
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteUsuario(int id)
        {
            using (OrdenReporteEntities1 entities = new OrdenReporteEntities1())
            {
                entities.SP_Delete_Usuario(id);
            }

            return new EmptyResult();
        }
    }
}