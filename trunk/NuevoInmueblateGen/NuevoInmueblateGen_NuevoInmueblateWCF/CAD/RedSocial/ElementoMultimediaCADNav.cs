

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
public class ElementoMultimediaCADNav : ElementoMultimediaCAD
{
public ElementoMultimediaCADNav() : base ()
{
}

public ElementoMultimediaCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> GetAllElementoMultimedia_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from ElementoMultimediaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<ElementoMultimediaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
