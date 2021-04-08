
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
 * Clase Muro:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class MuroCAD : BasicCAD, IMuroCAD
{
public MuroCAD() : base ()
{
}

public MuroCAD(ISession sessionAux) : base (sessionAux)
{
}



public MuroEN ReadOIDDefault (int id)
{
        MuroEN muroEN = null;

        try
        {
                SessionInitializeTransaction ();
                muroEN = (MuroEN)session.Get (typeof(MuroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return muroEN;
}

public System.Collections.Generic.IList<MuroEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<MuroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MuroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MuroEN>();
                        else
                                result = session.CreateCriteria (typeof(MuroEN)).List<MuroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }

        return result;
}

public int CrearMuro (MuroEN muro)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (muro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return muro.Id;
}

public void ModificarMuro (MuroEN muro)
{
        try
        {
                SessionInitializeTransaction ();
                MuroEN muroEN = (MuroEN)session.Load (typeof(MuroEN), muro.Id);

                muroEN.PendienteModeracion = muro.PendienteModeracion;

                session.Update (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarMuro (int id)
{
        try
        {
                SessionInitializeTransaction ();
                MuroEN muroEN = (MuroEN)session.Load (typeof(MuroEN), id);
                session.Delete (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsociarConGrupo (int p_muro, int p_grupo)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muroEN = null;
        try
        {
                SessionInitializeTransaction ();
                muroEN = (MuroEN)session.Load (typeof(MuroEN), p_muro);
                muroEN.PropietarioGrupo = (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN), p_grupo);

                muroEN.PropietarioGrupo.Muro = muroEN;




                session.Update (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsociarConUsuario (int p_muro, int p_superusuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muroEN = null;
        try
        {
                SessionInitializeTransaction ();
                muroEN = (MuroEN)session.Load (typeof(MuroEN), p_muro);
                muroEN.PropietarioUsuario = (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN), p_superusuario);

                muroEN.PropietarioUsuario.Muro = muroEN;




                session.Update (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muroEN = null;
        try
        {
                SessionInitializeTransaction ();
                muroEN = (MuroEN)session.Load (typeof(MuroEN), p_muro);
                NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradasENAux = null;
                if (muroEN.Entradas == null) {
                        muroEN.Entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                }

                foreach (int item in p_entrada) {
                        entradasENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN ();
                        entradasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN), item);
                        entradasENAux.Muro = muroEN;

                        muroEN.Entradas.Add (entradasENAux);
                }


                session.Update (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muroEN = null;
                muroEN = (MuroEN)session.Load (typeof(MuroEN), p_muro);

                NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradasENAux = null;
                if (muroEN.Entradas != null) {
                        foreach (int item in p_entrada) {
                                entradasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN), item);
                                if (muroEN.Entradas.Contains (entradasENAux) == true) {
                                        muroEN.Entradas.Remove (entradasENAux);
                                        entradasENAux.Muro = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entrada you are trying to unrelationer, doesn't exist in MuroEN");
                        }
                }

                session.Update (muroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorUsuario (int p_usuario)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MuroEN self where FROM MuroEN AS mu WHERE mu.PropietarioUsuario is not empty AND mu.PropietarioUsuario.Id = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MuroENobtenerMuroPorUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN> ObtenerMuroPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MuroEN self where FROM MuroEN AS mu WHERE mu.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MuroENobtenerMuroPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameMuroPorOID
//Con e: MuroEN
public MuroEN DameMuroPorOID (int id)
{
        MuroEN muroEN = null;

        try
        {
                SessionInitializeTransaction ();
                muroEN = (MuroEN)session.Get (typeof(MuroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return muroEN;
}

public System.Collections.Generic.IList<MuroEN> DameTodosLosMuros (int first, int size)
{
        System.Collections.Generic.IList<MuroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MuroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MuroEN>();
                else
                        result = session.CreateCriteria (typeof(MuroEN)).List<MuroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorGrupo (int p_grupo)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MuroEN self where FROM MuroEN AS mu WHERE mu.PropietarioGrupo is not empty AND mu.PropietarioGrupo.Id = :p_grupo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MuroENobtenerMuroPorGrupoHQL");
                query.SetParameter ("p_grupo", p_grupo);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in MuroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
