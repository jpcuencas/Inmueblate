using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Areas.Usuarios.Models
{
    public class ModelosEntradas
    {
        /**
         * Funciones de ordenar por cualidad
         * y demas...
         **/
        private List<EntradaEN> entradas;

        List<EntradaEN> getEntradas()
        {
            return entradas;
        }

    }
}