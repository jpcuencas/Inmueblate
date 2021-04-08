
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IEventoCAD
{
EventoEN ReadOIDDefault (int id);

int CrearEvento (EventoEN evento);

void ModificarEvento (EventoEN evento);


void BorrarEvento (int id);


System.Collections.Generic.IList<EventoEN> DameTodosLosEventos (int first, int size);


System.Collections.Generic.IList<EventoEN> DameTodasEntradas (int first, int size);


EventoEN DameEventoPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> DameEventosFiltro (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, int p_categoria, int first, int size);
}
}
