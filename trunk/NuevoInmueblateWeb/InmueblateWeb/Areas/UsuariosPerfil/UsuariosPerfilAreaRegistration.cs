using System.Web.Mvc;

namespace InmueblateWeb.Areas.UsuariosPerfil
{
    public class UsuariosPerfilAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UsuariosPerfil";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("UsuariosPerfil_default",
                             "UsuariosPerfil/{id}/{controller}/{action}",
                             new { action = "Index", controller = "HomeUSPE", id = UrlParameter.Optional, ga = UrlParameter.Optional});
            
            //context.MapRoute("UsuariosPerfil_Amigos",
            //                 "UsuariosPerfil/{controller}/{action}/{id}",
            //                 new { action = "Index", controller = "Amigos", id = UrlParameter.Optional });

            //context.MapRoute("UsuariosPerfil_Valoracion",
            //                 "UsuariosPerfil/{controller}/{action}/{id}",
            //                 new { action = "Index", controller = "Valoracion", id = UrlParameter.Optional });
        }
    }
}
