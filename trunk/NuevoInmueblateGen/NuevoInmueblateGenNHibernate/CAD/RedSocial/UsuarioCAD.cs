
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
 * Clase Usuario:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

public int CrearUsuario (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (usuario.Muro != null) {
                        // Argumento OID y no colección.
                        usuario.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), usuario.Muro.Id);

                        usuario.Muro.PropietarioUsuario
                                = usuario;
                }

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void ModificarUsuario (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Telefono = usuario.Telefono;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Direccion = usuario.Direccion;


                usuarioEN.Poblacion = usuario.Poblacion;


                usuarioEN.CodigoPostal = usuario.CodigoPostal;


                usuarioEN.Pais = usuario.Pais;


                usuarioEN.Password = usuario.Password;


                usuarioEN.ValoracionMedia = usuario.ValoracionMedia;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nif = usuario.Nif;


                usuarioEN.FechaNacimiento = usuario.FechaNacimiento;


                usuarioEN.Privacidad = usuario.Privacidad;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarUsuario (int id)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: DameUsuarioPorOID
//Con e: UsuarioEN
public UsuarioEN DameUsuarioPorOID (int id)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerPorApellidos (string p_apellido)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN AS us WHERE us.Apellidos=:p_apellido";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENobtenerPorApellidosHQL");
                query.SetParameter ("p_apellido", p_apellido);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> DameUsuariosFiltro (string p_nif, string p_email, string p_apellidos, Nullable<DateTime> p_fechaNacimiento, string p_direccion, string p_poblacion, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN AS u WHERE u.Apellidos LIKE CASE WHEN :p_apellidos = null THEN u.Apellidos ELSE :p_apellidos END AND u.Email LIKE CASE WHEN :p_email = null THEN u.Email ELSE :p_email END AND u.FechaNacimiento = CASE WHEN :p_fechaNacimiento = null THEN u.FechaNacimiento ELSE :p_fechaNacimiento END AND u.Nif LIKE CASE WHEN :p_nif = null THEN u.Nif ELSE :p_nif END AND u.Direccion LIKE CASE WHEN :p_direccion = null THEN u.Direccion ELSE :p_direccion END AND u.Poblacion LIKE CASE WHEN :p_poblacion = null THEN u.Poblacion ELSE :p_poblacion END";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosFiltroHQL");
                query.SetParameter ("p_nif", p_nif);
                query.SetParameter ("p_email", p_email);
                query.SetParameter ("p_apellidos", p_apellidos);
                query.SetParameter ("p_fechaNacimiento", p_fechaNacimiento);
                query.SetParameter ("p_direccion", p_direccion);
                query.SetParameter ("p_poblacion", p_poblacion);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigos (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT ListaAmigos FROM UsuarioEN AS us WHERE us.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENobtenerAmigosHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigosSP (int pe_usuario)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT ListaAmigos FROM UsuarioEN AS us WHERE us.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENobtenerAmigosSPHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueadosSP (int pe_usuario)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT ListaBloqueados FROM UsuarioEN AS us WHERE us.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENobtenerBloqueadosSPHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueados (int pe_usuario, int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT ListaBloqueados FROM UsuarioEN AS us WHERE us.Id = :pe_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENobtenerBloqueadosHQL");
                query.SetParameter ("pe_usuario", pe_usuario);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosENAux = null;
                if (usuarioEN.Elementos == null) {
                        usuarioEN.Elementos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                }

                foreach (int item in p_elementos_OIDs) {
                        elementosENAux = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                        elementosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                        elementosENAux.Usuario = usuarioEN;

                        usuarioEN.Elementos.Add (elementosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementosENAux = null;
                if (usuarioEN.Elementos != null) {
                        foreach (int item in p_elementos_OIDs) {
                                elementosENAux = (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN), item);
                                if (usuarioEN.Elementos.Contains (elementosENAux) == true) {
                                        usuarioEN.Elementos.Remove (elementosENAux);
                                        elementosENAux.Usuario = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_elementos_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
