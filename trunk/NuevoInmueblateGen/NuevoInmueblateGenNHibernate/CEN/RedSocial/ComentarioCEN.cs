

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
/*
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int CrearComentario (string p_cuerpo, bool p_pendienteModeracion, Nullable<DateTime> p_fechaPublicacion, int p_creador, int p_entrada)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Cuerpo = p_cuerpo;

        comentarioEN.PendienteModeracion = p_pendienteModeracion;

        comentarioEN.FechaPublicacion = p_fechaPublicacion;


        if (p_creador != -1) {
                // El argumento p_creador -> Property creador es oid = false
                // Lista de oids id
                comentarioEN.Creador = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                comentarioEN.Creador.Id = p_creador;
        }


        if (p_entrada != -1) {
                // El argumento p_entrada -> Property entrada es oid = false
                // Lista de oids id
                comentarioEN.Entrada = new NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN ();
                comentarioEN.Entrada.Id = p_entrada;
        }

        //Call to ComentarioCAD

        oid = _IComentarioCAD.CrearComentario (comentarioEN);
        return oid;
}

public void ModificarComentario (int p_oid, string p_cuerpo, bool p_pendienteModeracion, Nullable<DateTime> p_fechaPublicacion)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_oid;
        comentarioEN.Cuerpo = p_cuerpo;
        comentarioEN.PendienteModeracion = p_pendienteModeracion;
        comentarioEN.FechaPublicacion = p_fechaPublicacion;
        //Call to ComentarioCAD

        _IComentarioCAD.ModificarComentario (comentarioEN);
}

public void BorrarComentario (int id)
{
        _IComentarioCAD.BorrarComentario (id);
}

public void AnyadirElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to ComentarioCAD

        _IComentarioCAD.AnyadirElementosMultimedia (p_comentario, p_elementomultimedia);
}
public void BorrarElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to ComentarioCAD

        _IComentarioCAD.BorrarElementosMultimedia (p_comentario, p_elementomultimedia);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentarioPendienteModeracion ()
{
        return _IComentarioCAD.ObtenerComentarioPendienteModeracion ();
}
public ComentarioEN DameComentarioPorOID (int id)
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.DameComentarioPorOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.DameTodosLosComentarios (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentariosPorEntrada (int p_entrada)
{
        return _IComentarioCAD.ObtenerComentariosPorEntrada (p_entrada);
}
}
}
