
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
 * Clase SuperUsuario:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class SuperUsuarioCAD : BasicCAD, ISuperUsuarioCAD
{
public SuperUsuarioCAD() : base ()
{
}

public SuperUsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public SuperUsuarioEN ReadOIDDefault (int id)
{
        SuperUsuarioEN superUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                superUsuarioEN = (SuperUsuarioEN)session.Get (typeof(SuperUsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return superUsuarioEN;
}

public System.Collections.Generic.IList<SuperUsuarioEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<SuperUsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SuperUsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SuperUsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(SuperUsuarioEN)).List<SuperUsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }

        return result;
}

public int CrearSuperUsuario (SuperUsuarioEN superUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (superUsuario.Muro != null) {
                        // Argumento OID y no colección.
                        superUsuario.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), superUsuario.Muro.Id);

                        superUsuario.Muro.PropietarioUsuario
                                = superUsuario;
                }

                session.Save (superUsuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return superUsuario.Id;
}

public void ModificarSuperUsuario (SuperUsuarioEN superUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                SuperUsuarioEN superUsuarioEN = (SuperUsuarioEN)session.Load (typeof(SuperUsuarioEN), superUsuario.Id);

                superUsuarioEN.Nombre = superUsuario.Nombre;


                superUsuarioEN.Telefono = superUsuario.Telefono;


                superUsuarioEN.Email = superUsuario.Email;


                superUsuarioEN.Direccion = superUsuario.Direccion;


                superUsuarioEN.Poblacion = superUsuario.Poblacion;


                superUsuarioEN.CodigoPostal = superUsuario.CodigoPostal;


                superUsuarioEN.Pais = superUsuario.Pais;


                superUsuarioEN.Password = superUsuario.Password;


                superUsuarioEN.ValoracionMedia = superUsuario.ValoracionMedia;

                session.Update (superUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarSuperUsuario (int id)
{
        try
        {
                SessionInitializeTransaction ();
                SuperUsuarioEN superUsuarioEN = (SuperUsuarioEN)session.Load (typeof(SuperUsuarioEN), id);
                session.Delete (superUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnyadirEntradasReportadas (int p_SuperUsuario_OID, System.Collections.Generic.IList<int> p_entradasReportadas_OIDs)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN superUsuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                superUsuarioEN = (SuperUsuarioEN)session.Load (typeof(SuperUsuarioEN), p_SuperUsuario_OID);
                NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradasReportadasENAux = null;
                if (superUsuarioEN.EntradasReportadas == null) {
                        superUsuarioEN.EntradasReportadas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                }

                foreach (int item in p_entradasReportadas_OIDs) {
                        entradasReportadasENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN ();
                        entradasReportadasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN), item);
                        entradasReportadasENAux.Reportadores.Add (superUsuarioEN);

                        superUsuarioEN.EntradasReportadas.Add (entradasReportadasENAux);
                }


                session.Update (superUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarEntradasReportadas (int p_SuperUsuario_OID, System.Collections.Generic.IList<int> p_entradasReportadas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN superUsuarioEN = null;
                superUsuarioEN = (SuperUsuarioEN)session.Load (typeof(SuperUsuarioEN), p_SuperUsuario_OID);

                NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entradasReportadasENAux = null;
                if (superUsuarioEN.EntradasReportadas != null) {
                        foreach (int item in p_entradasReportadas_OIDs) {
                                entradasReportadasENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN), item);
                                if (superUsuarioEN.EntradasReportadas.Contains (entradasReportadasENAux) == true) {
                                        superUsuarioEN.EntradasReportadas.Remove (entradasReportadasENAux);
                                        entradasReportadasENAux.Reportadores.Remove (superUsuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entradasReportadas_OIDs you are trying to unrelationer, doesn't exist in SuperUsuarioEN");
                        }
                }

                session.Update (superUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ObtenerUsuarioPorEmail (string pe_email)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where FROM SuperUsuarioEN AS su WHERE su.Email = :pe_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENobtenerUsuarioPorEmailHQL");
                query.SetParameter ("pe_email", pe_email);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SuperUsuarioEN> DameTodosLosSuerUsuario (int first, int size)
{
        System.Collections.Generic.IList<SuperUsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SuperUsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SuperUsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(SuperUsuarioEN)).List<SuperUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameSuperUsuarioPorOID
//Con e: SuperUsuarioEN
public SuperUsuarioEN DameSuperUsuarioPorOID (int id)
{
        SuperUsuarioEN superUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                superUsuarioEN = (SuperUsuarioEN)session.Get (typeof(SuperUsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return superUsuarioEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposPorUsuario (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where SELECT Grupos FROM SuperUsuarioEN AS sp WHERE sp.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENObtenerGruposPorUsuarioHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

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
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> ObtenerGruposPorUsuarioNP (int pe_usuario)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where SELECT Grupos FROM SuperUsuarioEN AS sp WHERE sp.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENObtenerGruposPorUsuarioNPHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesRecibidas (int pe_id, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where SELECT ValoracionRecibida FROM SuperUsuarioEN as sp WHERE sp.Id = :pe_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENobtenerValoracionesRecibidasHQL");
                query.SetParameter ("pe_id", pe_id);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmitidas (int pe_id, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where SELECT ValoracionEmitida FROM SuperUsuarioEN AS sp WHERE sp.Id = :pe_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENobtenerValoracionesEmitidasHQL");
                query.SetParameter ("pe_id", pe_id);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> DameSuperUsuariosGrupo (int p_grupo, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SuperUsuarioEN self where FROM SuperUsuarioEN AS su WHERE :p_grupo MEMBER OF su.Grupos";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SuperUsuarioENdameSuperUsuariosGrupoHQL");
                query.SetParameter ("p_grupo", p_grupo);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in SuperUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
