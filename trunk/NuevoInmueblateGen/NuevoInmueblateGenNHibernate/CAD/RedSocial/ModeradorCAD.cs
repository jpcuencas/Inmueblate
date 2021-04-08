
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
 * Clase Moderador:
 *
 */

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial class ModeradorCAD : BasicCAD, IModeradorCAD
{
public ModeradorCAD() : base ()
{
}

public ModeradorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ModeradorEN ReadOIDDefault (int id)
{
        ModeradorEN moderadorEN = null;

        try
        {
                SessionInitializeTransaction ();
                moderadorEN = (ModeradorEN)session.Get (typeof(ModeradorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ModeradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return moderadorEN;
}

public System.Collections.Generic.IList<ModeradorEN> ReadAllDefault (int first, int size, NHibernate.ISession session)
{
        System.Collections.Generic.IList<ModeradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ModeradorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ModeradorEN>();
                        else
                                result = session.CreateCriteria (typeof(ModeradorEN)).List<ModeradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ModeradorCAD.", ex);
        }

        return result;
}

public int CrearModerador (ModeradorEN moderador)
{
        try
        {
                SessionInitializeTransaction ();
                if (moderador.Muro != null) {
                        // Argumento OID y no colección.
                        moderador.Muro = (NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN)session.Load (typeof(NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN), moderador.Muro.Id);

                        moderador.Muro.PropietarioUsuario
                                = moderador;
                }

                session.Save (moderador);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ModeradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return moderador.Id;
}

public void ModificarModerador (ModeradorEN moderador)
{
        try
        {
                SessionInitializeTransaction ();
                ModeradorEN moderadorEN = (ModeradorEN)session.Load (typeof(ModeradorEN), moderador.Id);

                moderadorEN.Nombre = moderador.Nombre;


                moderadorEN.Telefono = moderador.Telefono;


                moderadorEN.Email = moderador.Email;


                moderadorEN.Direccion = moderador.Direccion;


                moderadorEN.Poblacion = moderador.Poblacion;


                moderadorEN.CodigoPostal = moderador.CodigoPostal;


                moderadorEN.Pais = moderador.Pais;


                moderadorEN.Password = moderador.Password;


                moderadorEN.ValoracionMedia = moderador.ValoracionMedia;


                moderadorEN.Apellidos = moderador.Apellidos;


                moderadorEN.Nif = moderador.Nif;


                moderadorEN.FechaNacimiento = moderador.FechaNacimiento;


                moderadorEN.Privacidad = moderador.Privacidad;

                session.Update (moderadorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ModeradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarModerador (int id)
{
        try
        {
                SessionInitializeTransaction ();
                ModeradorEN moderadorEN = (ModeradorEN)session.Load (typeof(ModeradorEN), id);
                session.Delete (moderadorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is NuevoInmueblateGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new NuevoInmueblateGenNHibernate.Exceptions.DataLayerException ("Error in ModeradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
