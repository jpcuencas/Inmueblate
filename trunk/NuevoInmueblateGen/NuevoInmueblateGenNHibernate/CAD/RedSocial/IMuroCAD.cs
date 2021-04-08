
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IMuroCAD
{
MuroEN ReadOIDDefault (int id);

int CrearMuro (MuroEN muro);

void ModificarMuro (MuroEN muro);


void BorrarMuro (int id);


void AsociarConGrupo (int p_muro, int p_grupo);

void AsociarConUsuario (int p_muro, int p_superusuario);

void AnyadirEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada);

void BorrarEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada);

NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorUsuario (int p_usuario);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN> ObtenerMuroPendienteModeracion ();


MuroEN DameMuroPorOID (int id);


System.Collections.Generic.IList<MuroEN> DameTodosLosMuros (int first, int size);


NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorGrupo (int p_grupo);
}
}
