
using System;
// Definición clase PaginaCorporativaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class PaginaCorporativaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo uRL
 */
private string uRL;



/**
 *	Atributo inmobiliaria
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual string URL {
        get { return uRL; } set { uRL = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN Inmobiliaria {
        get { return inmobiliaria; } set { inmobiliaria = value;  }
}





public PaginaCorporativaEN()
{
}



public PaginaCorporativaEN(int id, string contenido, string uRL, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria
                           )
{
        this.init (Id, contenido, uRL, inmobiliaria);
}


public PaginaCorporativaEN(PaginaCorporativaEN paginaCorporativa)
{
        this.init (Id, paginaCorporativa.Contenido, paginaCorporativa.URL, paginaCorporativa.Inmobiliaria);
}

private void init (int id, string contenido, string uRL, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria)
{
        this.Id = id;


        this.Contenido = contenido;

        this.URL = uRL;

        this.Inmobiliaria = inmobiliaria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaginaCorporativaEN t = obj as PaginaCorporativaEN;
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
