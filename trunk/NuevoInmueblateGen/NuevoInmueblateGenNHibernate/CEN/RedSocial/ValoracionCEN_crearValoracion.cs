
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
public partial class ValoracionCEN
{
public int CrearValoracion (float p_valoracion, string p_descripcion, bool p_pendienteModeracion, int p_emisor, int p_receptor)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Valoracion_crearValoracion_customized) ENABLED START*/

        /*
         *  Funcion revisada
         */
        ValoracionEN valoracionEN = null;

        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Valoracion = p_valoracion;

        valoracionEN.Descripcion = p_descripcion;


        if (p_emisor != -1) {
                valoracionEN.Emisor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                valoracionEN.Emisor.Id = p_emisor;
        }


        if (p_receptor != -1) {
                valoracionEN.Receptor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                valoracionEN.Receptor.Id = p_receptor;
        }

        //Call to ValoracionCAD
        try
        {
                oid = _IValoracionCAD.CrearValoracion (valoracionEN);
                //float sum = 0;
                //for (int i = 0; i <= valoracionEN.Receptor.ValoracionRecibida.Count; i++) {
                //        sum += valoracionEN.Receptor.ValoracionRecibida [i].Valoracion;
                //}


                //valoracionEN.Receptor.ValoracionMedia = (sum / valoracionEN.Receptor.ValoracionRecibida.Count);
        }
        catch (Exception ex)
        {
                throw new Exception ("Error en el calculo de valoraci�n media: " + ex.Message);
        }

        return oid;
        /*PROTECTED REGION END*/
}
}
}
