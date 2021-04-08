
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
public void BorrarReportadores (int p_comentario, System.Collections.Generic.IList<int> p_superusuario)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Comentario_borrarReportadores_customized) ENABLED START*/


        SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN ();
        SuperUsuarioEN reportador = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_superusuario [0]);
        ComentarioEN comentario = _IComentarioCAD.ReadOIDDefault (p_comentario);

        _IComentarioCAD.BorrarReportadores (p_comentario, p_superusuario);

        if (comentario.PendienteModeracion && comentario.Reportadores.Count < 5) {
                comentario.PendienteModeracion = false;
                _IComentarioCAD.ModificarComentario (comentario);
        }

        /*PROTECTED REGION END*/
}
}
}
