
using System;
// Definición clase InmuebleEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class InmuebleEN
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
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo tipo
 */
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum tipo;



/**
 *	Atributo metrosCuadrados
 */
private int metrosCuadrados;



/**
 *	Atributo alquiler
 */
private bool alquiler;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo inquilinos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos;



/**
 *	Atributo geolocalizacion
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion;



/**
 *	Atributo caracteristicas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas;



/**
 *	Atributo habitaciones
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones;



/**
 *	Atributo elementosMultimedia
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia;



/**
 *	Atributo inmobiliaria
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual int MetrosCuadrados {
        get { return metrosCuadrados; } set { metrosCuadrados = value;  }
}



public virtual bool Alquiler {
        get { return alquiler; } set { alquiler = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> Inquilinos {
        get { return inquilinos; } set { inquilinos = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN Geolocalizacion {
        get { return geolocalizacion; } set { geolocalizacion = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> Caracteristicas {
        get { return caracteristicas; } set { caracteristicas = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> Habitaciones {
        get { return habitaciones; } set { habitaciones = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ElementosMultimedia {
        get { return elementosMultimedia; } set { elementosMultimedia = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN Inmobiliaria {
        get { return inmobiliaria; } set { inmobiliaria = value;  }
}





public InmuebleEN()
{
        inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
        habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
        elementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public InmuebleEN(int id, bool pendienteModeracion, string descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum tipo, int metrosCuadrados, bool alquiler, float precio, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria
                  )
{
        this.init (Id, pendienteModeracion, descripcion, tipo, metrosCuadrados, alquiler, precio, inquilinos, geolocalizacion, caracteristicas, habitaciones, elementosMultimedia, inmobiliaria);
}


public InmuebleEN(InmuebleEN inmueble)
{
        this.init (Id, inmueble.PendienteModeracion, inmueble.Descripcion, inmueble.Tipo, inmueble.MetrosCuadrados, inmueble.Alquiler, inmueble.Precio, inmueble.Inquilinos, inmueble.Geolocalizacion, inmueble.Caracteristicas, inmueble.Habitaciones, inmueble.ElementosMultimedia, inmueble.Inmobiliaria);
}

private void init (int id, bool pendienteModeracion, string descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum tipo, int metrosCuadrados, bool alquiler, float precio, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos, NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacion, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia, NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliaria)
{
        this.Id = id;


        this.PendienteModeracion = pendienteModeracion;

        this.Descripcion = descripcion;

        this.Tipo = tipo;

        this.MetrosCuadrados = metrosCuadrados;

        this.Alquiler = alquiler;

        this.Precio = precio;

        this.Inquilinos = inquilinos;

        this.Geolocalizacion = geolocalizacion;

        this.Caracteristicas = caracteristicas;

        this.Habitaciones = habitaciones;

        this.ElementosMultimedia = elementosMultimedia;

        this.Inmobiliaria = inmobiliaria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        InmuebleEN t = obj as InmuebleEN;
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
