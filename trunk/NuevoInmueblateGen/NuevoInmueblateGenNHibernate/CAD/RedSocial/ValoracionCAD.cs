
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
 * Clase Valoracion:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class ValoracionCAD : BasicCAD, IValoracionCAD
{
public ValoracionCAD() : base ()
{
}

public ValoracionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionEN ReadOIDDefault (int id)
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionEN)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }

        return result;
}

public int CrearValoracion (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Emisor != null) {
                        // Argumento OID y no colección.
                        valoracion.Emisor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), valoracion.Emisor.Id);

                        valoracion.Emisor.ValoracionEmitida
                        .Add (valoracion);
                }
                if (valoracion.Receptor != null) {
                        // Argumento OID y no colección.
                        valoracion.Receptor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), valoracion.Receptor.Id);

                        valoracion.Receptor.ValoracionRecibida
                        .Add (valoracion);
                }

                session.Save (valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracion.Id;
}

public void ModificarValoracion (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), valoracion.Id);

                valoracionEN.Valoracion = valoracion.Valoracion;


                valoracionEN.Descripcion = valoracion.Descripcion;


                valoracionEN.PendienteModeracion = valoracion.PendienteModeracion;

                session.Update (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarValoracion (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), id);
                session.Delete (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<ValoracionEN> DameTodasValoraciones (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionEN)).List<ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameValoracionPorOID
//Con e: ValoracionEN
public ValoracionEN DameValoracionPorOID (int id)
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptor (int pe_receptor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.Receptor = :pe_receptor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionesReceptorHQL");
                query.SetParameter ("pe_receptor", pe_receptor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisor (int pe_emisor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.Emisor = :pe_emisor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionesEmisorHQL");
                query.SetParameter ("pe_emisor", pe_emisor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN ObtenerValoracionDeA (int pe_emisor, int pe_receptor)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.Emisor = :pe_emisor AND va.Receptor = :pe_receptor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionDeAHQL");
                query.SetParameter ("pe_emisor", pe_emisor);
                query.SetParameter ("pe_receptor", pe_receptor);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisorNP (int pe_emisor)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.Emisor = :pe_emisor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionesEmisorNPHQL");
                query.SetParameter ("pe_emisor", pe_emisor);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptorNP (int pe_receptor)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where FROM ValoracionEN AS va WHERE va.Receptor = :pe_receptor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENobtenerValoracionesReceptorNPHQL");
                query.SetParameter ("pe_receptor", pe_receptor);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
