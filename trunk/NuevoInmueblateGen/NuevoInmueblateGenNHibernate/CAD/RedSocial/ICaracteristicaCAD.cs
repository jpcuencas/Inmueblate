
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface ICaracteristicaCAD
{
CaracteristicaEN ReadOIDDefault (int id);

int CrearCaracteristica (CaracteristicaEN caracteristica);

void ModificarCaracteristica (CaracteristicaEN caracteristica);


void BorrarCaracteristica (int id);


void AnyadirCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion);

void BorrarCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion);

void AnyadirCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble);

void BorrarCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble);

CaracteristicaEN DameCaracteristicaPorOID (int id);


System.Collections.Generic.IList<CaracteristicaEN> DameTodasLasCaracteristicas (int first, int size);
}
}
