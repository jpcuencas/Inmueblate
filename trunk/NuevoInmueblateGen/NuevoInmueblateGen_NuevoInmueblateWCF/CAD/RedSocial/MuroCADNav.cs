

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
public class MuroCADNav : MuroCAD
{
public MuroCADNav() : base ()
{
}

public MuroCADNav(ISession sessionAux) : base (sessionAux)
{
}



public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>   GetAllEntradasOfMuro_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM EntradaEN self inner join self.Muro as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Entradas FROM MuroEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}





public long GetAllEntradasOfMuroCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM EntradaEN self inner join self.Muro as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Entradas) FROM MuroEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }

        return result;
}
}
}
