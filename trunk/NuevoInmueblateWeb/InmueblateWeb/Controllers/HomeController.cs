using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGen_NuevoInmueblateLocal;

namespace InmueblateWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Service obt = new Service();
            
            ViewBag.Message = "¡Bienvenidos a Inmuéblate!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        
    }
}
