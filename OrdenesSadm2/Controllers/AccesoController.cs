using OrdenesSadm2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesSadm2.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            var SUser = Session["User"];

            if (SUser == null)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Login", "Acceso");
        }
        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            EncryptPassword ep = new EncryptPassword();
            string p = ep.Encrypt(Pass);
            try
            {
                var SUser = Session["User"];

                if (SUser == null)
                {

                    using (Models.OrdenReporteEntities1 db = new Models.OrdenReporteEntities1())
                    {
                        var oUser = (from d in db.Usuarios
                                     where d.email == User.Trim() && d.password == p
                                     select d).FirstOrDefault();


                        if (oUser == null)
                        {
                            ViewBag.Error = "Usuario o contraseña invalida";
                            return View();
                        }
                        else
                        {
                            Session["User"] = oUser;
                            Session["Id"] = oUser.id;
                            Session["Perfil"] = oUser.idRol;
                            Session["Nombre"] = oUser.nombre;
                            Session["Segmento"] = 0;
                            Session["Colaborador"] = 0;
                        }
                    }
                }
                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}