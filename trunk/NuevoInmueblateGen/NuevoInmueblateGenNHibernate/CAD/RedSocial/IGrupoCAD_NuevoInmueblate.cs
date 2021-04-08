
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IGrupoCAD
{
NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN                GetMuroOfPropietarioGrupo_NuevoInmueblate (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> GetAllGrupo_NuevoInmueblate ();
}
}
