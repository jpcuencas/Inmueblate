
using System;
// Definición clase FotografiaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class FotografiaEN                                                                   : NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN


{
public FotografiaEN() : base ()
{
}



public FotografiaEN(int id,
                    System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL
                    )
{
        this.init (Id, mensaje, galeria, entradas, aparicionComentarios, inmueble, usuario, fecha, descripcion, nombre, pendienteModeracion, uRL);
}


public FotografiaEN(FotografiaEN fotografia)
{
        this.init (Id, fotografia.Mensaje, fotografia.Galeria, fotografia.Entradas, fotografia.AparicionComentarios, fotografia.Inmueble, fotografia.Usuario, fotografia.Fecha, fotografia.Descripcion, fotografia.Nombre, fotografia.PendienteModeracion, fotografia.URL);
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
        FotografiaEN t = obj as FotografiaEN;
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
