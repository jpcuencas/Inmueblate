
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class MensajeAdapter {
public static MensajeDTO Convert (MensajeEN en)
{
        MensajeDTO newinstance = null;

        if (en != null) {
                newinstance = new MensajeDTO ();


                newinstance.Id = en.Id;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.FechaEnvio = en.FechaEnvio;
                newinstance.Asunto = en.Asunto;
                newinstance.Cuerpo = en.Cuerpo;
                newinstance.Leido = en.Leido;
                if (en.Emisor != null) {
                        newinstance.Emisor_oid = en.Emisor.Id;
                }
                if (en.Receptor != null) {
                        newinstance.Receptor_oid = en.Receptor.Id;
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
