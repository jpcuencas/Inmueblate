

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
 *      Definition of the class GustosCEN
 *
 */
public partial class GustosCEN
{
private IGustosCAD _IGustosCAD;

public GustosCEN()
{
        this._IGustosCAD = new GustosCAD ();
}

public GustosCEN(IGustosCAD _IGustosCAD)
{
        this._IGustosCAD = _IGustosCAD;
}

public IGustosCAD get_IGustosCAD ()
{
        return this._IGustosCAD;
}

public int CrearGustos (bool p_pendienteModeracion, int p_usuario)
{
        GustosEN gustosEN = null;
        int oid;

        //Initialized GustosEN
        gustosEN = new GustosEN ();
        gustosEN.PendienteModeracion = p_pendienteModeracion;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                gustosEN.Usuario = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                gustosEN.Usuario.Id = p_usuario;
        }

        //Call to GustosCAD

        oid = _IGustosCAD.CrearGustos (gustosEN);
        return oid;
}

public void ModificarGustos (int p_oid, bool p_pendienteModeracion, System.Collections.Generic.IList<string> p_musica, System.Collections.Generic.IList<string> p_libros, System.Collections.Generic.IList<string> p_peliculas, System.Collections.Generic.IList<string> p_juegos)
{
        GustosEN gustosEN = null;

        //Initialized GustosEN
        gustosEN = new GustosEN ();
        gustosEN.Id = p_oid;
        gustosEN.PendienteModeracion = p_pendienteModeracion;
        gustosEN.Musica = p_musica;
        gustosEN.Libros = p_libros;
        gustosEN.Peliculas = p_peliculas;
        gustosEN.Juegos = p_juegos;
        //Call to GustosCAD

        _IGustosCAD.ModificarGustos (gustosEN);
}

public void BorrarGustos (int id)
{
        _IGustosCAD.BorrarGustos (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN> ObtenerGustosPendienteModeracion ()
{
        return _IGustosCAD.ObtenerGustosPendienteModeracion ();
}
public GustosEN DameGustosPorOID (int id)
{
        GustosEN gustosEN = null;

        gustosEN = _IGustosCAD.DameGustosPorOID (id);
        return gustosEN;
}

public System.Collections.Generic.IList<GustosEN> DameTodosLosGustos (int first, int size)
{
        System.Collections.Generic.IList<GustosEN> list = null;

        list = _IGustosCAD.DameTodosLosGustos (first, size);
        return list;
}
}
}
