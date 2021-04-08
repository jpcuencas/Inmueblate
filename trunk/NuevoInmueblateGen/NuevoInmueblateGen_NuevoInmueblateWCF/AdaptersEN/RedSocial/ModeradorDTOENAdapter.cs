
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class ModeradorDTOENAdapter {
public static ModeradorEN Convert (ModeradorDTO dto)
{
        ModeradorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ModeradorEN ();



                        if (dto.ListaAmigos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.ListaAmigos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                foreach (int entry in dto.ListaAmigos_oid) {
                                        newinstance.ListaAmigos.Add (usuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.ListaBloqueados_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.ListaBloqueados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                foreach (int entry in dto.ListaBloqueados_oid) {
                                        newinstance.ListaBloqueados.Add (usuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Inmuebles_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD inmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD ();

                                newinstance.Inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                                foreach (int entry in dto.Inmuebles_oid) {
                                        newinstance.Inmuebles.Add (inmuebleCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Habitaciones_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IHabitacionCAD habitacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.HabitacionCAD ();

                                newinstance.Habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                                foreach (int entry in dto.Habitaciones_oid) {
                                        newinstance.Habitaciones.Add (habitacionCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.PeticionesEnviadas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD peticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD ();

                                newinstance.PeticionesEnviadas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                                foreach (int entry in dto.PeticionesEnviadas_oid) {
                                        newinstance.PeticionesEnviadas.Add (peticionAmistadCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.PeticionesRecibidas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD peticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD ();

                                newinstance.PeticionesRecibidas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                                foreach (int entry in dto.PeticionesRecibidas_oid) {
                                        newinstance.PeticionesRecibidas.Add (peticionAmistadCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.PreferenciasBusqueda_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD preferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD ();

                                newinstance.PreferenciasBusqueda = preferenciasBusquedaCAD.ReadOIDDefault (dto.PreferenciasBusqueda_oid);
                        }
                        if (dto.Gustos_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD gustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD ();

                                newinstance.Gustos = gustosCAD.ReadOIDDefault (dto.Gustos_oid);
                        }
                        if (dto.Elementos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD elementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD ();

                                newinstance.Elementos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                                foreach (int entry in dto.Elementos_oid) {
                                        newinstance.Elementos.Add (elementoMultimediaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Apellidos = dto.Apellidos;
                        newinstance.Nif = dto.Nif;
                        newinstance.FechaNacimiento = dto.FechaNacimiento;
                        newinstance.Privacidad = dto.Privacidad;
                        newinstance.Id = dto.Id;
                        if (dto.Muro_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD muroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD ();

                                newinstance.Muro = muroCAD.ReadOIDDefault (dto.Muro_oid);
                        }
                        if (dto.Grupos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD grupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD ();

                                newinstance.Grupos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
                                foreach (int entry in dto.Grupos_oid) {
                                        newinstance.Grupos.Add (grupoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.MensajesEnviados_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD mensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD ();

                                newinstance.MensajesEnviados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
                                foreach (int entry in dto.MensajesEnviados_oid) {
                                        newinstance.MensajesEnviados.Add (mensajeCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.MensajesRecibidos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD mensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD ();

                                newinstance.MensajesRecibidos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
                                foreach (int entry in dto.MensajesRecibidos_oid) {
                                        newinstance.MensajesRecibidos.Add (mensajeCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.ValoracionEmitida_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD valoracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD ();

                                newinstance.ValoracionEmitida = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                                foreach (int entry in dto.ValoracionEmitida_oid) {
                                        newinstance.ValoracionEmitida.Add (valoracionCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.ValoracionRecibida_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD valoracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD ();

                                newinstance.ValoracionRecibida = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                                foreach (int entry in dto.ValoracionRecibida_oid) {
                                        newinstance.ValoracionRecibida.Add (valoracionCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.EntradasMeGusta_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.EntradasMeGusta = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                foreach (int entry in dto.EntradasMeGusta_oid) {
                                        newinstance.EntradasMeGusta.Add (entradaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Entradas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.Entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                foreach (int entry in dto.Entradas_oid) {
                                        newinstance.Entradas.Add (entradaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.EntradasReportadas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.EntradasReportadas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                foreach (int entry in dto.EntradasReportadas_oid) {
                                        newinstance.EntradasReportadas.Add (entradaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Comentarios_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD comentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD ();

                                newinstance.Comentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                                foreach (int entry in dto.Comentarios_oid) {
                                        newinstance.Comentarios.Add (comentarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.ComentariosReportados_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD comentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD ();

                                newinstance.ComentariosReportados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                                foreach (int entry in dto.ComentariosReportados_oid) {
                                        newinstance.ComentariosReportados.Add (comentarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Telefono = dto.Telefono;
                        newinstance.Email = dto.Email;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Poblacion = dto.Poblacion;
                        newinstance.CodigoPostal = dto.CodigoPostal;
                        newinstance.Pais = dto.Pais;
                        newinstance.Password = dto.Password;
                        newinstance.ValoracionMedia = dto.ValoracionMedia;
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
