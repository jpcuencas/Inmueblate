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
    public class MensajeUSController : Controller
    {
        //
        // GET: /Usuarios/MensajeUS/
        Service servicio = new Service();


        MensajeCP entCP = new MensajeCP();
        UsuarioCP usuCP = new UsuarioCP();


        /*public ActionResult Index()
        {
            return RedirectToAction("Index","HomeUS");
        }*/
        public ActionResult Index(int id)
        {
            try
            {
            ViewBag.opcionMenu = "mensajes";
                if (null != Session)
                {
                    /*
                     //IList<MensajeEN> mensajes = servicio.NuevoInmueblate_Mensaje_ObtenerMensajesPorUsuario(id, 0);
                    IList<MensajeEN> mensajes = servicio.NuevoInmueblate_Mensaje_DameMensajeFiltro(null,null,null,false,false,id,-1,0,-1);
                    mensajes.Concat(servicio.NuevoInmueblate_Mensaje_DameMensajeFiltro(null,null,null,false,false,-1,id,0,-1));
                    List<SuperUsuarioEN> usuarios = new List<SuperUsuarioEN>();
                    for (int i = 0; i < mensajes.Count; i++)
                    {
                        if (mensajes[i].Emisor != null)
                        {
                            usuarios.Add(mensajes[i].Emisor);
                        }
                        if (mensajes[i].Receptor!= null)
                        {
                            usuarios.Add(mensajes[i].Receptor);
                        }
                    }*/

                   IList<UsuarioEN> amigos= servicio.NuevoInmueblate_Usuario_ObtenerAmigos(id,0);
                   IList<InmobiliariaEN> inmobiliarias = servicio.NuevoInmueblate_Inmobiliaria_DameTodasLasInmobiliarias(0,-1);
                    List<string> emails = new List<string>();
                    List<string> emails2 = new List<string>();
                    for (int i = 0; i < amigos.Count; i++)
                    {
                        emails.Add(amigos[i].Email);
                    }
                    for (int j = 0; j < amigos.Count; j++)
                    {
                        emails2.Add(inmobiliarias[j].Email);
                    }
                    //ViewBag.Usuarios = usuarios;
                    ViewBag.Amigos = emails;
                    ViewBag.Inmobiliarias= emails2;
                    IList<MensajeEN> entrada = servicio.NuevoInmueblate_Mensaje_DameMensajeFiltro(null, null, null, false, false, (int)Session["idUsuario"], -1, 0, -1);
                    IList<MensajeEN> salida = servicio.NuevoInmueblate_Mensaje_DameMensajeFiltro(null, null, null, false, false, -1, (int)Session["idUsuario"], 0, -1);
                    ViewBag.salida=salida.OrderByDescending(e => e.FechaEnvio).ToList();
                  //ViewBag.salida = salida.Reverse();
                    ViewBag.entrada=entrada.OrderByDescending(e => e.FechaEnvio).ToList();
                    //ViewBag.entrada = entrada.Reverse();
                        return View();
                }
                else
                    return RedirectToAction("Index", "HomeUS", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }
           
           
        }

        public ActionResult Mensajes(int id)
        {
            ViewBag.opcionMenu = "mensajes";
                    if (null != Session)
                    {

                        return View();
                    }
                    else
                        return RedirectToAction("Index", "MensajeUS", new { id = id });
                }

        public ActionResult EnviarMensaje(Mensaje mensaje)
        {
            try
            {
            string email = mensaje.Receptor;
            if (email != null)
            {
                SuperUsuarioEN recep = servicio.NuevoInmueblate_SuperUsuario_ObtenerUsuarioPorEmail(email);
                if (mensaje.Asunto != null)
                {
                    if (mensaje.Cuerpo != null)
                        servicio.NuevoInmueblate_Mensaje_CrearMensaje(true, DateTime.Now, mensaje.Asunto, mensaje.Cuerpo, false, (int)Session["idUsuario"], recep.Id);
                }
             }
                return RedirectToAction("Index", "MensajeUS", new { id = (int)Session["idUsuario"] });
            }
            catch
            {
                return RedirectToAction("Index", "MensajeUS", new { id = (int)Session["idUsuario"] });
            }
        }
        public ActionResult EnviarMensaje2(Mensaje mensaje)
        {
            try
            {
                string email = mensaje.Receptor;
                if (email != null)
                {
                    InmobiliariaEN inmobiliaria = new InmobiliariaEN();
                    IList<InmobiliariaEN> recep = servicio.NuevoInmueblate_Inmobiliaria_DameTodasLasInmobiliarias(0,-1);
                     bool control = true;
                     for (int i = 0; (i < recep.Count)&&control; i++)
                     {
                         if (recep[i].Email == email)
                         {
                             inmobiliaria = recep[i];
                             control = false;
                         }
                     }
                    if (mensaje.Asunto != null)
                    {
                        if (mensaje.Cuerpo != null)
                            servicio.NuevoInmueblate_Mensaje_CrearMensaje(true, DateTime.Now, mensaje.Asunto, mensaje.Cuerpo, false, (int)Session["idUsuario"], inmobiliaria.Id);
                    }
                }
                return RedirectToAction("Index", "MensajeUS", new { id = (int)Session["idUsuario"] });
            }
            catch
            {
                return RedirectToAction("Index", "MensajeUS", new { id = (int)Session["idUsuario"] });
            }
        }    
        
    }
}
