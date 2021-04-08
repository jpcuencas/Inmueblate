
using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class InmobiliariaCAD : BasicCAD, IInmobiliariaCAD
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN>         GetAllPaginaCorporativaOfInmobiliaria_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM PaginaCorporativaEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.PaginaCorporativa FROM InmobiliariaEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>    GetAllEventosOfInmobiliaria_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM EventoEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Eventos FROM InmobiliariaEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>  GetAllInmueblesOfInmobiliaria_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM InmuebleEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Inmuebles FROM InmobiliariaEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}





public long GetAllPaginaCorporativaOfInmobiliariaCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM PaginaCorporativaEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.PaginaCorporativa) FROM InmobiliariaEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }

        return result;
}



public long GetAllEventosOfInmobiliariaCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM EventoEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Eventos) FROM InmobiliariaEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }

        return result;
}



public long GetAllInmueblesOfInmobiliariaCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM InmuebleEN self inner join self.Inmobiliaria as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Inmuebles) FROM InmobiliariaEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }

        return result;
}


public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> GetAllInmobiliaria_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from InmobiliariaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<InmobiliariaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
