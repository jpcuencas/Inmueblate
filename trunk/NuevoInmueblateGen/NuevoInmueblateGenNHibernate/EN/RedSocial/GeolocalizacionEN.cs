
using System;
// Definición clase GeolocalizacionEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class GeolocalizacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo longitud
 */
private float longitud;



/**
 *	Atributo latitud
 */
private float latitud;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo poblacion
 */
private string poblacion;



/**
 *	Atributo preferenciasBusqueda
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda;



/**
 *	Atributo inmueble
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble;



/**
 *	Atributo evento
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN evento;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual float Longitud {
        get { return longitud; } set { longitud = value;  }
}



public virtual float Latitud {
        get { return latitud; } set { latitud = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Poblacion {
        get { return poblacion; } set { poblacion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN PreferenciasBusqueda {
        get { return preferenciasBusqueda; } set { preferenciasBusqueda = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN Inmueble {
        get { return inmueble; } set { inmueble = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN Evento {
        get { return evento; } set { evento = value;  }
}





public GeolocalizacionEN()
{
}



public GeolocalizacionEN(int id, float longitud, float latitud, string direccion, string poblacion, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN evento
                         )
{
        this.init (Id, longitud, latitud, direccion, poblacion, preferenciasBusqueda, inmueble, evento);
}


public GeolocalizacionEN(GeolocalizacionEN geolocalizacion)
{
        this.init (Id, geolocalizacion.Longitud, geolocalizacion.Latitud, geolocalizacion.Direccion, geolocalizacion.Poblacion, geolocalizacion.PreferenciasBusqueda, geolocalizacion.Inmueble, geolocalizacion.Evento);
}

private void init (int id, float longitud, float latitud, string direccion, string poblacion, NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusqueda, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN evento)
{
        this.Id = id;


        this.Longitud = longitud;

        this.Latitud = latitud;

        this.Direccion = direccion;

        this.Poblacion = poblacion;

        this.PreferenciasBusqueda = preferenciasBusqueda;

        this.Inmueble = inmueble;

        this.Evento = evento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GeolocalizacionEN t = obj as GeolocalizacionEN;
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
