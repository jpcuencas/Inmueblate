
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IGustosCAD
{
GustosEN ReadOIDDefault (int id);

int CrearGustos (GustosEN gustos);

void ModificarGustos (GustosEN gustos);


void BorrarGustos (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> ObtenerGustosPendienteModeracion ();


GustosEN DameGustosPorOID (int id);


System.Collections.Generic.IList<GustosEN> DameTodosLosGustos (int first, int size);
}
}
