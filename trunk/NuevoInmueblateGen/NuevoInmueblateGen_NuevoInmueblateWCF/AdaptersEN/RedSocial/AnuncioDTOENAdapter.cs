
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class AnuncioDTOENAdapter {
public static AnuncioEN Convert (AnuncioDTO dto)
{
        AnuncioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new AnuncioEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Imagen = dto.Imagen;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.FechaCaducidad = dto.FechaCaducidad;
                        newinstance.Tipo = dto.Tipo;
                        newinstance.URL = dto.URL;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
