
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IGrupoCAD
{
GrupoEN ReadOIDDefault (int id);

int CrearGrupo (GrupoEN grupo);

void ModificarGrupo (GrupoEN grupo);


void BorrarGrupo (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposConEntradasReportadas ();


System.Collections.Generic.IList<GrupoEN> DameTodosLosGrupos (int first, int size);


GrupoEN DameGrupoPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> DameGruposFiltro (int p_tipo, string p_nombre, string p_descripcion, int first, int size);
}
}
