
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class ComentarioDTOENAdapter {
public static ComentarioEN Convert (ComentarioDTO dto)
{
        ComentarioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ComentarioEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cuerpo = dto.Cuerpo;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.FechaPublicacion = dto.FechaPublicacion;
                        if (dto.Creador_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Creador = superUsuarioCAD.ReadOIDDefault (dto.Creador_oid);
                        }
                        if (dto.Reportadores_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Reportadores = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                                foreach (int entry in dto.Reportadores_oid) {
                                        newinstance.Reportadores.Add (superUsuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Entrada_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.Entrada = entradaCAD.ReadOIDDefault (dto.Entrada_oid);
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
