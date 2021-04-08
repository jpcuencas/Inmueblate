
using System;
// Definición clase GustosEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class GustosEN
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
 *	Atributo musica
 */
private System.Collections.Generic.IList<string> musica;



/**
 *	Atributo libros
 */
private System.Collections.Generic.IList<string> libros;



/**
 *	Atributo peliculas
 */
private System.Collections.Generic.IList<string> peliculas;



/**
 *	Atributo juegos
 */
private System.Collections.Generic.IList<string> juegos;



/**
 *	Atributo usuario
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual System.Collections.Generic.IList<string> Musica {
        get { return musica; } set { musica = value;  }
}



public virtual System.Collections.Generic.IList<string> Libros {
        get { return libros; } set { libros = value;  }
}



public virtual System.Collections.Generic.IList<string> Peliculas {
        get { return peliculas; } set { peliculas = value;  }
}



public virtual System.Collections.Generic.IList<string> Juegos {
        get { return juegos; } set { juegos = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public GustosEN()
{
}



public GustosEN(int id, bool pendienteModeracion, System.Collections.Generic.IList<string> musica, System.Collections.Generic.IList<string> libros, System.Collections.Generic.IList<string> peliculas, System.Collections.Generic.IList<string> juegos, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario
                )
{
        this.init (Id, pendienteModeracion, musica, libros, peliculas, juegos, usuario);
}


public GustosEN(GustosEN gustos)
{
        this.init (Id, gustos.PendienteModeracion, gustos.Musica, gustos.Libros, gustos.Peliculas, gustos.Juegos, gustos.Usuario);
}

private void init (int id, bool pendienteModeracion, System.Collections.Generic.IList<string> musica, System.Collections.Generic.IList<string> libros, System.Collections.Generic.IList<string> peliculas, System.Collections.Generic.IList<string> juegos, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario)
{
        this.Id = id;


        this.PendienteModeracion = pendienteModeracion;

        this.Musica = musica;

        this.Libros = libros;

        this.Peliculas = peliculas;

        this.Juegos = juegos;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GustosEN t = obj as GustosEN;
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
