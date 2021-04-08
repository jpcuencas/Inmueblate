
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IHabitacionCAD
{
HabitacionEN ReadOIDDefault (int id);

int CrearHabitacion (HabitacionEN habitacion);

void ModificarHabitacion (HabitacionEN habitacion);


void BorrarHabitacion (int id);


void AnyadirCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica);

void AnyadirInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario);

void BorrarCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica);

void BorrarInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> ObtenerHabitacionPendienteModeracion ();


HabitacionEN DameHabitacionPorOID (int id);


System.Collections.Generic.IList<HabitacionEN> DameTodasLasHabitaciones (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> DameHabitacionFiltro (string p_descripcion, int p_metrosCuadrados, string p_direccion, string p_poblacion, int p_inmueble, int first, int size);
}
}
