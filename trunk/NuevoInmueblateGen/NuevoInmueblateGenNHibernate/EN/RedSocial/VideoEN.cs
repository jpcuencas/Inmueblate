
using System;
// Definición clase VideoEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class VideoEN                                                                        : NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN


{
public VideoEN() : base ()
{
}



public VideoEN(int id,
               System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL
               )
{
        this.init (Id, mensaje, galeria, entradas, aparicionComentarios, inmueble, usuario, fecha, descripcion, nombre, pendienteModeracion, uRL);
}


public VideoEN(VideoEN video)
{
        this.init (Id, video.Mensaje, video.Galeria, video.Entradas, video.AparicionComentarios, video.Inmueble, video.Usuario, video.Fecha, video.Descripcion, video.Nombre, video.PendienteModeracion, video.URL);
}

private void init (int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL)
{
        this.Id = id;


        this.Mensaje = mensaje;

        this.Galeria = galeria;

        this.Entradas = entradas;

        this.AparicionComentarios = aparicionComentarios;

        this.Inmueble = inmueble;

        this.Usuario = usuario;

        this.Fecha = fecha;

        this.Descripcion = descripcion;

        this.Nombre = nombre;

        this.PendienteModeracion = pendienteModeracion;

        this.URL = uRL;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideoEN t = obj as VideoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
