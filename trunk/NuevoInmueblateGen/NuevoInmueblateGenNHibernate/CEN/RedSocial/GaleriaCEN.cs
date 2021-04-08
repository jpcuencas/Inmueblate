

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
 *      Definition of the class GaleriaCEN
 *
 */
public partial class GaleriaCEN
{
private IGaleriaCAD _IGaleriaCAD;

public GaleriaCEN()
{
        this._IGaleriaCAD = new GaleriaCAD ();
}

public GaleriaCEN(IGaleriaCAD _IGaleriaCAD)
{
        this._IGaleriaCAD = _IGaleriaCAD;
}

public IGaleriaCAD get_IGaleriaCAD ()
{
        return this._IGaleriaCAD;
}

public int CrearGaleria (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        GaleriaEN galeriaEN = null;
        int oid;

        //Initialized GaleriaEN
        galeriaEN = new GaleriaEN ();

        if (p_galeria != -1) {
                // El argumento p_galeria -> Property galeria es oid = false
                // Lista de oids id
                galeriaEN.Galeria = new NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ();
                galeriaEN.Galeria.Id = p_galeria;
        }

        galeriaEN.Fecha = p_fecha;

        galeriaEN.Descripcion = p_descripcion;

        galeriaEN.Nombre = p_nombre;

        galeriaEN.PendienteModeracion = p_pendienteModeracion;

        galeriaEN.URL = p_URL;

        //Call to GaleriaCAD

        oid = _IGaleriaCAD.CrearGaleria (galeriaEN);
        return oid;
}

public void ModificarGaleria (int p_Galeria_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        GaleriaEN galeriaEN = null;

        //Initialized GaleriaEN
        galeriaEN = new GaleriaEN ();
        galeriaEN.Id = p_Galeria_OID;
        galeriaEN.Fecha = p_fecha;
        galeriaEN.Descripcion = p_descripcion;
        galeriaEN.Nombre = p_nombre;
        galeriaEN.PendienteModeracion = p_pendienteModeracion;
        galeriaEN.URL = p_URL;
        //Call to GaleriaCAD

        _IGaleriaCAD.ModificarGaleria (galeriaEN);
}

public void BorrarGaleria (int id)
{
        _IGaleriaCAD.BorrarGaleria (id);
}

public void AnyadirElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        //Call to GaleriaCAD

        _IGaleriaCAD.AnyadirElementoMultimedia (p_Galeria_OID, p_elementosMultimedia_OIDs);
}
public void BorrarElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        //Call to GaleriaCAD

        _IGaleriaCAD.BorrarElementoMultimedia (p_Galeria_OID, p_elementosMultimedia_OIDs);
}
public GaleriaEN DameGaleriaPorOID (int id)
{
        GaleriaEN galeriaEN = null;

        galeriaEN = _IGaleriaCAD.DameGaleriaPorOID (id);
        return galeriaEN;
}

public System.Collections.Generic.IList<GaleriaEN> DameTodasLasGalerias (int first, int size)
{
        System.Collections.Generic.IList<GaleriaEN> list = null;

        list = _IGaleriaCAD.DameTodasLasGalerias (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN> ObtenerGaleriasPorUsuario (int pe_usuario, int first, int size)
{
        return _IGaleriaCAD.ObtenerGaleriasPorUsuario (pe_usuario, first, size);
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ObtenerGaleriaPerfil (int pe_usuario)
{
        return _IGaleriaCAD.ObtenerGaleriaPerfil (pe_usuario);
}
}
}
