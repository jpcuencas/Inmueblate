
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
 * Clase Entrada:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class EntradaCAD : BasicCAD, IEntradaCAD
{
public EntradaCAD() : base ()
{
}

public EntradaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EntradaEN ReadOIDDefault (int id)
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
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

        return entradaEN;
}

public System.Collections.Generic.IList<EntradaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<EntradaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EntradaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EntradaEN>();
                        else
                                result = session.CreateCriteria (typeof(EntradaEN)).List<EntradaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in EntradaCAD.", ex);
        }

        return result;
}

public int CrearEntrada (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                if (entrada.Muro != null) {
                        // Argumento OID y no colección.
                        entrada.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), entrada.Muro.Id);

                        entrada.Muro.Entradas
                        .Add (entrada);
                }
                if (entrada.Creador != null) {
                        // Argumento OID y no colección.
                        entrada.Creador = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), entrada.Creador.Id);

                        entrada.Creador.Entradas
                        .Add (entrada);
                }

                session.Save (entrada);
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

        return entrada.Id;
}

public void ModificarEntrada (EntradaEN entrada)
{
        try
        {
                SessionInitializeTransaction ();
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), entrada.Id);

                entradaEN.FechaPublicacion = entrada.FechaPublicacion;


                entradaEN.Titulo = entrada.Titulo;


                entradaEN.Cuerpo = entrada.Cuerpo;


                entradaEN.PendienteModeracion = entrada.PendienteModeracion;

                session.Update (entradaEN);
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
}
public void BorrarEntrada (int id)
{
        try
        {
                SessionInitializeTransaction ();
                EntradaEN entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), id);
                session.Delete (entradaEN);
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
}

public void AnyadirElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), p_entrada);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (entradaEN.ElementosMultimedia == null) {
                        entradaEN.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementomultimedia) {
                        elementosMultimediaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosMultimediaENAux.Entradas.Add (entradaEN);

                        entradaEN.ElementosMultimedia.Add (elementosMultimediaENAux);
                }


                session.Update (entradaEN);
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
}

public void BorrarElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradaEN = null;
                entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), p_entrada);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (entradaEN.ElementosMultimedia != null) {
                        foreach (int item in p_elementomultimedia) {
                                elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (entradaEN.ElementosMultimedia.Contains (elementosMultimediaENAux) == true) {
                                        entradaEN.ElementosMultimedia.Remove (elementosMultimediaENAux);
                                        elementosMultimediaENAux.Entradas.Remove (entradaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementomultimedia you are trying to unrelationer, doesn't exist in EntradaEN");
                        }
                }

                session.Update (entradaEN);
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
}
public void AnyadirReportador (int p_entrada, System.Collections.Generic.IList<int> p_superusuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), p_entrada);
                NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN reportadoresENAux = null;
                if (entradaEN.Reportadores == null) {
                        entradaEN.Reportadores = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                }

                foreach (int item in p_superusuario) {
                        reportadoresENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                        reportadoresENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), item);
                        reportadoresENAux.EntradasReportadas.Add (entradaEN);

                        entradaEN.Reportadores.Add (reportadoresENAux);
                }


                session.Update (entradaEN);
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
}

