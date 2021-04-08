
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IInmobiliariaCAD
{
InmobiliariaEN ReadOIDDefault (int id);

int CrearInmobiliaria (InmobiliariaEN inmobiliaria);

void ModificarInmobilaria (InmobiliariaEN inmobiliaria);


void BorrarInmobiliaria (int id);


System.Collections.Generic.IList<InmobiliariaEN> DameTodasLasInmobiliarias (int first, int size);


InmobiliariaEN DameInmobiliariaPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> DameInmobiliariaFiltro (string p_cif, string p_nombre, string p_descripcion, string p_email, string p_direccion, string p_poblacion, int first, int size);
}
}
