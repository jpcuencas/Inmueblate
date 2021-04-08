
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class UsuarioAdapter {
public static UsuarioDTO Convert (UsuarioEN en)
{
        UsuarioDTO newinstance = null;

        if (en != null) {
                newinstance = new UsuarioDTO ();


                if (en.ListaAmigos != null) {
                        newinstance.ListaAmigos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN entry in en.ListaAmigos)
                                newinstance.ListaAmigos_oid.Add (entry.Id);
                }
                if (en.ListaBloqueados != null) {
                        newinstance.ListaBloqueados_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN entry in en.ListaBloqueados)
                                newinstance.ListaBloqueados_oid.Add (entry.Id);
                }
                if (en.Inmuebles != null) {
                        newinstance.Inmuebles_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN entry in en.Inmuebles)
                                newinstance.Inmuebles_oid.Add (entry.Id);
                }
                if (en.Habitaciones != null) {
                        newinstance.Habitaciones_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN entry in en.Habitaciones)
                                newinstance.Habitaciones_oid.Add (entry.Id);
                }
                if (en.PeticionesEnviadas != null) {
                        newinstance.PeticionesEnviadas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN entry in en.PeticionesEnviadas)
                                newinstance.PeticionesEnviadas_oid.Add (entry.Id);
                }
                if (en.PeticionesRecibidas != null) {
                        newinstance.PeticionesRecibidas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN entry in en.PeticionesRecibidas)
                                newinstance.PeticionesRecibidas_oid.Add (entry.Id);
                }
                if (en.PreferenciasBusqueda != null) {
                        newinstance.PreferenciasBusqueda_oid = en.PreferenciasBusqueda.Id;
                }
                if (en.Gustos != null) {
                        newinstance.Gustos_oid = en.Gustos.Id;
                }
                if (en.Elementos != null) {
                        newinstance.Elementos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN entry in en.Elementos)
                                newinstance.Elementos_oid.Add (entry.Id);
                }
                newinstance.Apellidos = en.Apellidos;
                newinstance.Nif = en.Nif;
                newinstance.FechaNacimiento = en.FechaNacimiento;
                newinstance.Privacidad = en.Privacidad;
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
