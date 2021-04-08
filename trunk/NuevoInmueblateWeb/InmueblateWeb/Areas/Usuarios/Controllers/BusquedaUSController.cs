using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmueblateWeb.Models;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;

namespace InmueblateWeb.Areas.Usuarios.Controllers
{
    public class BusquedaUSController : Controller
    {
        //
        // GET: /Usuarios/BusquedaUS/

        Service servicio = new Service();

        public ActionResult BuscarInmueble(int id)
        {
            ViewBag.Titulo = "Página de busqueda de Inmuebles";
            ViewBag.opcionMenu = "buscarinm";
            int usuario = id;
            try
            {
                if (null != Session)
                {
                    //TODO

                    var options = new List<string>();
                    options.Add("Ninguno");
                    foreach (string Tipo in Enum.GetNames(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum)))
                    {
                        options.Add(Tipo);

                    }

                    ViewBag.lista = options;

                    return View();
                }

                return RedirectToAction("Index", "HomeUS");
            }
            catch
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }
        }
        [HttpPost]
        public ActionResult DetalleInmueble(Inmueble model)
        {
            try
            {
                string tiposel="";
                //proceso de busqueda
                List<InmuebleEN> lista1 = new List<InmuebleEN>();
                List<GeolocalizacionEN> lista2 = new List<GeolocalizacionEN>();
                IList<InmuebleEN> lista = servicio.NuevoInmueblate_Inmueble_DameTodosLosInmuebles();
                bool control = true;
                for (int i = 0; i < lista.Count; i++)
                {
                    if(model.Descripcion!=null)
                    if (control && lista[i].Descripcion != model.Descripcion)
                    { 
                        control =false;
                    }
                    if (model.Alquiler != false)
                    if (control && lista[i].Alquiler != model.Alquiler)
                    {
                        control = false;
                    }
                    if (model.MetrosCuadrados != 0)
                    if (control && lista[i].MetrosCuadrados != model.MetrosCuadrados)
                    {
                        control = false;
                    }
                    if (model.Precio != 0)
                    if (control && lista[i].Precio != model.Precio)
                    {
                        control = false;
                    }
                    tiposel = Enum.GetName(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum), lista[i].Tipo);
                    if (model.Categoria != "Ninguno")
                        if (control &&   tiposel!= model.Categoria)
                        {
                            control = false;
                        }
                    if (control)
                    {
                        lista1.Add(lista[i]);
                        lista2.Add(servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(lista[i].Geolocalizacion.Id));
                    }
                    control = true;
                
                }

                @ViewBag.Titulo = "Página de busqueda de Inmuebles";
                @ViewBag.Inmueble = lista1;
                @ViewBag.Geo = lista2;
                ViewBag.opcionMenu = "buscarinm";
                return View();
            }
            catch
            {
                return RedirectToAction("BuscarIn", "BusquedaUS", new { id = (int)Session["idUsuario"] });
            }
        }
        [HttpPost]
        public ActionResult DetalleIn(Busqueda model)
        {
            try
            {
                //proceso de busqueda
                // servicio.
                IList<InmobiliariaEN> lista = servicio.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(null, model.Nombre, null, model.Email, model.Direccion, model.Poblacion, 0);


                @ViewBag.Titulo = "Página de busqueda de Inmuebles";
                @ViewBag.Inmobilaria = lista;
                ViewBag.opcionMenu = "buscarin";
                return View();
            }
            catch
            {
                return RedirectToAction("BuscarIn", "BusquedaUS", new { id = (int)Session["idUsuario"] });
            }
        }

        public ActionResult BuscarIn(int id)
        {
            ViewBag.Titulo = "Página de busqueda de Inmuebles";
            ViewBag.opcionMenu = "buscarin";
            int usuario = id;
            try
            {
                if (usuario != (int)Session["idUsuario"])
                {
                    //TODO

                    return RedirectToAction("Index","HomeUS");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }
        }
       
        public ActionResult BuscarAm(int id)
        {
            try
            {
                @ViewBag.Titulo = "Página de busqueda de Amigos";

                int usuario = id;
                ViewBag.opcionMenu = "buscaram";
                if (usuario != (int)Session["idUsuario"])
                {
                    //TODO
                    //¿porque dame todos los usuarios esta paginado?
                    //servicio.NuevoInmueblate_Usuario_DameTodosLosUsuarios();
                    return RedirectToAction("Index", "HomeUS");
                
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "HomeUS", new { id = (int)Session["idUsuario"] });
            }
        }
        [HttpPost]
        public ActionResult DetalleAm(Busqueda model)
        {
            try
            {

            //proceso de busqueda
            UsuarioCEN usuarioss = new UsuarioCEN();
            IList<UsuarioEN> lista;
            ViewBag.opcionMenu = "buscaram";
           // servicio.
            if (model.FechaNacimiento == null)
                lista = usuarioss.DameUsuariosFiltro(null, model.Email,model.Apellidos,null,model.Direccion,model.Poblacion,0,-1);
            else
                lista = usuarioss.DameUsuariosFiltro(null, model.Email,model.Apellidos,null,model.Direccion,model.Poblacion,0,-1);
            

            @ViewBag.Titulo = "Página de busqueda de Amigos";
            @ViewBag.Amigo = lista;
            return View();

            }
            catch
            {
                return RedirectToAction("BuscarAm", "BusquedaUS", new { id = (int)Session["idUsuario"] });
            }
        }

    }
}
