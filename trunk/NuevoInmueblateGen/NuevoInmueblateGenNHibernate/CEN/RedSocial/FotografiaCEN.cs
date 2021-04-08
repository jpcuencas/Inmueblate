

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
 *      Definition of the class FotografiaCEN
 *
 */
public partial class FotografiaCEN
{
private IFotografiaCAD _IFotografiaCAD;

public FotografiaCEN()
{
        this._IFotografiaCAD = new FotografiaCAD ();
}

public FotografiaCEN(IFotografiaCAD _IFotografiaCAD)
{
        this._IFotografiaCAD = _IFotografiaCAD;
}

public IFotografiaCAD get_IFotografiaCAD ()
{
        return this._IFotografiaCAD;
}

public int CrearFotografia (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        FotografiaEN fotografiaEN = null;
        int oid;

        //Initialized FotografiaEN
        fotografiaEN = new FotografiaEN ();

        if (p_galeria != -1) {
                // El argumento p_galeria -> Property galeria es oid = false
                // Lista de oids id
                fotografiaEN.Galeria = new NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ();
                fotografiaEN.Galeria.Id = p_galeria;
        }

        fotografiaEN.Fecha = p_fecha;

        fotografiaEN.Descripcion = p_descripcion;

        fotografiaEN.Nombre = p_nombre;

        fotografiaEN.PendienteModeracion = p_pendienteModeracion;

        fotografiaEN.URL = p_URL;

        //Call to FotografiaCAD

        oid = _IFotografiaCAD.CrearFotografia (fotografiaEN);
        return oid;
}

public void ModificarFotografia (int p_Fotografia_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        FotografiaEN fotografiaEN = null;

        //Initialized FotografiaEN
        fotografiaEN = new FotografiaEN ();
        fotografiaEN.Id = p_Fotografia_OID;
        fotografiaEN.Fecha = p_fecha;
        fotografiaEN.Descripcion = p_descripcion;
        fotografiaEN.Nombre = p_nombre;
        fotografiaEN.PendienteModeracion = p_pendienteModeracion;
        fotografiaEN.URL = p_URL;
        //Call to FotografiaCAD

        _IFotografiaCAD.ModificarFotografia (fotografiaEN);
}

public void BorrarFotografia (int id)
{
        _IFotografiaCAD.BorrarFotografia (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerTodasFotografiasPorModerar ()
{
        return _IFotografiaCAD.ObtenerTodasFotografiasPorModerar ();
}
public FotografiaEN DameFotografiaPorOID (int id)
{
        FotografiaEN fotografiaEN = null;

        fotografiaEN = _IFotografiaCAD.DameFotografiaPorOID (id);
        return fotografiaEN;
}

public System.Collections.Generic.IList<FotografiaEN> DameTodasLasFotografias (int first, int size)
{
        System.Collections.Generic.IList<FotografiaEN> list = null;

        list = _IFotografiaCAD.DameTodasLasFotografias (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotografiasPorUsuario (int pe_usuario, int first, int size)
{
        return _IFotografiaCAD.ObtenerFotografiasPorUsuario (pe_usuario, first, size);
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN ObtenerFotoPerfil (int pe_usuario)
{
        return _IFotografiaCAD.ObtenerFotoPerfil (pe_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotosPorGaleria (int pe_galeria, int first, int size)
{
        return _IFotografiaCAD.ObtenerFotosPorGaleria (pe_galeria, first, size);
}
}
}
