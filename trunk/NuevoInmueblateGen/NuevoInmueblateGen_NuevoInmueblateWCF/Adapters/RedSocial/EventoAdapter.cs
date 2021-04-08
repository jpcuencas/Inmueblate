
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class EventoAdapter {
public static EventoDTO Convert (EventoEN en)
{
        EventoDTO newinstance = null;

        if (en != null) {
                newinstance = new EventoDTO ();


                newinstance.Id = en.Id;
                newinstance.Nombre = en.Nombre;
                newinstance.Descripcion = en.Descripcion;
                newinstance.Fecha = en.Fecha;
                newinstance.Categoria = en.Categoria;
                if (en.Inmobiliaria != null) {
                        newinstance.Inmobiliaria_oid = en.Inmobiliaria.Id;
                }
                if (en.Geolocalizacion != null) {
                        newinstance.Geolocalizacion_oid = en.Geolocalizacion.Id;
                }
        }

        return newinstance;
}
}
}
