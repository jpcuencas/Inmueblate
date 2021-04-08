

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
 *      Definition of the class EntradaCEN
 *
 */
public partial class EntradaCEN
{
private IEntradaCAD _IEntradaCAD;

public EntradaCEN()
{
        this._IEntradaCAD = new EntradaCAD ();
}

public EntradaCEN(IEntradaCAD _IEntradaCAD)
{
        this._IEntradaCAD = _IEntradaCAD;
}

public IEntradaCAD get_IEntradaCAD ()
{
        return this._IEntradaCAD;
}

public int CrearEntrada (Nullable<DateTime> p_fechaPublicacion, string p_titulo, string p_cuerpo, bool p_pendienteModeracion, int p_muro, int p_creador)
{
        EntradaEN entradaEN = null;
        int oid;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.FechaPublicacion = p_fechaPublicacion;

        entradaEN.Titulo = p_titulo;

        entradaEN.Cuerpo = p_cuerpo;

        entradaEN.PendienteModeracion = p_pendienteModeracion;


        if (p_muro != -1) {
                // El argumento p_muro -> Property muro es oid = false
                // Lista de oids id
                entradaEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                entradaEN.Muro.Id = p_muro;
        }


        if (p_creador != -1) {
                // El argumento p_creador -> Property creador es oid = false
                // Lista de oids id
                entradaEN.Creador = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                entradaEN.Creador.Id = p_creador;
        }

        //Call to EntradaCAD

        oid = _IEntradaCAD.CrearEntrada (entradaEN);
        return oid;
}

public void ModificarEntrada (int p_oid, Nullable<DateTime> p_fechaPublicacion, string p_titulo, string p_cuerpo, bool p_pendienteModeracion)
{
        EntradaEN entradaEN = null;

        //Initialized EntradaEN
        entradaEN = new EntradaEN ();
        entradaEN.Id = p_oid;
        entradaEN.FechaPublicacion = p_fechaPublicacion;
        entradaEN.Titulo = p_titulo;
        entradaEN.Cuerpo = p_cuerpo;
        entradaEN.PendienteModeracion = p_pendienteModeracion;
        //Call to EntradaCAD

        _IEntradaCAD.ModificarEntrada (entradaEN);
}

public void BorrarEntrada (int id)
{
        _IEntradaCAD.BorrarEntrada (id);
}

public void AnyadirElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to EntradaCAD

        _IEntradaCAD.AnyadirElementosMultimedia (p_entrada, p_elementomultimedia);
}
public void BorrarElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to EntradaCAD

        _IEntradaCAD.BorrarElementosMultimedia (p_entrada, p_elementomultimedia);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorModerar (string p_filter)
{
        return _IEntradaCAD.ObtenerEntradasPorModerar (p_filter);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorMuro (int p_muro, int first, int size)
{
        return _IEntradaCAD.ObtenerEntradasPorMuro (p_muro, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorGrupo (int pe_ID)
{
        return _IEntradaCAD.ObtenerEntradasPendientesPorGrupo (pe_ID);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorUsuario (int pe_ID)
{
        return _IEntradaCAD.ObtenerEntradasPendientesPorUsuario (pe_ID);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroConModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, bool p_pendienteModeracion, int p_usuario, int first, int size)
{
        return _IEntradaCAD.DameEntradasFiltroConModeracion (p_titulo, p_cuerpo, p_fechaPublicacion, p_pendienteModeracion, p_usuario, first, size);
}
public System.Collections.Generic.IList<EntradaEN> DameTodasLasEntradas (int first, int size)
{
        System.Collections.Generic.IList<EntradaEN> list = null;

        list = _IEntradaCAD.DameTodasLasEntradas (first, size);
        return list;
}
public EntradaEN DameEntradaPorOID (int id)
{
        EntradaEN entradaEN = null;

        entradaEN = _IEntradaCAD.DameEntradaPorOID (id);
        return entradaEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroSinModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, int p_usuario, int first, int size)
{
        return _IEntradaCAD.DameEntradasFiltroSinModeracion (p_titulo, p_cuerpo, p_fechaPublicacion, p_usuario, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasPorMuro (int p_muro, int first, int size)
{
        return _IEntradaCAD.DameEntradasPorMuro (p_muro, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimedia (int pe_entrada)
{
        return _IEntradaCAD.ObtenerElementosMultimedia (pe_entrada);
}
}
}
