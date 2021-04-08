
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class PaginaCorporativaAdapter {
public static PaginaCorporativaDTO Convert (PaginaCorporativaEN en)
{
        PaginaCorporativaDTO newinstance = null;

        if (en != null) {
                newinstance = new PaginaCorporativaDTO ();


                newinstance.Id = en.Id;
                newinstance.Contenido = en.Contenido;
                newinstance.URL = en.URL;
                if (en.Inmobiliaria != null) {
                        newinstance.Inmobiliaria_oid = en.Inmobiliaria.Id;
                }
        }

        return newinstance;
}
}
}
