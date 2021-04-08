
using System;
// Definición clase GrupoEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class GrupoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum tipo;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo miembros
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> miembros;



/**
 *	Atributo muro
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro;



/**
 *	Atributo preferenciasBusqueda
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> Miembros {
        get { return miembros; } set { miembros = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN Muro {
        get { return muro; } set { muro = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN PreferenciasBusqueda {
        get { return preferenciasBusqueda; } set { preferenciasBusqueda = value;  }
}





public GrupoEN()
{
        miembros = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
}



public GrupoEN(int id, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum tipo, string nombre, string descripcion, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> miembros, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda
               )
{
        this.init (Id, tipo, nombre, descripcion, miembros, muro, preferenciasBusqueda);
}


public GrupoEN(GrupoEN grupo)
{
        this.init (Id, grupo.Tipo, grupo.Nombre, grupo.Descripcion, grupo.Miembros, grupo.Muro, grupo.PreferenciasBusqueda);
}

private void init (int id, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum tipo, string nombre, string descripcion, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> miembros, NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muro, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Miembros = miembros;

        this.Muro = muro;

        this.PreferenciasBusqueda = preferenciasBusqueda;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GrupoEN t = obj as GrupoEN;
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
