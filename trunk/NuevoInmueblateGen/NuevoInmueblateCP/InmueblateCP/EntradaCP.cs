using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;
using System.Threading;

namespace NuevoInmueblateCP.InmueblateCP
{
    /**
     * falta probar 
     **/
    public class EntradaCP : BasicCP
    {
        public EntradaCP() : base() { }

        public EntradaCP(ISession sessionAux) : base(sessionAux) { }

        //recursos estaticos
       static List<EntradaEN> entradas = new List<EntradaEN>();
       static int id_usuario = 0;

        //semaforo concurrente
       private static Mutex mut = new Mutex();

        public static void entradasGrupos()
        {
            try
            {
                IList<EntradaEN> entradas1 = new List<EntradaEN>();

                EntradaCAD entradaCAD = new EntradaCAD();
                EntradaCEN entradaCEN = new EntradaCEN(entradaCAD);

                UsuarioCAD usuarioCAD = new UsuarioCAD();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                MuroCAD muroCAD = new MuroCAD();
                MuroCEN muroCEN = new MuroCEN(muroCAD);

                SuperUsuarioCAD superuserCAD = new SuperUsuarioCAD();
                SuperUsuarioCEN superuserCEN = new SuperUsuarioCEN(superuserCAD);

                MuroEN muro = new MuroEN();
                IList<SuperUsuarioEN> grupos = superuserCEN.ObtenerGruposPorUsuarioNP(id_usuario);
                foreach (SuperUsuarioEN am in grupos)
                {
                    muro = muroCEN.ObtenerMuroPorGrupo(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id,0,-1);  //falta paginar
                    // Wait until it is safe to enter.
                    mut.WaitOne(); 
                    entradas = entradas.Concat(entradas1).ToList();
                    if (entradas.Count >= 5)
                    {
                        // Release the Mutex.
                        mut.ReleaseMutex();
                        break;
                    }
                    // Release the Mutex.
                    mut.ReleaseMutex();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public static void entradasAmigos()
        {
            try
            {
               IList<EntradaEN> entradas1 = new List<EntradaEN>();

               EntradaCAD entradaCAD = new EntradaCAD();
               EntradaCEN entradaCEN = new EntradaCEN(entradaCAD);

                UsuarioCAD usuarioCAD = new UsuarioCAD();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                MuroCAD muroCAD = new MuroCAD();
                MuroCEN muroCEN = new MuroCEN(muroCAD);

                MuroEN muro = new MuroEN();
                IList<UsuarioEN> amigos = usuarioCEN.ObtenerAmigosSP(id_usuario);

                muro = muroCEN.ObtenerMuroPorUsuario(id_usuario);

                entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id,0,-1);
                entradas = entradas.Concat(entradas1).ToList();
                foreach (UsuarioEN am in amigos)
                {
                    muro = muroCEN.ObtenerMuroPorUsuario(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id,0,-1);

                    // Wait until it is safe to enter.
                    mut.WaitOne(); 
                    entradas = entradas.Concat(entradas1).ToList();
                    if (entradas.Count >= 5)
                    {
                        // Release the Mutex.
                        mut.ReleaseMutex();
                        break;
                    }
                    // Release the Mutex.
                    mut.ReleaseMutex();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public List<EntradaEN> ultimas5Entradas(int pe_usuario)
        {
            try
            {
                SessionInitializeTransaction();
            
                IList<EntradaEN> entradas1 = new List<EntradaEN>();
                EntradaCAD entradaCAD = new EntradaCAD();
                EntradaCEN entradaCEN = new EntradaCEN(entradaCAD);
            
                //UsuarioCAD usuarioCAD = new UsuarioCAD();
                //UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                MuroCAD muroCAD = new MuroCAD();
                MuroCEN muroCEN = new MuroCEN(muroCAD);
               // SuperUsuarioCAD superuserCAD = new SuperUsuarioCAD();
               // SuperUsuarioCEN superuserCEN = new SuperUsuarioCEN(superuserCAD);
              
                MuroEN muro = new MuroEN();

                id_usuario = pe_usuario;
                Thread t1 = new Thread(entradasAmigos);
                t1.Start();
                Thread t2 = new Thread(entradasGrupos);
                t2.Start();

                muro = muroCEN.ObtenerMuroPorUsuario(pe_usuario);

                entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id,0,-1);

                // Wait until it is safe to enter.
                mut.WaitOne();
                entradas = entradas.Concat(entradas1).ToList();
                // Release the Mutex.
                mut.ReleaseMutex();

                /*
                IList<UsuarioEN> amigos = usuarioCEN.ObtenerAmigos(pe_usuario);
                foreach (UsuarioEN am in amigos)
                {
                    muro = muroCEN.ObtenerMuroPorUsuario(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id);
                    entradas.Concat(entradas1);
                }

                IList<GrupoEN> grupos = superuserCEN.ObtenerGruposPorUsuario(pe_usuario);
                foreach (GrupoEN am in grupos)
                {
                    muro = muroCEN.ObtenerMuroPorGrupo(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id);  //falta paginar
                    entradas.Concat(entradas1);
                }
                 */

                entradas.OrderBy(e => e.FechaPublicacion);
                entradas = entradas.Distinct().ToList();
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

            return entradas;
        }
        public List<EntradaEN> ultimas5Entradas1(int pe_usuario)
        {
            try
            {
                SessionInitializeTransaction();

                IList<EntradaEN> entradas1 = new List<EntradaEN>();
                EntradaCAD entradaCAD = new EntradaCAD();
                EntradaCEN entradaCEN = new EntradaCEN(entradaCAD);

                //UsuarioCAD usuarioCAD = new UsuarioCAD();
                //UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);
                MuroCAD muroCAD = new MuroCAD();
                MuroCEN muroCEN = new MuroCEN(muroCAD);
                // SuperUsuarioCAD superuserCAD = new SuperUsuarioCAD();
                // SuperUsuarioCEN superuserCEN = new SuperUsuarioCEN(superuserCAD);

                MuroEN muro = new MuroEN();

                id_usuario = pe_usuario;
               // Thread t1 = new Thread(entradasAmigos);
                //t1.Start();
                //Thread t2 = new Thread(entradasGrupos);
                ///t2.Start();

                muro = muroCEN.ObtenerMuroPorUsuario(pe_usuario);

                entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id, 0, -1);

                // Wait until it is safe to enter.
                mut.WaitOne();
                entradas = entradas.Concat(entradas1).ToList();
                // Release the Mutex.
                mut.ReleaseMutex();

                /*
                IList<UsuarioEN> amigos = usuarioCEN.ObtenerAmigos(pe_usuario);
                foreach (UsuarioEN am in amigos)
                {
                    muro = muroCEN.ObtenerMuroPorUsuario(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id);
                    entradas.Concat(entradas1);
                }

                IList<GrupoEN> grupos = superuserCEN.ObtenerGruposPorUsuario(pe_usuario);
                foreach (GrupoEN am in grupos)
                {
                    muro = muroCEN.ObtenerMuroPorGrupo(am.Id);

                    entradas1 = entradaCEN.ObtenerEntradasPorMuro(muro.Id);  //falta paginar
                    entradas.Concat(entradas1);
                }
                 */

                entradas.OrderBy(e => e.FechaPublicacion);
                entradas = entradas.Distinct().ToList();
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

            return entradas;
        }
    }
}
