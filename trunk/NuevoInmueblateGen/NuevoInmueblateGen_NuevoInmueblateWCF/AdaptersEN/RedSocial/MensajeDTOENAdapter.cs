
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class MensajeDTOENAdapter {
public static MensajeEN Convert (MensajeDTO dto)
{
        MensajeEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MensajeEN ();



                        newinstance.Id = dto.Id;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.FechaEnvio = dto.FechaEnvio;
                        newinstance.Asunto = dto.Asunto;
                        newinstance.Cuerpo = dto.Cuerpo;
                        newinstance.Leido = dto.Leido;
                        if (dto.Emisor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Emisor = superUsuarioCAD.ReadOIDDefault (dto.Emisor_oid);
                        }
                        if (dto.Receptor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Receptor = superUsuarioCAD.ReadOIDDefault (dto.Receptor_oid);
                        }
                        if (dto.ElementosMultimedia_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD elementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD ();

                                newinstance.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                                foreach (int entry in dto.ElementosMultimedia_oid) {
                                        newinstance.ElementosMultimedia.Add (elementoMultimediaCAD.ReadOIDDefault (entry));
                                }
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
