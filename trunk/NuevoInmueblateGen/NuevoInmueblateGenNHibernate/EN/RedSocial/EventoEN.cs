
using System;
// Definición clase EventoEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class EventoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo categoria
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum categoria;



/**
 *	Atributo inmobiliaria
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria;



/**
 *	Atributo geolocalizacion
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN Inmobiliaria {
        get { return inmobiliaria; } set { inmobiliaria = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN Geolocalizacion {
        get { return geolocalizacion; } set { geolocalizacion = value;  }
}





public EventoEN()
{
}



public EventoEN(int id, string nombre, string descripcion, Nullable<DateTime> fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum categoria, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion
                )
{
        this.init (Id, nombre, descripcion, fecha, categoria, inmobiliaria, geolocalizacion);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Nombre, evento.Descripcion, evento.Fecha, evento.Categoria, evento.Inmobiliaria, evento.Geolocalizacion);
}

private void init (int id, string nombre, string descripcion, Nullable<DateTime> fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum categoria, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Fecha = fecha;

        this.Categoria = categoria;

        this.Inmobiliaria = inmobiliaria;

        this.Geolocalizacion = geolocalizacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventoEN t = obj as EventoEN;
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
