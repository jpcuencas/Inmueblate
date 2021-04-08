
using System;
// Definición clase PeticionAmistadEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class PeticionAmistadEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo asunto
 */
private string asunto;



/**
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo estado
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum estado;



/**
 *	Atributo emisor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN emisor;



/**
 *	Atributo receptor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN receptor;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Asunto {
        get { return asunto; } set { asunto = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN Emisor {
        get { return emisor; } set { emisor = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN Receptor {
        get { return receptor; } set { receptor = value;  }
}





public PeticionAmistadEN()
{
}



public PeticionAmistadEN(int id, string asunto, string cuerpo, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum estado, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN receptor
                         )
{
        this.init (Id, asunto, cuerpo, estado, emisor, receptor);
}


public PeticionAmistadEN(PeticionAmistadEN peticionAmistad)
{
        this.init (Id, peticionAmistad.Asunto, peticionAmistad.Cuerpo, peticionAmistad.Estado, peticionAmistad.Emisor, peticionAmistad.Receptor);
}

private void init (int id, string asunto, string cuerpo, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum estado, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN receptor)
{
        this.Id = id;


        this.Asunto = asunto;

        this.Cuerpo = cuerpo;

        this.Estado = estado;

        this.Emisor = emisor;

        this.Receptor = receptor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PeticionAmistadEN t = obj as PeticionAmistadEN;
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
