
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
 * Clase Habitacion:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class HabitacionCAD : BasicCAD, IHabitacionCAD
{
public HabitacionCAD() : base ()
{
}

public HabitacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public HabitacionEN ReadOIDDefault (int id)
{
        HabitacionEN habitacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                habitacionEN = (HabitacionEN)session.Get (typeof(HabitacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return habitacionEN;
}

public System.Collections.Generic.IList<HabitacionEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<HabitacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(HabitacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<HabitacionEN>();
                        else
                                result = session.CreateCriteria (typeof(HabitacionEN)).List<HabitacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }

        return result;
}

public int CrearHabitacion (HabitacionEN habitacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (habitacion.Inquilinos != null) {
                        for (int i = 0; i < habitacion.Inquilinos.Count; i++) {
                                habitacion.Inquilinos [i] = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), habitacion.Inquilinos [i].Id);
                                habitacion.Inquilinos [i].Habitaciones.Add (habitacion);
                        }
                }
                if (habitacion.Inmueble != null) {
                        // Argumento OID y no colección.
                        habitacion.Inmueble = (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN), habitacion.Inmueble.Id);

                        habitacion.Inmueble.Habitaciones
                        .Add (habitacion);
                }

                session.Save (habitacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return habitacion.Id;
}

public void ModificarHabitacion (HabitacionEN habitacion)
{
        try
        {
                SessionInitializeTransaction ();
                HabitacionEN habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), habitacion.Id);

                habitacionEN.PendienteModeracion = habitacion.PendienteModeracion;


                habitacionEN.Descripcion = habitacion.Descripcion;


                habitacionEN.MetrosCuadrados = habitacion.MetrosCuadrados;


                habitacionEN.Alquiler = habitacion.Alquiler;

                session.Update (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarHabitacion (int id)
{
        try
        {
                SessionInitializeTransaction ();
                HabitacionEN habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), id);
                session.Delete (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), p_habitacion);
                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicasENAux = null;
                if (habitacionEN.Caracteristicas == null) {
                        habitacionEN.Caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
                }

                foreach (int item in p_caracteristica) {
                        caracteristicasENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN ();
                        caracteristicasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN), item);
                        caracteristicasENAux.Habitaciones.Add (habitacionEN);

                        habitacionEN.Caracteristicas.Add (caracteristicasENAux);
                }


                session.Update (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), p_habitacion);
                NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN inquilinosENAux = null;
                if (habitacionEN.Inquilinos == null) {
                        habitacionEN.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                }

                foreach (int item in p_usuario) {
                        inquilinosENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                        inquilinosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), item);
                        inquilinosENAux.Habitaciones.Add (habitacionEN);

                        habitacionEN.Inquilinos.Add (inquilinosENAux);
                }


                session.Update (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionEN = null;
                habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), p_habitacion);

                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicasENAux = null;
                if (habitacionEN.Caracteristicas != null) {
                        foreach (int item in p_caracteristica) {
                                caracteristicasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN), item);
                                if (habitacionEN.Caracteristicas.Contains (caracteristicasENAux) == true) {
                                        habitacionEN.Caracteristicas.Remove (caracteristicasENAux);
                                        caracteristicasENAux.Habitaciones.Remove (habitacionEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_caracteristica you are trying to unrelationer, doesn't exist in HabitacionEN");
                        }
                }

                session.Update (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionEN = null;
                habitacionEN = (HabitacionEN)session.Load (typeof(HabitacionEN), p_habitacion);

                NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN inquilinosENAux = null;
                if (habitacionEN.Inquilinos != null) {
                        foreach (int item in p_usuario) {
                                inquilinosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), item);
                                if (habitacionEN.Inquilinos.Contains (inquilinosENAux) == true) {
                                        habitacionEN.Inquilinos.Remove (inquilinosENAux);
                                        inquilinosENAux.Habitaciones.Remove (habitacionEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario you are trying to unrelationer, doesn't exist in HabitacionEN");
                        }
                }

                session.Update (habitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> ObtenerHabitacionPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM HabitacionEN self where FROM HabitacionEN ha WHERE ha.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("HabitacionENobtenerHabitacionPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameHabitacionPorOID
//Con e: HabitacionEN
public HabitacionEN DameHabitacionPorOID (int id)
{
        HabitacionEN habitacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                habitacionEN = (HabitacionEN)session.Get (typeof(HabitacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return habitacionEN;
}

public System.Collections.Generic.IList<HabitacionEN> DameTodasLasHabitaciones (int first, int size)
{
        System.Collections.Generic.IList<HabitacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(HabitacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<HabitacionEN>();
                else
                        result = session.CreateCriteria (typeof(HabitacionEN)).List<HabitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> DameHabitacionFiltro (string p_descripcion, int p_metrosCuadrados, string p_direccion, string p_poblacion, int p_inmueble, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM HabitacionEN self where FROM HabitacionEN AS h WHERE h.Descripcion LIKE CASE WHEN :p_descripcion = null THEN h.Descripcion ELSE :p_descripcion END AND h.MetrosCuadrados = CASE WHEN :p_metrosCuadrados = -1 THEN h.MetrosCuadrados ELSE :p_metrosCuadrados END AND h.Inmueble.Geolocalizacion.Direccion LIKE CASE WHEN :p_direccion = null THEN h.Inmueble.Geolocalizacion.Direccion ELSE :p_direccion END AND h.Inmueble.Geolocalizacion.Poblacion LIKE CASE WHEN :p_poblacion = null THEN h.Inmueble.Geolocalizacion.Poblacion ELSE :p_poblacion END AND h.Inmueble = CASE WHEN :p_inmueble = -1 THEN h.Inmueble ELSE :p_inmueble END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("HabitacionENdameHabitacionFiltroHQL");
                query.SetParameter ("p_descripcion", p_descripcion);
                query.SetParameter ("p_metrosCuadrados", p_metrosCuadrados);
                query.SetParameter ("p_direccion", p_direccion);
                query.SetParameter ("p_poblacion", p_poblacion);
                query.SetParameter ("p_inmueble", p_inmueble);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in HabitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
