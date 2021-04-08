
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
 * Clase PaginaCorporativa:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class PaginaCorporativaCAD : BasicCAD, IPaginaCorporativaCAD
{
public PaginaCorporativaCAD() : base ()
{
}

public PaginaCorporativaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PaginaCorporativaEN ReadOIDDefault (int id)
{
        PaginaCorporativaEN paginaCorporativaEN = null;

        try
        {
                SessionInitializeTransaction ();
                paginaCorporativaEN = (PaginaCorporativaEN)session.Get (typeof(PaginaCorporativaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paginaCorporativaEN;
}

public System.Collections.Generic.IList<PaginaCorporativaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<PaginaCorporativaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaginaCorporativaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaginaCorporativaEN>();
                        else
                                result = session.CreateCriteria (typeof(PaginaCorporativaEN)).List<PaginaCorporativaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }

        return result;
}

public int CrearPaginaCorporativa (PaginaCorporativaEN paginaCorporativa)
{
        try
        {
                SessionInitializeTransaction ();
                if (paginaCorporativa.Inmobiliaria != null) {
                        // Argumento OID y no colección.
                        paginaCorporativa.Inmobiliaria = (NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN), paginaCorporativa.Inmobiliaria.Id);

                        paginaCorporativa.Inmobiliaria.PaginaCorporativa
                        .Add (paginaCorporativa);
                }

                session.Save (paginaCorporativa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paginaCorporativa.Id;
}

public void ModificarPaginaCorporativa (PaginaCorporativaEN paginaCorporativa)
{
        try
        {
                SessionInitializeTransaction ();
                PaginaCorporativaEN paginaCorporativaEN = (PaginaCorporativaEN)session.Load (typeof(PaginaCorporativaEN), paginaCorporativa.Id);

                paginaCorporativaEN.Contenido = paginaCorporativa.Contenido;


                paginaCorporativaEN.URL = paginaCorporativa.URL;

                session.Update (paginaCorporativaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPaginaCorporativa (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PaginaCorporativaEN paginaCorporativaEN = (PaginaCorporativaEN)session.Load (typeof(PaginaCorporativaEN), id);
                session.Delete (paginaCorporativaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PaginaCorporativaEN> DameTodasLasPaginas (int first, int size)
{
        System.Collections.Generic.IList<PaginaCorporativaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PaginaCorporativaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PaginaCorporativaEN>();
                else
                        result = session.CreateCriteria (typeof(PaginaCorporativaEN)).List<PaginaCorporativaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DamePaginaCorporativaPorOID
//Con e: PaginaCorporativaEN
public PaginaCorporativaEN DamePaginaCorporativaPorOID (int id)
{
        PaginaCorporativaEN paginaCorporativaEN = null;

        try
        {
                SessionInitializeTransaction ();
                paginaCorporativaEN = (PaginaCorporativaEN)session.Get (typeof(PaginaCorporativaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PaginaCorporativaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paginaCorporativaEN;
}
}
}
