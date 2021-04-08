
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IInmuebleCAD
{
InmuebleEN ReadOIDDefault (int id);

int CrearInmueble (InmuebleEN inmueble);

void ModificarInmueble (InmuebleEN inmueble);


void BorrarInmueble (int id);


void AnyadirCaracteristica (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica);

void AnyadirElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia);

void AnyadirGeolocalizacion (int p_inmueble, int p_geolocalizacion);

void AnyadirHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion);

void AnyadirInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario);

void BorrarCaracteristicas (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica);

void BorrarElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia);

void BorrarGeolocalizacion (int p_inmueble, int p_geolocalizacion);

void BorrarHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion);

void BorrarInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> ObtenerInmueblePendienteModeracion ();


System.Collections.Generic.IList<InmuebleEN> DameTodosLosInmuebles (int first, int size);


InmuebleEN DameInmueblePorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> DameInmuebleFiltro (int p_inmobiliaria, string p_descripcion, int p_tipo, int p_metrosCuadrados, int p_precio, string p_direccion, string p_poblacion, int first, int size);


void AnyadirInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID);

void BorrarInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID);
}
}
