
using System;
// Definición clase MensajeEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class MensajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pendienteModeracion
 */
private bool pendienteModeracion;



/**
 *	Atributo fechaEnvio
 */
private Nullable<DateTime> fechaEnvio;



/**
 *	Atributo asunto
 */
private string asunto;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo leido
 */
private bool leido;



/**
 *	Atributo emisor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor;



/**
 *	Atributo receptor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor;



/**
 *	Atributo elementosMultimedia
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual Nullable<DateTime> FechaEnvio {
        get { return fechaEnvio; } set { fechaEnvio = value;  }
}



public virtual string Asunto {
        get { return asunto; } set { asunto = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual bool Leido {
        get { return leido; } set { leido = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Emisor {
        get { return emisor; } set { emisor = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Receptor {
        get { return receptor; } set { receptor = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ElementosMultimedia {
        get { return elementosMultimedia; } set { elementosMultimedia = value;  }
}





public MensajeEN()
{
        elementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public MensajeEN(int id, bool pendienteModeracion, Nullable<DateTime> fechaEnvio, string asunto, string cuerpo, bool leido, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia
                 )
{
        this.init (Id, pendienteModeracion, fechaEnvio, asunto, cuerpo, leido, emisor, receptor, elementosMultimedia);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.PendienteModeracion, mensaje.FechaEnvio, mensaje.Asunto, mensaje.Cuerpo, mensaje.Leido, mensaje.Emisor, mensaje.Receptor, mensaje.ElementosMultimedia);
}

private void init (int id, bool pendienteModeracion, Nullable<DateTime> fechaEnvio, string asunto, string cuerpo, bool leido, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia)
{
        this.Id = id;


        this.PendienteModeracion = pendienteModeracion;

        this.FechaEnvio = fechaEnvio;

        this.Asunto = asunto;

        this.Cuerpo = cuerpo;

        this.Leido = leido;

        this.Emisor = emisor;

        this.Receptor = receptor;

        this.ElementosMultimedia = elementosMultimedia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
