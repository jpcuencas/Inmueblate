
using System;
// Definición clase GaleriaEN
namespace NuevoInmueblateGenNHibernate.EN.RedSocial
{
public partial class GaleriaEN                                                                      : NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN


{
/**
 *	Atributo elementosMultimedia
 */
private System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia;






public virtual System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ElementosMultimedia {
        get { return elementosMultimedia; } set { elementosMultimedia = value;  }
}





public GaleriaEN() : base ()
{
        elementosMultimedia = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>();
}



public GaleriaEN(int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia
                 , System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL
                 )
{
        this.init (Id, elementosMultimedia, mensaje, galeria, entradas, aparicionComentarios, inmueble, usuario, fecha, descripcion, nombre, pendienteModeracion, uRL);
}


public GaleriaEN(GaleriaEN galeria)
{
        this.init (Id, galeria.ElementosMultimedia, galeria.Mensaje, galeria.Galeria, galeria.Entradas, galeria.AparicionComentarios, galeria.Inmueble, galeria.Usuario, galeria.Fecha, galeria.Descripcion, galeria.Nombre, galeria.PendienteModeracion, galeria.URL);
}

private void init (int id, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> elementosMultimedia, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> mensaje, NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN galeria, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> entradas, System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> aparicionComentarios, NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN inmueble, NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN usuario, Nullable<DateTime> fecha, string descripcion, string nombre, bool pendienteModeracion, string uRL)
{
        this.Id = id;


        this.ElementosMultimedia = elementosMultimedia;

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
        GaleriaEN t = obj as GaleriaEN;
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
