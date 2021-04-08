
using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.Exceptions;

/*
 * Clase Gustos:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class GustosCAD : BasicCAD, IGustosCAD
{
public GustosCAD() : base ()
{
}

public GustosCAD(ISession sessionAux) : base (sessionAux)
{
}



public GustosEN ReadOIDDefault (int id)
{
        GustosEN gustosEN = null;

        try
        {
                SessionInitializeTransaction ();
                gustosEN = (GustosEN)session.Get (typeof(GustosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustosEN;
}

public System.Collections.Generic.IList<GustosEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<GustosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GustosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GustosEN>();
                        else
                                result = session.CreateCriteria (typeof(GustosEN)).List<GustosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }

        return result;
}

public int CrearGustos (GustosEN gustos)
{
        try
        {
                SessionInitializeTransaction ();
                if (gustos.Usuario != null) {
                        // Argumento OID y no colección.
                        gustos.Usuario = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), gustos.Usuario.Id);

                        gustos.Usuario.Gustos
                                = gustos;
                }

                session.Save (gustos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustos.Id;
}

public void ModificarGustos (GustosEN gustos)
{
        try
        {
                SessionInitializeTransaction ();
                GustosEN gustosEN = (GustosEN)session.Load (typeof(GustosEN), gustos.Id);

                gustosEN.PendienteModeracion = gustos.PendienteModeracion;


                gustosEN.Musica = gustos.Musica;


                gustosEN.Libros = gustos.Libros;


                gustosEN.Peliculas = gustos.Peliculas;


                gustosEN.Juegos = gustos.Juegos;

                session.Update (gustosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarGustos (int id)
{
        try
        {
                SessionInitializeTransaction ();
                GustosEN gustosEN = (GustosEN)session.Load (typeof(GustosEN), id);
                session.Delete (gustosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> ObtenerGustosPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GustosEN self where FROM GustosEN AS gu WHERE gu.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GustosENobtenerGustosPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameGustosPorOID
//Con e: GustosEN
public GustosEN DameGustosPorOID (int id)
{
        GustosEN gustosEN = null;

        try
        {
                SessionInitializeTransaction ();
                gustosEN = (GustosEN)session.Get (typeof(GustosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustosEN;
}

public System.Collections.Generic.IList<GustosEN> DameTodosLosGustos (int first, int size)
{
        System.Collections.Generic.IList<GustosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GustosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GustosEN>();
                else
                        result = session.CreateCriteria (typeof(GustosEN)).List<GustosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
