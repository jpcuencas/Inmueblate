
using System;
// Definición clase CaracteristicaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class CaracteristicaEN
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
 *	Atributo valor
 */
private string valor;



/**
 *	Atributo inmuebles
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles;



/**
 *	Atributo habitaciones
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Valor {
        get { return valor; } set { valor = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> Inmuebles {
        get { return inmuebles; } set { inmuebles = value;  }
}



public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> Habitaciones {
        get { return habitaciones; } set { habitaciones = value;  }
}





public CaracteristicaEN()
{
        inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
        habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
}



public CaracteristicaEN(int id, string nombre, string valor, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones
                        )
{
        this.init (Id, nombre, valor, inmuebles, habitaciones);
}


public CaracteristicaEN(CaracteristicaEN caracteristica)
{
        this.init (Id, caracteristica.Nombre, caracteristica.Valor, caracteristica.Inmuebles, caracteristica.Habitaciones);
}

private void init (int id, string nombre, string valor, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebles, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> habitaciones)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Valor = valor;

        this.Inmuebles = inmuebles;

        this.Habitaciones = habitaciones;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CaracteristicaEN t = obj as CaracteristicaEN;
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
