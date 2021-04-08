
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class PeticionAmistadAdapter {
public static PeticionAmistadDTO Convert (PeticionAmistadEN en)
{
        PeticionAmistadDTO newinstance = null;

        if (en != null) {
                newinstance = new PeticionAmistadDTO ();


                newinstance.Id = en.Id;
                newinstance.Asunto = en.Asunto;
                newinstance.Cuerpo = en.Cuerpo;
                newinstance.Estado = en.Estado;
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
