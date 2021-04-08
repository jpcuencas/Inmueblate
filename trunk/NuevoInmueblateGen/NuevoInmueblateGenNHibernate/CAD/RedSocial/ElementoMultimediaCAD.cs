
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
 * Clase ElementoMultimedia:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class ElementoMultimediaCAD : BasicCAD, IElementoMultimediaCAD
{
public ElementoMultimediaCAD() : base ()
{
}

public ElementoMultimediaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ElementoMultimediaEN ReadOIDDefault (int id)
{
        ElementoMultimediaEN elementoMultimediaEN = null;

        try
        {
                SessionInitializeTransaction ();
                elementoMultimediaEN = (ElementoMultimediaEN)session.Get (typeof(ElementoMultimediaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return elementoMultimediaEN;
}

public System.Collections.Generic.IList<ElementoMultimediaEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<ElementoMultimediaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ElementoMultimediaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ElementoMultimediaEN>();
                        else
                                result = session.CreateCriteria (typeof(ElementoMultimediaEN)).List<ElementoMultimediaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }

        return result;
}

public int CrearElementoMultimedia (ElementoMultimediaEN elementoMultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                if (elementoMultimedia.Galeria != null) {
                        // Argumento OID y no colección.
                        elementoMultimedia.Galeria = (NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN), elementoMultimedia.Galeria.Id);

                        elementoMultimedia.Galeria.ElementosMultimedia
                        .Add (elementoMultimedia);
                }

                session.Save (elementoMultimedia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return elementoMultimedia.Id;
}

public void ModificarElementoMultimedia (ElementoMultimediaEN elementoMultimedia)
{
        try
        {
                SessionInitializeTransaction ();
                ElementoMultimediaEN elementoMultimediaEN = (ElementoMultimediaEN)session.Load (typeof(ElementoMultimediaEN), elementoMultimedia.Id);

                elementoMultimediaEN.Fecha = elementoMultimedia.Fecha;


                elementoMultimediaEN.Descripcion = elementoMultimedia.Descripcion;


                elementoMultimediaEN.Nombre = elementoMultimedia.Nombre;


                elementoMultimediaEN.PendienteModeracion = elementoMultimedia.PendienteModeracion;


                elementoMultimediaEN.URL = elementoMultimedia.URL;

                session.Update (elementoMultimediaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarElementoMultimedia (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ElementoMultimediaEN elementoMultimediaEN = (ElementoMultimediaEN)session.Load (typeof(ElementoMultimediaEN), id);
                session.Delete (elementoMultimediaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementoPendienteModeracion ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ElementoMultimediaEN self where FROM ElementoMultimediaEN AS em WHERE em.PendienteModeracion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ElementoMultimediaENobtenerElementoPendienteModeracionHQL");

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: DameElementoMultimediaPorOID
//Con e: ElementoMultimediaEN
public ElementoMultimediaEN DameElementoMultimediaPorOID (int id)
{
        ElementoMultimediaEN elementoMultimediaEN = null;

        try
        {
                SessionInitializeTransaction ();
                elementoMultimediaEN = (ElementoMultimediaEN)session.Get (typeof(ElementoMultimediaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return elementoMultimediaEN;
}

public System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosLosElementosMultimedia (int first, int size)
{
        System.Collections.Generic.IList<ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ElementoMultimediaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ElementoMultimediaEN>();
                else
                        result = session.CreateCriteria (typeof(ElementoMultimediaEN)).List<ElementoMultimediaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimediaPorUsuario (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ElementoMultimediaEN self where FROM ElementoMultimediaEN AS el WHERE el.Usuario IS NOT NULL AND el.Usuario.Id = :pe_usuario ORDER BY el.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ElementoMultimediaENobtenerElementosMultimediaPorUsuarioHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementoMultimediaEN = null;
        try
        {
                SessionInitializeTransaction ();
                elementoMultimediaEN = (ElementoMultimediaEN)session.Load (typeof(ElementoMultimediaEN), p_ElementoMultimedia_OID);
                elementoMultimediaEN.Usuario = (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN), p_usuario_OID);

                elementoMultimediaEN.Usuario.Elementos.Add (elementoMultimediaEN);



                session.Update (elementoMultimediaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementoMultimediaEN = null;
                elementoMultimediaEN = (ElementoMultimediaEN)session.Load (typeof(ElementoMultimediaEN), p_ElementoMultimedia_OID);

                if (elementoMultimediaEN.Usuario.Id == p_usuario_OID) {
                        elementoMultimediaEN.Usuario = null;
                }
                else
                        throw new ModelException ("The identifier " + p_usuario_OID + " in p_usuario_OID you are trying to unrelationer, doesn't exist in ElementoMultimediaEN");

                session.Update (elementoMultimediaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosElementosMultimediaP (int first, int size)
{
        System.Collections.Generic.IList<ElementoMultimediaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ElementoMultimediaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ElementoMultimediaEN>();
                else
                        result = session.CreateCriteria (typeof(ElementoMultimediaEN)).List<ElementoMultimediaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ElementoMultimediaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
