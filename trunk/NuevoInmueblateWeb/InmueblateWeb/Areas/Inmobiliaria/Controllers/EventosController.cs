using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevoInmueblateGen_NuevoInmueblateLocal;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using InmueblateWeb.Models;
using System.Globalization;

namespace InmueblateWeb.Areas.Inmobiliaria.Controllers
{
    public class EventosController : Controller
    {
        Service servicio = new Service();


        UsuarioCP usuCP = new UsuarioCP();
        
        //
        // GET: /Inmobiliaria/Eventos/

        public ActionResult Index()
        {
            try
            {
                 //List<EventoEN>   eventos= servicio.
                IList<EventoEN> eventos;
                eventos = servicio.NuevoInmueblate_Evento_DameTodosLosEventos();
                List<int> ids = new List<int>();
                for (int i = 0; i < eventos.Count; i++)
                {
                    ids.Add(eventos[i].Id);
                }
                ViewBag.Evento = eventos;
                ViewBag.ids = ids;
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "HomeIN", new { id = (int)Session["idUsuario"] });
            }
        }

        //
        // GET: /Inmobiliaria/Eventos/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                if (null != Session)
                {
                    EventoEN evento;
                    evento = servicio.NuevoInmueblate_Evento_DameEventoPorOID(id);
                    ViewBag.Evento = evento;
                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(evento.Geolocalizacion.Id);
                    
                    string tiposel = Enum.GetName(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum), evento.Categoria);

                    ViewBag.Tipo = tiposel;
                    ViewBag.evento = evento;
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
        // GET: /Inmobiliaria/Eventos/Create

        public ActionResult Create(int id)
        {
            try
            {
                if (null != Session)
                {
                    IList<string> listaTipos = new List<string>();
                    var options = new List<SelectListItem>();


                    foreach (string Tipo in Enum.GetNames(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum)))
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
        // POST: /Inmobiliaria/Eventos/Create

        [HttpPost]
        public ActionResult Create(InmueblateWeb.Models.Evento collection)
        {
            try
            {
                // TODO: Add insert logic here

                if (null != Session)
                {


                    EventoEN evento = new EventoEN();
                    NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_filtro = (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum)Enum.Parse(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum), collection.Categoria);
                    //evento.valor=collection.valor
                    DateTime fecha = new DateTime();

                    if (collection.Fecha == null)
                    {
                        fecha = DateTime.Now;
                    }
                    else 
                    {
                        fecha = DateTime.Parse(collection.Fecha.ToString());
                    }

                    //collection.Latitud

                    int geoid = servicio.NuevoInmueblate_Geolocalizacion_CrearGeolocalizacion(collection.Longitud,collection.Latitud,"geo1","pop1");

                    servicio.NuevoInmueblate_Evento_CrearEvento(collection.Nombre.ToString(), collection.Descripcion.ToString(),
                       fecha, p_filtro, (int)Session["idUsuario"], geoid);

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
        // GET: /Inmobiliaria/Eventos/Edit/5
 
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
                    EventoEN evento = servicio.NuevoInmueblate_Evento_DameEventoPorOID(id);

                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(evento.Geolocalizacion.Id);

                    var options = new List<string>();

                   string tiposel= Enum.GetName(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum),evento.Categoria);

                    foreach (string Tipo in Enum.GetNames(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum)))
                    {
                        options.Add(Tipo);
                        
                    }

                    ViewBag.lista = options;

                    ViewBag.Tipo = tiposel;                   
                    ViewBag.evento = evento;
                    ViewBag.Longuitud = geo.Longitud;
                    ViewBag.Latitud = geo.Latitud;
                    ViewBag.Fecha = String.Format("{0:dd/MM/yyyy}", evento.Fecha);// (DateTime)(evento.Fecha).ToString("d", CultureInfo.InvariantCulture);
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
        // POST: /Inmobiliaria/Eventos/Edit/5

        [HttpPost]
        public ActionResult Edit(int id,InmueblateWeb.Models.Evento collection)
        {
            try
            {
                // TODO: Add update logic here
                if (null != Session)
                {

                    NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_filtro = (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum)Enum.Parse(typeof(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum), collection.Categoria);
                    //evento.valor=collection.valor
                  
                    EventoEN even =servicio.NuevoInmueblate_Evento_DameEventoPorOID(id);
                    GeolocalizacionEN geo = servicio.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(even.Geolocalizacion.Id);
                    servicio.NuevoInmueblate_Geolocalizacion_ModificarGeolocalizacion(geo.Id, collection.Longitud, collection.Latitud, geo.Direccion, geo.Poblacion);
                    servicio.NuevoInmueblate_Evento_ModificarEvento(id,collection.Nombre.ToString(), collection.Descripcion.ToString(),
                       DateTime.Parse(collection.Fecha), p_filtro);

                }
                
                    return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Inmobiliaria/Eventos/Delete/5
        
        public ActionResult Delete(int id)
        {
            try
            {
                if (null != Session)
                {
                    servicio.NuevoInmueblate_Evento_BorrarEvento(id);
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
