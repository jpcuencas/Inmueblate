
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class ElementoMultimediaDTOENAdapter {
public static ElementoMultimediaEN Convert (ElementoMultimediaDTO dto)
{
        ElementoMultimediaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ElementoMultimediaEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Mensaje_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD mensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD ();

                                newinstance.Mensaje = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
                                foreach (int entry in dto.Mensaje_oid) {
                                        newinstance.Mensaje.Add (mensajeCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Galeria_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD galeriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD ();

                                newinstance.Galeria = galeriaCAD.ReadOIDDefault (dto.Galeria_oid);
                        }
                        if (dto.Entradas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.Entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                foreach (int entry in dto.Entradas_oid) {
                                        newinstance.Entradas.Add (entradaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.AparicionComentarios_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD comentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD ();

                                newinstance.AparicionComentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                                foreach (int entry in dto.AparicionComentarios_oid) {
                                        newinstance.AparicionComentarios.Add (comentarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Inmueble_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD inmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD ();

                                newinstance.Inmueble = inmuebleCAD.ReadOIDDefault (dto.Inmueble_oid);
                        }
                        if (dto.Usuario_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.URL = dto.URL;
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
