using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Security.Policy;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;

namespace InmueblateWeb.Helpers
{
    public static class MenuHelpers
    {
        public static Service servicio = new Service();

        public static IHtmlString MenuCabeceraUsuario(this HtmlHelper helper, string opción = "home")
        {
            string menu = "";
            string nombre = (string)HttpContext.Current.Session["nombreUsuario"] + " " +
                            (string)HttpContext.Current.Session["apellUsuario"];
            int id_sesion = (int)HttpContext.Current.Session["idUsuario"];

            IList<PeticionAmistadEN> l_peticiones = servicio.NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmistadEstado(id_sesion,(int)NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente,0);
            string num_pet;
            if (l_peticiones != null && l_peticiones.Count > 0) num_pet = l_peticiones.Count.ToString();
            else num_pet = " ";

            menu += helper.ActionLink(num_pet.ToString(), "Index", "Peticion", new { id = id_sesion, area = "UsuariosPerfil" }, new { @class = "glyphicon glyphicon-user badge ico-ami" });
            menu += "<text>¡Hola, <strong>" + nombre + "</strong>!";
            menu += helper.ActionLink("Perfil", "Index", "HomeUSPE", new { id = id_sesion, area = "UsuariosPerfil" }, new { @class = " btn btn-link btnSalir" });
            menu += helper.ActionLink("Cerrar sesión", "LogOff", "Account", new { area = "" }, new { @class = " btn btn-link btnSalir" }) + "</text>";
            return helper.Raw(menu);
        }

        public static IHtmlString MenuIzquierdaUsuario(this HtmlHelper helper, string opcion = "home")
        {

            //object id_usuario = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];
            int id_usuario = (int)HttpContext.Current.Session["idUsuario"];
            string menu = "";

            menu += "<span class=\"navbar navbar-default col-lg-2 menuLateral\" role=\"navigation\"  style=\"\">";
            menu += "<h2 class=\"tituloMenu\">Menú</h2>";
            menu += "<ul id=\"menu-Lat\" class=\"nav nav-pills nav-stacked\">";

            menu += "<li" + (opcion == "ultimas" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Últimas Noticias", "Index", "HomeUS", new { id = id_usuario }, null) + "</li>";
            menu += "<li" + (opcion == "buscarin" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Buscar Inmobiliarias", "BuscarIn", "BusquedaUS", new { id = id_usuario }, null) + "</li>";
            menu += "<li" + (opcion == "buscarinm" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Buscar Inmuebles", "BuscarInmueble", "BusquedaUS", new { id = id_usuario }, null) + "</li>";
            menu += "<li" + (opcion == "buscaram" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Buscar Amigos", "BuscarAm", "BusquedaUS", new { id = id_usuario }, null) + "</li>";
            menu += "<li" + (opcion == "mensajes" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Mensajes", "Index", "MensajeUS", new { id = id_usuario }, null) + "</li>";
            menu += "<li" + (opcion == "galeria" ? " class=\"active\"" : "") + ">" + helper.ActionLink("Galeria", "Index", "Galeria", new { id = id_usuario, area = "UsuariosPerfil" }, null) + "</li>";
		    //menu += "<" + (opcion == "galeria" ? " class=\"active\"" : "") + "li>";
			//menu += "<fieldset>";
			//menu +=	"<legend class=\"tituloMenu\">Grupos <a href=\"\" class=\"lnk-addGurpos\">(+<span style=\"text-decoration:none;\"> Añadir</span>)</a></legend>";
			//menu +=	"<ul class=\"nav nav-pills nav-stacked\">";
			//menu +=	"<li><a href=\"#\">Pisos San Vicente</a></li>";
			//menu +=	"<li><a href=\"#\">Pisos Alicante</a></li>";
			//menu +=	"</ul>";
			//menu += "</fieldset>";
		    //menu += "</li>";
	        menu += "</ul>";
            menu +="</span>";

            return helper.Raw(menu);
        }

        public static IHtmlString MenuIzquierdaUsuarioPerfil(this HtmlHelper helper, string opcion = "home", string ruta = "")
        {
            string menu = "";
            object id_usuario = HttpContext.Current.Request.RequestContext.RouteData.Values["id"];
            int id_sesion = (int)HttpContext.Current.Session["idUsuario"];
            IList<UsuarioEN> l_amigos = servicio.NuevoInmueblate_Usuario_ObtenerAmigos(int.Parse(id_usuario.ToString()), -1);
            
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(int.Parse(id_usuario.ToString()));
            FotografiaEN fotPerfil = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(usuEN.Id);
            UsuarioEN sesEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id_sesion);
            bool mostrar = false;
            if (int.Parse(id_usuario.ToString()) == id_sesion) mostrar = true;
            else if (l_amigos.Count > 0 && l_amigos.Contains(sesEN)) mostrar = true;

            menu += "<div id=\"menu-Lat\" class=\"navbar navbar-default col-md-2 menuPerfil menuLateral\" role=\"navigation\">";
            menu += "<ul class=\"nav nav-pills nav-stacked\">";
       
            menu += "<li class=\"menu-iz\"><img src=\"" + ruta + fotPerfil.URL  + "\" alt=\"foto\" class=\"img-perfil-menu\"/></li>";
            menu += "<li class=\"menu-iz\"><span>" + helper.ActionLink(usuEN.Nombre + " " + usuEN.Apellidos, "Index", "HomeUSPE", null, null) + "</span></li>";
            //menu += "<li>" + id_usuario.ToString() + "</li>";
            menu += "<li" + (opcion == "perfil" ? " class=\"active\"" : "") + ">" + 
                helper.ActionLink("Perfil","Index","Perfil",null,null) + "</li>";
            if (mostrar)
            {
                menu += "<li" + (opcion == "galeria" ? " class=\"active\"" : "") + ">" +
                        helper.ActionLink("Galería","Index","Galeria",null,null) +"</li>";
            
                menu += "<li" + (opcion == "amigos" ? " class=\"active\"" : "") + ">" +
                        helper.ActionLink("Amigos", "Index", "Amigos", null, null) + "</li>";
            }
            menu += "<li" + (opcion == "valoracion" ? " class=\"active\"" : "") + ">" +
                    helper.ActionLink("Valoraciones", "Index", "Valoracion", null, null) + "</li>";
            menu += "</ul>";
            menu += "</div>";

            return helper.Raw(menu);
        }
        public static IHtmlString AnunciosSide(this HtmlHelper helper)
        {
            string aside = "";

            AnuncioCEN anuncioCEN = new AnuncioCEN();
           IList<AnuncioEN> anuncio=anuncioCEN.ObtenerAnunciosRandom(1);

           aside = " <asp:HyperLink id=\"hyperlink1\" runat=\"server\" NavigateUrl=\"http://" + anuncio[0].URL + "\"><img alt=\"" + anuncio[0].Descripcion + "\" style=\"width:120px;\" src=\"/img/anuncios/" + anuncio[0].Id + ".jpg\"/></asp:HyperLink>";

            var url =anuncio[0].URL;

            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", "/img/anuncios/" + anuncio[0].Id + ".jpg");
            imgBuilder.MergeAttribute("alt", anuncio[0].Descripcion);
            string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", "http://"+url);
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
            
            
            
            //return helper.Raw(aside);
        }

    }
}