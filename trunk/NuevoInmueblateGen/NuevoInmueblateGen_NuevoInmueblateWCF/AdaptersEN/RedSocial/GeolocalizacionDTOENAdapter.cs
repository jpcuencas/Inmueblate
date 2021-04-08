
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class GeolocalizacionDTOENAdapter {
public static GeolocalizacionEN Convert (GeolocalizacionDTO dto)
{
        GeolocalizacionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new GeolocalizacionEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Longitud = dto.Longitud;
                        newinstance.Latitud = dto.Latitud;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Poblacion = dto.Poblacion;
                        if (dto.PreferenciasBusqueda_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD preferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD ();

                                newinstance.PreferenciasBusqueda = preferenciasBusquedaCAD.ReadOIDDefault (dto.PreferenciasBusqueda_oid);
                        }
                        if (dto.Inmueble_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD inmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD ();

                                newinstance.Inmueble = inmuebleCAD.ReadOIDDefault (dto.Inmueble_oid);
                        }
                        if (dto.Evento_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD eventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD ();

                                newinstance.Evento = eventoCAD.ReadOIDDefault (dto.Evento_oid);
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
