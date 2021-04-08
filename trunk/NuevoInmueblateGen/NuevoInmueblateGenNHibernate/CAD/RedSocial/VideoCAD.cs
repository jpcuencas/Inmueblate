
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
 * Clase Video:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class VideoCAD : BasicCAD, IVideoCAD
{
public VideoCAD() : base ()
{
}

public VideoCAD(ISession sessionAux) : base (sessionAux)
{
}



public VideoEN ReadOIDDefault (int id)
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VideoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                        else
                                result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }

        return result;
}

public int CrearVideo (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                if (video.Galeria != null) {
                        // Argumento OID y no colección.
                        video.Galeria = (NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN), video.Galeria.Id);

                        video.Galeria.ElementosMultimedia
                        .Add (video);
                }

                session.Save (video);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return video.Id;
}

public void ModificarVideo (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), video.Id);

                videoEN.Fecha = video.Fecha;


                videoEN.Descripcion = video.Descripcion;


                videoEN.Nombre = video.Nombre;


                videoEN.PendienteModeracion = video.PendienteModeracion;


                videoEN.URL = video.URL;

                session.Update (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarVideo (int id)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), id);
                session.Delete (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerTodosVideosPorModerar ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN AS vi WHERE vi.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENobtenerTodosVideosPorModerarHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameVideoPorOID
//Con e: VideoEN
public VideoEN DameVideoPorOID (int id)
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> DameTodosLosVideos (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VideoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                else
                        result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorUsuario (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN AS vi WHERE vi.Usuario IS NOT NULL AND vi.Usuario.Id = :pe_usuario ORDER BY vi.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENobtenerVideosPorUsuarioHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorGaleria (int pe_galeria, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN AS vi WHERE vi.Galeria.Id = :pe_galeria ORDER BY vi.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENobtenerVideosPorGaleriaHQL");
                query.SetParameter ("pe_galeria", pe_galeria);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
