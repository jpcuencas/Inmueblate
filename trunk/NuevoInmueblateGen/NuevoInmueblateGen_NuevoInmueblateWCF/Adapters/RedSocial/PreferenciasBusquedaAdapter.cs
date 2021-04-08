
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class PreferenciasBusquedaAdapter {
public static PreferenciasBusquedaDTO Convert (PreferenciasBusquedaEN en)
{
        PreferenciasBusquedaDTO newinstance = null;

        if (en != null) {
                newinstance = new PreferenciasBusquedaDTO ();


                newinstance.Id = en.Id;
                newinstance.DistanciaTolerable = en.DistanciaTolerable;
                newinstance.PrecioMax = en.PrecioMax;
                newinstance.PrecioMin = en.PrecioMin;
                if (en.Usuario != null) {
                        newinstance.Usuario_oid = en.Usuario.Id;
                }
                if (en.Grupo != null) {
                        newinstance.Grupo_oid = en.Grupo.Id;
                }
                if (en.Geolocalizacion != null) {
                        newinstance.Geolocalizacion_oid = en.Geolocalizacion.Id;
                }
        }

        return newinstance;
}
}
}
