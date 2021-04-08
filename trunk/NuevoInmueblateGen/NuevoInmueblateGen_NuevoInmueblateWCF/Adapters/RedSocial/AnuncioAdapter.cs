
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class AnuncioAdapter {
public static AnuncioDTO Convert (AnuncioEN en)
{
        AnuncioDTO newinstance = null;

        if (en != null) {
                newinstance = new AnuncioDTO ();


                newinstance.Id = en.Id;
                newinstance.Imagen = en.Imagen;
                newinstance.Descripcion = en.Descripcion;
                newinstance.FechaCaducidad = en.FechaCaducidad;
                newinstance.Tipo = en.Tipo;
                newinstance.URL = en.URL;
        }

        return newinstance;
}
}
}
