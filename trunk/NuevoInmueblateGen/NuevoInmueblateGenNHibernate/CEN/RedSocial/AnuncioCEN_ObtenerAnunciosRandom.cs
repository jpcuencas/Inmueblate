
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
public partial class AnuncioCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> ObtenerAnunciosRandom (int pe_numero)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Anuncio_ObtenerAnunciosRandom) ENABLED START*/

        AnuncioCEN anuCEN = new AnuncioCEN ();
        Random w_random = new Random ();
        int w_totalAnuncios, w_numRand, w_i;

        System.Collections.Generic.IList<AnuncioEN> w_todosAnuncios = anuCEN.DameTodosLosAnuncios (1, 0);
        System.Collections.Generic.IList<AnuncioEN> w_listaAnuncios = new System.Collections.Generic.List<AnuncioEN>();
        w_totalAnuncios = w_todosAnuncios.Count;

        if (pe_numero > w_totalAnuncios) {
                pe_numero = w_totalAnuncios;
        }

        w_i = 0;
        while (w_i < pe_numero) {
                w_numRand = w_random.Next (w_totalAnuncios);
                if (!w_listaAnuncios.Contains (w_todosAnuncios [w_numRand])) {
                        w_listaAnuncios.Add (w_todosAnuncios [w_numRand]);
                        w_i++;
                }
        }
        return w_listaAnuncios;

        /*PROTECTED REGION END*/
}
}
}
