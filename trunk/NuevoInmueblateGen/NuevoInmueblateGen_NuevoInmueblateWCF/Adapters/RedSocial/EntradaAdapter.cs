
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class EntradaAdapter {
public static EntradaDTO Convert (EntradaEN en)
{
        EntradaDTO newinstance = null;

        if (en != null) {
                newinstance = new EntradaDTO ();


                newinstance.Id = en.Id;
                newinstance.FechaPublicacion = en.FechaPublicacion;
                newinstance.Titulo = en.Titulo;
                newinstance.Cuerpo = en.Cuerpo;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                if (en.Muro != null) {
                        newinstance.Muro_oid = en.Muro.Id;
                }
                if (en.UsuariosMeGusta != null) {
                        newinstance.UsuariosMeGusta_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN entry in en.UsuariosMeGusta)
                                newinstance.UsuariosMeGusta_oid.Add (entry.Id);
                }
                if (en.Creador != null) {
                        newinstance.Creador_oid = en.Creador.Id;
                }
                if (en.Reportadores != null) {
                        newinstance.Reportadores_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN entry in en.Reportadores)
                                newinstance.Reportadores_oid.Add (entry.Id);
                }
                if (en.Comentarios != null) {
                        newinstance.Comentarios_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN entry in en.Comentarios)
                                newinstance.Comentarios_oid.Add (entry.Id);
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
