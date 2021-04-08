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
    public class PeticionController : Controller
    {
        Service servicio = new Service();

        public ActionResult Index(int id)
        {
            if (id != (int)Session["idUsuario"])
                return RedirectToAction("Index", "HomeUSPE");
            IList<PeticionAmistadEN> l_pet_pen = servicio.NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmistadEstado(id, (int)NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente, 0);
            IList<PeticionAmistadEN> l_pet_pen_env = servicio.NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmisitadEstadoEmisor(id, (int)NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente, 0);
            IList<PeticionAmistadEN> l_pet_blo = servicio.NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmistadEstado(id, (int)NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum.bloqueada, 0);
            
            //Peticiones recibidas
            IList<UsuarioEN> l_usu_emi_pen = new List<UsuarioEN>();
            foreach (PeticionAmistadEN pet in l_pet_pen)
            {
                l_usu_emi_pen.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(pet.Emisor.Id));
            }

            //Peticiones enviadas
            IList<UsuarioEN> l_usu_env_pen = new List<UsuarioEN>();
            foreach (PeticionAmistadEN pet in l_pet_pen_env)
            {
                l_usu_env_pen.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(pet.Receptor.Id));
            }

            //Peticiones recibidas bloqueadas
            IList<UsuarioEN> l_usu_emi_blo = new List<UsuarioEN>();
            foreach (PeticionAmistadEN pet in l_pet_blo)
            {
                l_usu_emi_blo.Add(servicio.NuevoInmueblate_Usuario_DameUsuarioPorOID(pet.Emisor.Id));
            }
            
            ViewBag.PeticionesBlo = l_pet_blo;
            ViewBag.EmiPeticionesBlo = l_usu_emi_blo;

            ViewBag.PeticionesPen = l_pet_pen;
            ViewBag.EmiPeticionesPen = l_usu_emi_pen;

            ViewBag.PeticionesPenEnv = l_pet_pen_env;
            ViewBag.EnvPeticionesPen = l_usu_env_pen;
            return View();
        }

        public ActionResult Aceptar(int id)
        {
            servicio.AceptarPeticionAmistadCP(id);
            return RedirectToAction("Index","Amigos", new { id = (int)Session["idUsuario"] });
        }
 
        public ActionResult Cancelar(int id)
        {
            servicio.NuevoInmueblate_PeticionAmistad_BorrarPeticionAmistad(id);
            return RedirectToAction("Index", new { id = (int)Session["idUsuario"] });
        }

        public ActionResult Bloquear(int id)
        {
            servicio.NuevoInmueblate_PeticionAmistad_BloquearPeticionAmistad(id);
            return RedirectToAction("Index", new { id = (int)Session["idUsuario"] });
        }

        public ActionResult DesbloquearYAceptar(int id)
        {
            servicio.NuevoInmueblate_PeticionAmistad_DesbloquearPeticionAmistad(id);
            return RedirectToAction("Aceptar", id);
            //servicio.AceptarPeticionAmistadCP(id);
            //return RedirectToAction("Index", new { id = (int)Session["idUsuario"] });
        }

        public ActionResult Desbloquear(int id)
        {
            servicio.NuevoInmueblate_PeticionAmistad_DesbloquearPeticionAmistad(id);
            return RedirectToAction("Index", new { id = (int)Session["idUsuario"] });
        }
    }
}
