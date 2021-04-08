
using System;
// Definición clase ComentarioEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo pendienteModeracion
 */
private bool pendienteModeracion;



/**
 *	Atributo fechaPublicacion
 */
private Nullable<DateTime> fechaPublicacion;



/**
 *	Atributo creador
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador;



/**
 *	Atributo reportadores
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores;



/**
 *	Atributo entrada
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entrada;



/**
 *	Atributo elementosMultimedia
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual Nullable<DateTime> FechaPublicacion {
        get { return fechaPublicacion; } set { fechaPublicacion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Creador {
        get { return creador; } set { creador = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> Reportadores {
        get { return reportadores; } set { reportadores = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN Entrada {
        get { return entrada; } set { entrada = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ElementosMultimedia {
        get { return elementosMultimedia; } set { elementosMultimedia = value;  }
}





public ComentarioEN()
{
        reportadores = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
        elementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public ComentarioEN(int id, string cuerpo, bool pendienteModeracion, Nullable<DateTime> fechaPublicacion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores, NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entrada, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia
                    )
{
        this.init (Id, cuerpo, pendienteModeracion, fechaPublicacion, creador, reportadores, entrada, elementosMultimedia);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Cuerpo, comentario.PendienteModeracion, comentario.FechaPublicacion, comentario.Creador, comentario.Reportadores, comentario.Entrada, comentario.ElementosMultimedia);
}

private void init (int id, string cuerpo, bool pendienteModeracion, Nullable<DateTime> fechaPublicacion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN creador, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> reportadores, NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entrada, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia)
{
        this.Id = id;


        this.Cuerpo = cuerpo;

        this.PendienteModeracion = pendienteModeracion;

        this.FechaPublicacion = fechaPublicacion;

        this.Creador = creador;

        this.Reportadores = reportadores;

        this.Entrada = entrada;

        this.ElementosMultimedia = elementosMultimedia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
