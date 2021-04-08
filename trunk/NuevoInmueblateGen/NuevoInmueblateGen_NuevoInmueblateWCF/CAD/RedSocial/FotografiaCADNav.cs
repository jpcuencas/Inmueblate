

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
public class FotografiaCADNav : FotografiaCAD
{
public FotografiaCADNav() : base ()
{
}

public FotografiaCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> GetAllFotografia_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from FotografiaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
