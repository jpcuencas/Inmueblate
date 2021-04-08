
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class GaleriaAdapter {
public static GaleriaDTO Convert (GaleriaEN en)
{
        GaleriaDTO newinstance = null;

        if (en != null) {
                newinstance = new GaleriaDTO ();


                if (en.ElementosMultimedia != null) {
                        newinstance.ElementosMultimedia_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN entry in en.ElementosMultimedia)
                                newinstance.ElementosMultimedia_oid.Add (entry.Id);
                }
                newinstance.Id = en.Id;
                if (en.Mensaje != null) {
                        newinstance.Mensaje_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN entry in en.Mensaje)
                                newinstance.Mensaje_oid.Add (entry.Id);
                }
                if (en.Galeria != null) {
                        newinstance.Galeria_oid = en.Galeria.Id;
                }
                if (en.Entradas != null) {
                        newinstance.Entradas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entry in en.Entradas)
                                newinstance.Entradas_oid.Add (entry.Id);
                }
                if (en.AparicionComentarios != null) {
                        newinstance.AparicionComentarios_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN entry in en.AparicionComentarios)
                                newinstance.AparicionComentarios_oid.Add (entry.Id);
                }
                if (en.Inmueble != null) {
                        newinstance.Inmueble_oid = en.Inmueble.Id;
                }
                if (en.Usuario != null) {
                        newinstance.Usuario_oid = en.Usuario.Id;
                }
                newinstance.Fecha = en.Fecha;
                newinstance.Descripcion = en.Descripcion;
                newinstance.Nombre = en.Nombre;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.URL = en.URL;
        }

        return newinstance;
}
}
}
