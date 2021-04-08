
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface ISuperUsuarioCAD
{
SuperUsuarioEN ReadOIDDefault (int id);

int CrearSuperUsuario (SuperUsuarioEN superUsuario);

void ModificarSuperUsuario (SuperUsuarioEN superUsuario);


void BorrarSuperUsuario (int id);


void AnyadirEntradasReportadas (int p_SuperUsuario_OID, System.Collections.Generic.IList<int> p_entradasReportadas_OIDs);

void BorrarEntradasReportadas (int p_SuperUsuario_OID, System.Collections.Generic.IList<int> p_entradasReportadas_OIDs);


NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ObtenerUsuarioPorEmail (string pe_email);


System.Collections.Generic.IList<SuperUsuarioEN> DameTodosLosSuerUsuario (int first, int size);


SuperUsuarioEN DameSuperUsuarioPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposPorUsuario (int pe_usuario, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> ObtenerGruposPorUsuarioNP (int pe_usuario);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesRecibidas (int pe_id, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmitidas (int pe_id, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> DameSuperUsuariosGrupo (int p_grupo, int first, int size);
}
}
