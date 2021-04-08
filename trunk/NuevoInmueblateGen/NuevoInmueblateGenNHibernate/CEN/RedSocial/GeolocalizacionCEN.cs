

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
 *      Definition of the class GeolocalizacionCEN
 *
 */
public partial class GeolocalizacionCEN
{
private IGeolocalizacionCAD _IGeolocalizacionCAD;

public GeolocalizacionCEN()
{
        this._IGeolocalizacionCAD = new GeolocalizacionCAD ();
}

public GeolocalizacionCEN(IGeolocalizacionCAD _IGeolocalizacionCAD)
{
        this._IGeolocalizacionCAD = _IGeolocalizacionCAD;
}

public IGeolocalizacionCAD get_IGeolocalizacionCAD ()
{
        return this._IGeolocalizacionCAD;
}

public int CrearGeolocalizacion (float p_longitud, float p_latitud, string p_direccion, string p_poblacion)
{
        GeolocalizacionEN geolocalizacionEN = null;
        int oid;

        //Initialized GeolocalizacionEN
        geolocalizacionEN = new GeolocalizacionEN ();
        geolocalizacionEN.Longitud = p_longitud;

        geolocalizacionEN.Latitud = p_latitud;

        geolocalizacionEN.Direccion = p_direccion;

        geolocalizacionEN.Poblacion = p_poblacion;

        //Call to GeolocalizacionCAD

        oid = _IGeolocalizacionCAD.CrearGeolocalizacion (geolocalizacionEN);
        return oid;
}

public void ModificarGeolocalizacion (int p_oid, float p_longitud, float p_latitud, string p_direccion, string p_poblacion)
{
        GeolocalizacionEN geolocalizacionEN = null;

        //Initialized GeolocalizacionEN
        geolocalizacionEN = new GeolocalizacionEN ();
        geolocalizacionEN.Id = p_oid;
        geolocalizacionEN.Longitud = p_longitud;
        geolocalizacionEN.Latitud = p_latitud;
        geolocalizacionEN.Direccion = p_direccion;
        geolocalizacionEN.Poblacion = p_poblacion;
        //Call to GeolocalizacionCAD

        _IGeolocalizacionCAD.ModificarGeolocalizacion (geolocalizacionEN);
}

public void BorrarGeolocalizacion (int id)
{
        _IGeolocalizacionCAD.BorrarGeolocalizacion (id);
}

public GeolocalizacionEN DameGeolocalizacionPorOID (int id)
{
        GeolocalizacionEN geolocalizacionEN = null;

        geolocalizacionEN = _IGeolocalizacionCAD.DameGeolocalizacionPorOID (id);
        return geolocalizacionEN;
}

public System.Collections.Generic.IList<GeolocalizacionEN> DameTodasLasGeolocalizaciones (int first, int size)
{
        System.Collections.Generic.IList<GeolocalizacionEN> list = null;

        list = _IGeolocalizacionCAD.DameTodasLasGeolocalizaciones (first, size);
        return list;
}
}
}
