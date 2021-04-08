
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class InmuebleDTOENAdapter {
public static InmuebleEN Convert (InmuebleDTO dto)
{
        InmuebleEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new InmuebleEN ();



                        newinstance.Id = dto.Id;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.Tipo = dto.Tipo;
                        newinstance.MetrosCuadrados = dto.MetrosCuadrados;
                        newinstance.Alquiler = dto.Alquiler;
                        newinstance.Precio = dto.Precio;
                        if (dto.Inquilinos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                foreach (int entry in dto.Inquilinos_oid) {
                                        newinstance.Inquilinos.Add (usuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Geolocalizacion_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD geolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD ();

                                newinstance.Geolocalizacion = geolocalizacionCAD.ReadOIDDefault (dto.Geolocalizacion_oid);
                        }
                        if (dto.Caracteristicas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ICaracteristicaCAD caracteristicaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.CaracteristicaCAD ();

                                newinstance.Caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
                                foreach (int entry in dto.Caracteristicas_oid) {
                                        newinstance.Caracteristicas.Add (caracteristicaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Habitaciones_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IHabitacionCAD habitacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.HabitacionCAD ();

                                newinstance.Habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                                foreach (int entry in dto.Habitaciones_oid) {
                                        newinstance.Habitaciones.Add (habitacionCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.ElementosMultimedia_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD elementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD ();

                                newinstance.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                                foreach (int entry in dto.ElementosMultimedia_oid) {
                                        newinstance.ElementosMultimedia.Add (elementoMultimediaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Inmobiliaria_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD inmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD ();

                                newinstance.Inmobiliaria = inmobiliariaCAD.ReadOIDDefault (dto.Inmobiliaria_oid);
                        }
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
