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
    public class ValoracionCP : BasicCP
    {
        public ValoracionCP() : base() { }

        public ValoracionCP(ISession sessionAux) : base(sessionAux) { }
        #region CrearValoracion
        public int CrearValoracion(int pe_emisor, int pe_receptor, float pe_nota, string pe_descripcion)
        {
            /*****Códigos de error******/
            /* ret = -1 --> todo ok
             * ret = 0 --> ya existe la valoracion del emisor al receptor
             * ret = 1 --> emisor o receptor null
            /***************************/
            int ret = -1;
            
            try
            {
                SessionInitializeTransaction();
                ValoracionCAD valCAD = new ValoracionCAD(session);
                ValoracionCEN valCEN = new ValoracionCEN(valCAD);
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

                UsuarioEN w_emisor = usuCEN.DameUsuarioPorOID(pe_emisor);
                UsuarioEN w_receptor = usuCEN.DameUsuarioPorOID(pe_receptor);
                if (w_receptor != null && w_emisor != null)
                {
                    ValoracionEN w_valoracion = valCEN.ObtenerValoracionDeA(pe_emisor, pe_receptor);
                    if (w_valoracion != null)
                    {
                        ret = 0;
                    }
                    else
                    {
                        valCEN.CrearValoracion(pe_nota, pe_descripcion, false, pe_emisor, pe_receptor);
                        //calculo la valoración media
                        IList<ValoracionEN> l_val_rec_rece = valCEN.ObtenerValoracionesReceptorNP(pe_receptor);
                        float w_val_media = l_val_rec_rece.Sum(va => va.Valoracion) / l_val_rec_rece.Count;
                        w_receptor.ValoracionMedia = w_val_media;
                    }
                }
                else
                {
                    ret = 1;
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
        #endregion
        
        #region EliminarValoracion
        public int EliminarValoracion(int pe_emisor, int pe_receptor)
        {
            /*****Códigos de error******/
            /* ret = -1 --> todo ok
             * ret = 0 --> no existe la valoración
             * ret = 1 --> emisor o receptor null
            /***************************/
            float w_val_media;

            try
            {
                SessionInitializeTransaction();
                ValoracionCAD valCAD = new ValoracionCAD(session);
                ValoracionCEN valCEN = new ValoracionCEN(valCAD);
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

                UsuarioEN w_emisor = usuCEN.DameUsuarioPorOID(pe_emisor);
                UsuarioEN w_receptor = usuCEN.DameUsuarioPorOID(pe_receptor);
                if (w_receptor != null && w_emisor != null)
                {
                    ValoracionEN w_valoracion = valCEN.ObtenerValoracionDeA(pe_emisor, pe_receptor);
                    if (w_valoracion == null)
                    {
                        return 0;
                    }
                    else
                    {
                        valCEN.BorrarValoracion(w_valoracion.Id);
                        //Recalculo la valoración media
                        IList<ValoracionEN> l_val_rec_rece = valCEN.ObtenerValoracionesReceptorNP(pe_receptor);
                        if (l_val_rec_rece.Count > 0)
                            w_val_media = l_val_rec_rece.Sum(va => va.Valoracion) / l_val_rec_rece.Count;
                        else w_val_media = 0f;

                        w_receptor.ValoracionMedia = w_val_media;
                        
                    }
                }
                else
                {
                    return 1;
                }

                SessionCommit();
                return -1;
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
        }
        #endregion
    }
}
