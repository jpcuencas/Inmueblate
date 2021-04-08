
using System;
// Definición clase ValoracionEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valoracion
 */
private float valoracion;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo pendienteModeracion
 */
private bool pendienteModeracion;



/**
 *	Atributo emisor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor;



/**
 *	Atributo receptor
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual float Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Emisor {
        get { return emisor; } set { emisor = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN Receptor {
        get { return receptor; } set { receptor = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, float valoracion, string descripcion, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor
                    )
{
        this.init (Id, valoracion, descripcion, pendienteModeracion, emisor, receptor);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Valoracion, valoracion.Descripcion, valoracion.PendienteModeracion, valoracion.Emisor, valoracion.Receptor);
}

private void init (int id, float valoracion, string descripcion, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN emisor, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN receptor)
{
        this.Id = id;


        this.Valoracion = valoracion;

        this.Descripcion = descripcion;

        this.PendienteModeracion = pendienteModeracion;

        this.Emisor = emisor;

        this.Receptor = receptor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
