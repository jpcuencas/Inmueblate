using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;

namespace NuevoInmueblateCP.InmueblateCP
{
    public class MensajeCP : BasicCP
    {
        public MensajeCP() : base() { }

        public MensajeCP(ISession sessionAux) : base(sessionAux) { }

        public int CrearMensaje(bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_cuerpo, bool p_leido, int p_emisor, int p_receptor)
        {
            

            bool ok = false;
            int oid;

            try
            {
                SessionInitializeTransaction();
                SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN();
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                InmobiliariaCEN inmobiliariaCEN = new InmobiliariaCEN();
                MensajeCEN menCEN = new MensajeCEN();

                SuperUsuarioEN superUsuarioEmisor = superUsuarioCEN.get_ISuperUsuarioCAD().ReadOIDDefault(p_emisor);
                SuperUsuarioEN superUsuarioReceptor = superUsuarioCEN.get_ISuperUsuarioCAD().ReadOIDDefault(p_receptor);

                // comprobaci�n para conocer de qu� tipo es el SuperUsuari
                if (superUsuarioEmisor.GetType() == typeof(ModeradorEN))
                {
                    ok = true;
                }
                else
                {
                    if (superUsuarioEmisor.GetType() == typeof(UsuarioEN) && superUsuarioReceptor.GetType() == typeof(UsuarioEN))
                    {
                        UsuarioEN usuarioEmisor = usuarioCEN.DameUsuarioPorOID(p_emisor);
                        UsuarioEN usuarioReceptor = usuarioCEN.DameUsuarioPorOID(p_receptor);
                        if (usuarioEmisor.ListaAmigos != null && usuarioEmisor.ListaAmigos.Contains(usuarioReceptor) && usuarioReceptor.ListaBloqueados != null && !usuarioReceptor.ListaBloqueados.Contains(usuarioEmisor))
                        {
                            // TODO investigar si habr�a que hacer las comprobaciones desde el otro lado
                            ok = true;
                        }
                    }
                }

                if (superUsuarioEmisor.GetType() == typeof(UsuarioEN) && superUsuarioReceptor.GetType() == typeof(InmobiliariaEN))
                {
                    ok = true;
                }

                if (superUsuarioEmisor.GetType() == typeof(InmobiliariaEN) && superUsuarioReceptor.GetType() == typeof(UsuarioEN))
                {
                    InmobiliariaEN inmobiliariaEmisor = inmobiliariaCEN.get_IInmobiliariaCAD().ReadOIDDefault(p_emisor);
                    UsuarioEN usuarioReceptor = usuarioCEN.DameUsuarioPorOID(p_receptor);

                    foreach (MensajeEN mensaje in inmobiliariaEmisor.MensajesRecibidos)
                    {
                        if (mensaje.Emisor.Equals(superUsuarioReceptor))
                        { // TODO comprobar que esto es correcto
                            ok = true;
                        }
                    }
                }

                if (ok)
                {
                    MensajeEN mensajeEN = null;

                    //Initialized MensajeEN
                    mensajeEN = new MensajeEN();
                    mensajeEN.FechaEnvio = p_fechaEnvio;

                    mensajeEN.Asunto = p_asunto;

                    mensajeEN.Cuerpo = p_cuerpo;

                    mensajeEN.Leido = p_leido;



                    if (p_emisor != -1)
                    {
                        mensajeEN.Emisor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN();
                        mensajeEN.Emisor.Id = p_emisor;
                    }


                    if (p_receptor != -1)
                    {
                        mensajeEN.Receptor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN();
                        mensajeEN.Receptor.Id = p_receptor;
                    }

                    //Call to MensajeCAD

                    oid = menCEN.CrearMensaje(p_pendienteModeracion,
                                              mensajeEN.FechaEnvio,
                                              mensajeEN.Asunto,
                                              mensajeEN.Cuerpo,
                                              mensajeEN.Leido,
                                              mensajeEN.Emisor.Id,
                                              mensajeEN.Receptor.Id);
                }
                else
                {
                    oid = -1;
                }
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return oid;
            /*PROTECTED REGION END*/
        }
    }
}
