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
    public class PeticionAmistadCP : BasicCP
    {
        public PeticionAmistadCP() : base() { }

        public PeticionAmistadCP(ISession sessionAux) : base(sessionAux) { }

        public int AceptarPeticionAmistad(int pe_peticion)
        {
            /*Codigos de error                          */
            /* 0 --> No existe peticion                    */
            /* -1 --> Ya esta en mi lista de amigos     */
            /* -2 --> Ya esta en mi lista de bloqueados */
            /* 1 --> Petición aceptada                  */
            int ret = -1;
            UsuarioCP usuCP = new UsuarioCP();
            try
            {   SessionInitializeTransaction();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

                PeticionAmistadCEN petCEN = new PeticionAmistadCEN(new PeticionAmistadCAD(session));
                PeticionAmistadEN peticion = petCEN.get_IPeticionAmistadCAD().ReadOIDDefault(pe_peticion);
        
        
                PeticionAmistadEN petEN = petCEN.DamePeticionAmistadPorOID(pe_peticion);
                UsuarioEN emiEN = usuCEN.DameUsuarioPorOID (petEN.Emisor.Id);

                System.Collections.Generic.IList<UsuarioEN> l_amigos = usuCEN.ObtenerAmigos (petEN.Receptor.Id, 0, -1);
                System.Collections.Generic.IList<UsuarioEN> l_bloque = usuCEN.ObtenerBloqueadosSP (petEN.Receptor.Id);

                if (petEN == null) return 0;

                if (l_amigos.Contains (emiEN)) return -1;

                if (l_bloque.Contains (emiEN)) return -2;

                petCEN.AceptarPeticionAmistad(pe_peticion);

                usuCP.AgregarAmigo(petEN.Emisor.Id, petEN.Receptor.Id);

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
            return ret;
        }

        /**
         * Comprobar que los amigos existen
         **/
        public int RechazarPeticionAmistad(/*int pe_receptor,*/ int pe_peticion)
        {
            int ret = -1;
            try
            {
                SessionInitializeTransaction();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
                int i;
                bool esta = false;
                PeticionAmistadCEN petCEN = new PeticionAmistadCEN(new PeticionAmistadCAD(session));
                PeticionAmistadEN peticion = petCEN.get_IPeticionAmistadCAD().ReadOIDDefault(pe_peticion);

                esta = false;
                for (i = 0; (i < peticion.Receptor.PeticionesRecibidas.Count && !esta); i++)
                {
                    if (peticion.Receptor.PeticionesRecibidas[i].Equals(peticion.Emisor))
                    {
                        esta = true;
                    }
                }
                if (!esta)
                {
                    peticion.Receptor.PeticionesRecibidas.Remove(peticion);

                    petCEN.BorrarPeticionAmistad(pe_peticion);

                    ret = 0;
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
            return ret;
        }

        //bloquear amigo
        int BloquearAmigoListaAmigos(int id_usuario, int id_bloqueado)
        {
            int ret = -1;
            try
            {
                SessionInitializeTransaction();
                int i;
                bool esta = true;
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

                UsuarioEN usuario = usuCEN.DameUsuarioPorOID(id_usuario);
                UsuarioEN bloqueado = usuCEN.DameUsuarioPorOID(id_bloqueado);
                esta = false;

                for (i = 0; (i < usuario.ListaAmigos.Count && !esta); i++)
                {
                    if (usuario.ListaAmigos[i].Equals(bloqueado))
                    {
                        esta = true;
                    }
                }
                if (esta)
                {
                    usuario.ListaBloqueados.Add(bloqueado);
                    usuario.ListaAmigos.Remove(bloqueado);
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
            return ret;
        }
    }
}
