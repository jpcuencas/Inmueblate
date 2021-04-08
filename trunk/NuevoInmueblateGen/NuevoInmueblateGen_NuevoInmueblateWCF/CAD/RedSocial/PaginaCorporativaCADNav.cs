

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
public class PaginaCorporativaCADNav : PaginaCorporativaCAD
{
public PaginaCorporativaCADNav() : base ()
{
}

public PaginaCorporativaCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> GetAllPaginaCorporativa_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from PaginaCorporativaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<PaginaCorporativaEN>();
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
}
}