public void AnyadirUsuariosMeGusta (int p_entrada, System.Collections.Generic.IList<int> p_superusuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Load (typeof(EntradaEN), p_entrada);
                NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN usuariosMeGustaENAux = null;
                if (entradaEN.UsuariosMeGusta == null) {
                        entradaEN.UsuariosMeGusta = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                }

                foreach (int item in p_superusuario) {
                        usuariosMeGustaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                        usuariosMeGustaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), item);
                        usuariosMeGustaENAux.EntradasMeGusta.Add (entradaEN);

                        entradaEN.UsuariosMeGusta.Add (usuariosMeGustaENAux);
                }


                session.Update (entradaEN);
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
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorModerar (string p_filter)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN AS en WHERE en.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENObtenerEntradasPorModerarHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorMuro (int p_muro, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN AS en WHERE en.Muro.Id = :p_muro ORDER BY FechaPublicacion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENObtenerEntradasPorMuroHQL");
                query.SetParameter ("p_muro", p_muro);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorGrupo (int pe_ID)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where SELECT distinct en FROM EntradaEN AS en INNER JOIN en.Muro AS mu INNER JOIN mu.PropietarioGrupo AS pg WHERE pg IS NOT null AND en.PendienteModeracion = true AND pg.Id = :pe_ID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENObtenerEntradasPendientesPorGrupoHQL");
                query.SetParameter ("pe_ID", pe_ID);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorUsuario (int pe_ID)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where SELECT distinct en FROM EntradaEN AS en INNER JOIN en.Creador AS cr WHERE cr IS NOT null AND en.PendienteModeracion = true AND cr.Id = :pe_ID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENObtenerEntradasPendientesPorUsuarioHQL");
                query.SetParameter ("pe_ID", pe_ID);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroConModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, bool p_pendienteModeracion, int p_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN AS e WHERE e.Titulo LIKE CASE WHEN :p_titulo = null THEN e.Titulo ELSE :p_titulo END AND e.Cuerpo LIKE CASE WHEN :p_cuerpo = null THEN e.Cuerpo ELSE :p_cuerpo END AND e.FechaPublicacion = CASE WHEN :p_fechaPublicacion = null THEN e.FechaPublicacion ELSE :p_fechaPublicacion END AND e.PendienteModeracion = :p_pendienteModeracion AND e.Creador = CASE WHEN :p_usuario = -1 THEN e.Creador ELSE :p_usuario END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENdameEntradasFiltroConModeracionHQL");
                query.SetParameter ("p_titulo", p_titulo);
                query.SetParameter ("p_cuerpo", p_cuerpo);
                query.SetParameter ("p_fechaPublicacion", p_fechaPublicacion);
                query.SetParameter ("p_pendienteModeracion", p_pendienteModeracion);
                query.SetParameter ("p_usuario", p_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<EntradaEN> DameTodasLasEntradas (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EntradaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EntradaEN>();
                else
                        result = session.CreateCriteria (typeof(EntradaEN)).List<EntradaEN>();
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

//Sin e: DameEntradaPorOID
//Con e: EntradaEN
public EntradaEN DameEntradaPorOID (int id)
{
        EntradaEN entradaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entradaEN = (EntradaEN)session.Get (typeof(EntradaEN), id);
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

        return entradaEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroSinModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, int p_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN AS e WHERE e.Titulo LIKE CASE WHEN :p_titulo = null THEN e.Titulo ELSE :p_titulo END AND e.Cuerpo LIKE CASE WHEN :p_cuerpo = null THEN e.Cuerpo ELSE :p_cuerpo END AND e.FechaPublicacion = CASE WHEN :p_fechaPublicacion = null THEN e.FechaPublicacion ELSE :p_fechaPublicacion END AND e.Creador = CASE WHEN :p_usuario = -1 THEN e.Creador ELSE :p_usuario END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENdameEntradasFiltroSinModeracionHQL");
                query.SetParameter ("p_titulo", p_titulo);
                query.SetParameter ("p_cuerpo", p_cuerpo);
                query.SetParameter ("p_fechaPublicacion", p_fechaPublicacion);
                query.SetParameter ("p_usuario", p_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasPorMuro (int p_muro, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where FROM EntradaEN AS en WHERE en.Muro.Id = :p_muro ORDER BY FechaPublicacion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENdameEntradasPorMuroHQL");
                query.SetParameter ("p_muro", p_muro);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimedia (int pe_entrada)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntradaEN self where SELECT ElementosMultimedia FROM EntradaEN AS en WHERE en.Id = :pe_entrada";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntradaENobtenerElementosMultimediaHQL");
                query.SetParameter ("pe_entrada", pe_entrada);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
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
