

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
public class GrupoCADNav : GrupoCAD
{
public GrupoCADNav() : base ()
{
}

public GrupoCADNav(ISession sessionAux) : base (sessionAux)
{
}



public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN                GetMuroOfPropietarioGrupo_NuevoInmueblate (int id)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM MuroEN self inner join self.Grupo as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Muro FROM GrupoEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}





public long GetMuroOfPropietarioGrupoCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM MuroEN self inner join self.Grupo as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Muro) FROM GrupoEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }

        return result;
}


public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> GetAllGrupo_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from GrupoEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
