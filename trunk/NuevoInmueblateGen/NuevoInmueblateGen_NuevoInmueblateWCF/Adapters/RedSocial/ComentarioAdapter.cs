
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class ComentarioAdapter {
public static ComentarioDTO Convert (ComentarioEN en)
{
        ComentarioDTO newinstance = null;

        if (en != null) {
                newinstance = new ComentarioDTO ();


                newinstance.Id = en.Id;
                newinstance.Cuerpo = en.Cuerpo;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.FechaPublicacion = en.FechaPublicacion;
                if (en.Creador != null) {
                        newinstance.Creador_oid = en.Creador.Id;
                }
                if (en.Reportadores != null) {
                        newinstance.Reportadores_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN entry in en.Reportadores)
                                newinstance.Reportadores_oid.Add (entry.Id);
                }
                if (en.Entrada != null) {
                        newinstance.Entrada_oid = en.Entrada.Id;
                }
                if (en.ElementosMultimedia != null) {
                        newinstance.ElementosMultimedia_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN entry in en.ElementosMultimedia)
                                newinstance.ElementosMultimedia_oid.Add (entry.Id);
                }
        }

        return newinstance;
}
}
}
