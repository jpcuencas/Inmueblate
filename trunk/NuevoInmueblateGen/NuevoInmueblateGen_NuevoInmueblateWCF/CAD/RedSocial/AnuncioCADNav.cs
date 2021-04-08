

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
public class AnuncioCADNav : AnuncioCAD
{
public AnuncioCADNav() : base ()
{
}

public AnuncioCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> GetAllAnuncio_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from AnuncioEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
