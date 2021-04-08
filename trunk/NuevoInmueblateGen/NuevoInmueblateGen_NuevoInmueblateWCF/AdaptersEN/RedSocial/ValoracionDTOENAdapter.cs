
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class ValoracionDTOENAdapter {
public static ValoracionEN Convert (ValoracionDTO dto)
{
        ValoracionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ValoracionEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Valoracion = dto.Valoracion;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        if (dto.Emisor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Emisor = superUsuarioCAD.ReadOIDDefault (dto.Emisor_oid);
                        }
                        if (dto.Receptor_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Receptor = superUsuarioCAD.ReadOIDDefault (dto.Receptor_oid);
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
