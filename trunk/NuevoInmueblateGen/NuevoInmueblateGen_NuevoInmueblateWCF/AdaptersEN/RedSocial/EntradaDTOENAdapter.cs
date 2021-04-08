
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class EntradaDTOENAdapter {
public static EntradaEN Convert (EntradaDTO dto)
{
        EntradaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EntradaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.FechaPublicacion = dto.FechaPublicacion;
                        newinstance.Titulo = dto.Titulo;
                        newinstance.Cuerpo = dto.Cuerpo;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        if (dto.Muro_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD muroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD ();

                                newinstance.Muro = muroCAD.ReadOIDDefault (dto.Muro_oid);
                        }
                        if (dto.UsuariosMeGusta_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.UsuariosMeGusta = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                                foreach (int entry in dto.UsuariosMeGusta_oid) {
                                        newinstance.UsuariosMeGusta.Add (superUsuarioCAD.ReadOIDDefault (entry));
                                }
                        }
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
                        if (dto.Comentarios_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD comentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD ();

                                newinstance.Comentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                                foreach (int entry in dto.Comentarios_oid) {
                                        newinstance.Comentarios.Add (comentarioCAD.ReadOIDDefault (entry));
                                }
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
