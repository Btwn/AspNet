using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acceso.Models;

namespace Acceso.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Validar()
        {

            return View();

        }
      
        [HttpPost]
        public ActionResult Validar(string usuario, string pass)
        {

            Validacion val = new Validacion();
            Usuario usua = val.Recuperar(usuario, pass);

            if (usua.ac)
            {
                if (usua.rol == "Maestro")
                {
                    Session["usuario"] = usua.usuario;
                    return View("Validar");
                }
                else
                {
                    return View("Alumno");
                }
               
            }
            else
            {
                return View("Index");
            }
            

        }
        [Authorize]
        public ActionResult Alumno()
        {

            return View();

        }
    }
}