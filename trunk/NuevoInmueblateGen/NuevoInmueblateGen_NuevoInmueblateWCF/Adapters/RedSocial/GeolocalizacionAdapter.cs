
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class GeolocalizacionAdapter {
public static GeolocalizacionDTO Convert (GeolocalizacionEN en)
{
        GeolocalizacionDTO newinstance = null;

        if (en != null) {
                newinstance = new GeolocalizacionDTO ();


                newinstance.Id = en.Id;
                newinstance.Longitud = en.Longitud;
                newinstance.Latitud = en.Latitud;
                newinstance.Direccion = en.Direccion;
                newinstance.Poblacion = en.Poblacion;
                if (en.PreferenciasBusqueda != null) {
                        newinstance.PreferenciasBusqueda_oid = en.PreferenciasBusqueda.Id;
                }
                if (en.Inmueble != null) {
                        newinstance.Inmueble_oid = en.Inmueble.Id;
                }
                if (en.Evento != null) {
                        newinstance.Evento_oid = en.Evento.Id;
                }
        }

        return newinstance;
}
}
}
