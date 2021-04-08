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
    public class GaleriaCP: BasicCP
    {
        public GaleriaCP() : base() {}

        public GaleriaCP(ISession sessionAux) : base(sessionAux) {}

        public int SubirFotos(int pe_galeria, List<int> pe_fotos)
        {
            int ret = -1;
            try
            {
                int i;
                SessionInitializeTransaction();
                GaleriaCEN galeriaCEN = new GaleriaCEN(new GaleriaCAD(session));
                
                galeriaCEN.AnyadirElementoMultimedia(pe_galeria,pe_fotos);
                
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

        public int ModificarFotoPerfil(int pe_usuario, string ruta)
        {
            try
            {
                SessionInitializeTransaction();

                FotografiaCEN fotCEN = new FotografiaCEN(new FotografiaCAD(session));
                ElementoMultimediaCEN eleCEN = new ElementoMultimediaCEN(new ElementoMultimediaCAD(session));
                FotografiaEN fotEN = fotCEN.ObtenerFotoPerfil(pe_usuario);
                string nombre = fotEN.Nombre + String.Format("{0:yyyymmdd_hhmmss}",fotEN.Fecha);
                int id_foto = fotCEN.CrearFotografia(fotEN.Galeria.Id, fotEN.Fecha, fotEN.Descripcion, nombre, false, fotEN.URL);
                eleCEN.AnyadirUsuario(id_foto, pe_usuario);
                fotEN.URL = ruta;

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                return 0;
            }
            finally
            {
                SessionClose();
            }
            return -1;
        }

        public int AnyadirFotos(int pe_usuario, int pe_galeria, string ruta, string pe_nombre, string pe_descripcion)
        {
            try
            {
                SessionInitializeTransaction();
                FotografiaCEN fotCEN = new FotografiaCEN(new FotografiaCAD(session));
                ElementoMultimediaCEN eleCEN = new ElementoMultimediaCEN(new ElementoMultimediaCAD(session));

                int id_foto = fotCEN.CrearFotografia(pe_galeria, DateTime.Now, pe_descripcion, pe_nombre, false, ruta);

                eleCEN.AnyadirUsuario(id_foto, pe_usuario);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                return 0;
            }
            finally
            {
                SessionClose();
            }
            return -1;
        }

        public int AnyadirFotosEn(int pe_usuario, int pe_galeria, int pe_entrada, string ruta, string pe_nombre, string pe_descripcion)
        {
            try
            {
                SessionInitializeTransaction();
                FotografiaCEN fotCEN = new FotografiaCEN(new FotografiaCAD(session));
                ElementoMultimediaCEN eleCEN = new ElementoMultimediaCEN(new ElementoMultimediaCAD(session));
                EntradaCEN entCEN = new EntradaCEN(new EntradaCAD(session));

                int id_foto = fotCEN.CrearFotografia(pe_galeria, DateTime.Now, pe_descripcion, pe_nombre, false, ruta);

                eleCEN.AnyadirUsuario(id_foto, pe_usuario);
                IList<int> l_fo = new List<int>();
                l_fo.Add(id_foto);
                entCEN.AnyadirElementosMultimedia(pe_entrada,l_fo);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                return 0;
            }
            finally
            {
                SessionClose();
            }
            return -1;
        }
    }
}
