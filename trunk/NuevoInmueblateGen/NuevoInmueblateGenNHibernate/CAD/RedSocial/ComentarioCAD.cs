
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
 * Clase Comentario:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int id)
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

public int CrearComentario (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Creador != null) {
                        // Argumento OID y no colección.
                        comentario.Creador = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), comentario.Creador.Id);

                        comentario.Creador.Comentarios
                        .Add (comentario);
                }
                if (comentario.Entrada != null) {
                        // Argumento OID y no colección.
                        comentario.Entrada = (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN), comentario.Entrada.Id);

                        comentario.Entrada.Comentarios
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Id;
}

public void ModificarComentario (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Id);

                comentarioEN.Cuerpo = comentario.Cuerpo;


                comentarioEN.PendienteModeracion = comentario.PendienteModeracion;


                comentarioEN.FechaPublicacion = comentario.FechaPublicacion;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarComentario (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), id);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN comentarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_comentario);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (comentarioEN.ElementosMultimedia == null) {
                        comentarioEN.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementomultimedia) {
                        elementosMultimediaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosMultimediaENAux.AparicionComentarios.Add (comentarioEN);

                        comentarioEN.ElementosMultimedia.Add (elementosMultimediaENAux);
                }


                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN comentarioEN = null;
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_comentario);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (comentarioEN.ElementosMultimedia != null) {
                        foreach (int item in p_elementomultimedia) {
                                elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (comentarioEN.ElementosMultimedia.Contains (elementosMultimediaENAux) == true) {
                                        comentarioEN.ElementosMultimedia.Remove (elementosMultimediaENAux);
                                        elementosMultimediaENAux.AparicionComentarios.Remove (comentarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementomultimedia you are trying to unrelationer, doesn't exist in ComentarioEN");
                        }
                }

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirReportador (int p_comentario, System.Collections.Generic.IList<int> p_superusuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN comentarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_comentario);
                NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN reportadoresENAux = null;
                if (comentarioEN.Reportadores == null) {
                        comentarioEN.Reportadores = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                }

                foreach (int item in p_superusuario) {
                        reportadoresENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                        reportadoresENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), item);
                        reportadoresENAux.ComentariosReportados.Add (comentarioEN);

                        comentarioEN.Reportadores.Add (reportadoresENAux);
                }


                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarReportadores (int p_comentario, System.Collections.Generic.IList<int> p_superusuario)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN comentarioEN = null;
                comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), p_comentario);

                NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN reportadoresENAux = null;
                if (comentarioEN.Reportadores != null) {
                        foreach (int item in p_superusuario) {
                                reportadoresENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), item);
                                if (comentarioEN.Reportadores.Contains (reportadoresENAux) == true) {
                                        comentarioEN.Reportadores.Remove (reportadoresENAux);
                                        reportadoresENAux.ComentariosReportados.Remove (comentarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_superusuario you are trying to unrelationer, doesn't exist in ComentarioEN");
                        }
                }

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentarioPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioEN self where FROM ComentarioEN AS co WHERE co.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioENobtenerComentarioPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameComentarioPorOID
//Con e: ComentarioEN
public ComentarioEN DameComentarioPorOID (int id)
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentariosPorEntrada (int p_entrada)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioEN self where FROM ComentarioEN AS c WHERE c.Entrada.Id = :p_entrada ORDER BY c.FechaPublicacion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioENobtenerComentariosPorEntradaHQL");
                query.SetParameter ("p_entrada", p_entrada);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
