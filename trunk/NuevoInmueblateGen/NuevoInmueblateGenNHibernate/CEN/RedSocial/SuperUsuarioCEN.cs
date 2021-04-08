

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
 *      Definition of the class SuperUsuarioCEN
 *
 */
public partial class SuperUsuarioCEN
{
private ISuperUsuarioCAD _ISuperUsuarioCAD;

public SuperUsuarioCEN()
{
        this._ISuperUsuarioCAD = new SuperUsuarioCAD ();
}

public SuperUsuarioCEN(ISuperUsuarioCAD _ISuperUsuarioCAD)
{
        this._ISuperUsuarioCAD = _ISuperUsuarioCAD;
}

public ISuperUsuarioCAD get_ISuperUsuarioCAD ()
{
        return this._ISuperUsuarioCAD;
}

public void ModificarSuperUsuario (int p_SuperUsuario_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia)
{
        SuperUsuarioEN superUsuarioEN = null;

        //Initialized SuperUsuarioEN
        superUsuarioEN = new SuperUsuarioEN ();
        superUsuarioEN.Id = p_SuperUsuario_OID;
        superUsuarioEN.Nombre = p_nombre;
        superUsuarioEN.Telefono = p_telefono;
        superUsuarioEN.Email = p_email;
        superUsuarioEN.Direccion = p_direccion;
        superUsuarioEN.Poblacion = p_poblacion;
        superUsuarioEN.CodigoPostal = p_codigoPostal;
        superUsuarioEN.Pais = p_pais;
        superUsuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        superUsuarioEN.ValoracionMedia = p_valoracionMedia;
        //Call to SuperUsuarioCAD

        _ISuperUsuarioCAD.ModificarSuperUsuario (superUsuarioEN);
}

public void BorrarSuperUsuario (int id)
{
        _ISuperUsuarioCAD.BorrarSuperUsuario (id);
}

public NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ObtenerUsuarioPorEmail (string pe_email)
{
        return _ISuperUsuarioCAD.ObtenerUsuarioPorEmail (pe_email);
}
public System.Collections.Generic.IList<SuperUsuarioEN> DameTodosLosSuerUsuario (int first, int size)
{
        System.Collections.Generic.IList<SuperUsuarioEN> list = null;

        list = _ISuperUsuarioCAD.DameTodosLosSuerUsuario (first, size);
        return list;
}
public SuperUsuarioEN DameSuperUsuarioPorOID (int id)
{
        SuperUsuarioEN superUsuarioEN = null;

        superUsuarioEN = _ISuperUsuarioCAD.DameSuperUsuarioPorOID (id);
        return superUsuarioEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposPorUsuario (int pe_usuario, int first, int size)
{
        return _ISuperUsuarioCAD.ObtenerGruposPorUsuario (pe_usuario, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> ObtenerGruposPorUsuarioNP (int pe_usuario)
{
        return _ISuperUsuarioCAD.ObtenerGruposPorUsuarioNP (pe_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesRecibidas (int pe_id, int first, int size)
{
        return _ISuperUsuarioCAD.ObtenerValoracionesRecibidas (pe_id, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmitidas (int pe_id, int first, int size)
{
        return _ISuperUsuarioCAD.ObtenerValoracionesEmitidas (pe_id, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> DameSuperUsuariosGrupo (int p_grupo, int first, int size)
{
        return _ISuperUsuarioCAD.DameSuperUsuariosGrupo (p_grupo, first, size);
}
}
}
