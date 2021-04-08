
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
 * Clase Inmueble:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class InmuebleCAD : BasicCAD, IInmuebleCAD
{
public InmuebleCAD() : base ()
{
}

public InmuebleCAD(ISession sessionAux) : base (sessionAux)
{
}



public InmuebleEN ReadOIDDefault (int id)
{
        InmuebleEN inmuebleEN = null;

        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Get (typeof(InmuebleEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmuebleEN;
}

public System.Collections.Generic.IList<InmuebleEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<InmuebleEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(InmuebleEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<InmuebleEN>();
                        else
                                result = session.CreateCriteria (typeof(InmuebleEN)).List<InmuebleEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }

        return result;
}

public int CrearInmueble (InmuebleEN inmueble)
{
        try
        {
                SessionInitializeTransaction ();
                if (inmueble.Geolocalizacion != null) {
                        // Argumento OID y no colección.
                        inmueble.Geolocalizacion = (NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN), inmueble.Geolocalizacion.Id);

                        inmueble.Geolocalizacion.Inmueble
                                = inmueble;
                }

                session.Save (inmueble);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmueble.Id;
}

public void ModificarInmueble (InmuebleEN inmueble)
{
        try
        {
                SessionInitializeTransaction ();
                InmuebleEN inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), inmueble.Id);

                inmuebleEN.PendienteModeracion = inmueble.PendienteModeracion;


                inmuebleEN.Descripcion = inmueble.Descripcion;


                inmuebleEN.Tipo = inmueble.Tipo;


                inmuebleEN.MetrosCuadrados = inmueble.MetrosCuadrados;


                inmuebleEN.Alquiler = inmueble.Alquiler;


                inmuebleEN.Precio = inmueble.Precio;

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarInmueble (int id)
{
        try
        {
                SessionInitializeTransaction ();
                InmuebleEN inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), id);
                session.Delete (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirCaracteristica (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);
                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicasENAux = null;
                if (inmuebleEN.Caracteristicas == null) {
                        inmuebleEN.Caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
                }

                foreach (int item in p_caracteristica) {
                        caracteristicasENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN ();
                        caracteristicasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN), item);
                        caracteristicasENAux.Inmuebles.Add (inmuebleEN);

                        inmuebleEN.Caracteristicas.Add (caracteristicasENAux);
                }


                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (inmuebleEN.ElementosMultimedia == null) {
                        inmuebleEN.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementomultimedia) {
                        elementosMultimediaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosMultimediaENAux.Inmueble = inmuebleEN;

                        inmuebleEN.ElementosMultimedia.Add (elementosMultimediaENAux);
                }


                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirGeolocalizacion (int p_inmueble, int p_geolocalizacion)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);
                inmuebleEN.Geolocalizacion = (NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN), p_geolocalizacion);

                inmuebleEN.Geolocalizacion.Inmueble = inmuebleEN;




                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);
                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionesENAux = null;
                if (inmuebleEN.Habitaciones == null) {
                        inmuebleEN.Habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                }

                foreach (int item in p_habitacion) {
                        habitacionesENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN ();
                        habitacionesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN), item);
                        habitacionesENAux.Inmueble = inmuebleEN;

                        inmuebleEN.Habitaciones.Add (habitacionesENAux);
                }


                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);
                NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN inquilinosENAux = null;
                if (inmuebleEN.Inquilinos == null) {
                        inmuebleEN.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                }

                foreach (int item in p_usuario) {
                        inquilinosENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                        inquilinosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), item);
                        inquilinosENAux.Inmuebles.Add (inmuebleEN);

                        inmuebleEN.Inquilinos.Add (inquilinosENAux);
                }


                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarCaracteristicas (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);

                NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicasENAux = null;
                if (inmuebleEN.Caracteristicas != null) {
                        foreach (int item in p_caracteristica) {
                                caracteristicasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN), item);
                                if (inmuebleEN.Caracteristicas.Contains (caracteristicasENAux) == true) {
                                        inmuebleEN.Caracteristicas.Remove (caracteristicasENAux);
                                        caracteristicasENAux.Inmuebles.Remove (inmuebleEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_caracteristica you are trying to unrelationer, doesn't exist in InmuebleEN");
                        }
                }

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarElementosMultimedia (int p_inmueble, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (inmuebleEN.ElementosMultimedia != null) {
                        foreach (int item in p_elementomultimedia) {
                                elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (inmuebleEN.ElementosMultimedia.Contains (elementosMultimediaENAux) == true) {
                                        inmuebleEN.ElementosMultimedia.Remove (elementosMultimediaENAux);
                                        elementosMultimediaENAux.Inmueble = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementomultimedia you are trying to unrelationer, doesn't exist in InmuebleEN");
                        }
                }

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarGeolocalizacion (int p_inmueble, int p_geolocalizacion)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);

                if (inmuebleEN.Geolocalizacion.Id == p_geolocalizacion) {
                        inmuebleEN.Geolocalizacion = null;
                        NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacionEN = (NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN), p_geolocalizacion);
                        geolocalizacionEN.Inmueble = null;
                }
                else
                        throw new ModelException ("The identifier " + p_geolocalizacion + " in p_geolocalizacion you are trying to unrelationer, doesn't exist in InmuebleEN");

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);

                NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionesENAux = null;
                if (inmuebleEN.Habitaciones != null) {
                        foreach (int item in p_habitacion) {
                                habitacionesENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN), item);
                                if (inmuebleEN.Habitaciones.Contains (habitacionesENAux) == true) {
                                        inmuebleEN.Habitaciones.Remove (habitacionesENAux);
                                        habitacionesENAux.Inmueble = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_habitacion you are trying to unrelationer, doesn't exist in InmuebleEN");
                        }
                }

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_inmueble);

                NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN inquilinosENAux = null;
                if (inmuebleEN.Inquilinos != null) {
                        foreach (int item in p_usuario) {
                                inquilinosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), item);
                                if (inmuebleEN.Inquilinos.Contains (inquilinosENAux) == true) {
                                        inmuebleEN.Inquilinos.Remove (inquilinosENAux);
                                        inquilinosENAux.Inmuebles.Remove (inmuebleEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario you are trying to unrelationer, doesn't exist in InmuebleEN");
                        }
                }

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> ObtenerInmueblePendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM InmuebleEN self where FROM InmuebleEN AS im WHERE im.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("InmuebleENobtenerInmueblePendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<InmuebleEN> DameTodosLosInmuebles (int first, int size)
{
        System.Collections.Generic.IList<InmuebleEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(InmuebleEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<InmuebleEN>();
                else
                        result = session.CreateCriteria (typeof(InmuebleEN)).List<InmuebleEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameInmueblePorOID
//Con e: InmuebleEN
public InmuebleEN DameInmueblePorOID (int id)
{
        InmuebleEN inmuebleEN = null;

        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Get (typeof(InmuebleEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmuebleEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> DameInmuebleFiltro (int p_inmobiliaria, string p_descripcion, int p_tipo, int p_metrosCuadrados, int p_precio, string p_direccion, string p_poblacion, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM InmuebleEN self where FROM InmuebleEN AS i WHERE i.Inmobiliaria = CASE WHEN :p_inmobiliaria = -1 THEN i.Inmobiliaria ELSE :p_inmobiliaria END AND i.Descripcion LIKE CASE WHEN :p_descripcion = null THEN i.Descripcion ELSE :p_descripcion END AND i.Tipo = CASE WHEN :p_tipo = -1 THEN i.Tipo ELSE :p_tipo END AND i.MetrosCuadrados = CASE WHEN :p_metrosCuadrados = -1 THEN i.MetrosCuadrados ELSE :p_metrosCuadrados END AND i.Precio = CASE WHEN :p_precio = -1 THEN i.Precio ELSE :p_precio END AND i.Geolocalizacion.Direccion LIKE CASE WHEN :p_direccion = null THEN i.Geolocalizacion.Direccion ELSE :p_direccion END AND i.Geolocalizacion.Poblacion LIKE CASE WHEN :p_poblacion = null THEN i.Geolocalizacion.Poblacion ELSE :p_poblacion END ORDER BY i.MetrosCuadrados DESC, i.Precio DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("InmuebleENdameInmuebleFiltroHQL");
                query.SetParameter ("p_inmobiliaria", p_inmobiliaria);
                query.SetParameter ("p_descripcion", p_descripcion);
                query.SetParameter ("p_tipo", p_tipo);
                query.SetParameter ("p_metrosCuadrados", p_metrosCuadrados);
                query.SetParameter ("p_precio", p_precio);
                query.SetParameter ("p_direccion", p_direccion);
                query.SetParameter ("p_poblacion", p_poblacion);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
        try
        {
                SessionInitializeTransaction ();
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_Inmueble_OID);
                inmuebleEN.Inmobiliaria = (NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN), p_inmobiliaria_OID);

                inmuebleEN.Inmobiliaria.Inmuebles.Add (inmuebleEN);



                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarInmobiliaria (int p_Inmueble_OID, int p_inmobiliaria_OID)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;
                inmuebleEN = (InmuebleEN)session.Load (typeof(InmuebleEN), p_Inmueble_OID);

                if (inmuebleEN.Inmobiliaria.Id == p_inmobiliaria_OID) {
                        inmuebleEN.Inmobiliaria = null;
                }
                else
                        throw new ModelException ("The identifier " + p_inmobiliaria_OID + " in p_inmobiliaria_OID you are trying to unrelationer, doesn't exist in InmuebleEN");

                session.Update (inmuebleEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmuebleCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
