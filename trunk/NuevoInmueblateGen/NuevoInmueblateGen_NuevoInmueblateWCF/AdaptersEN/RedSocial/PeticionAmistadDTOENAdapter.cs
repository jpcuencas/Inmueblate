
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class PeticionAmistadDTOENAdapter {
public static PeticionAmistadEN Convert (PeticionAmistadDTO dto)
{
        PeticionAmistadEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PeticionAmistadEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Asunto = dto.Asunto;
                        newinstance.Cuerpo = dto.Cuerpo;
                        newinstance.Estado = dto.Estado;
                        if (dto.Emisor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Emisor = usuarioCAD.ReadOIDDefault (dto.Emisor_oid);
                        }
                        if (dto.Receptor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Receptor = usuarioCAD.ReadOIDDefault (dto.Receptor_oid);
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
