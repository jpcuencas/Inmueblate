
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
 * Clase Fotografia:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class FotografiaCAD : BasicCAD, IFotografiaCAD
{
public FotografiaCAD() : base ()
{
}

public FotografiaCAD(ISession sessionAux) : base (sessionAux)
{
}



public FotografiaEN ReadOIDDefault (int id)
{
        FotografiaEN fotografiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                fotografiaEN = (FotografiaEN)session.Get (typeof(FotografiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fotografiaEN;
}

public System.Collections.Generic.IList<FotografiaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<FotografiaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FotografiaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<FotografiaEN>();
                        else
                                result = session.CreateCriteria (typeof(FotografiaEN)).List<FotografiaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }

        return result;
}

public int CrearFotografia (FotografiaEN fotografia)
{
        try
        {
                SessionInitializeTransaction ();
                if (fotografia.Galeria != null) {
                        // Argumento OID y no colección.
                        fotografia.Galeria = (NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN), fotografia.Galeria.Id);

                        fotografia.Galeria.ElementosMultimedia
                        .Add (fotografia);
                }

                session.Save (fotografia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fotografia.Id;
}

public void ModificarFotografia (FotografiaEN fotografia)
{
        try
        {
                SessionInitializeTransaction ();
                FotografiaEN fotografiaEN = (FotografiaEN)session.Load (typeof(FotografiaEN), fotografia.Id);

                fotografiaEN.Fecha = fotografia.Fecha;


                fotografiaEN.Descripcion = fotografia.Descripcion;


                fotografiaEN.Nombre = fotografia.Nombre;


                fotografiaEN.PendienteModeracion = fotografia.PendienteModeracion;


                fotografiaEN.URL = fotografia.URL;

                session.Update (fotografiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarFotografia (int id)
{
        try
        {
                SessionInitializeTransaction ();
                FotografiaEN fotografiaEN = (FotografiaEN)session.Load (typeof(FotografiaEN), id);
                session.Delete (fotografiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerTodasFotografiasPorModerar ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FotografiaEN self where FROM FotografiaEN AS fo WHERE fo.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FotografiaENobtenerTodasFotografiasPorModerarHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameFotografiaPorOID
//Con e: FotografiaEN
public FotografiaEN DameFotografiaPorOID (int id)
{
        FotografiaEN fotografiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                fotografiaEN = (FotografiaEN)session.Get (typeof(FotografiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return fotografiaEN;
}

public System.Collections.Generic.IList<FotografiaEN> DameTodasLasFotografias (int first, int size)
{
        System.Collections.Generic.IList<FotografiaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FotografiaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<FotografiaEN>();
                else
                        result = session.CreateCriteria (typeof(FotografiaEN)).List<FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotografiasPorUsuario (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FotografiaEN self where FROM FotografiaEN AS fo WHERE fo.Usuario IS NOT NULL AND fo.Usuario.Id = :pe_usuario ORDER BY fo.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FotografiaENobtenerFotografiasPorUsuarioHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN ObtenerFotoPerfil (int pe_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FotografiaEN self where FROM FotografiaEN AS fo WHERE fo.Usuario IS NOT NULL AND fo.Usuario = :pe_usuario AND fo.Nombre = 'default'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FotografiaENobtenerFotoPerfilHQL");
                query.SetParameter ("pe_usuario", pe_usuario);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotosPorGaleria (int pe_galeria, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM FotografiaEN self where FROM FotografiaEN AS fo WHERE fo.Galeria.Id = :pe_galeria ORDER BY fo.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("FotografiaENobtenerFotosPorGaleriaHQL");
                query.SetParameter ("pe_galeria", pe_galeria);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in FotografiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
