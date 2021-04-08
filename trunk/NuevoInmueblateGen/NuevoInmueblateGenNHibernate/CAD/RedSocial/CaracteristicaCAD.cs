
using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.Exceptions;

/*
 * Clase Caracteristica:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class CaracteristicaCAD : BasicCAD, ICaracteristicaCAD
{
public CaracteristicaCAD() : base ()
{
}

public CaracteristicaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CaracteristicaEN ReadOIDDefault (int id)
{
        CaracteristicaEN caracteristicaEN = null;

        try
        {
                SessionInitializeTransaction ();
                caracteristicaEN = (CaracteristicaEN)session.Get (typeof(CaracteristicaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caracteristicaEN;
}

public System.Collections.Generic.IList<CaracteristicaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<CaracteristicaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CaracteristicaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CaracteristicaEN>();
                        else
                                result = session.CreateCriteria (typeof(CaracteristicaEN)).List<CaracteristicaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }

        return result;
}

public int CrearCaracteristica (CaracteristicaEN caracteristica)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (caracteristica);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caracteristica.Id;
}

public void ModificarCaracteristica (CaracteristicaEN caracteristica)
{
        try
        {
                SessionInitializeTransaction ();
                CaracteristicaEN caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), caracteristica.Id);

                caracteristicaEN.Nombre = caracteristica.Nombre;


                caracteristicaEN.Valor = caracteristica.Valor;

                session.Update (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarCaracteristica (int id)
{
        try
        {
                SessionInitializeTransaction ();
                CaracteristicaEN caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), id);
                session.Delete (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicaEN = null;
        try
        {
                SessionInitializeTransaction ();
                caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), p_caracteristica);
                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionesENAux = null;
                if (caracteristicaEN.Habitaciones == null) {
                        caracteristicaEN.Habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                }

                foreach (int item in p_habitacion) {
                        habitacionesENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN ();
                        habitacionesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN), item);
                        habitacionesENAux.Caracteristicas.Add (caracteristicaEN);

                        caracteristicaEN.Habitaciones.Add (habitacionesENAux);
                }


                session.Update (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarCaracteristicaHabitacion (int p_caracteristica, System.Collections.Generic.IList<int> p_habitacion)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicaEN = null;
                caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), p_caracteristica);

                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionesENAux = null;
                if (caracteristicaEN.Habitaciones != null) {
                        foreach (int item in p_habitacion) {
                                habitacionesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN), item);
                                if (caracteristicaEN.Habitaciones.Contains (habitacionesENAux) == true) {
                                        caracteristicaEN.Habitaciones.Remove (habitacionesENAux);
                                        habitacionesENAux.Caracteristicas.Remove (caracteristicaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_habitacion you are trying to unrelationer, doesn't exist in CaracteristicaEN");
                        }
                }

                session.Update (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicaEN = null;
        try
        {
                SessionInitializeTransaction ();
                caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), p_caracteristica);
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueblesENAux = null;
                if (caracteristicaEN.Inmuebles == null) {
                        caracteristicaEN.Inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                }

                foreach (int item in p_inmueble) {
                        inmueblesENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN ();
                        inmueblesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN), item);
                        inmueblesENAux.Caracteristicas.Add (caracteristicaEN);

                        caracteristicaEN.Inmuebles.Add (inmueblesENAux);
                }


                session.Update (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarCaracteristicaInmueble (int p_caracteristica, System.Collections.Generic.IList<int> p_inmueble)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicaEN = null;
                caracteristicaEN = (CaracteristicaEN)session.Load (typeof(CaracteristicaEN), p_caracteristica);

                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueblesENAux = null;
                if (caracteristicaEN.Inmuebles != null) {
                        foreach (int item in p_inmueble) {
                                inmueblesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN), item);
                                if (caracteristicaEN.Inmuebles.Contains (inmueblesENAux) == true) {
                                        caracteristicaEN.Inmuebles.Remove (inmueblesENAux);
                                        inmueblesENAux.Caracteristicas.Remove (caracteristicaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_inmueble you are trying to unrelationer, doesn't exist in CaracteristicaEN");
                        }
                }

                session.Update (caracteristicaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: DameCaracteristicaPorOID
//Con e: CaracteristicaEN
public CaracteristicaEN DameCaracteristicaPorOID (int id)
{
        CaracteristicaEN caracteristicaEN = null;

        try
        {
                SessionInitializeTransaction ();
                caracteristicaEN = (CaracteristicaEN)session.Get (typeof(CaracteristicaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caracteristicaEN;
}

public System.Collections.Generic.IList<CaracteristicaEN> DameTodasLasCaracteristicas (int first, int size)
{
        System.Collections.Generic.IList<CaracteristicaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CaracteristicaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CaracteristicaEN>();
                else
                        result = session.CreateCriteria (typeof(CaracteristicaEN)).List<CaracteristicaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
