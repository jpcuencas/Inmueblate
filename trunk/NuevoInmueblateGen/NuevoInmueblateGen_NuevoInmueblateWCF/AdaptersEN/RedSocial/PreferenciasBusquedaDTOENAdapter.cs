
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class PreferenciasBusquedaDTOENAdapter {
public static PreferenciasBusquedaEN Convert (PreferenciasBusquedaDTO dto)
{
        PreferenciasBusquedaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PreferenciasBusquedaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.DistanciaTolerable = dto.DistanciaTolerable;
                        newinstance.PrecioMax = dto.PrecioMax;
                        newinstance.PrecioMin = dto.PrecioMin;
                        if (dto.Usuario_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
                        if (dto.Grupo_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD grupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD ();

                                newinstance.Grupo = grupoCAD.ReadOIDDefault (dto.Grupo_oid);
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
