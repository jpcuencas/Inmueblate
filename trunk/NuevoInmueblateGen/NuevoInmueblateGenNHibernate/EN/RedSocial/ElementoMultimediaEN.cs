
using System;
// Definición clase ElementoMultimediaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class ElementoMultimediaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo mensaje
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje;



/**
 *	Atributo galeria
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria;



/**
 *	Atributo entradas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas;



/**
 *	Atributo aparicionComentarios
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios;



/**
 *	Atributo inmueble
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble;



/**
 *	Atributo usuario
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo pendienteModeracion
 */
private bool pendienteModeracion;



/**
 *	Atributo uRL
 */
private string uRL;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN Galeria {
        get { return galeria; } set { galeria = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> Entradas {
        get { return entradas; } set { entradas = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> AparicionComentarios {
        get { return aparicionComentarios; } set { aparicionComentarios = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN Inmueble {
        get { return inmueble; } set { inmueble = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual string URL {
        get { return uRL; } set { uRL = value;  }
}





public ElementoMultimediaEN()
{
        mensaje = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
        entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
        aparicionComentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
}



public ElementoMultimediaEN(int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL
                            )
{
        this.init (Id, mensaje, galeria, entradas, aparicionComentarios, inmueble, usuario, fecha, descripcion, nombre, pendienteModeracion, uRL);
}


public ElementoMultimediaEN(ElementoMultimediaEN elementoMultimedia)
{
        this.init (Id, elementoMultimedia.Mensaje, elementoMultimedia.Galeria, elementoMultimedia.Entradas, elementoMultimedia.AparicionComentarios, elementoMultimedia.Inmueble, elementoMultimedia.Usuario, elementoMultimedia.Fecha, elementoMultimedia.Descripcion, elementoMultimedia.Nombre, elementoMultimedia.PendienteModeracion, elementoMultimedia.URL);
}

private void init (int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL)
{
        this.Id = id;


        this.Mensaje = mensaje;

        this.Galeria = galeria;

        this.Entradas = entradas;

        this.AparicionComentarios = aparicionComentarios;

        this.Inmueble = inmueble;

        this.Usuario = usuario;

        this.Fecha = fecha;

        this.Descripcion = descripcion;

        this.Nombre = nombre;

        this.PendienteModeracion = pendienteModeracion;

        this.URL = uRL;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ElementoMultimediaEN t = obj as ElementoMultimediaEN;
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
