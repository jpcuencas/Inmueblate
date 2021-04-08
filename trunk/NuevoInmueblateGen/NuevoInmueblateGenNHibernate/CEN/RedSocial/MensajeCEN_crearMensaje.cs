
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
public partial class MensajeCEN
{
public int CrearMensaje (bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_cuerpo, bool p_leido, int p_emisor, int p_receptor)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Mensaje_crearMensaje_customized) ENABLED START*/

        bool ok = false;
        int oid;

        SuperUsuarioCAD superUsuarioCAD = new SuperUsuarioCAD ();
        SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN (superUsuarioCAD);

        UsuarioCEN usuarioCEN = new UsuarioCEN ();
        InmobiliariaCAD inmobiliariaCAD = new InmobiliariaCAD ();
        InmobiliariaCEN inmobiliariaCEN = new InmobiliariaCEN (inmobiliariaCAD);

        SuperUsuarioEN superUsuarioEmisor = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_emisor);
        SuperUsuarioEN superUsuarioReceptor = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_receptor);

        // comprobaci�n para conocer de qu� tipo es el SuperUsuario
        if (superUsuarioEmisor.GetType () == typeof(ModeradorEN)) {
                ok = true;
        }
        else{
                if (superUsuarioEmisor.GetType () == typeof(UsuarioEN) && superUsuarioReceptor.GetType () == typeof(UsuarioEN)) {
                        UsuarioEN usuarioEmisor = usuarioCEN.DameUsuarioPorOID (p_emisor);
                        UsuarioEN usuarioReceptor = usuarioCEN.DameUsuarioPorOID (p_receptor);
                        if (usuarioCEN.ObtenerAmigosSP (usuarioEmisor.Id).Contains (usuarioReceptor) &&
                            !usuarioCEN.ObtenerBloqueadosSP (usuarioReceptor.Id).Contains (usuarioEmisor)) {
                                // TODO investigar si habr�a que hacer las comprobaciones desde el otro lado
                                ok = true;
                        }
                }
        }
        if (superUsuarioEmisor.GetType () == typeof(UsuarioEN) && superUsuarioReceptor.GetType () == typeof(InmobiliariaEN)) {
                ok = true;
        }
        if (superUsuarioEmisor.GetType () == typeof(InmobiliariaEN) && superUsuarioReceptor.GetType () == typeof(UsuarioEN)) {
                InmobiliariaEN inmobiliariaEmisor = inmobiliariaCEN.get_IInmobiliariaCAD ().ReadOIDDefault (p_emisor);
                UsuarioEN usuarioReceptor = usuarioCEN.DameUsuarioPorOID (p_receptor);

                foreach (MensajeEN mensaje in inmobiliariaEmisor.MensajesRecibidos) {
                        if (mensaje.Emisor.Equals (superUsuarioReceptor)) { // TODO comprobar que esto es correcto
                                ok = true;
                        }
                }
        }

        if (ok) {
                MensajeEN mensajeEN = null;

                //Initialized MensajeEN
                mensajeEN = new MensajeEN ();
                mensajeEN.FechaEnvio = p_fechaEnvio;

                mensajeEN.Asunto = p_asunto;

                mensajeEN.Cuerpo = p_cuerpo;

                mensajeEN.Leido = p_leido;



                if (p_emisor != -1) {
                        mensajeEN.Emisor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                        mensajeEN.Emisor.Id = p_emisor;
                }


                if (p_receptor != -1) {
                        mensajeEN.Receptor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                        mensajeEN.Receptor.Id = p_receptor;
                }

                //Call to MensajeCAD

                oid = _IMensajeCAD.CrearMensaje (mensajeEN);
        }
        else{
                oid = -1;
        }

        return oid;
        /*PROTECTED REGION END*/
}
}
}
