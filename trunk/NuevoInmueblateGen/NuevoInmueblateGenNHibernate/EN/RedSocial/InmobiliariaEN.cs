
using System;
// Definición clase InmobiliariaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class InmobiliariaEN                                                                 : NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN


{
/**
 *	Atributo inmuebles
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles;



/**
 *	Atributo paginaCorporativa
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> paginaCorporativa;



/**
 *	Atributo eventos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventos;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo cif
 */
private string cif;






public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> Inmuebles {
        get { return inmuebles; } set { inmuebles = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> PaginaCorporativa {
        get { return paginaCorporativa; } set { paginaCorporativa = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> Eventos {
        get { return eventos; } set { eventos = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Cif {
        get { return cif; } set { cif = value;  }
}





public InmobiliariaEN() : base ()
{
        inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
        paginaCorporativa = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN>();
        eventos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>();
}



public InmobiliariaEN(int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> paginaCorporativa, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventos, string descripcion, string cif
                      , NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia
                      )
{
        this.init (Id, inmuebles, paginaCorporativa, eventos, descripcion, cif, muro, grupos, mensajesEnviados, mensajesRecibidos, valoracionEmitida, valoracionRecibida, entradasMeGusta, entradas, entradasReportadas, comentarios, comentariosReportados, nombre, telefono, email, direccion, poblacion, codigoPostal, pais, password, valoracionMedia);
}


public InmobiliariaEN(InmobiliariaEN inmobiliaria)
{
        this.init (Id, inmobiliaria.Inmuebles, inmobiliaria.PaginaCorporativa, inmobiliaria.Eventos, inmobiliaria.Descripcion, inmobiliaria.Cif, inmobiliaria.Muro, inmobiliaria.Grupos, inmobiliaria.MensajesEnviados, inmobiliaria.MensajesRecibidos, inmobiliaria.ValoracionEmitida, inmobiliaria.ValoracionRecibida, inmobiliaria.EntradasMeGusta, inmobiliaria.Entradas, inmobiliaria.EntradasReportadas, inmobiliaria.Comentarios, inmobiliaria.ComentariosReportados, inmobiliaria.Nombre, inmobiliaria.Telefono, inmobiliaria.Email, inmobiliaria.Direccion, inmobiliaria.Poblacion, inmobiliaria.CodigoPostal, inmobiliaria.Pais, inmobiliaria.Password, inmobiliaria.ValoracionMedia);
}

private void init (int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> paginaCorporativa, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventos, string descripcion, string cif, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionEmitida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> valoracionRecibida, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasMeGusta, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradasReportadas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentariosReportados, string nombre, string telefono, string email, string direccion, string poblacion, string codigoPostal, string pais, String password, float valoracionMedia)
{
        this.Id = id;


        this.Inmuebles = inmuebles;

        this.PaginaCorporativa = paginaCorporativa;

        this.Eventos = eventos;

        this.Descripcion = descripcion;

        this.Cif = cif;

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
        InmobiliariaEN t = obj as InmobiliariaEN;
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
