
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
public partial class EntradaCEN
{
public void AnyadirReportador (int p_entrada, System.Collections.Generic.IList<int> p_superusuario)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Entrada_anyadirReportador_customized) ENABLED START*/


        SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN ();
        SuperUsuarioEN reportador = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_superusuario [0]);
        EntradaEN entrada = _IEntradaCAD.ReadOIDDefault (p_entrada);

        if (!entrada.Reportadores.Contains (reportador)) {
                _IEntradaCAD.AnyadirReportador (p_entrada, p_superusuario);

                entrada = _IEntradaCAD.ReadOIDDefault (p_entrada);

                if (!entrada.PendienteModeracion && entrada.Reportadores.Count >= 5) {
                        entrada.PendienteModeracion = true;
                        _IEntradaCAD.ModificarEntrada (entrada);
                }
        }

        /*PROTECTED REGION END*/
}
}
}
