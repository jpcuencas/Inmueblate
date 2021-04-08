

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
/*
 *      Definition of the class EventoCEN
 *
 */
public partial class EventoCEN
{
private IEventoCAD _IEventoCAD;

public EventoCEN()
{
        this._IEventoCAD = new EventoCAD ();
}

public EventoCEN(IEventoCAD _IEventoCAD)
{
        this._IEventoCAD = _IEventoCAD;
}

public IEventoCAD get_IEventoCAD ()
{
        return this._IEventoCAD;
}

public int CrearEvento (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_categoria, int p_inmobiliaria, int p_geolocalizacion)
{
        EventoEN eventoEN = null;
        int oid;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Nombre = p_nombre;

        eventoEN.Descripcion = p_descripcion;

        eventoEN.Fecha = p_fecha;

        eventoEN.Categoria = p_categoria;


        if (p_inmobiliaria != -1) {
                // El argumento p_inmobiliaria -> Property inmobiliaria es oid = false
                // Lista de oids id
                eventoEN.Inmobiliaria = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN ();
                eventoEN.Inmobiliaria.Id = p_inmobiliaria;
        }


        if (p_geolocalizacion != -1) {
                // El argumento p_geolocalizacion -> Property geolocalizacion es oid = false
                // Lista de oids id
                eventoEN.Geolocalizacion = new NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN ();
                eventoEN.Geolocalizacion.Id = p_geolocalizacion;
        }

        //Call to EventoCAD

        oid = _IEventoCAD.CrearEvento (eventoEN);
        return oid;
}

public void ModificarEvento (int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_categoria)
{
        EventoEN eventoEN = null;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Id = p_oid;
        eventoEN.Nombre = p_nombre;
        eventoEN.Descripcion = p_descripcion;
        eventoEN.Fecha = p_fecha;
        eventoEN.Categoria = p_categoria;
        //Call to EventoCAD

        _IEventoCAD.ModificarEvento (eventoEN);
}

public void BorrarEvento (int id)
{
        _IEventoCAD.BorrarEvento (id);
}

public System.Collections.Generic.IList<EventoEN> DameTodosLosEventos (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.DameTodosLosEventos (first, size);
        return list;
}
public System.Collections.Generic.IList<EventoEN> DameTodasEntradas (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.DameTodasEntradas (first, size);
        return list;
}
public EventoEN DameEventoPorOID (int id)
{
        EventoEN eventoEN = null;

        eventoEN = _IEventoCAD.DameEventoPorOID (id);
        return eventoEN;
}
}
}
