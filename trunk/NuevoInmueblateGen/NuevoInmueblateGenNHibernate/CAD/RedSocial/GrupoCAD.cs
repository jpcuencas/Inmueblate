
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
 * Clase Grupo:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class GrupoCAD : BasicCAD, IGrupoCAD
{
public GrupoCAD() : base ()
{
}

public GrupoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GrupoEN ReadOIDDefault (int id)
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
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

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GrupoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                        else
                                result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
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

public int CrearGrupo (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                if (grupo.Muro != null) {
                        // Argumento OID y no colección.
                        grupo.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), grupo.Muro.Id);

                        grupo.Muro.PropietarioGrupo
                                = grupo;
                }

                session.Save (grupo);
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

        return grupo.Id;
}

public void ModificarGrupo (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Id);

                grupoEN.Tipo = grupo.Tipo;


                grupoEN.Nombre = grupo.Nombre;


                grupoEN.Descripcion = grupo.Descripcion;

                session.Update (grupoEN);
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
}
public void BorrarGrupo (int id)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), id);
                session.Delete (grupoEN);
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
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposConEntradasReportadas ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where SELECT distinct gr FROM GrupoEN AS gr INNER JOIN gr.Muro AS mu INNER JOIN mu.Entradas AS en WHERE en.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENObtenerGruposConEntradasReportadasHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
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
public System.Collections.Generic.IList<GrupoEN> DameTodosLosGrupos (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GrupoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                else
                        result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
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

//Sin e: DameGrupoPorOID
//Con e: GrupoEN
public GrupoEN DameGrupoPorOID (int id)
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), id);
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

        return grupoEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> DameGruposFiltro (int p_tipo, string p_nombre, string p_descripcion, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as g WHERE g.Tipo = CASE WHEN :p_tipo = -1 THEN g.Tipo ELSE :p_tipo END AND g.Nombre LIKE CASE WHEN :p_nombre = null THEN g.Nombre ELSE :p_nombre END AND g.Descripcion LIKE CASE WHEN :p_descripcion = null THEN g.Descripcion ELSE :p_descripcion END ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposFiltroHQL");
                query.SetParameter ("p_tipo", p_tipo);
                query.SetParameter ("p_nombre", p_nombre);
                query.SetParameter ("p_descripcion", p_descripcion);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
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
