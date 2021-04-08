
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class ValoracionAdapter {
public static ValoracionDTO Convert (ValoracionEN en)
{
        ValoracionDTO newinstance = null;

        if (en != null) {
                newinstance = new ValoracionDTO ();


                newinstance.Id = en.Id;
                newinstance.Valoracion = en.Valoracion;
                newinstance.Descripcion = en.Descripcion;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                if (en.Emisor != null) {
                        newinstance.Emisor_oid = en.Emisor.Id;
                }
                if (en.Receptor != null) {
                        newinstance.Receptor_oid = en.Receptor.Id;
                }
        }

        return newinstance;
}
}
}
