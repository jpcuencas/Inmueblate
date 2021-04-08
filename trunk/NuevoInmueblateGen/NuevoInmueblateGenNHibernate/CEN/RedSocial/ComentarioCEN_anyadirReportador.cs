
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
public partial class ComentarioCEN
{
public void AnyadirReportador (int p_comentario, System.Collections.Generic.IList<int> p_superusuario)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Comentario_anyadirReportador_customized) ENABLED START*/


        SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN ();
        SuperUsuarioEN reportador = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_superusuario [0]);
        ComentarioEN comentario = _IComentarioCAD.ReadOIDDefault (p_comentario);

        if (!comentario.Reportadores.Contains (reportador)) {
                _IComentarioCAD.AnyadirReportador (p_comentario, p_superusuario);

                comentario = _IComentarioCAD.ReadOIDDefault (p_comentario);

                if (!comentario.PendienteModeracion && comentario.Reportadores.Count >= 5) {
                        comentario.PendienteModeracion = true;
                        _IComentarioCAD.ModificarComentario (comentario);
                }
        }

        /*PROTECTED REGION END*/
}
}
}
