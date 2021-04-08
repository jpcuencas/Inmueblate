
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using System.IO;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                SuperUsuarioCEN supCEN = new SuperUsuarioCEN ();
                UsuarioCEN usuCEN = new UsuarioCEN ();
                ModeradorCEN modCEN = new ModeradorCEN ();
                InmobiliariaCEN inmCEN = new InmobiliariaCEN ();
                AnuncioCEN anuCEN = new AnuncioCEN ();
                EventoCEN evnCEN = new EventoCEN ();
                PaginaCorporativaCEN pagCEN = new PaginaCorporativaCEN ();
                GeolocalizacionCEN geoCEN = new GeolocalizacionCEN ();
                GaleriaCEN galeriaCEN = new GaleriaCEN ();
                FotografiaCEN fotoCEN = new FotografiaCEN ();
                VideoCEN vidCEN = new VideoCEN ();
                GrupoCEN grpCEN = new GrupoCEN ();
                MensajeCEN menCEN = new MensajeCEN ();
                PreferenciasBusquedaCEN preCEN = new PreferenciasBusquedaCEN ();
                ValoracionCEN valCeN = new ValoracionCEN ();
                PeticionAmistadCEN petCEN = new PeticionAmistadCEN ();
                HabitacionCEN habCEN = new HabitacionCEN ();

                InmuebleCEN inmuebleCEN = new InmuebleCEN ();
                CaracteristicaCEN carCEN = new CaracteristicaCEN ();

                MuroCEN muroCEN = new MuroCEN ();
                EntradaCEN entCEN = new EntradaCEN ();

                UsuarioCP usuCP = new UsuarioCP ();
                InmobiliariaCP inmCP = new InmobiliariaCP ();
                MensajeCP menCP = new MensajeCP ();
                ValoracionCP valCP = new ValoracionCP ();
                GaleriaCP galCP = new GaleriaCP ();
                #region Creación de elementos para las pruebas
                #region Usuarios
                int usu = usuCP.RegistrarUsuario ("Isidro", "Santacruz", "48569357G", "ijsl@inm.es",
                        "casa", "Alicante", "03690", "España", "ijsl", "",
                        "630913566", new DateTime (1986, 12, 10),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
                int usu2 = usuCP.RegistrarUsuario ("Alejandro", "Aravid", "11111111X", "avamu@inm.es",
                        "Su casa", "Elda", "01259", "España", "avam", "",
                        "589945632", new DateTime (1988, 1, 30),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu3 = usuCP.RegistrarUsuario ("Cristina", "Ruiz", "22222222X", "crt@inm.es",
                        "casa", "San Vicente", "03690", "España", "crt", "",
                        "569784512", new DateTime (1991, 3, 20),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Amigos);
                int usu4 = usuCP.RegistrarUsuario ("Jhon", "Nieve", "00000004X", "jhon@inm.es",
                        "casa4", "Invernalia", "01234", "Poniente", "nieve", "",
                        "000000004", new DateTime (1994, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu5 = usuCP.RegistrarUsuario ("Arya", "Stark", "00000005X", "arya@inm.es",
                        "casa5", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000005", new DateTime (2000, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu6 = usuCP.RegistrarUsuario ("Sansa", "Stark", "00000006X", "sansa@inm.es",
                        "casa6", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000006", new DateTime (1998, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu7 = usuCP.RegistrarUsuario ("Bran", "Stark", "00000007X", "bran@inm.es",
                        "casa7", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000007", new DateTime (2001, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu8 = usuCP.RegistrarUsuario ("Rickon", "Stark", "00000008X", "rickon@inm.es",
                        "casa8", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000008", new DateTime (2005, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu9 = usuCP.RegistrarUsuario ("Eddard", "Stark", "00000009X", "eddar@inm.es",
                        "casa9", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000009", new DateTime (1979, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);

                int usu10 = usuCP.RegistrarUsuario ("Catelyn", "Stark", "00000010X", "catelyn@inm.es",
                        "casa10", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000010", new DateTime (1979, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu11 = usuCP.RegistrarUsuario ("Robb", "Stark", "00000010X", "robb@inm.es",
                        "casa10", "Invernalia", "01234", "Poniente", "stark", "",
                        "000000010", new DateTime (1995, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                int usu12 = usuCP.RegistrarUsuario ("Daenerys", "Targaryen", "00000010X", "daenerys@inm.es",
                        "casa10", "7 reinos", "01234", "Poniente", "targaryen", "",
                        "000000010", new DateTime (1995, 1, 1),
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
                galCP.ModificarFotoPerfil (usu, "/ID0001/Imagen/ijsl.jpg");
                galCP.ModificarFotoPerfil (usu2, "/ID0002/Imagen/avan.jpg");
                galCP.ModificarFotoPerfil (usu3, "/ID0003/Imagen/crt.jpg");
                galCP.ModificarFotoPerfil (usu4, "/ID0004/Imagen/jhon.jpg");
                galCP.ModificarFotoPerfil (usu5, "/ID0005/Imagen/arya.jpg");
                galCP.ModificarFotoPerfil (usu6, "/ID0006/Imagen/sansa.jpg");
                galCP.ModificarFotoPerfil (usu7, "/ID0007/Imagen/bran.png");
                galCP.ModificarFotoPerfil (usu8, "/ID0008/Imagen/rickon.jpg");
                galCP.ModificarFotoPerfil (usu9, "/ID0009/Imagen/eddard.jpg");
                galCP.ModificarFotoPerfil (usu10, "/ID0010/Imagen/catelyn.jpg");
                galCP.ModificarFotoPerfil (usu11, "/ID0011/Imagen/robb.jpg");
                galCP.ModificarFotoPerfil (usu12, "/ID0012/Imagen/daenerys.jpg");
                usuCP.AgregarAmigo(usu, usu2);
                usuCP.AgregarAmigo(usu, usu4);
                usuCP.AgregarAmigo(usu, usu5);
                usuCP.AgregarAmigo(usu, usu6);
                #endregion
                #region Moderadores
                int mod1 = modCEN.CrearModerador (-1,
                        "Alejandro",
                        "9658965",
                        "avam@inm.es",
                        "su casa",
                        "elda",
                        "58963",
                        "España",
                        "avam",
                        10,
                        "Aravid",
                        "47856935A",
                        DateTime.Today,
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
                int mod2 = modCEN.CrearModerador (-1,
                        "Alejandro",
                        "9658965",
                        "a",
                        "su casa",
                        "elda",
                        "58963",
                        "España",
                        "a", 10,
                        "Aravid",
                        "47856935B",
                        DateTime.Today,
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
                #endregion
                #region Inmobiliarias
                int inm1 = inmCP.RegistrarInmobiliaria ("Juanpe Inmobiliaria",
                        "48569",
                        "jpcs@inm.es",
                        "direccion",
                        "san vicente",
                        "03690",
                        "España",
                        "jpcs",
                        0,
                        "INM",
                        "78787878");

                int inm2 = inmCP.RegistrarInmobiliaria ("Tyrion Lannister",
                        "485323",
                        "tyrion@inm.es",
                        "direccion",
                        "san vicente",
                        "03690",
                        "España",
                        "lannister",
                        0,
                        "INM",
                        "333333");
                int inm3 = inmCP.RegistrarInmobiliaria ("Jaime Lannister",
                        "485323",
                        "jaime@inm.es",
                        "direccion",
                        "san vicente",
                        "03690",
                        "España",
                        "lannister",
                        0,
                        "INM",
                        "333333");
                int inm4 = inmCP.RegistrarInmobiliaria ("Cersei Lannister",
                        "485323",
                        "cersei@inm.es",
                        "direccion",
                        "san vicente",
                        "03690",
                        "España",
                        "lannister",
                        0,
                        "INM",
                        "333333");
                #endregion
                #region Peticiones de amistad
                //peticion de amistad u2->u1
                //int pet0 = usuCEN.EnviarPeticionAmistad (usu2, usu, "peticion 0", "Usuario 2 a usuario 1");
                //petCEN.AceptarPeticionAmistad(pet0);
                //usuCP.AgregarAmigo (usu, usu2);
                //int pet0 = usuCP.EnviarPeticionAmistad(usu2, usu, "peticion1", "Usuario 2 a usuario 1");
                //peticion de amistad u4->u5
                //int pet1 = usuCP.EnviarPeticionAmistad (usu4, usu5, "peticion1", "Usuario 4 a usuario 5");
                //peticion de amistad u4->u6
                //int pet2 = usuCP.EnviarPeticionAmistad (usu4, usu6, "peticion2", "Usuario 4 a usuario 6");
                //peticion de amistad u7->u8
                //int pet3 = usuCP.EnviarPeticionAmistad (usu7, usu8, "peticion3", "Usuario 7 a usuario 8");
                //peticion de amistad u8->u9
                //int pet4 = usuCP.EnviarPeticionAmistad (usu8, usu9, "peticion4", "Usuario 8 a usuario 9");
                #endregion
                #region Anuncios
                int anu1 = anuCEN.CrearAnuncio ("http://img2.wikia.nocookie.net/__cb20120109113835/onepiece-cat/ca/images/9/98/Bandera_sanji.jpg", "anuncio1", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "www.ua.es");
                int anu2 = anuCEN.CrearAnuncio ("/img/anuncios/anuncios:JPG", "anuncio2", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Deportes, "www.marca.com");
                int anu3 = anuCEN.CrearAnuncio("img3.jpg", "anuncio3", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.appinformatica.com");
                int anu4 = anuCEN.CrearAnuncio("img4.jpg", "anuncio4", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.loteriagrill.com");
                int anu5 = anuCEN.CrearAnuncio("img5.jpg", "anuncio5", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.spf.com");
                int anu6 = anuCEN.CrearAnuncio("img6.jpg", "anuncio6", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.sueltatelpelo.com");
                int anu7 = anuCEN.CrearAnuncio("img7.jpg", "anuncio7", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.antena3.com");
                int anu8 = anuCEN.CrearAnuncio("img8.jpg", "anuncio8", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.telex.com");
                int anu9 = anuCEN.CrearAnuncio("img9.jpg", "anuncio9", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.earthhour.org");
                int anu10 = anuCEN.CrearAnuncio("img10.jpg", "anuncio10", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Musica, "www.cbp.gov");
                #endregion
                #region Golocalizacion
                float lat1 = 38.4757176F;
                float lon1 = -0.7948248F;
                int geo1 = geoCEN.CrearGeolocalizacion (lat1, lon1, "la mitad de uno", "santa catalina");
                float lat2 = -37.45F;
                float lon2 = -69.05F;
                int geo2 = geoCEN.CrearGeolocalizacion (lat2, lon2, "entorno a siete", "santa rita rita");
                float lat3 = 38.3943471F;
                float lon3 = -0.52423F;
                int geo3 = geoCEN.CrearGeolocalizacion (lat3, lon3, "en medio la UA", "A saber donde");
                #endregion
                #region PreferenciasBusqueda
                int preferenciasBusqueda1 = preCEN.CrearPreferenciasBusqueda (10, 250, 150, geo1);
                preCEN.AsociarConUsuario (preferenciasBusqueda1, usu);
                int preferenciasBusqueda2 = preCEN.CrearPreferenciasBusqueda (10, 250, 150, geo2);
                preCEN.AsociarConUsuario (preferenciasBusqueda2, usu);
                #endregion
                #region Eventos
                int evn1 = evnCEN.CrearEvento ("Últimas novedades -Moda", "Los iltimos pisos libres se encuentran en esta zona", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Moda, inm1, geo1);
                int evn2 = evnCEN.CrearEvento ("Conoce actividades de ocio", "Aqui podras encontrar actividades entretenidas para hacer por tu zona mudate a la diversión", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Cultura, inm1, geo2);
                int evn3 = evnCEN.CrearEvento ("Compaginate con el ginasio", "Te podemos sugerir varios ginasiosen tu zona", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Deportes, inm1, geo3);
                #endregion
                #region Valoraciones
                if (valCP.CrearValoracion (usu, usu2, 8.0f, "Eres el mejor") != -1) {
                        Console.WriteLine ("Error en CrearVoracion. E: " + usu + " R: " + usu2);
                }
                if (valCP.CrearValoracion (usu, usu10, 5.0f, "Mediocre") != -1) {
                        Console.WriteLine ("Error en CrearVoracion. E: " + usu + " R: " + usu10);
                }
                if (valCP.CrearValoracion (usu, usu3, 1.0f, "Eres lo peor") != -1) {
                        Console.WriteLine ("Error en CrearVoracion. E: " + usu + " R: " + usu3);
                }
                if (valCP.CrearValoracion (usu2, usu, 9.0f, "El mejor compañero que he tenido") != -1) {
                        Console.WriteLine ("Error en CrearVoracion. E: " + usu2 + " R: " + usu);
                }
                #endregion






                #region Muros
                int m1 = muroCEN.CrearMuro (false);
                int m2 = muroCEN.CrearMuro (false);
                int m3 = muroCEN.CrearMuro (false);
                int m4 = muroCEN.CrearMuro (false);

                int inmM1 = muroCEN.CrearMuro (false);
                #endregion
                #region Grupos
                int grp1 = grpCEN.CrearGrupo (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum.Privado, "g1", "grupo1", m1);
                int grp2 = grpCEN.CrearGrupo (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum.Privado, "g2", "grupo2", m2);
                int grp3 = grpCEN.CrearGrupo (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum.Privado, "g3", "grupo3", m3);

                #endregion
                #region Entradas
                int ent1 = entCEN.CrearEntrada (DateTime.Today, "e1", "entrada1", false, m1, usu);
                int ent2 = entCEN.CrearEntrada (DateTime.Today, "e2", "entrada2", false, m1, usu);
                int ent3 = entCEN.CrearEntrada (DateTime.Today, "e3", "entrada3", false, m1, usu);
                int ent4 = entCEN.CrearEntrada (DateTime.Today, "e4", "entrada4", false, m2, usu2);
                int ent5 = entCEN.CrearEntrada (DateTime.Today, "e5", "entrada5", false, m2, usu2);
                int ent6 = entCEN.CrearEntrada (DateTime.Today, "e6", "entrada6", true, m2, usu2);
                //int ent7 = entCEN.CrearEntrada (DateTime.Today, "e7", "entrada1", false, m3, usu3);
                //int ent8 = entCEN.CrearEntrada (DateTime.Today, "e8", "entrada1", true, m3, usu4);
                //int ent9 = entCEN.CrearEntrada (DateTime.Today, "e9", "entrada1", true, m3, usu5);

                //int ent10 = entCEN.CrearEntrada (DateTime.Today, "e10", "entrada6", true, inmM1, usu2);
                //int ent11 = entCEN.CrearEntrada (DateTime.Today, "e11", "entrada1", false, inmM1, usu3);
                //int ent12 = entCEN.CrearEntrada (DateTime.Today, "e12", "entrada1", true, m3, inm1);
                // int ent13 = entCEN.CrearEntrada (DateTime.Today, "e13", "entrada1", true, m3, inm1);
                #endregion
                #region Paginas
                int pag1 = pagCEN.CrearPaginaCorporativa ("<html><head><title>miPagina</title></head><body><h1>hola Pagina</h1><p>Esto es una paguina un poco triste...</p></body></html>", "pagina1", inm1);
                int pag2 = pagCEN.CrearPaginaCorporativa ("<html><head><link rel='stylesheet' href='http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css'></head><body><div class='container'><div class='jumbotron'><h1>Inicio de Testing</h1></div><div class='well'>Hola</div></div></body></html>", "Página", inm2);
                #endregion
                #region Mensajes
                int men1 = menCEN.CrearMensaje (true, DateTime.Today, "asunto1", "cuerpo1", false, mod1, usu2);
                int men2 = menCEN.CrearMensaje (true, DateTime.Today, "asunto2", "cuerpo2", false, mod1, usu2);
                int men3 = menCEN.CrearMensaje (false, DateTime.Now, "hola", "me molas", false, usu, usu2);
                int men4 = menCEN.CrearMensaje (false, DateTime.Now, "hola", "no me molas", false, usu2, usu);
                int men5 = menCEN.CrearMensaje (false, DateTime.Now, "hola", "era bromaa", false, usu2, usu);
                #endregion
                #region Elementos Multimedia
                #region Galerias
                int g1 = galeriaCEN.CrearGaleria (-1, DateTime.Now, "galeria1", "g1", false, "\\galeria1");
                int g2 = galeriaCEN.CrearGaleria (-1, DateTime.Now, "galeria2", "g2", false, "\\galeria2");
                int g3 = galeriaCEN.CrearGaleria (-1, DateTime.Now, "galeria3", "g3", false, "\\galeria3");

                #endregion
                /*#region Fotos
                 * int f1 = fotoCEN.CrearFotografia ("foto1.jpg", true, "f1", "foto1", DateTime.Today, g1);
                 * int f2 = fotoCEN.CrearFotografia ("foto2.jpg", true, "f2", "foto2", DateTime.Today, g1);
                 * int f3 = fotoCEN.CrearFotografia ("foto3.jpg", false, "f3", "foto3", DateTime.Today, g2);
                 * int f4 = fotoCEN.CrearFotografia ("foto4.jpg", false, "f4", "foto4", DateTime.Today, g3);
                 * int f5 = fotoCEN.CrearFotografia ("foto5.jpg", false, "f5", "foto5", DateTime.Today, g3);
                 * int f6 = fotoCEN.CrearFotografia ("foto6.jpg", false, "f6", "foto6", DateTime.Today, g3);
                 * #endregion
                 * #region Videos
                 * int v1 = vidCEN.CrearVideo ("video1.jpg", true, "v1", "video1", DateTime.Today, g1);
                 * int v2 = vidCEN.CrearVideo ("video2.jpg", true, "v2", "video2", DateTime.Today, g3);
                 * #endregion
                 * IList<int> lfotos = new List<int>();
                 * lfotos.Add (g1);
                 * lfotos.Add (g2);
                 * lfotos.Add (g3);*/
                #endregion

                #region Inmueble

                // Creo dos inmuebles
                int inmueble1 = inmuebleCEN.CrearInmueble (false, "Un castillo", NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum.Apartamento, 90, true, 350, geo1);
                int inmueble2 = inmuebleCEN.CrearInmueble (false, "Piso con buenas vistas", NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum.Ático, 105, true, 350, geo2);
                int inmueble3 = inmuebleCEN.CrearInmueble(false, "Piso acogedor", NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum.Ático, 105, true, 350, geo3);

                // Creo las caracteristicas que usare en los inmuebles y la habitación
                int carFumador = carCEN.CrearCaracteristica ("Fumadores", "Sí");
                int carAscensor = carCEN.CrearCaracteristica ("Ascensor", "Sí");
                int carGaraje = carCEN.CrearCaracteristica ("Garaje", "Sí");
                int carBalcon = carCEN.CrearCaracteristica ("Balcón", "Sí");

                // Creamos las listas de características de los dos inmuebles y las rellenamos
                IList<int> caracteristicasPiso1 = new List<int>();
                IList<int> caracteristicasPiso2 = new List<int>();

                caracteristicasPiso1.Add (carFumador);
                caracteristicasPiso1.Add (carAscensor);
                caracteristicasPiso1.Add (carGaraje);

                caracteristicasPiso2.Add (carFumador);

                // Añadimos las características a cada uno de los inmuebles
                inmuebleCEN.AnyadirCaracteristica (inmueble1, caracteristicasPiso1);
                inmuebleCEN.AnyadirCaracteristica (inmueble2, caracteristicasPiso2);

                // Asociamos los inmuebles a una inmobiliaria (que no es obligatorio)
                inmuebleCEN.AnyadirInmobiliaria (inmueble1, inm1);
                inmuebleCEN.AnyadirInmobiliaria (inmueble2, inm1);

                // Creo dos habitaciones para el inmueble1
                int hab1 = habCEN.CrearHabitacion (false, "Habitacion 1", 9, true, new List<int>(), inmueble1);
                int hab2 = habCEN.CrearHabitacion (false, "Habitacion 2", 8, true, new List<int>(), inmueble1);

                // Creamos la lista de características de la habitacion1
                IList<int> caracteristicasHab1 = new List<int>();
                caracteristicasHab1.Add (carBalcon);
                habCEN.AnyadirCaracteristica (hab1, caracteristicasHab1);

                // Creo las listas de inquilinos de cada habitación y las asocio con cada una. También añado los inquilinos al inmueble
                IList<int> inquilinosHab1 = new List<int>();
                IList<int> inquilinosHab2 = new List<int>();

                inquilinosHab1.Add (usu);
                inquilinosHab2.Add (usu2);

                habCEN.AnyadirInquilino (hab1, inquilinosHab1);
                habCEN.AnyadirInquilino (hab2, inquilinosHab2);

                inmuebleCEN.AnyadirInquilino (inmueble1, inquilinosHab1);
                inmuebleCEN.AnyadirInquilino (inmueble1, inquilinosHab2);
                #endregion

                #endregion
                #region Pruebas varias

                //usuCP.EnviarPeticionAmistad (usu, usu2, "Amistad", "Se mi amigo");
                UsuarioEN usuario = usuCEN.DameUsuarioPorOID (usu);
                Console.WriteLine (usu);
                /*******************************************************************************************************/
                IList<EntradaEN> entradas = entCEN.ObtenerEntradasPorMuro (usuario.Muro.Id, 0, -1);

                foreach (EntradaEN en in entradas) {
                        System.Console.WriteLine ("Entrada[" + en.Id + "]: " + en.Titulo);
                }
                //System.Console.WriteLine("entradas: " + usuario.Muro.Entradas.Count);
                System.Console.WriteLine ("Nombre del usuario: " + usuario.Nombre);
                //anuCEN.CrearAnuncio ("url_Imagen", "imagen1", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "url");
                SuperUsuarioEN supu = supCEN.ObtenerUsuarioPorEmail ("ddv@inm.es");
                if (supu == null) {
                        Console.WriteLine ("OK");
                }
                else{
                        Console.WriteLine ("NOT OK");
                }

                IList<AnuncioEN> w_lista1, w_lista2;
                w_lista1 = anuCEN.ObtenerAnunciosRandom (15);
                w_lista2 = anuCEN.ObtenerAnunciosRandom (5);

                IList<GrupoEN> w_lista_grupos;
                w_lista_grupos = grpCEN.ObtenerGruposConEntradasReportadas ();
                Console.WriteLine ("---------Grupos----------");
                foreach (GrupoEN gr in w_lista_grupos) {
                        Console.WriteLine ("Grupo: " + gr.Nombre);
                }
                Console.WriteLine ("---------Grupos----------");

                IList<UsuarioEN> w_lista_usuario1, w_lista_usuario2;
                w_lista_usuario1 = usuCEN.DameUsuariosFiltro (null, null, null, null, null, null, 0, 30);
                w_lista_usuario2 = usuCEN.DameTodosLosUsuarios (0, 30);
                if (w_lista_usuario1.Count == w_lista_usuario2.Count) {
                        Console.WriteLine ("Exito en el filtrado generico");
                }
                else{ Console.WriteLine ("FAIL!!!"); }

                //usuCP.AgregarAmigo (usu, usu2);
                //usuCP.AgregarAmigo (usu, usu4);
                //usuCP.AgregarAmigo (usu, usu5);
                //usuCP.AgregarAmigo (usu, usu6);
                //usuCP.AgregarAmigo (usu, usu7);
                //usuCP.AgregarAmigo (usu, usu8);
                IList<UsuarioEN> w_lista_amigos;
                w_lista_amigos = usuCEN.ObtenerAmigos (usu, 0, 3);
                Console.WriteLine ("---------Amigos----------");
                foreach (UsuarioEN us in w_lista_amigos) {
                        Console.WriteLine ("Nombre: " + us.Nombre);
                }
                Console.WriteLine ("---------Fin Amigos----------");

                IList<GrupoEN> w_lista_grupo;
                w_lista_grupo = supCEN.ObtenerGruposPorUsuario (usu, 1, 10);
                Console.WriteLine ("---------grupos----------");
                foreach (GrupoEN gr in w_lista_grupo) {
                        Console.WriteLine ("Nombre: " + gr.Nombre);
                }
                Console.WriteLine ("---------Fin grupos----------");

                MuroEN musu;
                musu = muroCEN.ObtenerMuroPorGrupo (grp1);
                Console.WriteLine ("---------grupo----------");
                if (musu == null) {
                        Console.WriteLine ("OK");
                }
                else{
                        Console.WriteLine ("NOT OK");
                }
                Console.WriteLine ("---------Fin grupo----------");

                Console.WriteLine ("---------Inmobiliarias----------");

                IList<InmobiliariaEN> listaInmobiliarias = inmCEN.DameInmobiliariaFiltro (null, null, null, null, null, null, 0, 10);
                foreach (InmobiliariaEN g in listaInmobiliarias) {
                        Console.WriteLine (g.Nombre + " " + g.Descripcion);
                }
                Console.WriteLine ("---------Fin Inmobiliarias----------");
                Console.WriteLine ("---------Peticion----------");
                //Console.WriteLine ("Petición: " + pet0);
                Console.WriteLine ("---------Fin Peticion----------");
                IList<PeticionAmistadEN> l_peticiones = petCEN.ObtenerPeticionesAmistadEstado (usu, 0, 0, -1);
                foreach (PeticionAmistadEN pet in l_peticiones) {
                        Console.WriteLine ("Petición: " + pet.Id);
                }
                #endregion
                string path = @"\Debug";
                DirectoryInfo di = new DirectoryInfo (path);
                if (di.Exists) {
                        DirectoryInfo[] diArr = di.GetDirectories ();
                        foreach (DirectoryInfo dri in diArr)
                                Console.WriteLine (dri.Name);
                }
                FotografiaEN fot = fotoCEN.ObtenerFotoPerfil (usu);
                if (fot != null) {
                        Console.WriteLine ("Url: " + fot.URL);
                }

                Console.WriteLine ("---------Caracteristicas----------");
                IList<HabitacionEN> listaHabitacion = habCEN.DameHabitacionFiltro (null, -1, null, null, -1, 0, 10);
                foreach (HabitacionEN c in listaHabitacion) {
                        Console.WriteLine (c.Descripcion);
                }
                Console.WriteLine ("---------Fin Caracteristicas----------");
                //int men1 = menCEN.CrearMensaje(true, DateTime.Today, "M1", "mensaje 1", false, usu, usu2);
                /*******************************************************************************************************/
                /*******************************************************************************************************/

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
