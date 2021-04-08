

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
 *      Definition of the class VideoCEN
 *
 */
public partial class VideoCEN
{
private IVideoCAD _IVideoCAD;

public VideoCEN()
{
        this._IVideoCAD = new VideoCAD ();
}

public VideoCEN(IVideoCAD _IVideoCAD)
{
        this._IVideoCAD = _IVideoCAD;
}

public IVideoCAD get_IVideoCAD ()
{
        return this._IVideoCAD;
}

public int CrearVideo (int p_galeria, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        VideoEN videoEN = null;
        int oid;

        //Initialized VideoEN
        videoEN = new VideoEN ();

        if (p_galeria != -1) {
                // El argumento p_galeria -> Property galeria es oid = false
                // Lista de oids id
                videoEN.Galeria = new NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ();
                videoEN.Galeria.Id = p_galeria;
        }

        videoEN.Fecha = p_fecha;

        videoEN.Descripcion = p_descripcion;

        videoEN.Nombre = p_nombre;

        videoEN.PendienteModeracion = p_pendienteModeracion;

        videoEN.URL = p_URL;

        //Call to VideoCAD

        oid = _IVideoCAD.CrearVideo (videoEN);
        return oid;
}

public void ModificarVideo (int p_Video_OID, Nullable<DateTime> p_fecha, string p_descripcion, string p_nombre, bool p_pendienteModeracion, string p_URL)
{
        VideoEN videoEN = null;

        //Initialized VideoEN
        videoEN = new VideoEN ();
        videoEN.Id = p_Video_OID;
        videoEN.Fecha = p_fecha;
        videoEN.Descripcion = p_descripcion;
        videoEN.Nombre = p_nombre;
        videoEN.PendienteModeracion = p_pendienteModeracion;
        videoEN.URL = p_URL;
        //Call to VideoCAD

        _IVideoCAD.ModificarVideo (videoEN);
}

public void BorrarVideo (int id)
{
        _IVideoCAD.BorrarVideo (id);
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerTodosVideosPorModerar ()
{
        return _IVideoCAD.ObtenerTodosVideosPorModerar ();
}
public VideoEN DameVideoPorOID (int id)
{
        VideoEN videoEN = null;

        videoEN = _IVideoCAD.DameVideoPorOID (id);
        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> DameTodosLosVideos (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> list = null;

        list = _IVideoCAD.DameTodosLosVideos (first, size);
        return list;
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorUsuario (int pe_usuario, int first, int size)
{
        return _IVideoCAD.ObtenerVideosPorUsuario (pe_usuario, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorGaleria (int pe_galeria, int first, int size)
{
        return _IVideoCAD.ObtenerVideosPorGaleria (pe_galeria, first, size);
}
}
}
