
using System;
// Definición clase EntradaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class EntradaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaPublicacion
 */
private Nullable<DateTime> fechaPublicacion;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo pendienteModeracion
 */
private bool pendienteModeracion;



/**
 *	Atributo muro
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro;



/**
 *	Atributo usuariosMeGusta
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> usuariosMeGusta;



/**
 *	Atributo creador
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador;



/**
 *	Atributo reportadores
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios;



/**
 *	Atributo elementosMultimedia
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaPublicacion {
        get { return fechaPublicacion; } set { fechaPublicacion = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN Muro {
        get { return muro; } set { muro = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> UsuariosMeGusta {
        get { return usuariosMeGusta; } set { usuariosMeGusta = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Creador {
        get { return creador; } set { creador = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> Reportadores {
        get { return reportadores; } set { reportadores = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ElementosMultimedia {
        get { return elementosMultimedia; } set { elementosMultimedia = value;  }
}





public EntradaEN()
{
        usuariosMeGusta = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
        reportadores = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
        comentarios = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
        elementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public EntradaEN(int id, Nullable<DateTime> fechaPublicacion, string titulo, string cuerpo, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> usuariosMeGusta, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia
                 )
{
        this.init (Id, fechaPublicacion, titulo, cuerpo, pendienteModeracion, muro, usuariosMeGusta, creador, reportadores, comentarios, elementosMultimedia);
}


public EntradaEN(EntradaEN entrada)
{
        this.init (Id, entrada.FechaPublicacion, entrada.Titulo, entrada.Cuerpo, entrada.PendienteModeracion, entrada.Muro, entrada.UsuariosMeGusta, entrada.Creador, entrada.Reportadores, entrada.Comentarios, entrada.ElementosMultimedia);
}

private void init (int id, Nullable<DateTime> fechaPublicacion, string titulo, string cuerpo, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> usuariosMeGusta, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> comentarios, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia)
{
        this.Id = id;


        this.FechaPublicacion = fechaPublicacion;

        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.PendienteModeracion = pendienteModeracion;

        this.Muro = muro;

        this.UsuariosMeGusta = usuariosMeGusta;

        this.Creador = creador;

        this.Reportadores = reportadores;

        this.Comentarios = comentarios;

        this.ElementosMultimedia = elementosMultimedia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EntradaEN t = obj as EntradaEN;
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
