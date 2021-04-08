

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
 *      Definition of the class ElementoMultimediaCEN
 *
 */
public partial class ElementoMultimediaCEN
{
private IElementoMultimediaCAD _IElementoMultimediaCAD;

public ElementoMultimediaCEN()
{
        this._IElementoMultimediaCAD = new ElementoMultimediaCAD ();
}

public ElementoMultimediaCEN(IElementoMultimediaCAD _IElementoMultimediaCAD)
{
        this._IElementoMultimediaCAD = _IElementoMultimediaCAD;
}

public IElementoMultimediaCAD get_IElementoMultimediaCAD ()
{
        return this._IElementoMultimediaCAD;
}

public int CrearElementoMultimedia (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        ElementoMultimediaEN elementoMultimediaEN = null;
        int oid;

        //Initialized ElementoMultimediaEN
        elementoMultimediaEN = new ElementoMultimediaEN ();

        if (p_galeria != -1) {
                // El argumento p_galeria -> Property galeria es oid = false
                // Lista de oids id
                elementoMultimediaEN.Galeria = new NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ();
                elementoMultimediaEN.Galeria.Id = p_galeria;
        }

        elementoMultimediaEN.Fecha = p_fecha;

        elementoMultimediaEN.Descripcion = p_descripcion;

        elementoMultimediaEN.Nombre = p_nombre;

        elementoMultimediaEN.PendienteModeracion = p_pendienteModeracion;

        elementoMultimediaEN.URL = p_URL;

        //Call to ElementoMultimediaCAD

        oid = _IElementoMultimediaCAD.CrearElementoMultimedia (elementoMultimediaEN);
        return oid;
}

public void ModificarElementoMultimedia (int p_ElementoMultimedia_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        ElementoMultimediaEN elementoMultimediaEN = null;

        //Initialized ElementoMultimediaEN
        elementoMultimediaEN = new ElementoMultimediaEN ();
        elementoMultimediaEN.Id = p_ElementoMultimedia_OID;
        elementoMultimediaEN.Fecha = p_fecha;
        elementoMultimediaEN.Descripcion = p_descripcion;
        elementoMultimediaEN.Nombre = p_nombre;
        elementoMultimediaEN.PendienteModeracion = p_pendienteModeracion;
        elementoMultimediaEN.URL = p_URL;
        //Call to ElementoMultimediaCAD

        _IElementoMultimediaCAD.ModificarElementoMultimedia (elementoMultimediaEN);
}

public void BorrarElementoMultimedia (int id)
{
        _IElementoMultimediaCAD.BorrarElementoMultimedia (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementoPendienteModeracion ()
{
        return _IElementoMultimediaCAD.ObtenerElementoPendienteModeracion ();
}
public ElementoMultimediaEN DameElementoMultimediaPorOID (int id)
{
        ElementoMultimediaEN elementoMultimediaEN = null;

        elementoMultimediaEN = _IElementoMultimediaCAD.DameElementoMultimediaPorOID (id);
        return elementoMultimediaEN;
}

public System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosLosElementosMultimedia (int first, int size)
{
        System.Collections.Generic.IList<ElementoMultimediaEN> list = null;

        list = _IElementoMultimediaCAD.DameTodosLosElementosMultimedia (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimediaPorUsuario (int pe_usuario, int first, int size)
{
        return _IElementoMultimediaCAD.ObtenerElementosMultimediaPorUsuario (pe_usuario, first, size);
}
public void AnyadirUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID)
{
        //Call to ElementoMultimediaCAD

        _IElementoMultimediaCAD.AnyadirUsuario (p_ElementoMultimedia_OID, p_usuario_OID);
}
public void EliminarUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID)
{
        //Call to ElementoMultimediaCAD

        _IElementoMultimediaCAD.EliminarUsuario (p_ElementoMultimedia_OID, p_usuario_OID);
}
public System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosElementosMultimediaP (int first, int size)
{
        System.Collections.Generic.IList<ElementoMultimediaEN> list = null;

        list = _IElementoMultimediaCAD.DameTodosElementosMultimediaP (first, size);
        return list;
}
}
}
