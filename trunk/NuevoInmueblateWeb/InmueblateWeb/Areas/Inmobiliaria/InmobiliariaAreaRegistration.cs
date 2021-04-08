using System.Web.Mvc;

namespace InmueblateWeb.Areas.Inmobiliaria
{
    public class InmobiliariaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Inmobiliaria";}
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Inmobiliaria_default",
                             "Inmobiliaria/{controller}/{action}/{id}",
                             new { action = "Index", controller = "HomeIN", id = UrlParameter.Optional }
            );
        }
    }
}
