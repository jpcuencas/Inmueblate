
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class PaginaCorporativaDTOENAdapter {
public static PaginaCorporativaEN Convert (PaginaCorporativaDTO dto)
{
        PaginaCorporativaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PaginaCorporativaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Contenido = dto.Contenido;
                        newinstance.URL = dto.URL;
                        if (dto.Inmobiliaria_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD inmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD ();

                                newinstance.Inmobiliaria = inmobiliariaCAD.ReadOIDDefault (dto.Inmobiliaria_oid);
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
