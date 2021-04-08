using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using InmueblateWeb.Models;
using System.IO;

namespace InmueblateWeb.Areas.UsuariosPerfil.Controllers
{
    public class GaleriaController : Controller
    {
        Service servicio = new Service();

        public ActionResult Index(int id)
        {
            ViewBag.opcionMenu = "galeria";
            if (Session == null) //no existe sesión, redirigo a la página principal
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            bool mio = true;
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);
            if (id == (int)Session["idUsuario"])
            {
                ViewBag.Mios = true;
                ViewBag.Titulo = "Mis Galerias";
            }
            else
            {
                mio = false;
                ViewBag.Mios = false;
                ViewBag.Titulo = "Galería de " + usuEN.Nombre;
                IList<UsuarioEN> l_amig_com = null;
                l_amig_com = servicio.NuevoInmueblate_Usuario_ObtenerAmigosSP(id);
                UsuarioEN usuSEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                if (!l_amig_com.Contains(usuSEN)) return RedirectToAction("Index", "HomeUSPE");
            }
            IList<GaleriaEN> l_galerias = servicio.NuevoInmueblate_Galeria_ObtenerGaleriasPorUsuario(id, 0);
            IList<FotografiaEN> l_fotos = servicio.NuevoInmueblate_Fotografia_ObtenerFotografiasPorUsuario(id, 0);
            IList<VideoEN> l_videos = servicio.NuevoInmueblate_Video_ObtenerVideosPorUsuario(id, 0);

            ViewBag.Galerias = l_galerias;
            ViewBag.Fotos = l_fotos;
            ViewBag.Videos = l_videos;

            ViewBag.GalExist = l_galerias.Count > 0 ? "visible active" : "disabled";
            ViewBag.FotExist = l_fotos.Count > 0 ? "visible":"disabled";
            ViewBag.VidExist = l_videos.Count > 0 ? "visible" : "disabled";

            return View();
        }

        [HttpPost]
        public ActionResult Details(int id, int gal)
        {
            if (Session == null) //no existe sesión, redirigo a la página principal
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            ViewBag.opcionMenu = "galeria";
            bool mio = true;
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);
            if (id == (int)Session["idUsuario"])
            {
                ViewBag.Mios = true;
                ViewBag.Titulo = "Mis Galerias";
            }
            else
            {
                mio = false;
                ViewBag.Mios = false;
                ViewBag.Titulo = "Galería de " + usuEN.Nombre;
                IList<UsuarioEN> l_amig_com = null;
                l_amig_com = servicio.NuevoInmueblate_Usuario_ObtenerAmigosSP(id);
                UsuarioEN usuSEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                if (!l_amig_com.Contains(usuSEN)) return RedirectToAction("Index", "HomeUSPE");
            }
            ViewBag.Galeria = gal;
            IList<FotografiaEN> l_fotos = servicio.NuevoInmueblate_Fotografia_ObtenerFotosPorGaleria(gal, 0);

            ViewBag.Fotos = l_fotos;

            return View();
        }

        //
        // GET: /UsuariosPerfil/Galeria/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UsuariosPerfil/Galeria/Create

        [HttpPost]
        public ActionResult NuevaGaleria(int id,Galeria galeria)
        {
            try
            {
                int g = servicio.NuevoInmueblate_Galeria_CrearGaleria(-1, DateTime.Now, galeria.descripcion, galeria.nombre, false, "");
                IList<int> l_g = new List<int>();
                l_g.Add(g);
                servicio.NuevoInmueblate_Usuario_AnyadirElementosMultimedia(id, l_g);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /UsuariosPerfil/Galeria/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UsuariosPerfil/Galeria/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UsuariosPerfil/Galeria/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UsuariosPerfil/Galeria/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SubirImagen(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string ruta_usuario = "/ID" + Session["idUsuario"].ToString().PadLeft(4, '0');
                    ruta_usuario += "/Imagen";

                    string extension = fileName.Substring(fileName.IndexOf("."));
                    fileName = "f_" + String.Format("{0:yyyymmdd_hhmmss}", DateTime.Now) + extension;

                    var path = Path.Combine(Server.MapPath("~/img" + ruta_usuario), fileName);
                    
                    file.SaveAs(path);
                    ruta_usuario += "/" + fileName;
                    if (servicio.AnaydirFotoCP((int)Session["idUsuario"],-1, ruta_usuario, "Desc","Foto") != -1)
                        return RedirectToAction("Index");
                    //ModificarFotoPerfilCP
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult SubirImagenF(int gal, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string ruta_usuario = "/ID" + Session["idUsuario"].ToString().PadLeft(4, '0');
                    ruta_usuario += "/Imagen";

                    string extension = fileName.Substring(fileName.IndexOf("."));
                    fileName = "f_" + String.Format("{0:yyyymmdd_hhmmss}", DateTime.Now) + extension;

                    var path = Path.Combine(Server.MapPath("~/img" + ruta_usuario), fileName);

                    file.SaveAs(path);
                    ruta_usuario += "/" + fileName;
                    if (servicio.AnaydirFotoCP((int)Session["idUsuario"],gal, ruta_usuario, "Desc", "Foto") != -1)
                        return RedirectToAction("Index");
                    //ModificarFotoPerfilCP
                }
                ViewBag.Message = "Upload successful";
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Index");
            }
        }
    }
}
