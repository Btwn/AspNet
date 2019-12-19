using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


       

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usu, string pass)
        {
            ABMAgenda ag = new ABMAgenda();
            Usuario usuario = ag.Validacontacto(usu, pass);

            if (usuario.acc)
            {
                if (usuario.rol == "Administrador")
                {
                    Session["usuario"] = usuario.usuario;
                   return  RedirectToAction("Index");
                }
                else
                {
                    Session["usuario"] = usuario.usuario;
                    return View("User");
                    
                }
            }
            else
            {
                return View();
            }
            
        }
      


        public ActionResult Index()

        {
            ABMAgenda agenda = new ABMAgenda();
            return View(agenda.RecuperaContactos());
        }

        public ActionResult Alta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Alta (FormCollection collection)
        {
          
                ABMAgenda agenda = new ABMAgenda();
                Contacto cont = new Contacto
                {
                    NombreContacto = collection["NombreContacto"],
                    ApellidoPaterno = collection["ApellidoPaterno"],
                    ApellidoMaterno = collection["ApellidoMaterno"],
                    sexo = collection["sexo"],
                    direccion = collection["direccion"],
                    Referencia = collection["Referencia"],
                    telefono = collection["telefono"]
                };
                agenda.Alta(cont);
                return RedirectToAction("Index");
          
        }
      


        public ActionResult Baja(int Idcontacto)
        {
            ABMAgenda ag = new ABMAgenda();
            ag.Borrar(Idcontacto);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int Idcontacto)
        {
            ABMAgenda ag = new ABMAgenda();
            Contacto cont = ag.Recuperar(Idcontacto);
            return View(cont);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            ABMAgenda ag = new ABMAgenda();
            Contacto cont = new Contacto
            {
                Idcontacto = int.Parse(collection["Idcontacto"]),
                NombreContacto = collection["NombreContacto"],
                ApellidoPaterno = collection["ApellidoPaterno"],
                ApellidoMaterno = collection["ApellidoMaterno"],
                sexo = collection["sexo"],
                direccion = collection["direccion"],
                Referencia = collection["Referencia"],
                telefono = collection["telefono"]
            };
            ag.Modificar(cont);
            return RedirectToAction("Index");

        }

    }
}