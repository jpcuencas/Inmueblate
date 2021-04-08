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
    public class InmobiliariaCP : BasicCP
    {
         public InmobiliariaCP() : base() { }

         public InmobiliariaCP(ISession sessionAux) : base(sessionAux) { }

         public int RegistrarInmobiliaria(string pe_nombre,
                                          string pe_telefono,
                                          string pe_email,
                                          string pe_direccion,
                                          string pe_poblacion,
                                          string pe_cp,
                                          string pe_pais,
                                          string pe_pass,
                                          float pe_valoracion,
                                          string pe_descripcion,
                                          string pe_cif)
         {
             int ret = -1;
             try
             {
                 SessionInitializeTransaction();
                 InmobiliariaCEN inmCEN = new InmobiliariaCEN(new InmobiliariaCAD(session));
                 MuroCEN muroCEN = new MuroCEN(new MuroCAD(session));
                 EntradaCEN entCEN = new EntradaCEN(new EntradaCAD(session));

                 //creamos el muro
                 int m = muroCEN.CrearMuro(false);
                 MuroEN muro = muroCEN.get_IMuroCAD().ReadOIDDefault(m);
                 //creamos una entrada en el muro de bien venida
                 string titulo = "Bienvenid@ " + pe_nombre;
                 string cuerpo = "Disfuta de nuestra red social, aquí podrás publicar los inmubles de los que dispones";
                 //int en = entCEN.CrearEntrada(DateTime.Today, titulo, cuerpo, false, m, -1);

                 //insertamos la entrada en el muro
                 //IList<int> entradas = new List<int>();
                 //entradas.Add(en);
                 //muroCEN.AnyadirEntradas(m, entradas);

                 //creamos a la nueva inmobiliaria
                 ret = inmCEN.CrearInmobiliaria(muro.Id,
                                                pe_nombre,
                                                pe_telefono,
                                                pe_email,
                                                pe_direccion,
                                                pe_poblacion,
                                                pe_cp,
                                                pe_pais,
                                                pe_pass, -1,
                                                pe_descripcion,
                                                pe_cif);
                 muroCEN.AsociarConUsuario(m, ret);

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
