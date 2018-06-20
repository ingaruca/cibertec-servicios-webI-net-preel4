using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ServicioWCF.ReferenceNegocios;

namespace ServicioWCF.Controllers
{
    public class NegociosController : Controller
    {
        ServiceNegociosClient service = new ServiceNegociosClient();

        // GET: Negocios
        public ActionResult Clientes()
        {
            return View(service.Clientes());
        }

        public ActionResult ClienteXNombre(string nombre)
        {
            ViewBag.nombre = nombre;

            return View(service.ClienteXNombre(nombre));
        }
    }
}