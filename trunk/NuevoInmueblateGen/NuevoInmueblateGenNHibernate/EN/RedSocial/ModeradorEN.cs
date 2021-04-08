
using System;
// Definición clase ModeradorEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class ModeradorEN                                                                    : NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN


{
public ModeradorEN() : base ()
{
}



public ModeradorEN(int id,
                   System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaAmigos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaBloqueados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesEnviadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesRecibidas, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda, NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementos, string apellidos, string nif, Nullable<DateTime> fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum privacidad
                   , NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia
                   )
{
        this.init (Id, listaAmigos, listaBloqueados, inmuebles, habitaciones, peticionesEnviadas, peticionesRecibidas, preferenciasBusqueda, gustos, elementos, apellidos, nif, fechaNacimiento, privacidad, muro, grupos, mensajesEnviados, mensajesRecibidos, valoracionEmitida, valoracionRecibida, entradasMeGusta, entradas, entradasReportadas, comentarios, comentariosReportados, nombre, telefono, email, direccion, poblacion, codigoPostal, pais, password, valoracionMedia);
}


public ModeradorEN(ModeradorEN moderador)
{
        this.init (Id, moderador.ListaAmigos, moderador.ListaBloqueados, moderador.Inmuebles, moderador.Habitaciones, moderador.PeticionesEnviadas, moderador.PeticionesRecibidas, moderador.PreferenciasBusqueda, moderador.Gustos, moderador.Elementos, moderador.Apellidos, moderador.Nif, moderador.FechaNacimiento, moderador.Privacidad, moderador.Muro, moderador.Grupos, moderador.MensajesEnviados, moderador.MensajesRecibidos, moderador.ValoracionEmitida, moderador.ValoracionRecibida, moderador.EntradasMeGusta, moderador.Entradas, moderador.EntradasReportadas, moderador.Comentarios, moderador.ComentariosReportados, moderador.Nombre, moderador.Telefono, moderador.Email, moderador.Direccion, moderador.Poblacion, moderador.CodigoPostal, moderador.Pais, moderador.Password, moderador.ValoracionMedia);
}

private void init (int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaAmigos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaBloqueados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesEnviadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesRecibidas, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda, NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementos, string apellidos, string nif, Nullable<DateTime> fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum privacidad, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia)
{
        this.Id = id;


        this.ListaAmigos = listaAmigos;

        this.ListaBloqueados = listaBloqueados;

        this.Inmuebles = inmuebles;

        this.Habitaciones = habitaciones;

        this.PeticionesEnviadas = peticionesEnviadas;

        this.PeticionesRecibidas = peticionesRecibidas;

        this.PreferenciasBusqueda = preferenciasBusqueda;

        this.Gustos = gustos;

        this.Elementos = elementos;

        this.Apellidos = apellidos;

        this.Nif = nif;

        this.FechaNacimiento = fechaNacimiento;

        this.Privacidad = privacidad;

        this.Muro = muro;

        this.Grupos = grupos;

        this.MensajesEnviados = mensajesEnviados;

        this.MensajesRecibidos = mensajesRecibidos;

        this.ValoracionEmitida = valoracionEmitida;

        this.ValoracionRecibida = valoracionRecibida;

        this.EntradasMeGusta = entradasMeGusta;

        this.Entradas = entradas;

        this.EntradasReportadas = entradasReportadas;

        this.Comentarios = comentarios;

        this.ComentariosReportados = comentariosReportados;

        this.Nombre = nombre;

        this.Telefono = telefono;

        this.Email = email;

        this.Direccion = direccion;

        this.Poblacion = poblacion;

        this.CodigoPostal = codigoPostal;

        this.Pais = pais;

        this.Password = password;

        this.ValoracionMedia = valoracionMedia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ModeradorEN t = obj as ModeradorEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
