using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;
using System.IO;

namespace NuevoInmueblateCP.InmueblateCP
{
    public class UsuarioCP: BasicCP
    {
        public UsuarioCP() : base() { }

        public UsuarioCP(ISession sessionAux) : base(sessionAux) { }

        public int RegistrarUsuario(string pe_nombre, string pe_apellido, string pe_nif, string pe_mail, string pe_direccion, string pe_poblacion, string pe_cp, string pe_pais, string pe_pass,string pe_urlFoto, string pe_telefono, DateTime pe_fNacimiento, TipoPrivacidadEnum pe_tipo)
        {
            int ret = -1;
            
            try
            {
                SessionInitializeTransaction();
                UsuarioCEN usuCEN = new UsuarioCEN(new UsuarioCAD(session));
                MuroCEN muroCEN = new MuroCEN(new MuroCAD(session));
                EntradaCEN entCEN = new EntradaCEN(new EntradaCAD(session));
                SuperUsuarioCEN supCEN = new SuperUsuarioCEN(new SuperUsuarioCAD(session));
                GaleriaCEN galCEN = new GaleriaCEN(new GaleriaCAD(session));
                FotografiaCEN fotCEN = new FotografiaCEN(new FotografiaCAD(session));
                ElementoMultimediaCEN eleCEN = new ElementoMultimediaCEN(new ElementoMultimediaCAD(session));

                //Compruebo que no existe previamente(debería comprobarse en niveles superiores)
                if (supCEN.ObtenerUsuarioPorEmail(pe_mail) != null)
                {
                    return -1;
                }
                //creamos el muro
                int m = muroCEN.CrearMuro(false);
                MuroEN muro = muroCEN.get_IMuroCAD().ReadOIDDefault(m);
                //creamos una entrada en el muro de bien venida
                string titulo = "Bienvenid@ " + pe_nombre;
                string cuerpo = "Disfuta de nuestra red social, aquí podrás encontrar el inmuble que buscas";
                
                
                //creamos al nuevo usuario
                ret = usuCEN.CrearUsuario(muro.Id,
                                          pe_nombre,
                                          pe_telefono,
                                          pe_mail,
                                          pe_direccion,
                                          pe_poblacion,
                                          pe_cp, pe_pais,
                                          pe_pass, 0,
                                          pe_apellido,
                                          pe_nif,
                                          pe_fNacimiento,
                                          pe_tipo);

                //int en = entCEN.CrearEntrada(DateTime.Now, titulo, cuerpo, false, muro.Id, -1);
                //insertamos la entrada en el muro
                //IList<int> entradas = new List<int>();
                //entradas.Add(en);
                //muroCEN.AnyadirEntradas(m, entradas);

                //muroCEN.AsociarConUsuario(m, ret);
                
                //Crear directorios de archivos.
                
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                ruta = ruta.Substring(0, ruta.LastIndexOf("\\trunk"));
                ruta += "\\trunk\\NuevoInmueblateWeb\\InmueblateWeb\\img";
                string ruta_default = ruta;
                ruta += "\\ID" + ret.ToString().PadLeft(4, '0');
                //retorno = "\\Anuncios";
                string img = "\\Imagen";
                string vid = "\\Video";
                if (!System.IO.Directory.Exists(ruta))
                {
                    System.IO.Directory.CreateDirectory(ruta);
                    
                    System.IO.Directory.CreateDirectory(ruta + img);

                    string dest = Path.Combine(ruta + img, "user-default.jpg");
                    File.Copy(ruta_default + "\\default\\user-default.jpg", dest);
                    
                    System.IO.Directory.CreateDirectory(ruta + vid);
                }
                ruta = "/ID" + ret.ToString().PadLeft(4, '0') + "/";
                //creamos la fotografia del perfil
                FotografiaEN foto = new FotografiaEN();
                GaleriaEN galEN = new GaleriaEN();
                int galeria = galCEN.CrearGaleria(-1, DateTime.Now, "Fotos de perfil", "Perfil", false, "");
                if (pe_urlFoto != "")
                {
                    foto.URL = pe_urlFoto;
                }
                else
                {
                    foto.URL = ruta + "Imagen/user-default.jpg";
                }
                foto.Nombre = "default";
                int id_foto = fotCEN.CrearFotografia(galeria, DateTime.Now, "Fotografía de perfil", foto.Nombre, false, foto.URL);
                eleCEN.AnyadirUsuario(id_foto, ret);
                IList<int> l_gal = new List<int>();
                l_gal.Add(galeria);
                usuCEN.AnyadirElementosMultimedia(ret, l_gal);

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

        public int RegistrarInmobiliaria(string pe_nombre, string pe_cif, string pe_mail, string pe_direccion, string pe_poblacion, string pe_cp, string pe_pais, string pe_pass, string pe_urlFoto, string pe_telefono, string pe_descripcion)
        {
            int ret = -1;

            try
            {
                SessionInitializeTransaction();
                InmobiliariaCEN usuCEN = new InmobiliariaCEN(new InmobiliariaCAD(session));
                MuroCEN muroCEN = new MuroCEN(new MuroCAD(session));
                EntradaCEN entCEN = new EntradaCEN(new EntradaCAD(session));
                SuperUsuarioCEN supCEN = new SuperUsuarioCEN(new SuperUsuarioCAD(session));
                GaleriaCEN galCEN = new GaleriaCEN(new GaleriaCAD(session));
                FotografiaCEN fotCEN = new FotografiaCEN(new FotografiaCAD(session));
                ElementoMultimediaCEN eleCEN = new ElementoMultimediaCEN(new ElementoMultimediaCAD(session));

                //Compruebo que no existe previamente(debería comprobarse en niveles superiores)
                if (supCEN.ObtenerUsuarioPorEmail(pe_mail) != null)
                {
                    return -1;
                }
                //creamos el muro
                int m = muroCEN.CrearMuro(false);
                MuroEN muro = muroCEN.get_IMuroCAD().ReadOIDDefault(m);
                //creamos una entrada en el muro de bien venida
                string titulo = "Bienvenid@ " + pe_nombre;
                string cuerpo = "Disfuta de nuestra red social, aquí podrás encontrar el inmuble que buscas";


                //creamos al nuevo usuario
                ret = usuCEN.CrearInmobiliaria(muro.Id,
                                          pe_nombre,
                                          pe_telefono,
                                          pe_mail,
                                          pe_direccion,
                                          pe_poblacion,
                                          pe_cp, pe_pais,
                                          pe_pass, 0,
                                          pe_descripcion,
                                          pe_cif);

                //int en = entCEN.CrearEntrada(DateTime.Now, titulo, cuerpo, false, muro.Id, -1);
                //insertamos la entrada en el muro
                //IList<int> entradas = new List<int>();
                //entradas.Add(en);
                //muroCEN.AnyadirEntradas(m, entradas);

                //muroCEN.AsociarConUsuario(m, ret);

                //Crear directorios de archivos.

                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                ruta = ruta.Substring(0, ruta.LastIndexOf("\\trunk"));
                ruta += "\\trunk\\NuevoInmueblateWeb\\InmueblateWeb\\img";
                string ruta_default = ruta;
                ruta += "\\ID" + ret.ToString().PadLeft(4, '0');
                //retorno = "\\Anuncios";
                string img = "\\Imagen";
                string vid = "\\Video";
                if (!System.IO.Directory.Exists(ruta))
                {
                    System.IO.Directory.CreateDirectory(ruta);

                    System.IO.Directory.CreateDirectory(ruta + img);

                    string dest = Path.Combine(ruta + img, "user-default.jpg");
                    File.Copy(ruta_default + "\\default\\user-default.jpg", dest);

                    System.IO.Directory.CreateDirectory(ruta + vid);
                }
                ruta = "/ID" + ret.ToString().PadLeft(4, '0') + "/";
                //creamos la fotografia del perfil
                FotografiaEN foto = new FotografiaEN();
                GaleriaEN galEN = new GaleriaEN();
                int galeria = galCEN.CrearGaleria(-1, DateTime.Now, "Fotos de perfil", "Perfil", false, "");
                if (pe_urlFoto != "")
                {
                    foto.URL = pe_urlFoto;
                }
                else
                {
                    foto.URL = ruta + "Imagen/user-default.jpg";
                }
                foto.Nombre = "default";
                /*int id_foto = fotCEN.CrearFotografia(galeria, DateTime.Now, "Fotografía de perfil", foto.Nombre, false, foto.URL);
                eleCEN.AnyadirUsuario(id_foto, ret);
                IList<int> l_gal = new List<int>();
                l_gal.Add(galeria);
                usuCEN.AnyadirElementosMultimedia(ret, l_gal);*/

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

        public int EnviarPeticionAmistad(int pe_emisor, int pe_receptor, string pe_asunto, string pe_cuerpo)
        {
            /*****Códigos de error******/
            /* ret = -1 --> todo ok
             * ret = 0 --> emisor y receptor el mismo
             * ret = 1 --> emisor o receptor null
             * ret = 2 --> receptor esta en la lista de bloqueados o ya es amigo
             * ret = 3 --> hay peticion previa
            /***************************/
            //ret = -1 --> todo ok
            int ret = -1;
            try
            {
                SessionInitializeTransaction();

                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

                if (pe_emisor == pe_receptor)
                {
                    //ret = 0 --> emisor y receptor el mismo
                    ret = 0;
                }
                else
                {
                    UsuarioEN emisor = usuCEN.DameUsuarioPorOID(pe_emisor);
                    UsuarioEN receptor = usuCEN.DameUsuarioPorOID(pe_receptor);
                    
                    
                    if (emisor == null || receptor == null)
                    {
                        //ret = 1 --> emisor o receptor null
                        ret = 1;
                    }
                    else
                    {
                        //compruebo que el emisor no esté entre los usuarios boloquedados o de amigos del receptor
                        if (!receptor.ListaBloqueados.Contains(emisor) && !receptor.ListaAmigos.Contains(emisor))
                        {
                            //ni que haya una petición previa
                            bool peticion = true;
                            foreach (PeticionAmistadEN peti in receptor.PeticionesRecibidas)
                            {
                                if (peti.Emisor.Id == emisor.Id)
                                {
                                    peticion = false;
                                }
                            }
                            if (peticion)
                            {
                                PeticionAmistadCEN petCEN = new PeticionAmistadCEN(new PeticionAmistadCAD(session));
                                ret = petCEN.CrearPeticionAmistad(pe_asunto, pe_cuerpo, EstadoSolicitudAmistadEnum.pendiente, emisor.Id, receptor.Id);
                            }
                            else
                            {
                                //ret = 3 --> hay peticion previa
                                ret = 3;
                            }
                        }
                        else
                        {
                            //ret = 2 --> receptor esta en la lista de bloqueados o ya es amigo
                            ret = 2;
                        }
                    }
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

        //eliminar amigo
        public int BorrarAmigoListaAmigos(int id_usuario, int id_eliminado)
        {
            int ret = -1;
            try
            {
                SessionInitializeTransaction();

                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
                PeticionAmistadCEN petCEN = new PeticionAmistadCEN(new PeticionAmistadCAD(session));
                PeticionAmistadEN petENUsuario, petENEliminado;

                UsuarioEN usuario = usuCEN.DameUsuarioPorOID(id_usuario);
                UsuarioEN eliminado = usuCEN.DameUsuarioPorOID(id_eliminado);
                
                if (usuario.ListaAmigos.Contains(eliminado))
                {
                    usuario.ListaAmigos.Remove(eliminado);
                    petENUsuario = petCEN.DamePeticionDePara(id_usuario, id_eliminado);
                    if (petENUsuario != null) petCEN.BorrarPeticionAmistad(petENUsuario.Id);
                    if (eliminado.ListaAmigos.Contains(usuario))
                    {
                        petENEliminado = petCEN.DamePeticionDePara(id_eliminado, id_usuario);
                        if (petENEliminado != null) petCEN.BorrarPeticionAmistad(petENEliminado.Id);
                        eliminado.ListaAmigos.Remove(usuario);
                    }
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

        public int AgregarAmigo(int pe_usuario, int pe_amigo)
        {
            int ret = -1;
            try
            {
                UsuarioEN usuEN, amiEN;
                SessionInitializeTransaction();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
                
                usuEN = usuCEN.DameUsuarioPorOID(pe_usuario);
                amiEN = usuCEN.DameUsuarioPorOID(pe_amigo);
                usuEN.ListaAmigos.Add(amiEN);
                amiEN.ListaAmigos.Add(usuEN);


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

        public int ModificarUsuario(int pe_usuario, 
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
            try
            {
                SessionInitializeTransaction();
                UsuarioCEN usuCEN = new UsuarioCEN(new UsuarioCAD(session));
                UsuarioEN usuEN = usuCEN.DameUsuarioPorOID(pe_usuario);

                usuEN.Nombre = pe_nombre;
                usuEN.Apellidos = pe_apellido;
                usuEN.Nif = pe_nif;
                usuEN.Email = pe_mail;
                usuEN.Direccion = pe_direccion;
                usuEN.Poblacion = pe_poblacion;
                usuEN.CodigoPostal = pe_cp;
                usuEN.Pais = pe_pais;
                if (pe_pass != "") usuEN.Password = NuevoInmueblateGenNHibernate.Utils.Util.GetEncondeMD5(pe_pass);
                usuEN.Telefono = pe_telefono;
                //usuEN.FechaNacimiento = pe_fNacimiento;
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                return 1;
            }
            finally
            {
                SessionClose();
            }
           

            return -1;
        }
    }
}
