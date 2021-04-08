
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
 * Clase Inmobiliaria:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class InmobiliariaCAD : BasicCAD, IInmobiliariaCAD
{
public InmobiliariaCAD() : base ()
{
}

public InmobiliariaCAD(ISession sessionAux) : base (sessionAux)
{
}



public InmobiliariaEN ReadOIDDefault (int id)
{
        InmobiliariaEN inmobiliariaEN = null;

        try
        {
                SessionInitializeTransaction ();
                inmobiliariaEN = (InmobiliariaEN)session.Get (typeof(InmobiliariaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmobiliariaEN;
}

public System.Collections.Generic.IList<InmobiliariaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<InmobiliariaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(InmobiliariaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<InmobiliariaEN>();
                        else
                                result = session.CreateCriteria (typeof(InmobiliariaEN)).List<InmobiliariaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }

        return result;
}

public int CrearInmobiliaria (InmobiliariaEN inmobiliaria)
{
        try
        {
                SessionInitializeTransaction ();
                if (inmobiliaria.Muro != null) {
                        // Argumento OID y no colección.
                        inmobiliaria.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), inmobiliaria.Muro.Id);

                        inmobiliaria.Muro.PropietarioUsuario
                                = inmobiliaria;
                }

                session.Save (inmobiliaria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmobiliaria.Id;
}

public void ModificarInmobilaria (InmobiliariaEN inmobiliaria)
{
        try
        {
                SessionInitializeTransaction ();
                InmobiliariaEN inmobiliariaEN = (InmobiliariaEN)session.Load (typeof(InmobiliariaEN), inmobiliaria.Id);

                inmobiliariaEN.Nombre = inmobiliaria.Nombre;


                inmobiliariaEN.Telefono = inmobiliaria.Telefono;


                inmobiliariaEN.Email = inmobiliaria.Email;


                inmobiliariaEN.Direccion = inmobiliaria.Direccion;


                inmobiliariaEN.Poblacion = inmobiliaria.Poblacion;


                inmobiliariaEN.CodigoPostal = inmobiliaria.CodigoPostal;


                inmobiliariaEN.Pais = inmobiliaria.Pais;


                inmobiliariaEN.Password = inmobiliaria.Password;


                inmobiliariaEN.ValoracionMedia = inmobiliaria.ValoracionMedia;


                inmobiliariaEN.Descripcion = inmobiliaria.Descripcion;


                inmobiliariaEN.Cif = inmobiliaria.Cif;

                session.Update (inmobiliariaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarInmobiliaria (int id)
{
        try
        {
                SessionInitializeTransaction ();
                InmobiliariaEN inmobiliariaEN = (InmobiliariaEN)session.Load (typeof(InmobiliariaEN), id);
                session.Delete (inmobiliariaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<InmobiliariaEN> DameTodasLasInmobiliarias (int first, int size)
{
        System.Collections.Generic.IList<InmobiliariaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(InmobiliariaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<InmobiliariaEN>();
                else
                        result = session.CreateCriteria (typeof(InmobiliariaEN)).List<InmobiliariaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameInmobiliariaPorOID
//Con e: InmobiliariaEN
public InmobiliariaEN DameInmobiliariaPorOID (int id)
{
        InmobiliariaEN inmobiliariaEN = null;

        try
        {
                SessionInitializeTransaction ();
                inmobiliariaEN = (InmobiliariaEN)session.Get (typeof(InmobiliariaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return inmobiliariaEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> DameInmobiliariaFiltro (string p_cif, string p_nombre, string p_descripcion, string p_email, string p_direccion, string p_poblacion, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM InmobiliariaEN self where FROM InmobiliariaEN AS i WHERE i.Nombre LIKE CASE WHEN :p_nombre = null THEN i.Nombre ELSE :p_nombre END AND i.Cif LIKE CASE WHEN :p_cif = null THEN i.Cif ELSE :p_cif END AND i.Email LIKE CASE WHEN :p_email = null THEN i.Email ELSE :p_email END AND i.Descripcion LIKE CASE WHEN :p_descripcion = null THEN i.Descripcion ELSE :p_descripcion END AND i.Direccion LIKE CASE WHEN :p_direccion = null THEN i.Direccion ELSE :p_direccion END AND i.Poblacion LIKE CASE WHEN :p_poblacion = null THEN i.Poblacion ELSE :p_poblacion END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("InmobiliariaENdameInmobiliariaFiltroHQL");
                query.SetParameter ("p_cif", p_cif);
                query.SetParameter ("p_nombre", p_nombre);
                query.SetParameter ("p_descripcion", p_descripcion);
                query.SetParameter ("p_email", p_email);
                query.SetParameter ("p_direccion", p_direccion);
                query.SetParameter ("p_poblacion", p_poblacion);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in InmobiliariaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
