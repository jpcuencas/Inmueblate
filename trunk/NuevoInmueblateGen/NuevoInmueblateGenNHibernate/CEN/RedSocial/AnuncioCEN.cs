

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
 *      Definition of the class AnuncioCEN
 *
 */
public partial class AnuncioCEN
{
private IAnuncioCAD _IAnuncioCAD;

public AnuncioCEN()
{
        this._IAnuncioCAD = new AnuncioCAD ();
}

public AnuncioCEN(IAnuncioCAD _IAnuncioCAD)
{
        this._IAnuncioCAD = _IAnuncioCAD;
}

public IAnuncioCAD get_IAnuncioCAD ()
{
        return this._IAnuncioCAD;
}

public int CrearAnuncio (string p_imagen, string p_descripcion, Nullable<DateTime> p_fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum p_tipo, string p_URL)
{
        AnuncioEN anuncioEN = null;
        int oid;

        //Initialized AnuncioEN
        anuncioEN = new AnuncioEN ();
        anuncioEN.Imagen = p_imagen;

        anuncioEN.Descripcion = p_descripcion;

        anuncioEN.FechaCaducidad = p_fechaCaducidad;

        anuncioEN.Tipo = p_tipo;

        anuncioEN.URL = p_URL;

        //Call to AnuncioCAD

        oid = _IAnuncioCAD.CrearAnuncio (anuncioEN);
        return oid;
}

public void ModificarAnuncio (int p_oid, string p_imagen, string p_descripcion, Nullable<DateTime> p_fechaCaducidad, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum p_tipo, string p_URL)
{
        AnuncioEN anuncioEN = null;

        //Initialized AnuncioEN
        anuncioEN = new AnuncioEN ();
        anuncioEN.Id = p_oid;
        anuncioEN.Imagen = p_imagen;
        anuncioEN.Descripcion = p_descripcion;
        anuncioEN.FechaCaducidad = p_fechaCaducidad;
        anuncioEN.Tipo = p_tipo;
        anuncioEN.URL = p_URL;
        //Call to AnuncioCAD

        _IAnuncioCAD.ModificarAnuncio (anuncioEN);
}

public void BorrarAnuncio (int id)
{
        _IAnuncioCAD.BorrarAnuncio (id);
}

public AnuncioEN DameAnuncioPorOID (int id)
{
        AnuncioEN anuncioEN = null;

        anuncioEN = _IAnuncioCAD.DameAnuncioPorOID (id);
        return anuncioEN;
}
}
}
