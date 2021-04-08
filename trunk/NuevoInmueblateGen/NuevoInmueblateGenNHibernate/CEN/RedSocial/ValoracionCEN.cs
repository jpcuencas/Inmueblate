

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
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public void ModificarValoracion (int p_oid, float p_valoracion, string p_descripcion, bool p_pendienteModeracion)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_oid;
        valoracionEN.Valoracion = p_valoracion;
        valoracionEN.Descripcion = p_descripcion;
        valoracionEN.PendienteModeracion = p_pendienteModeracion;
        //Call to ValoracionCAD

        _IValoracionCAD.ModificarValoracion (valoracionEN);
}

public void BorrarValoracion (int id)
{
        _IValoracionCAD.BorrarValoracion (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionPendienteModeracion ()
{
        return _IValoracionCAD.ObtenerValoracionPendienteModeracion ();
}
public System.Collections.Generic.IList<ValoracionEN> DameTodasValoraciones (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionCAD.DameTodasValoraciones (first, size);
        return list;
}
public ValoracionEN DameValoracionPorOID (int id)
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionCAD.DameValoracionPorOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptor (int pe_receptor, int first, int size)
{
        return _IValoracionCAD.ObtenerValoracionesReceptor (pe_receptor, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisor (int pe_emisor, int first, int size)
{
        return _IValoracionCAD.ObtenerValoracionesEmisor (pe_emisor, first, size);
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN ObtenerValoracionDeA (int pe_emisor, int pe_receptor)
{
        return _IValoracionCAD.ObtenerValoracionDeA (pe_emisor, pe_receptor);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisorNP (int pe_emisor)
{
        return _IValoracionCAD.ObtenerValoracionesEmisorNP (pe_emisor);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptorNP (int pe_receptor)
{
        return _IValoracionCAD.ObtenerValoracionesReceptorNP (pe_receptor);
}
}
}
