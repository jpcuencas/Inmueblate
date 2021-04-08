

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
public class MensajeCADNav : MensajeCAD
{
public MensajeCADNav() : base ()
{
}

public MensajeCADNav(ISession sessionAux) : base (sessionAux)
{
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> GetAllMensaje_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from MensajeEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> GetAllMensajeUsuario_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from MensajeEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
