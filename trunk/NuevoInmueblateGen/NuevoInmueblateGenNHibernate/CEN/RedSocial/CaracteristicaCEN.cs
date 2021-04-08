

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
/*
 *      Definition of the class CaracteristicaCEN
 *
 */
public partial class CaracteristicaCEN
{
private ICaracteristicaCAD _ICaracteristicaCAD;

public CaracteristicaCEN()
{
        this._ICaracteristicaCAD = new CaracteristicaCAD ();
}

public CaracteristicaCEN(ICaracteristicaCAD _ICaracteristicaCAD)
{
        this._ICaracteristicaCAD = _ICaracteristicaCAD;
}

public ICaracteristicaCAD get_ICaracteristicaCAD ()
{
        return this._ICaracteristicaCAD;
}

public int CrearCaracteristica (string p_nombre, string p_valor)
{
        CaracteristicaEN caracteristicaEN = null;
        int oid;

        //Initialized CaracteristicaEN
        caracteristicaEN = new CaracteristicaEN ();
        caracteristicaEN.Nombre = p_nombre;

        caracteristicaEN.Valor = p_valor;

        //Call to CaracteristicaCAD

        oid = _ICaracteristicaCAD.CrearCaracteristica (caracteristicaEN);
        return oid;
}

public void ModificarCaracteristica (int p_oid, string p_nombre, string p_valor)
{
        CaracteristicaEN caracteristicaEN = null;

        //Initialized CaracteristicaEN
        caracteristicaEN = new CaracteristicaEN ();
        caracteristicaEN.Id = p_oid;
        caracteristicaEN.Nombre = p_nombre;
        caracteristicaEN.Valor = p_valor;
        //Call to CaracteristicaCAD

        _ICaracteristicaCAD.ModificarCaracteristica (caracteristicaEN);
}

public void BorrarCaracteristica (int id)
{
        _ICaracteristicaCAD.BorrarCaracteristica (id);
}

public void AnyadirCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion)
{
        //Call to CaracteristicaCAD

        _ICaracteristicaCAD.AnyadirCaracteristicaHabitacion (p_caracteristica, p_habitacion);
}
public void BorrarCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion)
{
        //Call to CaracteristicaCAD

        _ICaracteristicaCAD.BorrarCaracteristicaHabitacion (p_caracteristica, p_habitacion);
}
public void AnyadirCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble)
{
        //Call to CaracteristicaCAD

        _ICaracteristicaCAD.AnyadirCaracteristicaInmueble (p_caracteristica, p_inmueble);
}
public void BorrarCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble)
{
        //Call to CaracteristicaCAD

        _ICaracteristicaCAD.BorrarCaracteristicaInmueble (p_caracteristica, p_inmueble);
}
public CaracteristicaEN DameCaracteristicaPorOID (int id)
{
        CaracteristicaEN caracteristicaEN = null;

        caracteristicaEN = _ICaracteristicaCAD.DameCaracteristicaPorOID (id);
        return caracteristicaEN;
}

public System.Collections.Generic.IList<CaracteristicaEN> DameTodasLasCaracteristicas (int first, int size)
{
        System.Collections.Generic.IList<CaracteristicaEN> list = null;

        list = _ICaracteristicaCAD.DameTodasLasCaracteristicas (first, size);
        return list;
}
}
}
