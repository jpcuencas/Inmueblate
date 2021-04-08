
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class GustosAdapter {
public static GustosDTO Convert (GustosEN en)
{
        GustosDTO newinstance = null;

        if (en != null) {
                newinstance = new GustosDTO ();


                newinstance.Id = en.Id;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.Musica = en.Musica;
                newinstance.Libros = en.Libros;
                newinstance.Peliculas = en.Peliculas;
                newinstance.Juegos = en.Juegos;
                if (en.Usuario != null) {
                        newinstance.Usuario_oid = en.Usuario.Id;
                }
        }

        return newinstance;
}
}
}
