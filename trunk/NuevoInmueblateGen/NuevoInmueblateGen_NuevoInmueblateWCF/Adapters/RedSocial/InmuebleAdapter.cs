
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class InmuebleAdapter {
public static InmuebleDTO Convert (InmuebleEN en)
{
        InmuebleDTO newinstance = null;

        if (en != null) {
                newinstance = new InmuebleDTO ();


                newinstance.Id = en.Id;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.Descripcion = en.Descripcion;
                newinstance.Tipo = en.Tipo;
                newinstance.MetrosCuadrados = en.MetrosCuadrados;
                newinstance.Alquiler = en.Alquiler;
                newinstance.Precio = en.Precio;
                if (en.Inquilinos != null) {
                        newinstance.Inquilinos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN entry in en.Inquilinos)
                                newinstance.Inquilinos_oid.Add (entry.Id);
                }
                if (en.Geolocalizacion != null) {
                        newinstance.Geolocalizacion_oid = en.Geolocalizacion.Id;
                }
                if (en.Caracteristicas != null) {
                        newinstance.Caracteristicas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN entry in en.Caracteristicas)
                                newinstance.Caracteristicas_oid.Add (entry.Id);
                }
                if (en.Habitaciones != null) {
                        newinstance.Habitaciones_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN entry in en.Habitaciones)
                                newinstance.Habitaciones_oid.Add (entry.Id);
                }
                if (en.ElementosMultimedia != null) {
                        newinstance.ElementosMultimedia_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN entry in en.ElementosMultimedia)
                                newinstance.ElementosMultimedia_oid.Add (entry.Id);
                }
                if (en.Inmobiliaria != null) {
                        newinstance.Inmobiliaria_oid = en.Inmobiliaria.Id;
                }
        }

        return newinstance;
}
}
}
