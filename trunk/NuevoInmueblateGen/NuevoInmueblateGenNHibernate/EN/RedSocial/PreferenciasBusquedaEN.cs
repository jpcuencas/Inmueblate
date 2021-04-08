
using System;
// Definición clase PreferenciasBusquedaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class PreferenciasBusquedaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo distanciaTolerable
 */
private int distanciaTolerable;



/**
 *	Atributo precioMax
 */
private float precioMax;



/**
 *	Atributo precioMin
 */
private float precioMin;



/**
 *	Atributo usuario
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario;



/**
 *	Atributo grupo
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN grupo;



/**
 *	Atributo geolocalizacion
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int DistanciaTolerable {
        get { return distanciaTolerable; } set { distanciaTolerable = value;  }
}



public virtual float PrecioMax {
        get { return precioMax; } set { precioMax = value;  }
}



public virtual float PrecioMin {
        get { return precioMin; } set { precioMin = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN Geolocalizacion {
        get { return geolocalizacion; } set { geolocalizacion = value;  }
}





public PreferenciasBusquedaEN()
{
}



public PreferenciasBusquedaEN(int id, int distanciaTolerable, float precioMax, float precioMin, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN grupo, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion
                              )
{
        this.init (Id, distanciaTolerable, precioMax, precioMin, usuario, grupo, geolocalizacion);
}


public PreferenciasBusquedaEN(PreferenciasBusquedaEN preferenciasBusqueda)
{
        this.init (Id, preferenciasBusqueda.DistanciaTolerable, preferenciasBusqueda.PrecioMax, preferenciasBusqueda.PrecioMin, preferenciasBusqueda.Usuario, preferenciasBusqueda.Grupo, preferenciasBusqueda.Geolocalizacion);
}

private void init (int id, int distanciaTolerable, float precioMax, float precioMin, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN grupo, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion)
{
        this.Id = id;


        this.DistanciaTolerable = distanciaTolerable;

        this.PrecioMax = precioMax;

        this.PrecioMin = precioMin;

        this.Usuario = usuario;

        this.Grupo = grupo;

        this.Geolocalizacion = geolocalizacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PreferenciasBusquedaEN t = obj as PreferenciasBusquedaEN;
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
