
using System;
// Definición clase AnuncioEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class AnuncioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fechaCaducidad
 */
private Nullable<DateTime> fechaCaducidad;



/**
 *	Atributo tipo
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum tipo;



/**
 *	Atributo uRL
 */
private string uRL;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> FechaCaducidad {
        get { return fechaCaducidad; } set { fechaCaducidad = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string URL {
        get { return uRL; } set { uRL = value;  }
}





public AnuncioEN()
{
}



public AnuncioEN(int id, string imagen, string descripcion, Nullable<DateTime> fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum tipo, string uRL
                 )
{
        this.init (Id, imagen, descripcion, fechaCaducidad, tipo, uRL);
}


public AnuncioEN(AnuncioEN anuncio)
{
        this.init (Id, anuncio.Imagen, anuncio.Descripcion, anuncio.FechaCaducidad, anuncio.Tipo, anuncio.URL);
}

private void init (int id, string imagen, string descripcion, Nullable<DateTime> fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum tipo, string uRL)
{
        this.Id = id;


        this.Imagen = imagen;

        this.Descripcion = descripcion;

        this.FechaCaducidad = fechaCaducidad;

        this.Tipo = tipo;

        this.URL = uRL;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AnuncioEN t = obj as AnuncioEN;
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
