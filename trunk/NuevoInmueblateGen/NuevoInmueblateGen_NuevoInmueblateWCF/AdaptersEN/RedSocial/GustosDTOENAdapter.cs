
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class GustosDTOENAdapter {
public static GustosEN Convert (GustosDTO dto)
{
        GustosEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new GustosEN ();



                        newinstance.Id = dto.Id;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.Musica = dto.Musica;
                        newinstance.Libros = dto.Libros;
                        newinstance.Peliculas = dto.Peliculas;
                        newinstance.Juegos = dto.Juegos;
                        if (dto.Usuario_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
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
