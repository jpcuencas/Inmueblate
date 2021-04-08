
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class EventoDTOENAdapter {
public static EventoEN Convert (EventoDTO dto)
{
        EventoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EventoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.Fecha = dto.Fecha;
                        newinstance.Categoria = dto.Categoria;
                        if (dto.Inmobiliaria_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD inmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD ();

                                newinstance.Inmobiliaria = inmobiliariaCAD.ReadOIDDefault (dto.Inmobiliaria_oid);
                        }
                        if (dto.Geolocalizacion_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD geolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD ();

                                newinstance.Geolocalizacion = geolocalizacionCAD.ReadOIDDefault (dto.Geolocalizacion_oid);
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
