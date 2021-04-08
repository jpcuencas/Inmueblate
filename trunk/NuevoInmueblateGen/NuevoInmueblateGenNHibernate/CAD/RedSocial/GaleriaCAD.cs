
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
 * Clase Galeria:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class GaleriaCAD : BasicCAD, IGaleriaCAD
{
public GaleriaCAD() : base ()
{
}

public GaleriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public GaleriaEN ReadOIDDefault (int id)
{
        GaleriaEN galeriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                galeriaEN = (GaleriaEN)session.Get (typeof(GaleriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return galeriaEN;
}

public System.Collections.Generic.IList<GaleriaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<GaleriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GaleriaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GaleriaEN>();
                        else
                                result = session.CreateCriteria (typeof(GaleriaEN)).List<GaleriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }

        return result;
}

public int CrearGaleria (GaleriaEN galeria)
{
        try
        {
                SessionInitializeTransaction ();
                if (galeria.Galeria != null) {
                        // Argumento OID y no colección.
                        galeria.Galeria = (NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN), galeria.Galeria.Id);

                        galeria.Galeria.ElementosMultimedia
                        .Add (galeria);
                }

                session.Save (galeria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return galeria.Id;
}

public void ModificarGaleria (GaleriaEN galeria)
{
        try
        {
                SessionInitializeTransaction ();
                GaleriaEN galeriaEN = (GaleriaEN)session.Load (typeof(GaleriaEN), galeria.Id);

                galeriaEN.Fecha = galeria.Fecha;


                galeriaEN.Descripcion = galeria.Descripcion;


                galeriaEN.Nombre = galeria.Nombre;


                galeriaEN.PendienteModeracion = galeria.PendienteModeracion;


                galeriaEN.URL = galeria.URL;

                session.Update (galeriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarGaleria (int id)
{
        try
        {
                SessionInitializeTransaction ();
                GaleriaEN galeriaEN = (GaleriaEN)session.Load (typeof(GaleriaEN), id);
                session.Delete (galeriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                galeriaEN = (GaleriaEN)session.Load (typeof(GaleriaEN), p_Galeria_OID);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (galeriaEN.ElementosMultimedia == null) {
                        galeriaEN.ElementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementosMultimedia_OIDs) {
                        elementosMultimediaENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosMultimediaENAux.Galeria = galeriaEN;

                        galeriaEN.ElementosMultimedia.Add (elementosMultimediaENAux);
                }


                session.Update (galeriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeriaEN = null;
                galeriaEN = (GaleriaEN)session.Load (typeof(GaleriaEN), p_Galeria_OID);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosMultimediaENAux = null;
                if (galeriaEN.ElementosMultimedia != null) {
                        foreach (int item in p_elementosMultimedia_OIDs) {
                                elementosMultimediaENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (galeriaEN.ElementosMultimedia.Contains (elementosMultimediaENAux) == true) {
                                        galeriaEN.ElementosMultimedia.Remove (elementosMultimediaENAux);
                                        elementosMultimediaENAux.Galeria = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementosMultimedia_OIDs you are trying to unrelationer, doesn't exist in GaleriaEN");
                        }
                }

                session.Update (galeriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: DameGaleriaPorOID
//Con e: GaleriaEN
public GaleriaEN DameGaleriaPorOID (int id)
{
        GaleriaEN galeriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                galeriaEN = (GaleriaEN)session.Get (typeof(GaleriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return galeriaEN;
}

public System.Collections.Generic.IList<GaleriaEN> DameTodasLasGalerias (int first, int size)
{
        System.Collections.Generic.IList<GaleriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GaleriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GaleriaEN>();
                else
                        result = session.CreateCriteria (typeof(GaleriaEN)).List<GaleriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN> ObtenerGaleriasPorUsuario (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GaleriaEN self where FROM GaleriaEN AS ga WHERE ga.Usuario IS NOT NULL AND ga.Usuario.Id = :pe_usuario ORDER BY ga.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GaleriaENobtenerGaleriasPorUsuarioHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ObtenerGaleriaPerfil (int pe_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GaleriaEN self where FROM GaleriaEN AS ga WHERE ga.Usuario IS NOT NULL AND ga.Usuario.Id = :pe_usuario AND ga.Nombre = 'Perfil'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GaleriaENobtenerGaleriaPerfilHQL");
                query.SetParameter ("pe_usuario", pe_usuario);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in GaleriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
