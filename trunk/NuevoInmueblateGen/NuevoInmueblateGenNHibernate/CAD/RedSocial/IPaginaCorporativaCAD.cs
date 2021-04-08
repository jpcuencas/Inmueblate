
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IPaginaCorporativaCAD
{
PaginaCorporativaEN ReadOIDDefault (int id);

int CrearPaginaCorporativa (PaginaCorporativaEN paginaCorporativa);

void ModificarPaginaCorporativa (PaginaCorporativaEN paginaCorporativa);


void BorrarPaginaCorporativa (int id);


System.Collections.Generic.IList<PaginaCorporativaEN> DameTodasLasPaginas (int first, int size);


PaginaCorporativaEN DamePaginaCorporativaPorOID (int id);
}
}
