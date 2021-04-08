

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
 *      Definition of the class PaginaCorporativaCEN
 *
 */
public partial class PaginaCorporativaCEN
{
private IPaginaCorporativaCAD _IPaginaCorporativaCAD;

public PaginaCorporativaCEN()
{
        this._IPaginaCorporativaCAD = new PaginaCorporativaCAD ();
}

public PaginaCorporativaCEN(IPaginaCorporativaCAD _IPaginaCorporativaCAD)
{
        this._IPaginaCorporativaCAD = _IPaginaCorporativaCAD;
}

public IPaginaCorporativaCAD get_IPaginaCorporativaCAD ()
{
        return this._IPaginaCorporativaCAD;
}

public int CrearPaginaCorporativa (string p_contenido, string p_URL, int p_inmobiliaria)
{
        PaginaCorporativaEN paginaCorporativaEN = null;
        int oid;

        //Initialized PaginaCorporativaEN
        paginaCorporativaEN = new PaginaCorporativaEN ();
        paginaCorporativaEN.Contenido = p_contenido;

        paginaCorporativaEN.URL = p_URL;


        if (p_inmobiliaria != -1) {
                // El argumento p_inmobiliaria -> Property inmobiliaria es oid = false
                // Lista de oids id
                paginaCorporativaEN.Inmobiliaria = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN ();
                paginaCorporativaEN.Inmobiliaria.Id = p_inmobiliaria;
        }

        //Call to PaginaCorporativaCAD

        oid = _IPaginaCorporativaCAD.CrearPaginaCorporativa (paginaCorporativaEN);
        return oid;
}

public void ModificarPaginaCorporativa (int p_oid, string p_contenido, string p_URL)
{
        PaginaCorporativaEN paginaCorporativaEN = null;

        //Initialized PaginaCorporativaEN
        paginaCorporativaEN = new PaginaCorporativaEN ();
        paginaCorporativaEN.Id = p_oid;
        paginaCorporativaEN.Contenido = p_contenido;
        paginaCorporativaEN.URL = p_URL;
        //Call to PaginaCorporativaCAD

        _IPaginaCorporativaCAD.ModificarPaginaCorporativa (paginaCorporativaEN);
}

public void BorrarPaginaCorporativa (int id)
{
        _IPaginaCorporativaCAD.BorrarPaginaCorporativa (id);
}

public System.Collections.Generic.IList<PaginaCorporativaEN> DameTodasLasPaginas (int first, int size)
{
        System.Collections.Generic.IList<PaginaCorporativaEN> list = null;

        list = _IPaginaCorporativaCAD.DameTodasLasPaginas (first, size);
        return list;
}
public PaginaCorporativaEN DamePaginaCorporativaPorOID (int id)
{
        PaginaCorporativaEN paginaCorporativaEN = null;

        paginaCorporativaEN = _IPaginaCorporativaCAD.DamePaginaCorporativaPorOID (id);
        return paginaCorporativaEN;
}
}
}
