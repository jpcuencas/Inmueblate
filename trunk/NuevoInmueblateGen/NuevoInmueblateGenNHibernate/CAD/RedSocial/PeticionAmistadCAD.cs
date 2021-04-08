
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
 * Clase PeticionAmistad:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class PeticionAmistadCAD : BasicCAD, IPeticionAmistadCAD
{
public PeticionAmistadCAD() : base ()
{
}

public PeticionAmistadCAD(ISession sessionAux) : base (sessionAux)
{
}



public PeticionAmistadEN ReadOIDDefault (int id)
{
        PeticionAmistadEN peticionAmistadEN = null;

        try
        {
                SessionInitializeTransaction ();
                peticionAmistadEN = (PeticionAmistadEN)session.Get (typeof(PeticionAmistadEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peticionAmistadEN;
}

public System.Collections.Generic.IList<PeticionAmistadEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<PeticionAmistadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PeticionAmistadEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PeticionAmistadEN>();
                        else
                                result = session.CreateCriteria (typeof(PeticionAmistadEN)).List<PeticionAmistadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }

        return result;
}

public int CrearPeticionAmistad (PeticionAmistadEN peticionAmistad)
{
        try
        {
                SessionInitializeTransaction ();
                if (peticionAmistad.Emisor != null) {
                        // Argumento OID y no colección.
                        peticionAmistad.Emisor = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), peticionAmistad.Emisor.Id);

                        peticionAmistad.Emisor.PeticionesEnviadas
                        .Add (peticionAmistad);
                }
                if (peticionAmistad.Receptor != null) {
                        // Argumento OID y no colección.
                        peticionAmistad.Receptor = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), peticionAmistad.Receptor.Id);

                        peticionAmistad.Receptor.PeticionesRecibidas
                        .Add (peticionAmistad);
                }

                session.Save (peticionAmistad);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peticionAmistad.Id;
}

public void ModificarPeticionAmistad (PeticionAmistadEN peticionAmistad)
{
        try
        {
                SessionInitializeTransaction ();
                PeticionAmistadEN peticionAmistadEN = (PeticionAmistadEN)session.Load (typeof(PeticionAmistadEN), peticionAmistad.Id);

                peticionAmistadEN.Asunto = peticionAmistad.Asunto;


                peticionAmistadEN.Cuerpo = peticionAmistad.Cuerpo;


                peticionAmistadEN.Estado = peticionAmistad.Estado;

                session.Update (peticionAmistadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPeticionAmistad (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PeticionAmistadEN peticionAmistadEN = (PeticionAmistadEN)session.Load (typeof(PeticionAmistadEN), id);
                session.Delete (peticionAmistadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePeticionAmistadPorOID
//Con e: PeticionAmistadEN
public PeticionAmistadEN DamePeticionAmistadPorOID (int id)
{
        PeticionAmistadEN peticionAmistadEN = null;

        try
        {
                SessionInitializeTransaction ();
                peticionAmistadEN = (PeticionAmistadEN)session.Get (typeof(PeticionAmistadEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return peticionAmistadEN;
}

public System.Collections.Generic.IList<PeticionAmistadEN> DameTodasLasPeticionAmistad (int first, int size)
{
        System.Collections.Generic.IList<PeticionAmistadEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PeticionAmistadEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PeticionAmistadEN>();
                else
                        result = session.CreateCriteria (typeof(PeticionAmistadEN)).List<PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorEmisor (int pe_emisor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticionAmistadEN self where FROM PeticionAmistadEN AS pe WHERE pe.Emisor = :pe_emisor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticionAmistadENdamePeticionPorEmisorHQL");
                query.SetParameter ("pe_emisor", pe_emisor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorReceptor (int pe_receptor, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticionAmistadEN self where FROM PeticionAmistadEN AS pe WHERE pe.Receptor = :pe_receptor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticionAmistadENdamePeticionPorReceptorHQL");
                query.SetParameter ("pe_receptor", pe_receptor);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmistadEstado (int pe_receptor, int pe_estado, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticionAmistadEN self where FROM PeticionAmistadEN AS pe WHERE pe.Receptor = :pe_receptor AND pe.Estado =  CASE WHEN :pe_estado = -1 THEN pe.Estado ELSE :pe_estado END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticionAmistadENobtenerPeticionesAmistadEstadoHQL");
                query.SetParameter ("pe_receptor", pe_receptor);
                query.SetParameter ("pe_estado", pe_estado);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN DamePeticionDePara (int pe_emisor, int pe_receptor)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticionAmistadEN self where FROM PeticionAmistadEN AS pe WHERE pe.Emisor = :pe_emisor AND pe.Receptor = :pe_receptor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticionAmistadENdamePeticionDeParaHQL");
                query.SetParameter ("pe_emisor", pe_emisor);
                query.SetParameter ("pe_receptor", pe_receptor);


                result = query.UniqueResult<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmisitadEstadoEmisor (int pe_emisor, int pe_estado, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PeticionAmistadEN self where FROM PeticionAmistadEN AS pe WHERE pe.Emisor = :pe_emisor AND pe.Estado =  CASE WHEN :pe_estado = -1 THEN pe.Estado ELSE :pe_estado END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PeticionAmistadENobtenerPeticionesAmisitadEstadoEmisorHQL");
                query.SetParameter ("pe_emisor", pe_emisor);
                query.SetParameter ("pe_estado", pe_estado);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in PeticionAmistadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
