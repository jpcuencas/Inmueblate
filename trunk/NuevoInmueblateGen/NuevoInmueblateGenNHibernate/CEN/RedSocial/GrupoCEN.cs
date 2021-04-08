

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
 *      Definition of the class GrupoCEN
 *
 */
public partial class GrupoCEN
{
private IGrupoCAD _IGrupoCAD;

public GrupoCEN()
{
        this._IGrupoCAD = new GrupoCAD ();
}

public GrupoCEN(IGrupoCAD _IGrupoCAD)
{
        this._IGrupoCAD = _IGrupoCAD;
}

public IGrupoCAD get_IGrupoCAD ()
{
        return this._IGrupoCAD;
}

public int CrearGrupo (NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum p_tipo, string p_nombre, string p_descripcion, int p_muro)
{
        GrupoEN grupoEN = null;
        int oid;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Tipo = p_tipo;

        grupoEN.Nombre = p_nombre;

        grupoEN.Descripcion = p_descripcion;


        if (p_muro != -1) {
                // El argumento p_muro -> Property muro es oid = false
                // Lista de oids id
                grupoEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                grupoEN.Muro.Id = p_muro;
        }

        //Call to GrupoCAD

        oid = _IGrupoCAD.CrearGrupo (grupoEN);
        return oid;
}

public void ModificarGrupo (int p_oid, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum p_tipo, string p_nombre, string p_descripcion)
{
        GrupoEN grupoEN = null;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Id = p_oid;
        grupoEN.Tipo = p_tipo;
        grupoEN.Nombre = p_nombre;
        grupoEN.Descripcion = p_descripcion;
        //Call to GrupoCAD

        _IGrupoCAD.ModificarGrupo (grupoEN);
}

public void BorrarGrupo (int id)
{
        _IGrupoCAD.BorrarGrupo (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> ObtenerGruposConEntradasReportadas ()
{
        return _IGrupoCAD.ObtenerGruposConEntradasReportadas ();
}
public System.Collections.Generic.IList<GrupoEN> DameTodosLosGrupos (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> list = null;

        list = _IGrupoCAD.DameTodosLosGrupos (first, size);
        return list;
}
public GrupoEN DameGrupoPorOID (int id)
{
        GrupoEN grupoEN = null;

        grupoEN = _IGrupoCAD.DameGrupoPorOID (id);
        return grupoEN;
}
}
}
