
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
 * Clase Geolocalizacion:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class GeolocalizacionCAD : BasicCAD, IGeolocalizacionCAD
{
public GeolocalizacionCAD() : base ()
{
}

public GeolocalizacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public GeolocalizacionEN ReadOIDDefault (int id)
{
        GeolocalizacionEN geolocalizacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                geolocalizacionEN = (GeolocalizacionEN)session.Get (typeof(GeolocalizacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return geolocalizacionEN;
}

public System.Collections.Generic.IList<GeolocalizacionEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<GeolocalizacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GeolocalizacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GeolocalizacionEN>();
                        else
                                result = session.CreateCriteria (typeof(GeolocalizacionEN)).List<GeolocalizacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }

        return result;
}

public int CrearGeolocalizacion (GeolocalizacionEN geolocalizacion)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (geolocalizacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return geolocalizacion.Id;
}

public void ModificarGeolocalizacion (GeolocalizacionEN geolocalizacion)
{
        try
        {
                SessionInitializeTransaction ();
                GeolocalizacionEN geolocalizacionEN = (GeolocalizacionEN)session.Load (typeof(GeolocalizacionEN), geolocalizacion.Id);

                geolocalizacionEN.Longitud = geolocalizacion.Longitud;


                geolocalizacionEN.Latitud = geolocalizacion.Latitud;


                geolocalizacionEN.Direccion = geolocalizacion.Direccion;


                geolocalizacionEN.Poblacion = geolocalizacion.Poblacion;

                session.Update (geolocalizacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarGeolocalizacion (int id)
{
        try
        {
                SessionInitializeTransaction ();
                GeolocalizacionEN geolocalizacionEN = (GeolocalizacionEN)session.Load (typeof(GeolocalizacionEN), id);
                session.Delete (geolocalizacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameGeolocalizacionPorOID
//Con e: GeolocalizacionEN
public GeolocalizacionEN DameGeolocalizacionPorOID (int id)
{
        GeolocalizacionEN geolocalizacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                geolocalizacionEN = (GeolocalizacionEN)session.Get (typeof(GeolocalizacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return geolocalizacionEN;
}

public System.Collections.Generic.IList<GeolocalizacionEN> DameTodasLasGeolocalizaciones (int first, int size)
{
        System.Collections.Generic.IList<GeolocalizacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GeolocalizacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GeolocalizacionEN>();
                else
                        result = session.CreateCriteria (typeof(GeolocalizacionEN)).List<GeolocalizacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GeolocalizacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
