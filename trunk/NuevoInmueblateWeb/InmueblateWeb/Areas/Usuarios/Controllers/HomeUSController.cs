using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using InmueblateWeb.Models;

namespace InmueblateWeb.Areas.Usuarios.Controllers
{
    [Authorize]
    public class HomeUSController : Controller
    {
        //
        // GET: /Usuarios/HomeUS/

        Service servicio = new Service();


        EntradaCP entCP = new EntradaCP();
        GaleriaCP galCP = new GaleriaCP();
        UsuarioCP usuCP = new UsuarioCP();

        public ActionResult Index(int id)
        {
            @ViewBag.Titulo = "Página del usuario";
            int usuario = id;
            ViewBag.opcionMenu = "ultimas";
            //if(usuario != (int)Session["idUsuario"])
            //{
                @ViewBag.IdUsuario = (int)Session["idUsuario"];
            List<EntradaEN> entradas=entCP.ultimas5Entradas(id);
            ViewBag.Entradas = entradas;

            IList<string> l_foto = new List<string>();
            IList<UsuarioEN> l_usu_ent = new List<UsuarioEN>();
            UsuarioEN inm = new UsuarioEN();
            inm.Nombre = "Inmuéblate";
            inm.Apellidos = "";
            foreach (EntradaEN en in entradas)
            {
                //if (en.ElementosMultimedia != null)
                //   id_foto = en.ElementosMultimedia[0].Id;
                string url;
                if (en.Creador != null)
                    url = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(en.Creador.Id).URL;
                else url = "/default/inmueblate.png";
                if (en.Creador != null)
                    l_usu_ent.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(en.Creador.Id));
                else l_usu_ent.Add(inm);
                l_foto.Add(url);
            }
            ViewBag.FotosEnt = l_foto;
             ViewBag.Usuarios = l_usu_ent;
            //}
            return View();
        }
        
        public ActionResult Mensajes(int id)
        {
            @ViewBag.Titulo = "Página de mensajes";
            try
            {
            int usuario = id;
            ViewBag.opcionMenu = "mensajes";
            if (null != Session)
            {
                 return RedirectToAction("Index");
            }
            //TODO
            ViewBag.Mensaje = (List<MensajeEN>)servicio.NuevoInmueblate_Mensaje_ObtenerMensajesPorUsuario(usuario, 0);
            return View();
            }
            catch
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }
        }
        public ActionResult Galeria(int id)
        {
            @ViewBag.Titulo = "Página para galeria de pisos";

            int usuario = id;
            ViewBag.opcionMenu = "galeria";
            if (null != Session)
            {
                //TODO
                //ViewBag.Galeria = (List<GaleriaEN>)servicio.;


            }
            return View();
        }
        [HttpPost]
        public ActionResult NuevaEntrada(InmueblateWeb.Models.Entrada collection)
        {
            try
            {
               MuroEN muro= servicio.NuevoInmueblate_Muro_ObtenerMuroPorUsuario((int)Session["idUsuario"]);
               servicio.NuevoInmueblate_Entrada_CrearEntrada(DateTime.Now,collection.Titulo,collection.Cuerpo,false,muro.Id,(int)Session["idUsuario"]);

               return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });

            }
            catch 
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }

           
        }

    }
}
