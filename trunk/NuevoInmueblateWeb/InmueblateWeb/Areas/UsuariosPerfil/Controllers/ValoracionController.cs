using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using InmueblateWeb.Models;

namespace InmueblateWeb.Areas.UsuariosPerfil.Controllers
{
    public class ValoracionController : Controller
    {
        Service servicio = new Service();
        ValoracionCP valCP = new ValoracionCP();
        //
        // GET: /UsuariosPerfil/Valoracion/

        public ActionResult Index(int id)
        {
            ViewBag.opcionMenu = "valoracion";
            int usuario = id;
            
            @ViewBag.ExisteValoracion = true;
            if (usuario != (int)Session["idUsuario"])
            {
                ViewBag.UsuarioSes = false;
                ValoracionEN val = servicio.NuevoInmueblate_Valoracion_ObtenerValoracionDeA((int)Session["idUsuario"], id);
                if (val != null) @ViewBag.ExisteValoracion = true;
                else @ViewBag.ExisteValoracion = false;
            }
            else ViewBag.UsuarioSes = true;
            IList<UsuarioEN> l_usu_rec = new List<UsuarioEN>();
            IList<UsuarioEN> l_usu_rea = new List<UsuarioEN>();
            IList<string> l_foto_rec = new List<string>();
            IList<string> l_foto_rea = new List<string>();
            UsuarioEN aux;
            @ViewBag.RecibidasV = "disabled";
            @ViewBag.RealizadasV = "disabled";
            IList<ValoracionEN> l_val_rec = servicio.NuevoInmueblate_Valoracion_ObtenerValoracionesReceptor(usuario, 0);
            IList<ValoracionEN> l_val_rea = servicio.NuevoInmueblate_Valoracion_ObtenerValoracionesEmisor(usuario, 0);

            if (l_val_rec.Count > 0)
            {
                @ViewBag.RecibidasV = "visible active";
                foreach (ValoracionEN val in l_val_rec)
                {
                    aux = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(val.Emisor.Id);
                    l_usu_rec.Add(aux);
                    string ruta = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(val.Emisor.Id).URL;
                    l_foto_rec.Add(ruta);
                }
            }
            if (l_val_rea.Count > 0)
            {
                @ViewBag.RealizadasV = "visible";
                foreach (ValoracionEN val in l_val_rea)
                {
                    aux = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(val.Receptor.Id);
                    l_usu_rea.Add(aux);
                    string ruta = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(val.Receptor.Id).URL;
                    l_foto_rea.Add(ruta);
                }
            }
            ViewBag.LValoracionesReci = l_val_rec;
            ViewBag.LValoracionesReal = l_val_rea;
            ViewBag.LUsuariosValRec = l_usu_rec;
            ViewBag.LUsuariosValRea = l_usu_rea;
            ViewBag.LFotosValRec = l_foto_rec;
            ViewBag.LFotosValRea = l_foto_rea;

            return View();
        }

        [HttpPost]
        public ActionResult Valorar(Valoracion model, int id)
        {
            valCP.CrearValoracion((int)Session["idUsuario"], id, model.valora, model.Descripcion);

            return RedirectToAction("Index", "Valoracion");
        }

        public ActionResult EliminarValoracion(int id)
        {
            try
            {
                valCP.EliminarValoracion((int)Session["idUsuario"], id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error eliminado valoraciones");
            }
            return RedirectToAction("Index", "Valoracion", new { id = (int)Session["idUsuario"]});
        }

    }
}
