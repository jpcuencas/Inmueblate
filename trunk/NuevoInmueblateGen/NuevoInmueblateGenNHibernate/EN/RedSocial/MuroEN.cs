
using System;
// Definición clase MuroEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class MuroEN
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
 *	Atributo propietarioUsuario
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN propietarioUsuario;



/**
 *	Atributo propietarioGrupo
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN propietarioGrupo;



/**
 *	Atributo entradas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN PropietarioUsuario {
        get { return propietarioUsuario; } set { propietarioUsuario = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN PropietarioGrupo {
        get { return propietarioGrupo; } set { propietarioGrupo = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> Entradas {
        get { return entradas; } set { entradas = value;  }
}





public MuroEN()
{
        entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
}



public MuroEN(int id, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN propietarioUsuario, NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN propietarioGrupo, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas
              )
{
        this.init (Id, pendienteModeracion, propietarioUsuario, propietarioGrupo, entradas);
}


public MuroEN(MuroEN muro)
{
        this.init (Id, muro.PendienteModeracion, muro.PropietarioUsuario, muro.PropietarioGrupo, muro.Entradas);
}

private void init (int id, bool pendienteModeracion, NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN propietarioUsuario, NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN propietarioGrupo, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas)
{
        this.Id = id;


        this.PendienteModeracion = pendienteModeracion;

        this.PropietarioUsuario = propietarioUsuario;

        this.PropietarioGrupo = propietarioGrupo;

        this.Entradas = entradas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MuroEN t = obj as MuroEN;
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
