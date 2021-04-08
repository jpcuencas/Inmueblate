using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using NHibernate;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF
{
[ServiceContract (Namespace = "http://Service/")]
[AspNetCompatibilityRequirements (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public partial class Service
{
/*PROTECTED REGION ID(NuevoInmueblateGen_NuevoInmueblateWCF_Other_Operations) ENABLED START*/
[OperationContract]
public string subirAnuncio (string base64String, int nombreFichero, string extensionFichero)
{
        string ruta = String.Empty;
        string retorno = String.Empty;

        byte[] imageBytes = Convert.FromBase64String (base64String);
        System.IO.MemoryStream ms = new System.IO.MemoryStream (imageBytes, 0,
                imageBytes.Length);

        // Convert byte[] to Image
        ms.Write (imageBytes, 0, imageBytes.Length);
        System.Drawing.Image image = System.Drawing.Image.FromStream (ms, true);

        ruta = AppDomain.CurrentDomain.RelativeSearchPath;
        // quito el /bin
        ruta = ruta.Substring (0, ruta.LastIndexOf ('\\'));

        retorno = "\\Anuncios";

        if (!System.IO.Directory.Exists (ruta + retorno)) {
                System.IO.Directory.CreateDirectory (ruta + retorno);
        }

        retorno += "\\" + nombreFichero + extensionFichero;

        image.Save (ruta + retorno);

        //quito el InmueblateGenWCF
        ruta = ruta.Substring(0, ruta.LastIndexOf('\\'));
        ruta = ruta.Substring(0, ruta.LastIndexOf('\\'));
        ruta += "\\NuevoInmueblateWeb\\InmueblateWeb\\img\\anuncios";
        image.Save(ruta + "\\" + nombreFichero + extensionFichero);

        retorno = retorno.Replace ("\\", "/");

        return retorno;
}
/*PROTECTED REGION END*/



[OperationContract]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum
NuevoInmueblate_Moderador_Anonimo_Login (int p_oid, string p_email, string p_pass)
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






[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO> NuevoInmueblate_Moderador_GetAllAnuncio ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.AnuncioCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.AnuncioCADNav (session);
                                listEn__ = cad.GetAllAnuncio_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.AnuncioAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> NuevoInmueblate_Moderador_GetAllEvento ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EventoCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EventoCADNav (session);
                                listEn__ = cad.GetAllEvento_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EventoAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> NuevoInmueblate_Moderador_GetAllMensaje ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MensajeCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MensajeCADNav (session);
                                listEn__ = cad.GetAllMensaje_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MensajeAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_Moderador_GetAllElementoMultimedia ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.ElementoMultimediaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.ElementoMultimediaCADNav (session);
                                listEn__ = cad.GetAllElementoMultimedia_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO> NuevoInmueblate_Moderador_GetAllInmobiliaria ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav (session);
                                listEn__ = cad.GetAllInmobiliaria_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmobiliariaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> NuevoInmueblate_Moderador_GetAllGrupo ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.GrupoCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.GrupoCADNav (session);
                                listEn__ = cad.GetAllGrupo_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GrupoAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> NuevoInmueblate_Moderador_GetAllPaginaCorporativa ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.PaginaCorporativaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.PaginaCorporativaCADNav (session);
                                listEn__ = cad.GetAllPaginaCorporativa_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PaginaCorporativaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> NuevoInmueblate_Moderador_GetAllUsuario ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                listEn__ = cad.GetAllUsuario_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> NuevoInmueblate_Moderador_GetAllInmueble ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmuebleCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmuebleCADNav (session);
                                listEn__ = cad.GetAllInmueble_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> NuevoInmueblate_Moderador_GetAllEntrada ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EntradaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EntradaCADNav (session);
                                listEn__ = cad.GetAllEntrada_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO> NuevoInmueblate_Moderador_GetAllSuperUsuario ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.SuperUsuarioCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.SuperUsuarioCADNav (session);
                                listEn__ = cad.GetAllSuperUsuario_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.SuperUsuarioAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}




[OperationContract]
public int NuevoInmueblate_Anuncio_CrearAnuncio (string p_imagen, string p_descripcion, Nullable<DateTime> p_fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum p_tipo, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);

                                returnValue = anuncioCEN.CrearAnuncio (p_imagen, p_descripcion, p_fechaCaducidad, p_tipo, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}



[OperationContract]

public void NuevoInmueblate_Anuncio_ModificarAnuncio (int p_oid, string p_imagen, string p_descripcion, Nullable<DateTime> p_fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum p_tipo, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);

                                anuncioCEN.ModificarAnuncio (p_oid, p_imagen, p_descripcion, p_fechaCaducidad, p_tipo, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public void NuevoInmueblate_Anuncio_BorrarAnuncio (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);

                                anuncioCEN.BorrarAnuncio (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO> NuevoInmueblate_Anuncio_DameTodosLosAnuncios (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO> anuncioDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> anuncioENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                anuncioDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO>();


                                anuncioENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN>();
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);
                                anuncioENs = anuncioCEN.DameTodosLosAnuncios (first, size);
                                if (anuncioENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN item in anuncioENs) {
                                                anuncioDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.AnuncioAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return anuncioDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO>
NuevoInmueblate_Anuncio_DameAnunciosFiltro (int p_tipo, Nullable<DateTime> p_fechaCaducidad, string p_url, string p_descripcion, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN anuncioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IAnuncioCAD _IanuncioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IanuncioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.AnuncioCAD (session);
                                anuncioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.AnuncioCEN (_IanuncioCAD);


                                returnValueEN = anuncioCEN.DameAnunciosFiltro (p_tipo, p_fechaCaducidad, p_url, p_descripcion, first, 3);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.AnuncioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.AnuncioAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}





[OperationContract]
public int NuevoInmueblate_Usuario_CrearUsuario (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);

                                returnValue = usuarioCEN.CrearUsuario (p_muro, p_nombre, p_telefono, p_email, p_direccion, p_poblacion, p_codigoPostal, p_pais, p_password, p_valoracionMedia, p_apellidos, p_nif, p_fechaNacimiento, p_privacidad);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}



[OperationContract]

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


[OperationContract]

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


[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO NuevoInmueblate_Usuario_DameUsuarioPorOID (int p_Usuario_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO usuarioDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuarioEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO ();

                                usuarioEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioEN = usuarioCEN.DameUsuarioPorOID (p_Usuario_OID);
                                usuarioDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (usuarioEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return usuarioDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> NuevoInmueblate_Usuario_DameTodosLosUsuarios ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> usuarioDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> usuarioENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>();


                                usuarioENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);
                                usuarioENs = usuarioCEN.DameTodosLosUsuarios (0, -1);
                                if (usuarioENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN item in usuarioENs) {
                                                usuarioDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return usuarioDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>
NuevoInmueblate_Usuario_DameUsuariosFiltro (string p_nif, string p_email, string p_apellidos, Nullable<DateTime> p_fechaNacimiento, string p_direccion, string p_poblacion, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);


                                returnValueEN = usuarioCEN.DameUsuariosFiltro (p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>
NuevoInmueblate_Usuario_ObtenerAmigos (int pe_usuario, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);


                                returnValueEN = usuarioCEN.ObtenerAmigos (pe_usuario, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>
NuevoInmueblate_Usuario_ObtenerBloqueados (int pe_usuario, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN usuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD _IusuarioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IusuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD (session);
                                usuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.UsuarioCEN (_IusuarioCAD);


                                returnValueEN = usuarioCEN.ObtenerBloqueados (pe_usuario, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.UsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.UsuarioAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}




[OperationContract]
public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO NuevoInmueblate_Usuario_GetMuroOfPropietarioUsuario (int id)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO dto = null;
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetMuroOfPropietarioUsuario_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MuroAdapter.Convert (en);
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> NuevoInmueblate_Usuario_GetAllInmueblesOfInquilinos (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetAllInmueblesOfInquilinos_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_Usuario_GetAllFotosOfFusuario (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetAllFotosOfFusuario_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PreferenciasBusquedaDTO NuevoInmueblate_Usuario_GetPreferenciasBusquedaOfUsuario (int id)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PreferenciasBusquedaDTO dto = null;
        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetPreferenciasBusquedaOfUsuario_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PreferenciasBusquedaAdapter.Convert (en);
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GustosDTO NuevoInmueblate_Usuario_GetGustosOfUsuario (int id)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GustosDTO dto = null;
        NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetGustosOfUsuario_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GustosAdapter.Convert (en);
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_Usuario_GetAllElementosOfUsuario (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav usuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                usuarioCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.UsuarioCADNav (session);
                                en = usuarioCAD.GetAllElementosOfUsuario_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> NuevoInmueblate_Usuario_GetAllEntradaUsuario ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EntradaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.EntradaCADNav (session);
                                listEn__ = cad.GetAllEntradaUsuario_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> NuevoInmueblate_Usuario_GetAllMensajeUsuario ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MensajeCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MensajeCADNav (session);
                                listEn__ = cad.GetAllMensajeUsuario_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MensajeAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}




[OperationContract]
public int NuevoInmueblate_Grupo_CrearGrupo (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum p_tipo, string p_nombre, string p_descripcion, int p_muro)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);

                                returnValue = grupoCEN.CrearGrupo (p_tipo, p_nombre, p_descripcion, p_muro);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}



[OperationContract]

public void NuevoInmueblate_Grupo_ModificarGrupo (int p_oid, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum p_tipo, string p_nombre, string p_descripcion)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);

                                grupoCEN.ModificarGrupo (p_oid, p_tipo, p_nombre, p_descripcion);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public void NuevoInmueblate_Grupo_BorrarGrupo (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);

                                grupoCEN.BorrarGrupo (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> NuevoInmueblate_Grupo_DameTodosLosGrupos ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> grupoDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> grupoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                grupoDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>();


                                grupoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN>();
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);
                                grupoENs = grupoCEN.DameTodosLosGrupos (0, -1);
                                if (grupoENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN item in grupoENs) {
                                                grupoDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GrupoAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return grupoDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>
NuevoInmueblate_Grupo_ObtenerGruposConEntradasReportadas ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);


                                returnValueEN = grupoCEN.ObtenerGruposConEntradasReportadas ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GrupoAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>
NuevoInmueblate_Grupo_DameGruposFiltro (int p_tipo, string p_nombre, string p_descripcion, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN grupoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD _IgrupoCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IgrupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD (session);
                                grupoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GrupoCEN (_IgrupoCAD);


                                returnValueEN = grupoCEN.DameGruposFiltro (p_tipo, p_nombre, p_descripcion, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GrupoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GrupoAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}




[OperationContract]
public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO NuevoInmueblate_Grupo_GetMuroOfPropietarioGrupo (int id)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO dto = null;
        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.GrupoCADNav grupoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                grupoCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.GrupoCADNav (session);
                                en = grupoCAD.GetMuroOfPropietarioGrupo_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MuroAdapter.Convert (en);
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}





[OperationContract]
public int NuevoInmueblate_Inmobiliaria_CrearInmobiliaria (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_descripcion, string p_cif)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);

                                returnValue = inmobiliariaCEN.CrearInmobiliaria (p_muro, p_nombre, p_telefono, p_email, p_direccion, p_poblacion, p_codigoPostal, p_pais, p_password, p_valoracionMedia, p_descripcion, p_cif);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}



[OperationContract]

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


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO> NuevoInmueblate_Inmobiliaria_DameTodasInmobiliarias ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO> inmobiliariaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> inmobiliariaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO>();


                                inmobiliariaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN>();
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaENs = inmobiliariaCEN.DameTodasLasInmobiliarias (0, -1);
                                if (inmobiliariaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN item in inmobiliariaENs) {
                                                inmobiliariaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmobiliariaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmobiliariaDTOs;
}




[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID (int p_Inmobiliaria_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO inmobiliariaDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN inmobiliariaEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO ();

                                inmobiliariaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN ();
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);
                                inmobiliariaEN = inmobiliariaCEN.DameInmobiliariaPorOID (p_Inmobiliaria_OID);
                                inmobiliariaDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmobiliariaAdapter.Convert (inmobiliariaEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmobiliariaDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO>
NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro (string p_cif, string p_nombre, string p_descripcion, string p_email, string p_direccion, string p_poblacion, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN inmobiliariaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmobiliariaCAD _IinmobiliariaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmobiliariaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmobiliariaCAD (session);
                                inmobiliariaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmobiliariaCEN (_IinmobiliariaCAD);


                                returnValueEN = inmobiliariaCEN.DameInmobiliariaFiltro (p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmobiliariaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmobiliariaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> NuevoInmueblate_Inmobiliaria_GetAllPaginaCorporativaOfInmobiliaria (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav inmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav (session);
                                en = inmobiliariaCAD.GetAllPaginaCorporativaOfInmobiliaria_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PaginaCorporativaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> NuevoInmueblate_Inmobiliaria_GetAllEventosOfInmobiliaria (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav inmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav (session);
                                en = inmobiliariaCAD.GetAllEventosOfInmobiliaria_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EventoAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> NuevoInmueblate_Inmobiliaria_GetAllInmueblesOfInmobiliaria (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav inmobiliariaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmobiliariaCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmobiliariaCADNav (session);
                                en = inmobiliariaCAD.GetAllInmueblesOfInmobiliaria_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}





[OperationContract]
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



[OperationContract]

public void NuevoInmueblate_Mensaje_ModificarMensaje (int p_oid, bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_cuerpo, bool p_leido)
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

                                mensajeCEN.ModificarMensaje (p_oid, p_pendienteModeracion, p_fechaEnvio, p_asunto, p_cuerpo, p_leido);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>
NuevoInmueblate_Mensaje_ObtenerMensajePendienteModeracion ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);


                                returnValueEN = mensajeCEN.ObtenerMensajePendienteModeracion ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MensajeAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> NuevoInmueblate_Mensaje_DameTodosLosMensajes ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> mensajeDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensajeENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                mensajeDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>();


                                mensajeENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN>();
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);
                                mensajeENs = mensajeCEN.DameTodosLosMensajes (0, -1);
                                if (mensajeENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN item in mensajeENs) {
                                                mensajeDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MensajeAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return mensajeDTOs;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>
NuevoInmueblate_Mensaje_DameMensajeFiltro (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_filtrarPendienteModeracion, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN mensajeCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMensajeCAD _ImensajeCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _ImensajeCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MensajeCAD (session);
                                mensajeCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MensajeCEN (_ImensajeCAD);

                                returnValueEN = mensajeCEN.DameMensajeFiltro (p_asunto, p_cuerpo, p_fechaEnvio, p_filtrarPendienteModeracion, p_pendienteModeracion, p_emisor, p_receptor, first, size);

                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MensajeDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN item in
                                                 returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MensajeAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]
public int NuevoInmueblate_Mensaje_CrearMensajeDeModerador (int p_emisor, int p_receptor, bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_mensaje, bool p_leido)
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

                                returnValue = mensajeCEN.CrearMensajeDeModerador (p_emisor, p_receptor, p_pendienteModeracion, p_fechaEnvio, p_asunto, p_mensaje, p_leido);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}





[OperationContract]
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



[OperationContract]

public void NuevoInmueblate_ElementoMultimedia_ModificarElementoMultimedia (int p_ElementoMultimedia_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
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

                                elementoMultimediaCEN.ModificarElementoMultimedia (p_ElementoMultimedia_OID, p_fecha, p_descripcion, p_nombre, p_pendienteModeracion, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>
NuevoInmueblate_ElementoMultimedia_ObtenerElementoPendienteModeracion ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);


                                returnValueEN = elementoMultimediaCEN.ObtenerElementoPendienteModeracion ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimedia ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> elementoMultimediaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementoMultimediaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                elementoMultimediaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();


                                elementoMultimediaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);
                                elementoMultimediaENs = elementoMultimediaCEN.DameTodosLosElementosMultimedia (0, -1);
                                if (elementoMultimediaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in elementoMultimediaENs) {
                                                elementoMultimediaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return elementoMultimediaDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP (int first, int size)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> elementoMultimediaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementoMultimediaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN elementoMultimediaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IElementoMultimediaCAD _IelementoMultimediaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                elementoMultimediaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();


                                elementoMultimediaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
                                _IelementoMultimediaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.ElementoMultimediaCAD (session);
                                elementoMultimediaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.ElementoMultimediaCEN (_IelementoMultimediaCAD);
                                elementoMultimediaENs = elementoMultimediaCEN.DameTodosElementosMultimediaP (first, size);
                                if (elementoMultimediaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in elementoMultimediaENs) {
                                                elementoMultimediaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return elementoMultimediaDTOs;
}





[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO> NuevoInmueblate_ElementoMultimedia_GetAllFotografia ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.FotografiaCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.FotografiaCADNav (session);
                                listEn__ = cad.GetAllFotografia_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.FotografiaAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}



[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO> NuevoInmueblate_ElementoMultimedia_GetAllVideo ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO> listDto__ = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> listEn__ = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.VideoCADNav cad = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                cad = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.VideoCADNav (session);
                                listEn__ = cad.GetAllVideo_NuevoInmueblate ();
                                if (listEn__ != null) {
                                        listDto__ = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN self in listEn__) {
                                                listDto__.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.VideoAdapter.Convert (self));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return listDto__;
}




[OperationContract]
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



[OperationContract]

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


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>
NuevoInmueblate_Inmueble_ObtenerInmueblePendienteModeracion ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);


                                returnValueEN = inmuebleCEN.ObtenerInmueblePendienteModeracion ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> NuevoInmueblate_Inmueble_DameTodosLosInmuebles ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> inmuebleDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> inmuebleENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmuebleDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();


                                inmuebleENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleENs = inmuebleCEN.DameTodosLosInmuebles (0, -1);
                                if (inmuebleENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN item in inmuebleENs) {
                                                inmuebleDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmuebleDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>
NuevoInmueblate_Inmueble_DameInmuebleFiltro (int p_inmobiliaria, string p_descripcion, int p_tipo, int p_metrosCuadrados, int p_precio, string p_direccion, string p_poblacion, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);


                                returnValueEN = inmuebleCEN.DameInmuebleFiltro (p_inmobiliaria, p_descripcion, p_tipo, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO NuevoInmueblate_Inmueble_DameInmueblePorOID (int p_Inmueble_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO inmuebleDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmuebleEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN inmuebleCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD _IinmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmuebleDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.InmuebleDTO ();

                                inmuebleEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN ();
                                _IinmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD (session);
                                inmuebleCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.InmuebleCEN (_IinmuebleCAD);
                                inmuebleEN = inmuebleCEN.DameInmueblePorOID (p_Inmueble_OID);
                                inmuebleDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.InmuebleAdapter.Convert (inmuebleEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return inmuebleDTO;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> NuevoInmueblate_Inmueble_GetAllElementosMultimediaOfInmueble (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmuebleCADNav inmuebleCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                inmuebleCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.InmuebleCADNav (session);
                                en = inmuebleCAD.GetAllElementosMultimediaOfInmueble_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.ElementoMultimediaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}





[OperationContract]
public int NuevoInmueblate_PaginaCorporativa_CrearPaginaCorporativa (string p_contenido, string p_URL, int p_inmobiliaria)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN paginaCorporativaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPaginaCorporativaCAD _IpaginaCorporativaCAD = null;
        int returnValue = -1;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpaginaCorporativaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PaginaCorporativaCAD (session);
                                paginaCorporativaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN (_IpaginaCorporativaCAD);

                                returnValue = paginaCorporativaCEN.CrearPaginaCorporativa (p_contenido, p_URL, p_inmobiliaria);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return returnValue;
}



[OperationContract]

public void NuevoInmueblate_PaginaCorporativa_ModificarPaginaCorporativa (int p_oid, string p_contenido, string p_URL)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN paginaCorporativaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPaginaCorporativaCAD _IpaginaCorporativaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpaginaCorporativaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PaginaCorporativaCAD (session);
                                paginaCorporativaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN (_IpaginaCorporativaCAD);

                                paginaCorporativaCEN.ModificarPaginaCorporativa (p_oid, p_contenido, p_URL);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public void NuevoInmueblate_PaginaCorporativa_BorrarPaginaCorporativa (int p_oid)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN paginaCorporativaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPaginaCorporativaCAD _IpaginaCorporativaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IpaginaCorporativaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PaginaCorporativaCAD (session);
                                paginaCorporativaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN (_IpaginaCorporativaCAD);

                                paginaCorporativaCEN.BorrarPaginaCorporativa (p_oid);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }
}


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> NuevoInmueblate_PaginaCorporativa_DameTodasLasPaginas ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO> paginaCorporativaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN> paginaCorporativaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN paginaCorporativaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPaginaCorporativaCAD _IpaginaCorporativaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                paginaCorporativaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO>();


                                paginaCorporativaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN>();
                                _IpaginaCorporativaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PaginaCorporativaCAD (session);
                                paginaCorporativaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN (_IpaginaCorporativaCAD);
                                paginaCorporativaENs = paginaCorporativaCEN.DameTodasLasPaginas (0, -1);
                                if (paginaCorporativaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN item in paginaCorporativaENs) {
                                                paginaCorporativaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PaginaCorporativaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return paginaCorporativaDTOs;
}




[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO NuevoInmueblate_PaginaCorporativa_DamePaginaCorporativaPorOID (int p_PaginaCorporativa_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO paginaCorporativaDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN paginaCorporativaEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN paginaCorporativaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPaginaCorporativaCAD _IpaginaCorporativaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                paginaCorporativaDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PaginaCorporativaDTO ();

                                paginaCorporativaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN ();
                                _IpaginaCorporativaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PaginaCorporativaCAD (session);
                                paginaCorporativaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PaginaCorporativaCEN (_IpaginaCorporativaCAD);
                                paginaCorporativaEN = paginaCorporativaCEN.DamePaginaCorporativaPorOID (p_PaginaCorporativa_OID);
                                paginaCorporativaDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PaginaCorporativaAdapter.Convert (paginaCorporativaEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return paginaCorporativaDTO;
}





[OperationContract]
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



[OperationContract]

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


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> NuevoInmueblate_Evento_DameTodosLosEventos ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> eventoDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> eventoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                eventoDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO>();


                                eventoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>();
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);
                                eventoENs = eventoCEN.DameTodosLosEventos (0, -1);
                                if (eventoENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN item in eventoENs) {
                                                eventoDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EventoAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return eventoDTOs;
}




[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO>
NuevoInmueblate_Evento_DameEventosFiltro (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, int p_categoria, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN eventoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEventoCAD _IeventoCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IeventoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EventoCAD (session);
                                eventoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EventoCEN (_IeventoCAD);


                                returnValueEN = eventoCEN.DameEventosFiltro (p_nombre, p_descripcion, p_fecha, p_categoria, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EventoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EventoAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}





[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO NuevoInmueblate_Muro_DameMuroPorOID (int p_Muro_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO muroDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN muroEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN muroCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD _ImuroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                muroDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.MuroDTO ();

                                muroEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                                _ImuroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD (session);
                                muroCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.MuroCEN (_ImuroCAD);
                                muroEN = muroCEN.DameMuroPorOID (p_Muro_OID);
                                muroDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.MuroAdapter.Convert (muroEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return muroDTO;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> NuevoInmueblate_Muro_GetAllEntradasOfMuro (int id)
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> dto = null;
        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MuroCADNav muroCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                muroCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.MuroCADNav (session);
                                en = muroCAD.GetAllEntradasOfMuro_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in en) {
                                                dto.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}





[OperationContract]
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



[OperationContract]

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


[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_ObtenerEntradasPorModerar (string p_filter)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);


                                returnValueEN = entradaCEN.ObtenerEntradasPorModerar (p_filter);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_ObtenerEntradasPendientesPorGrupo (int pe_ID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);


                                returnValueEN = entradaCEN.ObtenerEntradasPendientesPorGrupo (pe_ID);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_ObtenerEntradasPendientesPorUsuario (int pe_ID)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);


                                returnValueEN = entradaCEN.ObtenerEntradasPendientesPorUsuario (pe_ID);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> NuevoInmueblate_Entrada_DameTodasLasEntradas ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> entradaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                entradaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();


                                entradaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);
                                entradaENs = entradaCEN.DameTodasLasEntradas (0, -1);
                                if (entradaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in entradaENs) {
                                                entradaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return entradaDTOs;
}




[OperationContract]
public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_DameEntradasFiltro (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, bool p_filtrarPendienteModeracion, bool p_pendienteModeracion, int p_usuario, int first, int size)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);

                                returnValueEN = entradaCEN.DameEntradasFiltro (p_titulo, p_cuerpo, p_fechaPublicacion, p_filtrarPendienteModeracion, p_pendienteModeracion, p_usuario, first, size);

                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in
                                                 returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_DameEntradasPorMuro (int p_muro, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);


                                returnValueEN = entradaCEN.DameEntradasPorMuro (p_muro, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>
NuevoInmueblate_Entrada_ObtenerEntradasPorMuro (int p_muro, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN entradaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD _IentradaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IentradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD (session);
                                entradaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.EntradaCEN (_IentradaCAD);


                                returnValueEN = entradaCEN.ObtenerEntradasPorMuro (p_muro, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.EntradaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.EntradaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}





[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO>
NuevoInmueblate_Fotografia_ObtenerTodasFotografiasPorModerar ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);


                                returnValueEN = fotografiaCEN.ObtenerTodasFotografiasPorModerar ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.FotografiaAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO> NuevoInmueblate_Fotografia_DameTodasLasFotografias ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO> fotografiaDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> fotografiaENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN fotografiaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IFotografiaCAD _IfotografiaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                fotografiaDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.FotografiaDTO>();


                                fotografiaENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN>();
                                _IfotografiaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.FotografiaCAD (session);
                                fotografiaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.FotografiaCEN (_IfotografiaCAD);
                                fotografiaENs = fotografiaCEN.DameTodasLasFotografias (0, -1);
                                if (fotografiaENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN item in fotografiaENs) {
                                                fotografiaDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.FotografiaAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return fotografiaDTOs;
}






[OperationContract]

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


[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO>
NuevoInmueblate_Video_ObtenerTodosVideosPorModerar ()
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);


                                returnValueEN = videoCEN.ObtenerTodosVideosPorModerar ();



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.VideoAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO> NuevoInmueblate_Video_DameTodosLosVideos ()
{
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO> videoDTOs = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> videoENs = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN videoCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IVideoCAD _IvideoCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                videoDTOs = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.VideoDTO>();


                                videoENs = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN>();
                                _IvideoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.VideoCAD (session);
                                videoCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.VideoCEN (_IvideoCAD);
                                videoENs = videoCEN.DameTodosLosVideos (0, -1);
                                if (videoENs != null) {
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN item in videoENs) {
                                                videoDTOs.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.VideoAdapter.Convert (item));
                                        }
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return videoDTOs;
}






[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PreferenciasBusquedaDTO NuevoInmueblate_PreferenciasBusqueda_DamePreferenciasBusquedaPorOID (int p_PreferenciasBusqueda_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PreferenciasBusquedaDTO preferenciasBusquedaDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN preferenciasBusquedaEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN preferenciasBusquedaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD _IpreferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                preferenciasBusquedaDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.PreferenciasBusquedaDTO ();

                                preferenciasBusquedaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN ();
                                _IpreferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD (session);
                                preferenciasBusquedaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.PreferenciasBusquedaCEN (_IpreferenciasBusquedaCAD);
                                preferenciasBusquedaEN = preferenciasBusquedaCEN.DamePreferenciasBusquedaPorOID (p_PreferenciasBusqueda_OID);
                                preferenciasBusquedaDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.PreferenciasBusquedaAdapter.Convert (preferenciasBusquedaEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return preferenciasBusquedaDTO;
}




[OperationContract]
public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GeolocalizacionDTO NuevoInmueblate_PreferenciasBusqueda_GetGeolocalizacionOfPreferenciasBusqueda (int id)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GeolocalizacionDTO dto = null;
        NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN en = null;
        NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.PreferenciasBusquedaCADNav preferenciasBusquedaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                preferenciasBusquedaCAD = new NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial.PreferenciasBusquedaCADNav (session);
                                en = preferenciasBusquedaCAD.GetGeolocalizacionOfPreferenciasBusqueda_NuevoInmueblate (id);
                                if (en != null) {
                                        dto = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GeolocalizacionAdapter.Convert (en);
                                }
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return dto;
}





[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GeolocalizacionDTO NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID (int p_Geolocalizacion_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GeolocalizacionDTO geolocalizacionDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN geolocalizacionEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN geolocalizacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGeolocalizacionCAD _IgeolocalizacionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                geolocalizacionDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GeolocalizacionDTO ();

                                geolocalizacionEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GeolocalizacionEN ();
                                _IgeolocalizacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GeolocalizacionCAD (session);
                                geolocalizacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GeolocalizacionCEN (_IgeolocalizacionCAD);
                                geolocalizacionEN = geolocalizacionCEN.DameGeolocalizacionPorOID (p_Geolocalizacion_OID);
                                geolocalizacionDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GeolocalizacionAdapter.Convert (geolocalizacionEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return geolocalizacionDTO;
}





[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GustosDTO NuevoInmueblate_Gustos_DameGustosPorOID (int p_Gustos_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GustosDTO gustosDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN gustosEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN gustosCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IGustosCAD _IgustosCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                gustosDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.GustosDTO ();

                                gustosEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN ();
                                _IgustosCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GustosCAD (session);
                                gustosCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.GustosCEN (_IgustosCAD);
                                gustosEN = gustosCEN.DameGustosPorOID (p_Gustos_OID);
                                gustosDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.GustosAdapter.Convert (gustosEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return gustosDTO;
}





[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO NuevoInmueblate_SuperUsuario_DameSuperUsuarioPorOID (int p_SuperUsuario_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO superUsuarioDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN superUsuarioEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                superUsuarioDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO ();

                                superUsuarioEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);
                                superUsuarioEN = superUsuarioCEN.DameSuperUsuarioPorOID (p_SuperUsuario_OID);
                                superUsuarioDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.SuperUsuarioAdapter.Convert (superUsuarioEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return superUsuarioDTO;
}



[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO>
NuevoInmueblate_SuperUsuario_DameSuperUsuariosGrupo (int p_grupo, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN superUsuarioCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD _IsuperUsuarioCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IsuperUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD (session);
                                superUsuarioCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.SuperUsuarioCEN (_IsuperUsuarioCAD);


                                returnValueEN = superUsuarioCEN.DameSuperUsuariosGrupo (p_grupo, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.SuperUsuarioAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}





[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.CaracteristicaDTO NuevoInmueblate_Caracteristica_DameCaracteristicaPorOID (int p_Caracteristica_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.CaracteristicaDTO caracteristicaDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN caracteristicaEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.CaracteristicaCEN caracteristicaCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.ICaracteristicaCAD _IcaracteristicaCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                caracteristicaDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.CaracteristicaDTO ();

                                caracteristicaEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN ();
                                _IcaracteristicaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.CaracteristicaCAD (session);
                                caracteristicaCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.CaracteristicaCEN (_IcaracteristicaCAD);
                                caracteristicaEN = caracteristicaCEN.DameCaracteristicaPorOID (p_Caracteristica_OID);
                                caracteristicaDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.CaracteristicaAdapter.Convert (caracteristicaEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return caracteristicaDTO;
}





[OperationContract]

public System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO>
NuevoInmueblate_Habitacion_DameHabitacionFiltro (string p_descripcion, int p_metrosCuadrados, string p_direccion, string p_poblacion, int p_inmueble, int first)
{
        NuevoInmueblateGenNHibernate.CEN.RedSocial.HabitacionCEN habitacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IHabitacionCAD _IhabitacionCAD = null;

        System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> returnValueEN = null;
        System.Collections.Generic.IList<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO> returnValueDTO = null;

        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                _IhabitacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.HabitacionCAD (session);
                                habitacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.HabitacionCEN (_IhabitacionCAD);


                                returnValueEN = habitacionCEN.DameHabitacionFiltro (p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, first, 10);



                                if (returnValueEN != null) {
                                        returnValueDTO = new System.Collections.Generic.List<NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO>();
                                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN item in returnValueEN) {
                                                returnValueDTO.Add (NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.HabitacionAdapter.Convert (item));
                                        }
                                }

                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }


        return returnValueDTO;
}



[OperationContract]

public NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO NuevoInmueblate_Habitacion_DameHabitacionPorOID (int p_Habitacion_OID)
{
        NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO habitacionDTO = null;

        NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN habitacionEN = null;

        NuevoInmueblateGenNHibernate.CEN.RedSocial.HabitacionCEN habitacionCEN = null;
        NuevoInmueblateGenNHibernate.CAD.RedSocial.IHabitacionCAD _IhabitacionCAD = null;
        try
        {
                using (ISession session = NHibernateHelper.OpenSession ())
                        using (ITransaction tx = session.BeginTransaction ())
                        {
                                habitacionDTO = new NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.HabitacionDTO ();

                                habitacionEN = new NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN ();
                                _IhabitacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.HabitacionCAD (session);
                                habitacionCEN = new NuevoInmueblateGenNHibernate.CEN.RedSocial.HabitacionCEN (_IhabitacionCAD);
                                habitacionEN = habitacionCEN.DameHabitacionPorOID (p_Habitacion_OID);
                                habitacionDTO = NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial.HabitacionAdapter.Convert (habitacionEN);
                                tx.Commit ();
                        }
        }

        catch (Exception ex)
        {
                throw ex;
        }

        return habitacionDTO;
}
}
}
