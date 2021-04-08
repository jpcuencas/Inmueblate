

using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial
{
public class InmuebleCADNav : InmuebleCAD
{
public InmuebleCADNav() : base ()
{
}

public InmuebleCADNav(ISession sessionAux) : base (sessionAux)
{
}



public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>        GetAllElementosMultimediaOfInmueble_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM ElementoMultimediaEN self inner join self.Inmueble as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.ElementosMultimedia FROM InmuebleEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();

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





public long GetAllElementosMultimediaOfInmuebleCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM ElementoMultimediaEN self inner join self.Inmueble as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.ElementosMultimedia) FROM InmuebleEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
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


public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> GetAllInmueble_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from InmuebleEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<InmuebleEN>();
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
}
}
