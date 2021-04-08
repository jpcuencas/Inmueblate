
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class MuroAdapter {
public static MuroDTO Convert (MuroEN en)
{
        MuroDTO newinstance = null;

        if (en != null) {
                newinstance = new MuroDTO ();


                newinstance.Id = en.Id;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                if (en.PropietarioUsuario != null) {
                        newinstance.PropietarioUsuario_oid = en.PropietarioUsuario.Id;
                }
                if (en.PropietarioGrupo != null) {
                        newinstance.PropietarioGrupo_oid = en.PropietarioGrupo.Id;
                }
                if (en.Entradas != null) {
                        newinstance.Entradas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN entry in en.Entradas)
                                newinstance.Entradas_oid.Add (entry.Id);
                }
        }

        return newinstance;
}
}
}
