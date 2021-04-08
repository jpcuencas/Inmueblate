
using System;
// Definición clase SuperUsuarioEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class SuperUsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo muro
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro;



/**
 *	Atributo grupos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos;



/**
 *	Atributo mensajesEnviados
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados;



/**
 *	Atributo mensajesRecibidos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos;



/**
 *	Atributo valoracionEmitida
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida;



/**
 *	Atributo valoracionRecibida
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida;



/**
 *	Atributo entradasMeGusta
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta;



/**
 *	Atributo entradas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas;



/**
 *	Atributo entradasReportadas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios;



/**
 *	Atributo comentariosReportados
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo poblacion
 */
private string poblacion;



/**
 *	Atributo codigoPostal
 */
private string codigoPostal;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo valoracionMedia
 */
private float valoracionMedia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN Muro {
        get { return muro; } set { muro = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> Grupos {
        get { return grupos; } set { grupos = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> MensajesEnviados {
        get { return mensajesEnviados; } set { mensajesEnviados = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> MensajesRecibidos {
        get { return mensajesRecibidos; } set { mensajesRecibidos = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ValoracionEmitida {
        get { return valoracionEmitida; } set { valoracionEmitida = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ValoracionRecibida {
        get { return valoracionRecibida; } set { valoracionRecibida = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> EntradasMeGusta {
        get { return entradasMeGusta; } set { entradasMeGusta = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> Entradas {
        get { return entradas; } set { entradas = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> EntradasReportadas {
        get { return entradasReportadas; } set { entradasReportadas = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ComentariosReportados {
        get { return comentariosReportados; } set { comentariosReportados = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Poblacion {
        get { return poblacion; } set { poblacion = value;  }
}



public virtual string CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual float ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}





public SuperUsuarioEN()
{
        grupos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
        mensajesEnviados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
        mensajesRecibidos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
        valoracionEmitida = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
        valoracionRecibida = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
        entradasMeGusta = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
        entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
        entradasReportadas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
        comentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
        comentariosReportados = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
}



public SuperUsuarioEN(int id, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia
                      )
{
        this.init (Id, muro, grupos, mensajesEnviados, mensajesRecibidos, valoracionEmitida, valoracionRecibida, entradasMeGusta, entradas, entradasReportadas, comentarios, comentariosReportados, nombre, telefono, email, direccion, poblacion, codigoPostal, pais, password, valoracionMedia);
}


public SuperUsuarioEN(SuperUsuarioEN superUsuario)
{
        this.init (Id, superUsuario.Muro, superUsuario.Grupos, superUsuario.MensajesEnviados, superUsuario.MensajesRecibidos, superUsuario.ValoracionEmitida, superUsuario.ValoracionRecibida, superUsuario.EntradasMeGusta, superUsuario.Entradas, superUsuario.EntradasReportadas, superUsuario.Comentarios, superUsuario.ComentariosReportados, superUsuario.Nombre, superUsuario.Telefono, superUsuario.Email, superUsuario.Direccion, superUsuario.Poblacion, superUsuario.CodigoPostal, superUsuario.Pais, superUsuario.Password, superUsuario.ValoracionMedia);
}

private void init (int id, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia)
{
        this.Id = id;


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
        SuperUsuarioEN t = obj as SuperUsuarioEN;
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
