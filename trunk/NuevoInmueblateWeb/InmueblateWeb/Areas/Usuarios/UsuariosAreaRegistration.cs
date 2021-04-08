using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InmueblateWeb.Areas.Usuarios
{
    public class UsuariosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Usuarios"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Usuarios_default",
                             "Usuarios/{controller}/{action}/{id}",
                             new { action = "Index", controller="HomeUS", id = UrlParameter.Optional });
        }
    }
}