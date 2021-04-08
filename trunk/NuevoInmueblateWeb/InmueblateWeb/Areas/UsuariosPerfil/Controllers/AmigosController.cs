using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGen_NuevoInmueblateLocal;

namespace InmueblateWeb.Areas.UsuariosPerfil.Controllers
{
    public class AmigosController : Controller
    {
        Service servicio = new Service();

        UsuarioCP usuCP = new UsuarioCP();
        int pag_amig_ac = 0;
        int pag_amig_tam = 3;
        IList<string> l_foto_perfil = new List<string>();
        

        public ActionResult Index(int id)
        {
            ViewBag.opcionMenu = "amigos";
            bool mio = true;
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);
            if (id == (int)Session["idUsuario"])
            {
                ViewBag.Mios = true;
                ViewBag.Titulo = "Mis Amigos";
            }
            else
            {
                mio = false;
                ViewBag.Mios = false;
                ViewBag.Titulo = "Amigos de " + usuEN.Nombre;
                IList<UsuarioEN> l_amig_com = null;
                l_amig_com = servicio.NuevoInmueblate_Usuario_ObtenerAmigos(id, pag_amig_ac);
                UsuarioEN usuSEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                if (!l_amig_com.Contains(usuSEN)) return RedirectToAction("Index","HomeUSPE");
            } 
   
            IList<UsuarioEN> l_amig = null;
            l_amig = servicio.NuevoInmueblate_Usuario_ObtenerAmigos(id, pag_amig_ac);
            pag_amig_ac += 3;
            ViewBag.Tam = pag_amig_ac;
            l_amig.OrderBy(a => a.Apellidos);
            ViewBag.Amigos = l_amig;

            foreach (UsuarioEN us in l_amig)
            {
                string ruta = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(us.Id).URL;

                l_foto_perfil.Add(ruta);
            }
            ViewBag.FotosPerfil = l_foto_perfil;

            if (l_amig.Count == 0)
            {
                if (mio) ViewBag.SinAmigos = "No tienes amigos";
                else ViewBag.SinAmigos = usuEN.Nombre + "no tiene amigos";
            }

            if (l_amig.Count < 10)
            {
                ViewBag.Visible = false;
            }
            else
            {
                IList<UsuarioEN> l_amig_aux = null;
                l_amig_aux = servicio.NuevoInmueblate_Usuario_ObtenerAmigos(id, pag_amig_ac + 10);
                if (l_amig_aux.Count > 0)
                {
                    ViewBag.Visible = true;
                }
                else
                {
                    ViewBag.Visible = false;
                }
            }

            return View();
        }

        public ActionResult eliminarAmigoAviso(int id)
        {
            ViewBag.opcionMenu = "amigos";
            ViewBag.TiutloEA = "Eliminar";
            ViewBag.Usuario = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);

            return View();
        }

        public ActionResult elminarAmigo(int id)
        {
            ViewBag.opcionMenu = "amigos";
            if (servicio.BorrarUsuariosListaAmigosCP((int)Session["idUsuario"], id) != -1);

            return RedirectToAction("Index", new { id = (int)Session["idUsuario"]});
        }

    }
}
