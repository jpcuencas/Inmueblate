using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Areas.Inmobiliaria.Controllers
{
    public class HomeINController : Controller
    {
        //
        // GET: /Inmobiliaria/HomeIN/

        Service servicio = new Service();


        EntradaCP entCP = new EntradaCP();
        GaleriaCP galCP = new GaleriaCP();
        UsuarioCP usuCP = new UsuarioCP();

        public ActionResult Index(int id)
        {
            @ViewBag.Titulo = "Página de la inmobiliaria";
            int usuario = id;
            ViewBag.opcionMenu = "ultimas";
            //if(usuario != (int)Session["idUsuario"])
            //{
            @ViewBag.IdUsuario = (int)Session["idUsuario"];
            List<EntradaEN> entradas = entCP.ultimas5Entradas1(id);
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
       
                if (en.Creador != null)
                    l_usu_ent.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(en.Creador.Id));
                else l_usu_ent.Add(inm);
            }
            ViewBag.FotosEnt = l_foto;
            ViewBag.Usuarios = l_usu_ent;
            //}
            
            return View();
        }
       /* public ActionResult Mensajes(int id)
        {
            @ViewBag.Titulo = "Página de mensajes";
            ViewBag.opcionMenu = "mensajes";
            int usuario = id;
            try
            {
                if (usuario != (int)Session["idUsuario"])
                {

                    IList<MensajeEN> mens = servicio.NuevoInmueblate_Mensaje_ObtenerMensajesPorUsuario(id,0);
                    if (mens != null) @ViewBag.Mensajes = mens;
                    else @ViewBag.Mensajes = null;
                    return View();
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }*/

        public ActionResult Galeria(int id)
        {
            @ViewBag.Titulo = "Página para galeria de pisos";
            ViewBag.opcionMenu = "galeria";

            return View();
        }
        [HttpPost]
        public ActionResult NuevaEntrada(InmueblateWeb.Models.Entrada collection)
        {
            try
            {
            
                MuroEN muro = servicio.NuevoInmueblate_Muro_ObtenerMuroPorUsuario((int)Session["idUsuario"]);
                servicio.NuevoInmueblate_Entrada_CrearEntrada(DateTime.Now, collection.Titulo, collection.Cuerpo, false, muro.Id, (int)Session["idUsuario"]);

                return RedirectToAction("Index", "HomeIN", new { id = (int)Session["idUsuario"] });
            }
            catch
            {
                return RedirectToAction("Index", "HomeIN", new { id = (int)Session["idUsuario"] });
            }
            
                
            


        }

    }
}
