
using System;
// Definición clase UsuarioEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class UsuarioEN                                                                      : NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN


{
/**
 *	Atributo listaAmigos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaAmigos;



/**
 *	Atributo listaBloqueados
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaBloqueados;



/**
 *	Atributo inmuebles
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles;



/**
 *	Atributo habitaciones
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones;



/**
 *	Atributo peticionesEnviadas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesEnviadas;



/**
 *	Atributo peticionesRecibidas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesRecibidas;



/**
 *	Atributo preferenciasBusqueda
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda;



/**
 *	Atributo gustos
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustos;



/**
 *	Atributo elementos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementos;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nif
 */
private string nif;



/**
 *	Atributo fechaNacimiento
 */
private Nullable<DateTime> fechaNacimiento;



/**
 *	Atributo privacidad
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum privacidad;






public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ListaAmigos {
        get { return listaAmigos; } set { listaAmigos = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ListaBloqueados {
        get { return listaBloqueados; } set { listaBloqueados = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> Inmuebles {
        get { return inmuebles; } set { inmuebles = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> Habitaciones {
        get { return habitaciones; } set { habitaciones = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> PeticionesEnviadas {
        get { return peticionesEnviadas; } set { peticionesEnviadas = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> PeticionesRecibidas {
        get { return peticionesRecibidas; } set { peticionesRecibidas = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN PreferenciasBusqueda {
        get { return preferenciasBusqueda; } set { preferenciasBusqueda = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN Gustos {
        get { return gustos; } set { gustos = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> Elementos {
        get { return elementos; } set { elementos = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Nif {
        get { return nif; } set { nif = value;  }
}



public virtual Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum Privacidad {
        get { return privacidad; } set { privacidad = value;  }
}





public UsuarioEN() : base ()
{
        listaAmigos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        listaBloqueados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
        habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
        peticionesEnviadas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
        peticionesRecibidas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
        elementos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public UsuarioEN(int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaAmigos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listaBloqueados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesEnviadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> peticionesRecibidas, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda, NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementos, string apellidos, string nif, Nullable<DateTime> fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum privacidad
                 , NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia
                 )
{
        this.init (Id, listaAmigos, listaBloqueados, inmuebles, habitaciones, peticionesEnviadas, peticionesRecibidas, preferenciasBusqueda, gustos, elementos, apellidos, nif, fechaNacimiento, privacidad, muro, grupos, mensajesEnviados, mensajesRecibidos, valoracionEmitida, valoracionRecibida, entradasMeGusta, entradas, entradasReportadas, comentarios, comentariosReportados, nombre, telefono, email, direccion, poblacion, codigoPostal, pais, password, valoracionMedia);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.ListaAmigos, usuario.ListaBloqueados, usuario.Inmuebles, usuario.Habitaciones, usuario.PeticionesEnviadas, usuario.PeticionesRecibidas, usuario.PreferenciasBusqueda, usuario.Gustos, usuario.Elementos, usuario.Apellidos, usuario.Nif, usuario.FechaNacimiento, usuario.Privacidad, usuario.Muro, usuario.Grupos, usuario.MensajesEnviados, usuario.MensajesRecibidos, usuario.ValoracionEmitida, usuario.ValoracionRecibida, usuario.EntradasMeGusta, usuario.Entradas, usuario.EntradasReportadas, usuario.Comentarios, usuario.ComentariosReportados, usuario.Nombre, usuario.Telefono, usuario.Email, usuario.Direccion, usuario.Poblacion, usuario.CodigoPostal, usuario.Pais, usuario.Password, usuario.ValoracionMedia);
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
        UsuarioEN t = obj as UsuarioEN;
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
