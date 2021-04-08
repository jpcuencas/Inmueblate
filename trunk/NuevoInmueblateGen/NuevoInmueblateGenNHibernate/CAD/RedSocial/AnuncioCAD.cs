
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
 * Clase Anuncio:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class AnuncioCAD : BasicCAD, IAnuncioCAD
{
public AnuncioCAD() : base ()
{
}

public AnuncioCAD(ISession sessionAux) : base (sessionAux)
{
}



public AnuncioEN ReadOIDDefault (int id)
{
        AnuncioEN anuncioEN = null;

        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Get (typeof(AnuncioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncioEN;
}

public System.Collections.Generic.IList<AnuncioEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<AnuncioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AnuncioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AnuncioEN>();
                        else
                                result = session.CreateCriteria (typeof(AnuncioEN)).List<AnuncioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }

        return result;
}

public int CrearAnuncio (AnuncioEN anuncio)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (anuncio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncio.Id;
}

public void ModificarAnuncio (AnuncioEN anuncio)
{
        try
        {
                SessionInitializeTransaction ();
                AnuncioEN anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), anuncio.Id);

                anuncioEN.Imagen = anuncio.Imagen;


                anuncioEN.Descripcion = anuncio.Descripcion;


                anuncioEN.FechaCaducidad = anuncio.FechaCaducidad;


                anuncioEN.Tipo = anuncio.Tipo;


                anuncioEN.URL = anuncio.URL;

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarAnuncio (int id)
{
        try
        {
                SessionInitializeTransaction ();
                AnuncioEN anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), id);
                session.Delete (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<AnuncioEN> DameTodosLosAnuncios (int first, int size)
{
        System.Collections.Generic.IList<AnuncioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AnuncioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AnuncioEN>();
                else
                        result = session.CreateCriteria (typeof(AnuncioEN)).List<AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameAnuncioPorOID
//Con e: AnuncioEN
public AnuncioEN DameAnuncioPorOID (int id)
{
        AnuncioEN anuncioEN = null;

        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Get (typeof(AnuncioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncioEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> DameAnunciosFiltro (int p_tipo, Nullable<DateTime> p_fechaCaducidad, string p_url, string p_descripcion, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN AS a WHERE a.Tipo = CASE WHEN :p_tipo = -1 THEN a.Tipo ELSE :p_tipo END AND a.FechaCaducidad <= CASE WHEN :p_fechaCaducidad = null THEN a.FechaCaducidad ELSE :p_fechaCaducidad END AND a.URL LIKE CASE WHEN :p_url = null THEN a.URL ELSE :p_url END AND a.Descripcion LIKE CASE WHEN :p_descripcion = null THEN a.Descripcion ELSE :p_descripcion END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENdameAnunciosFiltroHQL");
                query.SetParameter ("p_tipo", p_tipo);
                query.SetParameter ("p_fechaCaducidad", p_fechaCaducidad);
                query.SetParameter ("p_url", p_url);
                query.SetParameter ("p_descripcion", p_descripcion);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
