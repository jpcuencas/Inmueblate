

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
 *      Definition of the class PreferenciasBusquedaCEN
 *
 */
public partial class PreferenciasBusquedaCEN
{
private IPreferenciasBusquedaCAD _IPreferenciasBusquedaCAD;

public PreferenciasBusquedaCEN()
{
        this._IPreferenciasBusquedaCAD = new PreferenciasBusquedaCAD ();
}

public PreferenciasBusquedaCEN(IPreferenciasBusquedaCAD _IPreferenciasBusquedaCAD)
{
        this._IPreferenciasBusquedaCAD = _IPreferenciasBusquedaCAD;
}

public IPreferenciasBusquedaCAD get_IPreferenciasBusquedaCAD ()
{
        return this._IPreferenciasBusquedaCAD;
}

public int CrearPreferenciasBusqueda (int p_distanciaTolerable, float p_precioMax, float p_precioMin, int p_geolocalizacion)
{
        PreferenciasBusquedaEN preferenciasBusquedaEN = null;
        int oid;

        //Initialized PreferenciasBusquedaEN
        preferenciasBusquedaEN = new PreferenciasBusquedaEN ();
        preferenciasBusquedaEN.DistanciaTolerable = p_distanciaTolerable;

        preferenciasBusquedaEN.PrecioMax = p_precioMax;

        preferenciasBusquedaEN.PrecioMin = p_precioMin;


        if (p_geolocalizacion != -1) {
                // El argumento p_geolocalizacion -> Property geolocalizacion es oid = false
                // Lista de oids id
                preferenciasBusquedaEN.Geolocalizacion = new NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN ();
                preferenciasBusquedaEN.Geolocalizacion.Id = p_geolocalizacion;
        }

        //Call to PreferenciasBusquedaCAD

        oid = _IPreferenciasBusquedaCAD.CrearPreferenciasBusqueda (preferenciasBusquedaEN);
        return oid;
}

public void ModificarPreferenciasBusqueda (int p_oid, int p_distanciaTolerable, float p_precioMax, float p_precioMin)
{
        PreferenciasBusquedaEN preferenciasBusquedaEN = null;

        //Initialized PreferenciasBusquedaEN
        preferenciasBusquedaEN = new PreferenciasBusquedaEN ();
        preferenciasBusquedaEN.Id = p_oid;
        preferenciasBusquedaEN.DistanciaTolerable = p_distanciaTolerable;
        preferenciasBusquedaEN.PrecioMax = p_precioMax;
        preferenciasBusquedaEN.PrecioMin = p_precioMin;
        //Call to PreferenciasBusquedaCAD

        _IPreferenciasBusquedaCAD.ModificarPreferenciasBusqueda (preferenciasBusquedaEN);
}

public void BorrarPreferenciasBusqueda (int id)
{
        _IPreferenciasBusquedaCAD.BorrarPreferenciasBusqueda (id);
}

public void AsociarConGrupo (int p_preferenciasbusqueda, int p_grupo)
{
        //Call to PreferenciasBusquedaCAD

        _IPreferenciasBusquedaCAD.AsociarConGrupo (p_preferenciasbusqueda, p_grupo);
}
public void AsociarConUsuario (int p_preferenciasbusqueda, int p_usuario)
{
        //Call to PreferenciasBusquedaCAD

        _IPreferenciasBusquedaCAD.AsociarConUsuario (p_preferenciasbusqueda, p_usuario);
}
public System.Collections.Generic.IList<PreferenciasBusquedaEN> DameTodasLasPreferenciasBusqueda (int first, int size)
{
        System.Collections.Generic.IList<PreferenciasBusquedaEN> list = null;

        list = _IPreferenciasBusquedaCAD.DameTodasLasPreferenciasBusqueda (first, size);
        return list;
}
public PreferenciasBusquedaEN DamePreferenciasBusquedaPorOID (int id)
{
        PreferenciasBusquedaEN preferenciasBusquedaEN = null;

        preferenciasBusquedaEN = _IPreferenciasBusquedaCAD.DamePreferenciasBusquedaPorOID (id);
        return preferenciasBusquedaEN;
}
}
}
