
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
 * Clase Mensaje:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class MensajeCAD : BasicCAD, IMensajeCAD
{
public MensajeCAD() : base ()
{
}

public MensajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public MensajeEN ReadOIDDefault (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
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

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeEN)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }

        return result;
}

public int CrearMensaje (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Emisor != null) {
                        // Argumento OID y no colección.
                        mensaje.Emisor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), mensaje.Emisor.Id);

                        mensaje.Emisor.MensajesEnviados
                        .Add (mensaje);
                }
                if (mensaje.Receptor != null) {
                        // Argumento OID y no colección.
                        mensaje.Receptor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), mensaje.Receptor.Id);

                        mensaje.Receptor.MensajesRecibidos
                        .Add (mensaje);
                }

                session.Save (mensaje);
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

        return mensaje.Id;
}

public void ModificarMensaje (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), mensaje.Id);

                mensajeEN.PendienteModeracion = mensaje.PendienteModeracion;


                mensajeEN.FechaEnvio = mensaje.FechaEnvio;


                mensajeEN.Asunto = mensaje.Asunto;


                mensajeEN.Cuerpo = mensaje.Cuerpo;


                mensajeEN.Leido = mensaje.Leido;

                session.Update (mensajeEN);
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
}
public void BorrarMensaje (int id)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), id);
                session.Delete (mensajeEN);
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
}

public void AnyadirElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN mensajeEN = null;
        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (mensajeEN.ElementosMultimedia == null) {
                        mensajeEN.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementomultimedia) {
                        elementosMultimediaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosMultimediaENAux.Mensaje.Add (mensajeEN);

                        mensajeEN.ElementosMultimedia.Add (elementosMultimediaENAux);
                }


                session.Update (mensajeEN);
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
}

public void BorrarElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN mensajeEN = null;
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (mensajeEN.ElementosMultimedia != null) {
                        foreach (int item in p_elementomultimedia) {
                                elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (mensajeEN.ElementosMultimedia.Contains (elementosMultimediaENAux) == true) {
                                        mensajeEN.ElementosMultimedia.Remove (elementosMultimediaENAux);
                                        elementosMultimediaENAux.Mensaje.Remove (mensajeEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementomultimedia you are trying to unrelationer, doesn't exist in MensajeEN");
                        }
                }

                session.Update (mensajeEN);
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
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajePendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN AS me WHERE me.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENobtenerMensajePendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajesPorUsuario (int p_idUsuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN m where m.Receptor = :p_idUsuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENobtenerMensajesPorUsuarioHQL");
                query.SetParameter ("p_idUsuario", p_idUsuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
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
public System.Collections.Generic.IList<MensajeEN> DameTodosLosMensajes (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MensajeEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                else
                        result = session.CreateCriteria (typeof(MensajeEN)).List<MensajeEN>();
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

//Sin e: DameMensajePorOID
//Con e: MensajeEN
public MensajeEN DameMensajePorOID (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
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

        return mensajeEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroConModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN AS m WHERE m.Asunto LIKE CASE WHEN :p_asunto = null THEN m.Asunto ELSE :p_asunto END AND m.Cuerpo LIKE CASE WHEN :p_cuerpo = null THEN m.Cuerpo ELSE :p_cuerpo END AND m.FechaEnvio = CASE WHEN :p_fechaEnvio = null THEN m.FechaEnvio ELSE :p_fechaEnvio END AND m.PendienteModeracion = :p_pendienteModeracion AND m.Emisor = CASE WHEN :p_emisor = -1 THEN m.Emisor ELSE :p_emisor END AND m.Receptor = CASE WHEN :p_receptor = -1 THEN m.Receptor ELSE :p_receptor END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajeFiltroConModeracionHQL");
                query.SetParameter ("p_asunto", p_asunto);
                query.SetParameter ("p_cuerpo", p_cuerpo);
                query.SetParameter ("p_fechaEnvio", p_fechaEnvio);
                query.SetParameter ("p_pendienteModeracion", p_pendienteModeracion);
                query.SetParameter ("p_emisor", p_emisor);
                query.SetParameter ("p_receptor", p_receptor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroSinModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, int p_emisor, int p_receptor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN AS m WHERE m.Asunto LIKE CASE WHEN :p_asunto = null THEN m.Asunto ELSE :p_asunto END AND m.Cuerpo LIKE CASE WHEN :p_cuerpo = null THEN m.Cuerpo ELSE :p_cuerpo END AND m.FechaEnvio = CASE WHEN :p_fechaEnvio = null THEN m.FechaEnvio ELSE :p_fechaEnvio END AND m.Emisor = CASE WHEN :p_emisor = -1 THEN m.Emisor ELSE :p_emisor END AND m.Receptor = CASE WHEN :p_receptor = -1 THEN m.Receptor ELSE :p_receptor END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajeFiltroSinModeracionHQL");
                query.SetParameter ("p_asunto", p_asunto);
                query.SetParameter ("p_cuerpo", p_cuerpo);
                query.SetParameter ("p_fechaEnvio", p_fechaEnvio);
                query.SetParameter ("p_emisor", p_emisor);
                query.SetParameter ("p_receptor", p_receptor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
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
public int CrearMensajeDeModerador (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Emisor != null) {
                        // Argumento OID y no colección.
                        mensaje.Emisor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), mensaje.Emisor.Id);

                        mensaje.Emisor.MensajesEnviados
                        .Add (mensaje);
                }
                if (mensaje.Receptor != null) {
                        // Argumento OID y no colección.
                        mensaje.Receptor = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), mensaje.Receptor.Id);

                        mensaje.Receptor.MensajesRecibidos
                        .Add (mensaje);
                }

                session.Save (mensaje);
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

        return mensaje.Id;
}
}
}
