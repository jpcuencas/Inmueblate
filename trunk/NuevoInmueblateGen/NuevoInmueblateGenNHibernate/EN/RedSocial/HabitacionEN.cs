
using System;
// Definición clase HabitacionEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class HabitacionEN
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
 *	Atributo metrosCuadrados
 */
private int metrosCuadrados;



/**
 *	Atributo alquiler
 */
private bool alquiler;



/**
 *	Atributo inquilinos
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos;



/**
 *	Atributo caracteristicas
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas;



/**
 *	Atributo inmueble
 */
private NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int MetrosCuadrados {
        get { return metrosCuadrados; } set { metrosCuadrados = value;  }
}



public virtual bool Alquiler {
        get { return alquiler; } set { alquiler = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> Inquilinos {
        get { return inquilinos; } set { inquilinos = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> Caracteristicas {
        get { return caracteristicas; } set { caracteristicas = value;  }
}



public virtual NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN Inmueble {
        get { return inmueble; } set { inmueble = value;  }
}





public HabitacionEN()
{
        inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
}



public HabitacionEN(int id, bool pendienteModeracion, string descripcion, int metrosCuadrados, bool alquiler, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble
                    )
{
        this.init (Id, pendienteModeracion, descripcion, metrosCuadrados, alquiler, inquilinos, caracteristicas, inmueble);
}


public HabitacionEN(HabitacionEN habitacion)
{
        this.init (Id, habitacion.PendienteModeracion, habitacion.Descripcion, habitacion.MetrosCuadrados, habitacion.Alquiler, habitacion.Inquilinos, habitacion.Caracteristicas, habitacion.Inmueble);
}

private void init (int id, bool pendienteModeracion, string descripcion, int metrosCuadrados, bool alquiler, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> inquilinos, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN> caracteristicas, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble)
{
        this.Id = id;


        this.PendienteModeracion = pendienteModeracion;

        this.Descripcion = descripcion;

        this.MetrosCuadrados = metrosCuadrados;

        this.Alquiler = alquiler;

        this.Inquilinos = inquilinos;

        this.Caracteristicas = caracteristicas;

        this.Inmueble = inmueble;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HabitacionEN t = obj as HabitacionEN;
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
