

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
public class EntradaCADNav : EntradaCAD
{
public EntradaCADNav() : base ()
{
}

public EntradaCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> GetAllEntrada_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from EntradaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<EntradaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> GetAllEntradaUsuario_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from EntradaEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<EntradaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
