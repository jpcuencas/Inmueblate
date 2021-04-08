
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IGeolocalizacionCAD
{
GeolocalizacionEN ReadOIDDefault (int id);

int CrearGeolocalizacion (GeolocalizacionEN geolocalizacion);

void ModificarGeolocalizacion (GeolocalizacionEN geolocalizacion);


void BorrarGeolocalizacion (int id);


GeolocalizacionEN DameGeolocalizacionPorOID (int id);


System.Collections.Generic.IList<GeolocalizacionEN> DameTodasLasGeolocalizaciones (int first, int size);
}
}
