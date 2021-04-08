
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class InmobiliariaAdapter {
public static InmobiliariaDTO Convert (InmobiliariaEN en)
{
        InmobiliariaDTO newinstance = null;

        if (en != null) {
                newinstance = new InmobiliariaDTO ();


                if (en.Inmuebles != null) {
                        newinstance.Inmuebles_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN entry in en.Inmuebles)
                                newinstance.Inmuebles_oid.Add (entry.Id);
                }
                if (en.PaginaCorporativa != null) {
                        newinstance.PaginaCorporativa_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN entry in en.PaginaCorporativa)
                                newinstance.PaginaCorporativa_oid.Add (entry.Id);
                }
                if (en.Eventos != null) {
                        newinstance.Eventos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN entry in en.Eventos)
                                newinstance.Eventos_oid.Add (entry.Id);
                }
                newinstance.Descripcion = en.Descripcion;
                newinstance.Cif = en.Cif;
                newinstance.Id = en.Id;
                if (en.Muro != null) {
                        newinstance.Muro_oid = en.Muro.Id;
                }
                if (en.Grupos != null) {
                        newinstance.Grupos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN entry in en.Grupos)
                                newinstance.Grupos_oid.Add (entry.Id);
                }
                if (en.MensajesEnviados != null) {
                        newinstance.MensajesEnviados_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN entry in en.MensajesEnviados)
                                newinstance.MensajesEnviados_oid.Add (entry.Id);
                }
                if (en.MensajesRecibidos != null) {
                        newinstance.MensajesRecibidos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN entry in en.MensajesRecibidos)
                                newinstance.MensajesRecibidos_oid.Add (entry.Id);
                }
                if (en.ValoracionEmitida != null) {
                        newinstance.ValoracionEmitida_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN entry in en.ValoracionEmitida)
                                newinstance.ValoracionEmitida_oid.Add (entry.Id);
                }
                if (en.ValoracionRecibida != null) {
                        newinstance.ValoracionRecibida_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN entry in en.ValoracionRecibida)
                                newinstance.ValoracionRecibida_oid.Add (entry.Id);
                }
                if (en.EntradasMeGusta != null) {
                        newinstance.EntradasMeGusta_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entry in en.EntradasMeGusta)
                                newinstance.EntradasMeGusta_oid.Add (entry.Id);
                }
                if (en.Entradas != null) {
                        newinstance.Entradas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entry in en.Entradas)
                                newinstance.Entradas_oid.Add (entry.Id);
                }
                if (en.EntradasReportadas != null) {
                        newinstance.EntradasReportadas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entry in en.EntradasReportadas)
                                newinstance.EntradasReportadas_oid.Add (entry.Id);
                }
                if (en.Comentarios != null) {
                        newinstance.Comentarios_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN entry in en.Comentarios)
                                newinstance.Comentarios_oid.Add (entry.Id);
                }
                if (en.ComentariosReportados != null) {
                        newinstance.ComentariosReportados_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN entry in en.ComentariosReportados)
                                newinstance.ComentariosReportados_oid.Add (entry.Id);
                }
                newinstance.Nombre = en.Nombre;
                newinstance.Telefono = en.Telefono;
                newinstance.Email = en.Email;
                newinstance.Direccion = en.Direccion;
                newinstance.Poblacion = en.Poblacion;
                newinstance.CodigoPostal = en.CodigoPostal;
                newinstance.Pais = en.Pais;
                newinstance.Password = en.Password;
                newinstance.ValoracionMedia = en.ValoracionMedia;
        }

        return newinstance;
}
}
}
