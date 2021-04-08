using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;

namespace InmueblateWeb.Areas.Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {

        Service servicio = new Service();


        UsuarioCP usuCP = new UsuarioCP();
        //
        //
        // GET: /Inmobiliaria/Inmuebles/

        public ActionResult Index()
        {
            try{
                IList<InmuebleEN> inmuebles;
                inmuebles = servicio.NuevoInmueblate_Inmueble_DameTodosLosInmuebles();
                List<int> ids = new List<int>();
                for (int i = 0; i < inmuebles.Count; i++)
                {
                    ids.Add(inmuebles[i].Id);
                }
                ViewBag.Inmueble = inmuebles;
                ViewBag.ids = ids;
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "HomeIN", new { id = (int)Session["idUsuario"] });
            }
        }

        //
        // GET: /Inmobiliaria/Inmuebles/Details/5

        public ActionResult Details(int id)
        {
            
                if (null != Session)
                {
                    InmuebleEN inmueble;


                    inmueble = servicio.NuevoInmueblate_Inmueble_DameInmueblePorOID(id);
                    ViewBag.Inmueble = inmueble;
                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(inmueble.Geolocalizacion.Id);
                    InmobiliariaEN inm = servicio.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(inmueble.Inmobiliaria.Id);
                    string tiposel = Enum.GetName(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum), inmueble.Tipo);

                    ViewBag.Tipo = tiposel;
                    ViewBag.Longuitud = geo.Longitud;
                    ViewBag.Latitud = geo.Latitud;
                    ViewBag.Email = inm.Email;
                    return View();
                }
                else
                    return RedirectToAction("Index");
           
        }

        //
        // GET: /Inmobiliaria/Inmuebles/Create

        public ActionResult Create(int id)
        {
            try
            {
                if (null != Session)
                {

                    IList<string> listaTipos = new List<string>();
                    var options = new List<SelectListItem>();


                    foreach (string Tipo in Enum.GetNames(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum)))
                    {
                        listaTipos.Add(Tipo);
                        options.Add(new SelectListItem { Value = Tipo, Text = Tipo });
                    }

                    ViewBag.lista = options;

                    ViewBag.listaTipos = listaTipos;
                    //ViewBag.m = evento;
                    return View();
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        } 

        //
        // POST: /Inmobiliaria/Inmuebles/Create

        [HttpPost]
        public ActionResult Create(InmueblateWeb.Models.Inmueble collection)
        {
            try
            {
            // TODO: Add insert logic here

            if (null != Session)
            {
                InmuebleCEN inmuebleCEN = new InmuebleCEN();
                bool alquiler = collection.Alquiler;
                NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_filtro = (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum)Enum.Parse(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum), collection.Categoria);
                int geo1  = servicio.NuevoInmueblate_Geolocalizacion_CrearGeolocalizacion(collection.Longitud,collection.Latitud,"geo1","pop1");
                int idinm=servicio.NuevoInmueblate_Inmueble_CrearInmueble(true, collection.Descripcion, p_filtro,collection.MetrosCuadrados, alquiler,collection.Precio, geo1);
                inmuebleCEN.AnyadirInmobiliaria(idinm, (int)Session["idUsuario"]);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
             }
             catch
             {
                 return RedirectToAction("Index");
             }
        }
        
        //
        // GET: /Inmobiliaria/Inmuebles/Edit/5
 
        public ActionResult Edit(int id)
        {
            try
            {


                if (null != Session)
                {
                    // EventoEN evento = new EventoEN();
                    // evento= servicio.NuevoInmueblate_Evento_DameEventoPorOID(id);
                    //NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_filtro = (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum)Enum.Parse(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum), evento.Categoria.ToString());
                    //evento.valor=collection.valor

                   
                    InmuebleEN inmueble = servicio.NuevoInmueblate_Inmueble_DameInmueblePorOID(id);

                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(inmueble.Geolocalizacion.Id);

                    var options = new List<string>();

                    string tiposel = Enum.GetName(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum), inmueble.Tipo);

                    foreach (string Tipo in Enum.GetNames(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum)))
                    {
                        options.Add(Tipo);

                    }

                    ViewBag.lista = options;

                    ViewBag.Tipo = tiposel;
                    ViewBag.inmueble = inmueble;
                    ViewBag.Longuitud = geo.Longitud;
                    ViewBag.Latitud = geo.Latitud;


                    return View();
                }
                else
                    return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Inmobiliaria/Inmuebles/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, InmueblateWeb.Models.Inmueble collection)
        {
            try
            {
                // TODO: Add update logic here
                if (null != Session)
                {

                    NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_filtro = (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum)Enum.Parse(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum), collection.Categoria);
                    InmuebleEN inm = servicio.NuevoInmueblate_Inmueble_DameInmueblePorOID(id);

                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(inm.Geolocalizacion.Id);
                    servicio.NuevoInmueblate_Geolocalizacion_ModificarGeolocalizacion(geo.Id, collection.Longitud, collection.Latitud, geo.Direccion, geo.Poblacion);
                    servicio.NuevoInmueblate_Inmueble_ModificarInmueble(id,true, collection.Descripcion,
                        p_filtro,
                        int.Parse(collection.MetrosCuadrados.ToString()), true, float.Parse(collection.Precio.ToString())
                        );


                }
                
                    return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Inmobiliaria/Inmuebles/Delete/5
 
        public ActionResult Delete(int id)
        {
            try
            {
            InmuebleEN inmueble;
                if (null != Session)
                {
                    inmueble = servicio.NuevoInmueblate_Inmueble_DameInmueblePorOID(id);
                    servicio.NuevoInmueblate_Geolocalizacion_BorrarGeolocalizacion(inmueble.Geolocalizacion.Id);
                 
                    if (inmueble.Habitaciones.Count > 0)
                    {
                        inmueble.Habitaciones.Clear();
                    }
                    if (inmueble.Inquilinos.Count > 0)
                    {
                        inmueble.Inquilinos.Clear();
                    }
                    if (inmueble.ElementosMultimedia.Count > 0)
                    {
                        inmueble.ElementosMultimedia.Clear();
                    }
                    servicio.NuevoInmueblate_Inmueble_BorrarInmueble(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}
