

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
public class UsuarioCADNav : UsuarioCAD
{
public UsuarioCADNav() : base ()
{
}

public UsuarioCADNav(ISession sessionAux) : base (sessionAux)
{
}



public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN                GetMuroOfPropietarioUsuario_NuevoInmueblate (int id)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM MuroEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Muro FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>  GetAllInmueblesOfInquilinos_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM InmuebleEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Inmuebles FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>        GetAllFotosOfFusuario_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM ElementoMultimediaEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Elementos FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN                GetPreferenciasBusquedaOfUsuario_NuevoInmueblate (int id)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM PreferenciasBusquedaEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.PreferenciasBusqueda FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN              GetGustosOfUsuario_NuevoInmueblate (int id)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM GustosEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Gustos FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>        GetAllElementosOfUsuario_NuevoInmueblate (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                /*
                 * String sql = @"select self FROM ElementoMultimediaEN self inner join self.Usuario as target with target.Id=:p_Id";
                 * IQuery query = session.CreateQuery(sql).SetParameter("p_Id", id);
                 */
                String sql = @"select self.Elementos FROM UsuarioEN self where self.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}





public long GetMuroOfPropietarioUsuarioCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM MuroEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Muro) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}



public long GetAllInmueblesOfInquilinosCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM InmuebleEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Inmuebles) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}



public long GetAllFotosOfFusuarioCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM ElementoMultimediaEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Elementos) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}



public long GetPreferenciasBusquedaOfUsuarioCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM PreferenciasBusquedaEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.PreferenciasBusqueda) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}



public long GetGustosOfUsuarioCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM GustosEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Gustos) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}



public long GetAllElementosOfUsuarioCount_NuevoInmueblate (int id)
{
        long result = 0;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                /*
                                 * String sql = @"select count(*) FROM ElementoMultimediaEN self inner join self.Usuario as target with target.Id=:p_Id";
                                 */
                                String sql = @"select count(self.Elementos) FROM UsuarioEN self where self.Id=:p_Id";
                                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);
                                result = query.UniqueResult<Int64>();
                        }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}


public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> GetAllUsuario_NuevoInmueblate ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                String sql = "from UsuarioEN self";
                IQuery query = session.CreateQuery (sql);

                result = query.List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
