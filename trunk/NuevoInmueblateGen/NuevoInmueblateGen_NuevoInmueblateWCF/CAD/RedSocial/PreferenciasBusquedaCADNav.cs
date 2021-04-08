

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
public class PreferenciasBusquedaCADNav : PreferenciasBusquedaCAD
{
public PreferenciasBusquedaCADNav() : base ()
{
}

public PreferenciasBusquedaCADNav(ISession sessionAux) : base (sessionAux)
{
}



public NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN             GetGeolocalizacionOfPreferenciasBusqueda_NuevoInmueblate (int id)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM GeolocalizacionEN self inner join self.PreferenciasBusqueda as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Geolocalizacion FROM PreferenciasBusquedaEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN>();

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





public long GetGeolocalizacionOfPreferenciasBusquedaCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM GeolocalizacionEN self inner join self.PreferenciasBusqueda as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Geolocalizacion) FROM PreferenciasBusquedaEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
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
}
}
