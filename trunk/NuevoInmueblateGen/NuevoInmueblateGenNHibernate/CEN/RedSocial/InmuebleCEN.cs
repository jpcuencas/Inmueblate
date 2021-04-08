

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
 *      Definition of the class InmuebleCEN
 *
 */
public partial class InmuebleCEN
{
private IInmuebleCAD _IInmuebleCAD;

public InmuebleCEN()
{
        this._IInmuebleCAD = new InmuebleCAD ();
}

public InmuebleCEN(IInmuebleCAD _IInmuebleCAD)
{
        this._IInmuebleCAD = _IInmuebleCAD;
}

public IInmuebleCAD get_IInmuebleCAD ()
{
        return this._IInmuebleCAD;
}

public int CrearInmueble (bool p_pendienteModeracion, string p_descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_tipo, int p_metrosCuadrados, bool p_alquiler, float p_precio, int p_geolocalizacion)
{
        InmuebleEN inmuebleEN = null;
        int oid;

        //Initialized InmuebleEN
        inmuebleEN = new InmuebleEN ();
        inmuebleEN.PendienteModeracion = p_pendienteModeracion;

        inmuebleEN.Descripcion = p_descripcion;

        inmuebleEN.Tipo = p_tipo;

        inmuebleEN.MetrosCuadrados = p_metrosCuadrados;

        inmuebleEN.Alquiler = p_alquiler;

        inmuebleEN.Precio = p_precio;


        if (p_geolocalizacion != -1) {
                // El argumento p_geolocalizacion -> Property geolocalizacion es oid = false
                // Lista de oids id
                inmuebleEN.Geolocalizacion = new NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN ();
                inmuebleEN.Geolocalizacion.Id = p_geolocalizacion;
        }

        //Call to InmuebleCAD

        oid = _IInmuebleCAD.CrearInmueble (inmuebleEN);
        return oid;
}

public void ModificarInmueble (int p_oid, bool p_pendienteModeracion, string p_descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_tipo, int p_metrosCuadrados, bool p_alquiler, float p_precio)
{
        InmuebleEN inmuebleEN = null;

        //Initialized InmuebleEN
        inmuebleEN = new InmuebleEN ();
        inmuebleEN.Id = p_oid;
        inmuebleEN.PendienteModeracion = p_pendienteModeracion;
        inmuebleEN.Descripcion = p_descripcion;
        inmuebleEN.Tipo = p_tipo;
        inmuebleEN.MetrosCuadrados = p_metrosCuadrados;
        inmuebleEN.Alquiler = p_alquiler;
        inmuebleEN.Precio = p_precio;
        //Call to InmuebleCAD

        _IInmuebleCAD.ModificarInmueble (inmuebleEN);
}

public void BorrarInmueble (int id)
{
        _IInmuebleCAD.BorrarInmueble (id);
}

public void AnyadirCaracteristica (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirCaracteristica (p_inmueble, p_caracteristica);
}
public void AnyadirElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirElementosMultimedia (p_inmueble, p_elementomultimedia);
}
public void AnyadirGeolocalizacion (int p_inmueble, int p_geolocalizacion)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirGeolocalizacion (p_inmueble, p_geolocalizacion);
}
public void AnyadirHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirHabitacion (p_inmueble, p_habitacion);
}
public void AnyadirInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirInquilino (p_inmueble, p_usuario);
}
public void BorrarCaracteristicas (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarCaracteristicas (p_inmueble, p_caracteristica);
}
public void BorrarElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarElementosMultimedia (p_inmueble, p_elementomultimedia);
}
public void BorrarGeolocalizacion (int p_inmueble, int p_geolocalizacion)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarGeolocalizacion (p_inmueble, p_geolocalizacion);
}
public void BorrarHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarHabitacion (p_inmueble, p_habitacion);
}
public void BorrarInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarInquilino (p_inmueble, p_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> ObtenerInmueblePendienteModeracion ()
{
        return _IInmuebleCAD.ObtenerInmueblePendienteModeracion ();
}
public System.Collections.Generic.IList<InmuebleEN> DameTodosLosInmuebles (int first, int size)
{
        System.Collections.Generic.IList<InmuebleEN> list = null;

        list = _IInmuebleCAD.DameTodosLosInmuebles (first, size);
        return list;
}
public InmuebleEN DameInmueblePorOID (int id)
{
        InmuebleEN inmuebleEN = null;

        inmuebleEN = _IInmuebleCAD.DameInmueblePorOID (id);
        return inmuebleEN;
}

public void AnyadirInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.AnyadirInmobiliaria (p_Inmueble_OID, p_inmobiliaria_OID);
}
public void BorrarInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID)
{
        //Call to InmuebleCAD

        _IInmuebleCAD.BorrarInmobiliaria (p_Inmueble_OID, p_inmobiliaria_OID);
}
}
}
