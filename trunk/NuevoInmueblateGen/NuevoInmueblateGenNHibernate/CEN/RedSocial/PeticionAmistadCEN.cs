

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
 *      Definition of the class PeticionAmistadCEN
 *
 */
public partial class PeticionAmistadCEN
{
private IPeticionAmistadCAD _IPeticionAmistadCAD;

public PeticionAmistadCEN()
{
        this._IPeticionAmistadCAD = new PeticionAmistadCAD ();
}

public PeticionAmistadCEN(IPeticionAmistadCAD _IPeticionAmistadCAD)
{
        this._IPeticionAmistadCAD = _IPeticionAmistadCAD;
}

public IPeticionAmistadCAD get_IPeticionAmistadCAD ()
{
        return this._IPeticionAmistadCAD;
}

public void ModificarPeticionAmistad (int p_oid, string p_asunto, string p_cuerpo, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum p_estado)
{
        PeticionAmistadEN peticionAmistadEN = null;

        //Initialized PeticionAmistadEN
        peticionAmistadEN = new PeticionAmistadEN ();
        peticionAmistadEN.Id = p_oid;
        peticionAmistadEN.Asunto = p_asunto;
        peticionAmistadEN.Cuerpo = p_cuerpo;
        peticionAmistadEN.Estado = p_estado;
        //Call to PeticionAmistadCAD

        _IPeticionAmistadCAD.ModificarPeticionAmistad (peticionAmistadEN);
}

public void BorrarPeticionAmistad (int id)
{
        _IPeticionAmistadCAD.BorrarPeticionAmistad (id);
}

public PeticionAmistadEN DamePeticionAmistadPorOID (int id)
{
        PeticionAmistadEN peticionAmistadEN = null;

        peticionAmistadEN = _IPeticionAmistadCAD.DamePeticionAmistadPorOID (id);
        return peticionAmistadEN;
}

public System.Collections.Generic.IList<PeticionAmistadEN> DameTodasLasPeticionAmistad (int first, int size)
{
        System.Collections.Generic.IList<PeticionAmistadEN> list = null;

        list = _IPeticionAmistadCAD.DameTodasLasPeticionAmistad (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorEmisor (int pe_emisor, int first, int size)
{
        return _IPeticionAmistadCAD.DamePeticionPorEmisor (pe_emisor, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorReceptor (int pe_receptor, int first, int size)
{
        return _IPeticionAmistadCAD.DamePeticionPorReceptor (pe_receptor, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmistadEstado (int pe_receptor, int pe_estado, int first, int size)
{
        return _IPeticionAmistadCAD.ObtenerPeticionesAmistadEstado (pe_receptor, pe_estado, first, size);
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN DamePeticionDePara (int pe_emisor, int pe_receptor)
{
        return _IPeticionAmistadCAD.DamePeticionDePara (pe_emisor, pe_receptor);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmisitadEstadoEmisor (int pe_emisor, int pe_estado, int first, int size)
{
        return _IPeticionAmistadCAD.ObtenerPeticionesAmisitadEstadoEmisor (pe_emisor, pe_estado, first, size);
}
}
}
