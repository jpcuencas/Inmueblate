
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
 * Clase PreferenciasBusqueda:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class PreferenciasBusquedaCAD : BasicCAD, IPreferenciasBusquedaCAD
{
public PreferenciasBusquedaCAD() : base ()
{
}

public PreferenciasBusquedaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PreferenciasBusquedaEN ReadOIDDefault (int id)
{
        PreferenciasBusquedaEN preferenciasBusquedaEN = null;

        try
        {
                SessionInitializeTransaction ();
                preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Get (typeof(PreferenciasBusquedaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preferenciasBusquedaEN;
}

public System.Collections.Generic.IList<PreferenciasBusquedaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<PreferenciasBusquedaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PreferenciasBusquedaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PreferenciasBusquedaEN>();
                        else
                                result = session.CreateCriteria (typeof(PreferenciasBusquedaEN)).List<PreferenciasBusquedaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }

        return result;
}

public int CrearPreferenciasBusqueda (PreferenciasBusquedaEN preferenciasBusqueda)
{
        try
        {
                SessionInitializeTransaction ();
                if (preferenciasBusqueda.Geolocalizacion != null) {
                        // Argumento OID y no colección.
                        preferenciasBusqueda.Geolocalizacion = (NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN), preferenciasBusqueda.Geolocalizacion.Id);

                        preferenciasBusqueda.Geolocalizacion.PreferenciasBusqueda
                                = preferenciasBusqueda;
                }

                session.Save (preferenciasBusqueda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preferenciasBusqueda.Id;
}

public void ModificarPreferenciasBusqueda (PreferenciasBusquedaEN preferenciasBusqueda)
{
        try
        {
                SessionInitializeTransaction ();
                PreferenciasBusquedaEN preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Load (typeof(PreferenciasBusquedaEN), preferenciasBusqueda.Id);

                preferenciasBusquedaEN.DistanciaTolerable = preferenciasBusqueda.DistanciaTolerable;


                preferenciasBusquedaEN.PrecioMax = preferenciasBusqueda.PrecioMax;


                preferenciasBusquedaEN.PrecioMin = preferenciasBusqueda.PrecioMin;

                session.Update (preferenciasBusquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPreferenciasBusqueda (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PreferenciasBusquedaEN preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Load (typeof(PreferenciasBusquedaEN), id);
                session.Delete (preferenciasBusquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsociarConGrupo (int p_preferenciasbusqueda, int p_grupo)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusquedaEN = null;
        try
        {
                SessionInitializeTransaction ();
                preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Load (typeof(PreferenciasBusquedaEN), p_preferenciasbusqueda);
                preferenciasBusquedaEN.Grupo = (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN), p_grupo);

                preferenciasBusquedaEN.Grupo.PreferenciasBusqueda = preferenciasBusquedaEN;




                session.Update (preferenciasBusquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsociarConUsuario (int p_preferenciasbusqueda, int p_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusquedaEN = null;
        try
        {
                SessionInitializeTransaction ();
                preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Load (typeof(PreferenciasBusquedaEN), p_preferenciasbusqueda);
                preferenciasBusquedaEN.Usuario = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), p_usuario);

                preferenciasBusquedaEN.Usuario.PreferenciasBusqueda = preferenciasBusquedaEN;




                session.Update (preferenciasBusquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PreferenciasBusquedaEN> DameTodasLasPreferenciasBusqueda (int first, int size)
{
        System.Collections.Generic.IList<PreferenciasBusquedaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PreferenciasBusquedaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PreferenciasBusquedaEN>();
                else
                        result = session.CreateCriteria (typeof(PreferenciasBusquedaEN)).List<PreferenciasBusquedaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DamePreferenciasBusquedaPorOID
//Con e: PreferenciasBusquedaEN
public PreferenciasBusquedaEN DamePreferenciasBusquedaPorOID (int id)
{
        PreferenciasBusquedaEN preferenciasBusquedaEN = null;

        try
        {
                SessionInitializeTransaction ();
                preferenciasBusquedaEN = (PreferenciasBusquedaEN)session.Get (typeof(PreferenciasBusquedaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PreferenciasBusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preferenciasBusquedaEN;
}
}
}
