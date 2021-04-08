using System.Web.Mvc;

namespace InmueblateWeb.Areas.InmobiliariaPerfil
{
    public class InmobiliariaPerfilAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "InmobiliariaPerfil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "InmobiliariaPerfil_default",
                "InmobiliariaPerfil/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
