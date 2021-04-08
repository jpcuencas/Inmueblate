
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IPreferenciasBusquedaCAD
{
PreferenciasBusquedaEN ReadOIDDefault (int id);

int CrearPreferenciasBusqueda (PreferenciasBusquedaEN preferenciasBusqueda);

void ModificarPreferenciasBusqueda (PreferenciasBusquedaEN preferenciasBusqueda);


void BorrarPreferenciasBusqueda (int id);


void AsociarConGrupo (int p_preferenciasbusqueda, int p_grupo);

void AsociarConUsuario (int p_preferenciasbusqueda, int p_usuario);

System.Collections.Generic.IList<PreferenciasBusquedaEN> DameTodasLasPreferenciasBusqueda (int first, int size);


PreferenciasBusquedaEN DamePreferenciasBusquedaPorOID (int id);
}
}
