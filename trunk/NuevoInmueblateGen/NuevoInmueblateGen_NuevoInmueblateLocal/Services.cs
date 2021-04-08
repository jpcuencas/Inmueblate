using System;
using System.Runtime.Serialization;
using NHibernate;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateLocal
{
public class Service
{
/*PROTECTED REGION ID(NuevoInmueblateGen_NuevoInmueblateLocal_Other_Operations) ENABLED START*/
public int BorrarUsuariosListaAmigosCP (int pe_usuario, int pe_usu_borrar)
{
        NuevoInmueblateCP.InmueblateCP.UsuarioCP usuCP = new NuevoInmueblateCP.InmueblateCP.UsuarioCP ();
        return usuCP.BorrarAmigoListaAmigos (pe_usuario, pe_usu_borrar);
}

public int AceptarPeticionAmistadCP (int pe_peticion)
{
        NuevoInmueblateCP.InmueblateCP.PeticionAmistadCP petCP = new NuevoInmueblateCP.InmueblateCP.PeticionAmistadCP ();
        return petCP.AceptarPeticionAmistad (pe_peticion);
}

public int ModificarUsuarioCP (int pe_usuario,
                               string pe_nombre,
                               string pe_apellido,
                               string pe_nif,
                               string pe_mail,
                               string pe_direccion,
                               string pe_poblacion,
                               string pe_cp,
                               string pe_pais,
                               string pe_pass,
                               string pe_telefono)
{
        NuevoInmueblateCP.InmueblateCP.UsuarioCP usuCP = new NuevoInmueblateCP.InmueblateCP.UsuarioCP ();
        return usuCP.ModificarUsuario (pe_usuario, pe_nombre, pe_apellido, pe_nif, pe_mail, pe_direccion, pe_poblacion, pe_cp, pe_pais, pe_pass, pe_telefono);
}

public int ModificarFotoPerfilCP (int pe_usuario, string pe_ruta)
{
        NuevoInmueblateCP.InmueblateCP.GaleriaCP galCP = new NuevoInmueblateCP.InmueblateCP.GaleriaCP ();
        return galCP.ModificarFotoPerfil (pe_usuario, pe_ruta);
}

public int AnaydirFotoCP (int pe_usuario, int pe_galeria, string pe_ruta, string pe_descripcion, string pe_nombre)
{
        NuevoInmueblateCP.InmueblateCP.GaleriaCP galCP = new NuevoInmueblateCP.InmueblateCP.GaleriaCP ();
        return galCP.AnyadirFotos (pe_usuario, pe_galeria, pe_ruta, pe_descripcion, pe_nombre);
}
public int AnyadirFotosEnCP (int pe_usuario, int pe_galeria, int pe_entrada, string ruta, string pe_nombre, string pe_descripcion)
{
        NuevoInmueblateCP.InmueblateCP.GaleriaCP galCP = new NuevoInmueblateCP.InmueblateCP.GaleriaCP ();
        return galCP.AnyadirFotosEn (pe_usuario, pe_galeria, pe_entrada, ruta, pe_nombre, pe_descripcion);
}
/*PROTECTED REGION END*/




public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum
NuevoInmueblate_SuperUsuario_Login (int p_oid, string p_email, string p_pass)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;

        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum returnValueEN;


        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);
                                returnValueEN = superUsuarioCEN.Login (p_oid, p_email, p_pass);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN NuevoInmueblate_SuperUsuario_ObtenerUsuarioPorEmail (string pe_email){
        NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);

                                returnValueEN = superUsuarioCEN.ObtenerUsuarioPorEmail (pe_email);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> NuevoInmueblate_SuperUsuario_DameTodosLosSuerUsuario (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> superUsuarioENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                superUsuarioENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);
                                superUsuarioENs = superUsuarioCEN.DameTodosLosSuerUsuario (first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return superUsuarioENs;
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>
NuevoInmueblate_SuperUsuario_ObtenerGruposPorUsuario (int pe_usuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);

                                returnValueEN = superUsuarioCEN.ObtenerGruposPorUsuario (pe_usuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>
NuevoInmueblate_SuperUsuario_ObtenerGruposPorUsuarioNP (int pe_usuario)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);

                                returnValueEN = superUsuarioCEN.ObtenerGruposPorUsuarioNP (pe_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>
NuevoInmueblate_SuperUsuario_ObtenerValoracionesRecibidas (int pe_id, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);

                                returnValueEN = superUsuarioCEN.ObtenerValoracionesRecibidas (pe_id, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>
NuevoInmueblate_SuperUsuario_ObtenerValoracionesEmitidas (int pe_id, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);

                                returnValueEN = superUsuarioCEN.ObtenerValoracionesEmitidas (pe_id, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN NuevoInmueblate_SuperUsuario_DameSuperUsuarioPorOID (int p_SuperUsuario_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN superUsuarioEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                superUsuarioEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);
                                superUsuarioEN = superUsuarioCEN.DameSuperUsuarioPorOID (p_SuperUsuario_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return superUsuarioEN;
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN>
NuevoInmueblate_Anuncio_ObtenerAnunciosRandom (int pe_numero)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> returnValueEN = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);
                                returnValueEN = anuncioCEN.ObtenerAnunciosRandom (pe_numero);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueEN;
}





public NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN NuevoInmueblate_Anuncio_DameAnuncioPorOID (int p_Anuncio_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN anuncioEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                anuncioEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN ();
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);
                                anuncioEN = anuncioCEN.DameAnuncioPorOID (p_Anuncio_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return anuncioEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> NuevoInmueblate_Anuncio_DameTodosLosAnuncios ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> anuncioENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                anuncioENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN>();
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);
                                anuncioENs = anuncioCEN.DameTodosLosAnuncios (0, -1);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return anuncioENs;
}







public int NuevoInmueblate_PreferenciasBusqueda_CrearPreferenciasBusqueda (int p_distanciaTolerable, float p_precioMax, float p_precioMin, int p_geolocalizacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                returnValue = preferenciasBusquedaCEN.CrearPreferenciasBusqueda (p_distanciaTolerable, p_precioMax, p_precioMin, p_geolocalizacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_PreferenciasBusqueda_ModificarPreferenciasBusqueda (int p_oid, int p_distanciaTolerable, float p_precioMax, float p_precioMin)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                preferenciasBusquedaCEN.ModificarPreferenciasBusqueda (p_oid, p_distanciaTolerable, p_precioMax, p_precioMin);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_PreferenciasBusqueda_BorrarPreferenciasBusqueda (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                preferenciasBusquedaCEN.BorrarPreferenciasBusqueda (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN> NuevoInmueblate_PreferenciasBusqueda_DameTodasLasPreferenciasBusqueda (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN> preferenciasBusquedaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                preferenciasBusquedaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN>();
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                preferenciasBusquedaENs = preferenciasBusquedaCEN.DameTodasLasPreferenciasBusqueda (first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return preferenciasBusquedaENs;
}






public NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN NuevoInmueblate_PreferenciasBusqueda_DamePreferenciasBusquedaPorOID (int p_PreferenciasBusqueda_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusquedaEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                preferenciasBusquedaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN ();
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                preferenciasBusquedaEN = preferenciasBusquedaCEN.DamePreferenciasBusquedaPorOID (p_PreferenciasBusqueda_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return preferenciasBusquedaEN;
}






public int NuevoInmueblate_Gustos_CrearGustos (bool p_pendienteModeracion, int p_usuario)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                returnValue = gustosCEN.CrearGustos (p_pendienteModeracion, p_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Gustos_ModificarGustos (int p_oid, bool p_pendienteModeracion, System.Collections.Generic.IList<string> p_musica, System.Collections.Generic.IList<string> p_libros, System.Collections.Generic.IList<string> p_peliculas, System.Collections.Generic.IList<string> p_juegos)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                gustosCEN.ModificarGustos (p_oid, p_pendienteModeracion, p_musica, p_libros, p_peliculas, p_juegos);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Gustos_BorrarGustos (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                gustosCEN.BorrarGustos (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN NuevoInmueblate_Gustos_DameGustosPorOID (int p_Gustos_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustosEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                gustosEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN ();
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                gustosEN = gustosCEN.DameGustosPorOID (p_Gustos_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return gustosEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> NuevoInmueblate_Gustos_DameTodosLosGustos ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> gustosENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                gustosENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN>();
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                gustosENs = gustosCEN.DameTodosLosGustos (0, -1);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return gustosENs;
}








public void NuevoInmueblate_Muro_AnyadirEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN muroCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD _ImuroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImuroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD (session);
                                muroCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN (_ImuroCAD);
                                muroCEN.AnyadirEntradas (p_muro, p_entrada);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Muro_BorrarEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN muroCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD _ImuroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImuroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD (session);
                                muroCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN (_ImuroCAD);
                                muroCEN.BorrarEntradas (p_muro, p_entrada);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public
NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN NuevoInmueblate_Muro_ObtenerMuroPorUsuario (int p_usuario){
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN muroCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD _ImuroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImuroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD (session);
                                muroCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN (_ImuroCAD);

                                returnValueEN = muroCEN.ObtenerMuroPorUsuario (p_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN NuevoInmueblate_Muro_ObtenerMuroPorGrupo (int p_grupo){
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN muroCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD _ImuroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImuroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD (session);
                                muroCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN (_ImuroCAD);

                                returnValueEN = muroCEN.ObtenerMuroPorGrupo (p_grupo);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Entrada_CrearEntrada (Nullable<DateTime> p_fechaPublicacion, string p_titulo, string p_cuerpo, bool p_pendienteModeracion, int p_muro, int p_creador)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                returnValue = entradaCEN.CrearEntrada (p_fechaPublicacion, p_titulo, p_cuerpo, p_pendienteModeracion, p_muro, p_creador);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Entrada_ModificarEntrada (int p_oid, Nullable<DateTime> p_fechaPublicacion, string p_titulo, string p_cuerpo, bool p_pendienteModeracion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                entradaCEN.ModificarEntrada (p_oid, p_fechaPublicacion, p_titulo, p_cuerpo, p_pendienteModeracion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Entrada_BorrarEntrada (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                entradaCEN.BorrarEntrada (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>
NuevoInmueblate_Entrada_ObtenerEntradasPorMuro (int p_muro, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);

                                returnValueEN = entradaCEN.ObtenerEntradasPorMuro (p_muro, first, 5);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>
NuevoInmueblate_Entrada_ObtenerEntradasPendientesPorUsuario (int pe_ID)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);

                                returnValueEN = entradaCEN.ObtenerEntradasPendientesPorUsuario (pe_ID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>
NuevoInmueblate_Entrada_ObtenerEntradasPendientesPorGrupo (int pe_ID)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);

                                returnValueEN = entradaCEN.ObtenerEntradasPendientesPorGrupo (pe_ID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public void NuevoInmueblate_Entrada_AnyadirElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                entradaCEN.AnyadirElementosMultimedia (p_entrada, p_elementomultimedia);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Entrada_BorrarElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                entradaCEN.BorrarElementosMultimedia (p_entrada, p_elementomultimedia);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>
NuevoInmueblate_Entrada_ObtenerElementosMultimedia (int pe_entrada)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);

                                returnValueEN = entradaCEN.ObtenerElementosMultimedia (pe_entrada);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Comentario_CrearComentario (string p_cuerpo, bool p_pendienteModeracion, Nullable<DateTime> p_fechaPublicacion, int p_creador, int p_entrada)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN comentarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD _IcomentarioCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IcomentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD (session);
                                comentarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN (_IcomentarioCAD);
                                returnValue = comentarioCEN.CrearComentario (p_cuerpo, p_pendienteModeracion, p_fechaPublicacion, p_creador, p_entrada);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Comentario_BorrarComentario (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN comentarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD _IcomentarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IcomentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD (session);
                                comentarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN (_IcomentarioCAD);
                                comentarioCEN.BorrarComentario (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN>
NuevoInmueblate_Comentario_ObtenerComentariosPorEntrada (int p_entrada)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN comentarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IComentarioCAD _IcomentarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IcomentarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ComentarioCAD (session);
                                comentarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ComentarioCEN (_IcomentarioCAD);

                                returnValueEN = comentarioCEN.ObtenerComentariosPorEntrada (p_entrada);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Mensaje_CrearMensaje (bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_cuerpo, bool p_leido, int p_emisor, int p_receptor)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);
                                returnValue = mensajeCEN.CrearMensaje (p_pendienteModeracion, p_fechaEnvio, p_asunto, p_cuerpo, p_leido, p_emisor, p_receptor);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Mensaje_BorrarMensaje (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);
                                mensajeCEN.BorrarMensaje (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>
NuevoInmueblate_Mensaje_ObtenerMensajesPorUsuario (int p_idUsuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);

                                returnValueEN = mensajeCEN.ObtenerMensajesPorUsuario (p_idUsuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN NuevoInmueblate_Mensaje_DameMensajePorOID (int p_Mensaje_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN mensajeEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                mensajeEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN ();
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);
                                mensajeEN = mensajeCEN.DameMensajePorOID (p_Mensaje_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return mensajeEN;
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>
NuevoInmueblate_Mensaje_DameMensajeFiltro (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_filtrarPendienteModeracion, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> returnValueEN = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);
                                returnValueEN = mensajeCEN.DameMensajeFiltro (p_asunto, p_cuerpo, p_fechaEnvio, p_filtrarPendienteModeracion, p_pendienteModeracion, p_emisor, p_receptor, first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>
NuevoInmueblate_Mensaje_DameMensajeFiltroSinModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, int p_emisor, int p_receptor, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);

                                returnValueEN = mensajeCEN.DameMensajeFiltroSinModeracion (p_asunto, p_cuerpo, p_fechaEnvio, p_emisor, p_receptor, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}







public NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN NuevoInmueblate_Grupo_DameGrupoPorOID (int p_Grupo_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN grupoEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                grupoEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN ();
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);
                                grupoEN = grupoCEN.DameGrupoPorOID (p_Grupo_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return grupoEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> NuevoInmueblate_Grupo_DameTodosLosGrupos (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                grupoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);
                                grupoENs = grupoCEN.DameTodosLosGrupos (first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return grupoENs;
}








public NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN NuevoInmueblate_Valoracion_DameValoracionPorOID (int p_Valoracion_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN valoracionEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN valoracionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD _IvaloracionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                valoracionEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN ();
                                _IvaloracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD (session);
                                valoracionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN (_IvaloracionCAD);
                                valoracionEN = valoracionCEN.DameValoracionPorOID (p_Valoracion_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return valoracionEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>
NuevoInmueblate_Valoracion_ObtenerValoracionesReceptor (int pe_receptor, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN valoracionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD _IvaloracionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvaloracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD (session);
                                valoracionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN (_IvaloracionCAD);

                                returnValueEN = valoracionCEN.ObtenerValoracionesReceptor (pe_receptor, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN>
NuevoInmueblate_Valoracion_ObtenerValoracionesEmisor (int pe_emisor, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN valoracionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD _IvaloracionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvaloracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD (session);
                                valoracionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN (_IvaloracionCAD);

                                returnValueEN = valoracionCEN.ObtenerValoracionesEmisor (pe_emisor, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN NuevoInmueblate_Valoracion_ObtenerValoracionDeA (int pe_emisor, int pe_receptor){
        NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN valoracionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IValoracionCAD _IvaloracionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvaloracionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ValoracionCAD (session);
                                valoracionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ValoracionCEN (_IvaloracionCAD);

                                returnValueEN = valoracionCEN.ObtenerValoracionDeA (pe_emisor, pe_receptor);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_PeticionAmistad_CrearPeticionAmistad (string p_asunto, string p_cuerpo, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum p_estado, int p_emisor, int p_receptor)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                returnValue = peticionAmistadCEN.CrearPeticionAmistad (p_asunto, p_cuerpo, p_estado, p_emisor, p_receptor);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_PeticionAmistad_BorrarPeticionAmistad (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                peticionAmistadCEN.BorrarPeticionAmistad (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}



public void
NuevoInmueblate_PeticionAmistad_AceptarPeticionAmistad (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;


        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                peticionAmistadCEN.AceptarPeticionAmistad (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void
NuevoInmueblate_PeticionAmistad_BloquearPeticionAmistad (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;


        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                peticionAmistadCEN.BloquearPeticionAmistad (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}





public NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN NuevoInmueblate_PeticionAmistad_DamePeticionAmistadPorOID (int p_PeticionAmistad_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN peticionAmistadEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                peticionAmistadEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN ();
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                peticionAmistadEN = peticionAmistadCEN.DamePeticionAmistadPorOID (p_PeticionAmistad_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return peticionAmistadEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>
NuevoInmueblate_PeticionAmistad_DamePeticionPorEmisor (int pe_emisor, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);

                                returnValueEN = peticionAmistadCEN.DamePeticionPorEmisor (pe_emisor, first, 5);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>
NuevoInmueblate_PeticionAmistad_DamePeticionPorReceptor (int pe_receptor, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);

                                returnValueEN = peticionAmistadCEN.DamePeticionPorReceptor (pe_receptor, first, 5);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN NuevoInmueblate_PeticionAmistad_DamePeticionDePara (int pe_emisor, int pe_receptor){
        NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);

                                returnValueEN = peticionAmistadCEN.DamePeticionDePara (pe_emisor, pe_receptor);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>
NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmistadEstado (int pe_receptor, int pe_estado, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);

                                returnValueEN = peticionAmistadCEN.ObtenerPeticionesAmistadEstado (pe_receptor, pe_estado, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN>
NuevoInmueblate_PeticionAmistad_ObtenerPeticionesAmisitadEstadoEmisor (int pe_emisor, int pe_estado, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);

                                returnValueEN = peticionAmistadCEN.ObtenerPeticionesAmisitadEstadoEmisor (pe_emisor, pe_estado, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}




public void
NuevoInmueblate_PeticionAmistad_DesbloquearPeticionAmistad (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN peticionAmistadCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPeticionAmistadCAD _IpeticionAmistadCAD = null;


        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpeticionAmistadCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PeticionAmistadCAD (session);
                                peticionAmistadCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PeticionAmistadCEN (_IpeticionAmistadCAD);
                                peticionAmistadCEN.DesbloquearPeticionAmistad (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}






public int NuevoInmueblate_Evento_CrearEvento (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_categoria, int p_inmobiliaria, int p_geolocalizacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                returnValue = eventoCEN.CrearEvento (p_nombre, p_descripcion, p_fecha, p_categoria, p_inmobiliaria, p_geolocalizacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Evento_BorrarEvento (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoCEN.BorrarEvento (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>
NuevoInmueblate_Evento_DameEventosFiltro (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, int p_categoria, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);

                                returnValueEN = eventoCEN.DameEventosFiltro (p_nombre, p_descripcion, p_fecha, p_categoria, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> NuevoInmueblate_Evento_DameTodosLosEventos ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                eventoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>();
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoENs = eventoCEN.DameTodosLosEventos (0, -1);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return eventoENs;
}






public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> NuevoInmueblate_Evento_DameTodasEntradas ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                eventoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>();
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoENs = eventoCEN.DameTodasEntradas (0, -1);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return eventoENs;
}






public void NuevoInmueblate_Evento_ModificarEvento (int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum p_categoria)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoCEN.ModificarEvento (p_oid, p_nombre, p_descripcion, p_fecha, p_categoria);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN NuevoInmueblate_Evento_DameEventoPorOID (int p_Evento_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN eventoEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                eventoEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN ();
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoEN = eventoCEN.DameEventoPorOID (p_Evento_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return eventoEN;
}






public int NuevoInmueblate_Inmueble_CrearInmueble (bool p_pendienteModeracion, string p_descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_tipo, int p_metrosCuadrados, bool p_alquiler, float p_precio, int p_geolocalizacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                returnValue = inmuebleCEN.CrearInmueble (p_pendienteModeracion, p_descripcion, p_tipo, p_metrosCuadrados, p_alquiler, p_precio, p_geolocalizacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Inmueble_ModificarInmueble (int p_oid, bool p_pendienteModeracion, string p_descripcion, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum p_tipo, int p_metrosCuadrados, bool p_alquiler, float p_precio)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleCEN.ModificarInmueble (p_oid, p_pendienteModeracion, p_descripcion, p_tipo, p_metrosCuadrados, p_alquiler, p_precio);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Inmueble_BorrarInmueble (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleCEN.BorrarInmueble (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Inmueble_AnyadirCaracteristica (int p_inmueble, System.Collections.Generic.IList<int> p_caracteristica)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleCEN.AnyadirCaracteristica (p_inmueble, p_caracteristica);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Inmueble_AnyadirInquilino (int p_inmueble, System.Collections.Generic.IList<int> p_usuario)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleCEN.AnyadirInquilino (p_inmueble, p_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Inmueble_AnyadirHabitacion (int p_inmueble, System.Collections.Generic.IList<int> p_habitacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleCEN.AnyadirHabitacion (p_inmueble, p_habitacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> NuevoInmueblate_Inmueble_DameTodosLosInmuebles ()
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebleENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmuebleENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleENs = inmuebleCEN.DameTodosLosInmuebles (0, -1);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmuebleENs;
}






public NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN NuevoInmueblate_Inmueble_DameInmueblePorOID (int p_Inmueble_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmuebleEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN ();
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleEN = inmuebleCEN.DameInmueblePorOID (p_Inmueble_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmuebleEN;
}






public int NuevoInmueblate_Fotografia_CrearFotografia (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);
                                returnValue = fotografiaCEN.CrearFotografia (p_galeria, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Fotografia_ModificarFotografia (int p_Fotografia_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);
                                fotografiaCEN.ModificarFotografia (p_Fotografia_OID, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Fotografia_BorrarFotografia (int p_Fotografia_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);
                                fotografiaCEN.BorrarFotografia (p_Fotografia_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN NuevoInmueblate_Fotografia_DameFotografiaPorOID (int p_Fotografia_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN fotografiaEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                fotografiaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN ();
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);
                                fotografiaEN = fotografiaCEN.DameFotografiaPorOID (p_Fotografia_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return fotografiaEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>
NuevoInmueblate_Fotografia_ObtenerFotografiasPorUsuario (int pe_usuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);

                                returnValueEN = fotografiaCEN.ObtenerFotografiasPorUsuario (pe_usuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN NuevoInmueblate_Fotografia_ObtenerFotoPerfil (int pe_usuario){
        NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);

                                returnValueEN = fotografiaCEN.ObtenerFotoPerfil (pe_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>
NuevoInmueblate_Fotografia_ObtenerFotosPorGaleria (int pe_galeria, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);

                                returnValueEN = fotografiaCEN.ObtenerFotosPorGaleria (pe_galeria, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_ElementoMultimedia_CrearElementoMultimedia (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);
                                returnValue = elementoMultimediaCEN.CrearElementoMultimedia (p_galeria, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_ElementoMultimedia_BorrarElementoMultimedia (int p_ElementoMultimedia_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);
                                elementoMultimediaCEN.BorrarElementoMultimedia (p_ElementoMultimedia_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN NuevoInmueblate_ElementoMultimedia_DameElementoMultimediaPorOID (int p_ElementoMultimedia_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN elementoMultimediaEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                elementoMultimediaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN ();
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);
                                elementoMultimediaEN = elementoMultimediaCEN.DameElementoMultimediaPorOID (p_ElementoMultimedia_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return elementoMultimediaEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>
NuevoInmueblate_ElementoMultimedia_ObtenerElementosMultimediaPorUsuario (int pe_usuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);

                                returnValueEN = elementoMultimediaCEN.ObtenerElementosMultimediaPorUsuario (pe_usuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Video_CrearVideo (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);
                                returnValue = videoCEN.CrearVideo (p_galeria, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Video_ModificarVideo (int p_Video_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);
                                videoCEN.ModificarVideo (p_Video_OID, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Video_BorrarVideo (int p_Video_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);
                                videoCEN.BorrarVideo (p_Video_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN NuevoInmueblate_Video_DameVideoPorOID (int p_Video_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN videoEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                videoEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN ();
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);
                                videoEN = videoCEN.DameVideoPorOID (p_Video_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return videoEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>
NuevoInmueblate_Video_ObtenerVideosPorUsuario (int pe_usuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);

                                returnValueEN = videoCEN.ObtenerVideosPorUsuario (pe_usuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>
NuevoInmueblate_Video_ObtenerVideosPorGaleria (int pe_galeria, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);

                                returnValueEN = videoCEN.ObtenerVideosPorGaleria (pe_galeria, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Galeria_CrearGaleria (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                returnValue = galeriaCEN.CrearGaleria (p_galeria, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Galeria_ModificarGaleria (int p_Galeria_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                galeriaCEN.ModificarGaleria (p_Galeria_OID, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Galeria_BorrarGaleria (int p_Galeria_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                galeriaCEN.BorrarGaleria (p_Galeria_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Galeria_AnyadirElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                galeriaCEN.AnyadirElementoMultimedia (p_Galeria_OID, p_elementosMultimedia_OIDs);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Galeria_BorrarElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                galeriaCEN.BorrarElementoMultimedia (p_Galeria_OID, p_elementosMultimedia_OIDs);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN NuevoInmueblate_Galeria_DameGaleriaPorOID (int p_Galeria_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeriaEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                galeriaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ();
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);
                                galeriaEN = galeriaCEN.DameGaleriaPorOID (p_Galeria_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return galeriaEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN>
NuevoInmueblate_Galeria_ObtenerGaleriasPorUsuario (int pe_usuario,int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);

                                returnValueEN = galeriaCEN.ObtenerGaleriasPorUsuario (pe_usuario,first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public
NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN NuevoInmueblate_Galeria_ObtenerGaleriaPerfil (int pe_usuario){
        NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN galeriaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGaleriaCAD _IgaleriaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgaleriaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GaleriaCAD (session);
                                galeriaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GaleriaCEN (_IgaleriaCAD);

                                returnValueEN = galeriaCEN.ObtenerGaleriaPerfil (pe_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}







public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> NuevoInmueblate_Usuario_DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> usuarioENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioENs = usuarioCEN.DameTodosLosUsuarios (first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return usuarioENs;
}






public NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN NuevoInmueblate_Usuario_DameUsuarioPorOID (int p_Usuario_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuarioEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioEN = usuarioCEN.DameUsuarioPorOID (p_Usuario_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return usuarioEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>
NuevoInmueblate_Usuario_ObtenerAmigosSP (int pe_usuario)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);

                                returnValueEN = usuarioCEN.ObtenerAmigosSP (pe_usuario);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>
NuevoInmueblate_Usuario_ObtenerAmigos (int pe_usuario, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);

                                returnValueEN = usuarioCEN.ObtenerAmigos (pe_usuario, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}





public void NuevoInmueblate_Usuario_BorrarUsuario (int p_Usuario_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioCEN.BorrarUsuario (p_Usuario_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Usuario_ModificarUsuario (int p_Usuario_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioCEN.ModificarUsuario (p_Usuario_OID, p_nombre, p_telefono, p_email, p_direccion, p_poblacion, p_codigoPostal, p_pais, p_password, p_valoracionMedia, p_apellidos, p_nif, p_fechaNacimiento, p_privacidad);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}



public int
NuevoInmueblate_Usuario_EnviarPeticionAmistad (int pe_emisor, int pe_receptor, string pe_asunto, string pe_cuerpo)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;

        int returnValueEN;


        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                returnValueEN = usuarioCEN.EnviarPeticionAmistad (pe_emisor, pe_receptor, pe_asunto, pe_cuerpo);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueEN;
}





public void NuevoInmueblate_Usuario_AnyadirElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioCEN.AnyadirElementosMultimedia (p_Usuario_OID, p_elementos_OIDs);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Usuario_BorrarElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioCEN.BorrarElementosMultimedia (p_Usuario_OID, p_elementos_OIDs);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>
NuevoInmueblate_Usuario_DameUsuariosFiltro (string p_nif, string p_email, string p_apellidos, Nullable<DateTime> p_fechaNacimiento, string p_direccion, string p_poblacion, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);

                                returnValueEN = usuarioCEN.DameUsuariosFiltro (p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}







public void NuevoInmueblate_Inmobiliaria_ModificarInmobilaria (int p_Inmobiliaria_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_descripcion, string p_cif)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaCEN.ModificarInmobilaria (p_Inmobiliaria_OID, p_nombre, p_telefono, p_email, p_direccion, p_poblacion, p_codigoPostal, p_pais, p_password, p_valoracionMedia, p_descripcion, p_cif);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Inmobiliaria_BorrarInmobiliaria (int p_Inmobiliaria_OID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaCEN.BorrarInmobiliaria (p_Inmobiliaria_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> NuevoInmueblate_Inmobiliaria_DameTodasLasInmobiliarias (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> inmobiliariaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN>();
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaENs = inmobiliariaCEN.DameTodasLasInmobiliarias (first, size);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmobiliariaENs;
}






public NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID (int p_Inmobiliaria_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliariaEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN ();
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaEN = inmobiliariaCEN.DameInmobiliariaPorOID (p_Inmobiliaria_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmobiliariaEN;
}





public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN>
NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro (string p_cif, string p_nombre, string p_descripcion, string p_email, string p_direccion, string p_poblacion, int first)
{
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> returnValueEN = null;



        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);

                                returnValueEN = inmobiliariaCEN.DameInmobiliariaFiltro (p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, first, 10);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValueEN;
}






public int NuevoInmueblate_Geolocalizacion_CrearGeolocalizacion (float p_longitud, float p_latitud, string p_direccion, string p_poblacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN geolocalizacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD _IgeolocalizacionCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgeolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD (session);
                                geolocalizacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN (_IgeolocalizacionCAD);
                                returnValue = geolocalizacionCEN.CrearGeolocalizacion (p_longitud, p_latitud, p_direccion, p_poblacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





public void NuevoInmueblate_Geolocalizacion_ModificarGeolocalizacion (int p_oid, float p_longitud, float p_latitud, string p_direccion, string p_poblacion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN geolocalizacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD _IgeolocalizacionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgeolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD (session);
                                geolocalizacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN (_IgeolocalizacionCAD);
                                geolocalizacionCEN.ModificarGeolocalizacion (p_oid, p_longitud, p_latitud, p_direccion, p_poblacion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public void NuevoInmueblate_Geolocalizacion_BorrarGeolocalizacion (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN geolocalizacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD _IgeolocalizacionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgeolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD (session);
                                geolocalizacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN (_IgeolocalizacionCAD);
                                geolocalizacionCEN.BorrarGeolocalizacion (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}




public NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID (int p_Geolocalizacion_OID)
{
        NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacionEN = null;


        NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN geolocalizacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD _IgeolocalizacionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                geolocalizacionEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN ();
                                _IgeolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD (session);
                                geolocalizacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN (_IgeolocalizacionCAD);
                                geolocalizacionEN = geolocalizacionCEN.DameGeolocalizacionPorOID (p_Geolocalizacion_OID);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return geolocalizacionEN;
}
}
}
