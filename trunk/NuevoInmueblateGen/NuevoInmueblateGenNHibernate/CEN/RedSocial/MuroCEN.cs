

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
 *      Definition of the class MuroCEN
 *
 */
public partial class MuroCEN
{
private IMuroCAD _IMuroCAD;

public MuroCEN()
{
        this._IMuroCAD = new MuroCAD ();
}

public MuroCEN(IMuroCAD _IMuroCAD)
{
        this._IMuroCAD = _IMuroCAD;
}

public IMuroCAD get_IMuroCAD ()
{
        return this._IMuroCAD;
}

public int CrearMuro (bool p_pendienteModeracion)
{
        MuroEN muroEN = null;
        int oid;

        //Initialized MuroEN
        muroEN = new MuroEN ();
        muroEN.PendienteModeracion = p_pendienteModeracion;

        //Call to MuroCAD

        oid = _IMuroCAD.CrearMuro (muroEN);
        return oid;
}

public void ModificarMuro (int p_oid, bool p_pendienteModeracion)
{
        MuroEN muroEN = null;

        //Initialized MuroEN
        muroEN = new MuroEN ();
        muroEN.Id = p_oid;
        muroEN.PendienteModeracion = p_pendienteModeracion;
        //Call to MuroCAD

        _IMuroCAD.ModificarMuro (muroEN);
}

public void BorrarMuro (int id)
{
        _IMuroCAD.BorrarMuro (id);
}

public void AsociarConGrupo (int p_muro, int p_grupo)
{
        //Call to MuroCAD

        _IMuroCAD.AsociarConGrupo (p_muro, p_grupo);
}
public void AsociarConUsuario (int p_muro, int p_superusuario)
{
        //Call to MuroCAD

        _IMuroCAD.AsociarConUsuario (p_muro, p_superusuario);
}
public void AnyadirEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        //Call to MuroCAD

        _IMuroCAD.AnyadirEntradas (p_muro, p_entrada);
}
public void BorrarEntradas (int p_muro, System.Collections.Generic.IList<int> p_entrada)
{
        //Call to MuroCAD

        _IMuroCAD.BorrarEntradas (p_muro, p_entrada);
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorUsuario (int p_usuario)
{
        return _IMuroCAD.ObtenerMuroPorUsuario (p_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN> ObtenerMuroPendienteModeracion ()
{
        return _IMuroCAD.ObtenerMuroPendienteModeracion ();
}
public MuroEN DameMuroPorOID (int id)
{
        MuroEN muroEN = null;

        muroEN = _IMuroCAD.DameMuroPorOID (id);
        return muroEN;
}

public System.Collections.Generic.IList<MuroEN> DameTodosLosMuros (int first, int size)
{
        System.Collections.Generic.IList<MuroEN> list = null;

        list = _IMuroCAD.DameTodosLosMuros (first, size);
        return list;
}
public NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ObtenerMuroPorGrupo (int p_grupo)
{
        return _IMuroCAD.ObtenerMuroPorGrupo (p_grupo);
}
}
}
