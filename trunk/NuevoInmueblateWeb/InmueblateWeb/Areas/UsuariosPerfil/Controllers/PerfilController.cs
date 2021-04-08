using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.Utils;
using InmueblateWeb.Models;
using System.IO;


namespace InmueblateWeb.Areas.UsuariosPerfil.Controllers
{
    public class PerfilController : Controller
    {
        Service servicio = new Service();
        //
        // GET: /UsuariosPerfil/Perfil/

        public ActionResult Index(int id)
        {
            ViewBag.opcionMenu = "perfil";
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);
            FotografiaEN fotPerfil = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(id);

            ViewBag.MostrarDatos = true;
            ViewBag.UsuarioSession = false;
            ViewBag.Usuario = usuEN;
            ViewBag.FotoPerfil = fotPerfil;
            if (id != (int)Session["idUsuario"])
            {
                IList<UsuarioEN> l_amig_com = null;
                l_amig_com = servicio.NuevoInmueblate_Usuario_ObtenerAmigos(id, -1);
                UsuarioEN sesEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                if (!l_amig_com.Contains(sesEN)) ViewBag.MostrarDatos = false;
            }
            else ViewBag.UsuarioSession = true;

            return View();
        }

        [HttpPost]
        public ActionResult cambiarFotoPerfil(int id)
        {
            return View();
        }

        //
        // GET: /UsuariosPerfil/Perfil/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UsuariosPerfil/Perfil/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UsuariosPerfil/Perfil/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index","Perfil");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /UsuariosPerfil/Perfil/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UsuariosPerfil/Perfil/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                UsuarioEN usu = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                
                usuario.privacidad = usu.Privacidad;
                usuario.gustos = usu.Gustos;

                int retorno = servicio.ModificarUsuarioCP((int)Session["idUsuario"],
                                                            usuario.nombre,
                                                            usuario.apellidos,
                                                            usuario.nif,
                                                            usuario.email,
                                                            usuario.direccion,
                                                            usuario.poblacion,
                                                            usuario.codigoPostal,
                                                            usuario.pais,
                                                            "",
                                                            usuario.telefono);

                if (retorno != -1)
                {
                    return RedirectToAction("Index", "HomeUSPE");
                }
 
                return RedirectToAction("Index","Perfil");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UsuariosPerfil/Perfil/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UsuariosPerfil/Perfil/Delete/5

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
                    fileName = "perfil_" + String.Format("{0:yyyymmdd_hhmmss}", DateTime.Now) + extension;
                    var path = Path.Combine(Server.MapPath("~/img" + ruta_usuario), fileName);
                    //if (!System.IO.Directory.Exists(path))
                    //{
                        //
                    //}
                    file.SaveAs(path);
                    ruta_usuario += "/" + fileName;
                    if (servicio.ModificarFotoPerfilCP((int)Session["idUsuario"], ruta_usuario) != -1)
                        return RedirectToAction("Index");
                    //ModificarFotoPerfilCP
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            } catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Index");
            }
        }
    }
}
