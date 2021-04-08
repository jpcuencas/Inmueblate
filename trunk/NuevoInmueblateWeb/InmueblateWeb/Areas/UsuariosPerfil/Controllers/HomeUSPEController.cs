using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Security.Policy;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using InmueblateWeb.Models;
using System.IO;

namespace InmueblateWeb.Areas.UsuariosPerfil.Controllers
{
    public class HomeUSPEController : Controller
    {
        Service servicio = new Service();
        UsuarioCP usuCP = new UsuarioCP();

        //
        // GET: /UsuariosPerfil/HomeUSPE/

        public ActionResult Index(int id)
        {
            ViewBag.opcionMenu = "home";
            UsuarioEN usuEN = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(id);
            //ViewBag.Page = page;
            ViewBag.EsAmigo = false;
            ViewBag.EstadoPetcion = "";
            if (id == (int)Session["idUsuario"])
            {
                ViewBag.EsAmigo = true;
                ViewBag.Titulo = "Mi Muro";
            }
            else
            {
                IList<UsuarioEN> l_amig = servicio.NuevoInmueblate_Usuario_ObtenerAmigosSP(id);
                UsuarioEN w_yo = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
                ViewBag.Titulo = "Muro de " + usuEN.Nombre;
                if (l_amig.Contains(w_yo)) ViewBag.EsAmigo = true;
                else
                {
                    PeticionAmistadEN petEN = servicio.NuevoInmueblate_PeticionAmistad_DamePeticionDePara((int)Session["idUsuario"], id);
                    PeticionAmistadEN petEmEN = servicio.NuevoInmueblate_PeticionAmistad_DamePeticionDePara(id,(int)Session["idUsuario"]);
                    if (petEN != null)
                    {
                        if (petEN.Estado == NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente)
                            ViewBag.EstadoPetcion = "Pendiente";
                        if (petEN.Estado == NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.bloqueada)
                            ViewBag.EstadoPetcion = "Bloqueada";
                    }
                    else if (petEmEN != null)
                    {
                        if (petEmEN.Estado == NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente)
                            ViewBag.EstadoPetcion = "PendienteAceptar";
                        if (petEmEN.Estado == NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.bloqueada)
                            ViewBag.EstadoPetcion = "Bloqueado";
                    }
                }
            }

            if (ViewBag.EsAmigo)
            {
                MuroEN w_muro = servicio.NuevoInmueblate_Muro_ObtenerMuroPorUsuario(id);

                IList<EntradaEN> l_ent = null;
                IList<string> l_foto = new List<string>();
                IList<UsuarioEN> l_usu_ent = new List<UsuarioEN>();
                UsuarioEN inm = new UsuarioEN();
                inm.Nombre = "Inmuéblate";
                inm.Apellidos = "";

                l_ent = servicio.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(w_muro.Id,0);
                //int id_foto;
                IList<ElementoMultimediaEN> l_elem = new List<ElementoMultimediaEN>();
                IList<string> l_foto_en = new List<string>();
                string url_ent = "";

                foreach (EntradaEN en in l_ent)
                {
                    
                    l_elem = servicio.NuevoInmueblate_Entrada_ObtenerElementosMultimedia(en.Id);
                    if (l_elem.Count > 0)
                        url_ent = l_elem[0].URL;
                    string url;
                    if (en.Creador != null)
                        url = servicio.NuevoInmueblate_Fotografia_ObtenerFotoPerfil(en.Creador.Id).URL;
                    else url = "/default/inmueblate.png";
                    if (en.Creador != null)
                        l_usu_ent.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(en.Creador.Id));
                    else l_usu_ent.Add(inm);
                    l_foto.Add(url);
                    l_foto_en.Add(url_ent);

                }

                ViewBag.Entradas = l_ent;
                ViewBag.Usuarios = l_usu_ent;
                ViewBag.FotosEnt = l_foto;
                ViewBag.FotosEntCue = l_foto_en;
            }

            return View();
        }

        [HttpPost]
        public ActionResult enviarPeticion(int id, Peticion pet)
        {
            ViewBag.EsAmigo = false;
            servicio.NuevoInmueblate_PeticionAmistad_CrearPeticionAmistad(pet.Titulo, pet.Mensaje,
                                                                          NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente,
                                                                          (int)Session["idUsuario"],
                                                                          id);

            return RedirectToAction("Index");
        }


        public ActionResult enviarPeticionAviso(int id)
        {
            ViewBag.EsAmigo = false;
            ViewBag.ID = id;

            return View();
        }

        [HttpPost]
        public ActionResult NuevaEntrada(int id, Entrada ent, HttpPostedFileBase file)
        {
            MuroEN musu = servicio.NuevoInmueblate_Muro_ObtenerMuroPorUsuario(id);
            EntradaCEN entCEN = new EntradaCEN();
            UsuarioEN use = servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID((int)Session["idUsuario"]);
            //int en = entCEN.CrearEntrada(DateTime.Now, "prueba", ent.Cuerpo, false, musu.Id, use.Id);
            int en = servicio.NuevoInmueblate_Entrada_CrearEntrada(DateTime.Now, "", ent.Cuerpo, false, musu.Id, use.Id);

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                string ruta_usuario = "/ID" + Session["idUsuario"].ToString().PadLeft(4, '0');
                ruta_usuario += "/Imagen";

                string extension = fileName.Substring(fileName.IndexOf("."));
                fileName = "fen_" + String.Format("{0:yyyymmdd_hhmmss}", DateTime.Now) + extension;

                var path = Path.Combine(Server.MapPath("~/img" + ruta_usuario), fileName);

                file.SaveAs(path);
                ruta_usuario += "/" + fileName;
                if (servicio.AnyadirFotosEnCP((int)Session["idUsuario"], -1,en, ruta_usuario, "Foto Entrada", "Foto") != -1)
                    return RedirectToAction("Index");
                //ModificarFotoPerfilCP
            }
            ViewBag.Message = "Upload successful";

            
            return RedirectToAction("Index");
        }
    }
}
