using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using GestorInmobiliaria.views;
using System.Windows;

namespace GestorInmobiliaria.viewmodels
{
    class InmueblesViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<InmuebleDTO> inmuebles = null;
        InmuebleDTO selectedInmueble;
        GeolocalizacionDTO geolocalizacion;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string descripcionFiltro;
        string metrosCuadradosFiltro;
        string precioFiltro;
        string tipoFiltroString = "Todas";
        string direccionFiltro;
        string poblacionFiltro;

        int p_inmobiliaria;
        string p_descripcion;
        int p_metrosCuadrados;
        int p_precio;
        int p_filtro;
        string p_direccion;
        string p_poblacion;

        public InmueblesViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_inmobiliaria = -1;
            p_descripcion = null;
            p_metrosCuadrados = -1;
            p_precio = -1;
            p_filtro = -1;
            p_direccion = null;
            p_poblacion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión de todos los inmuebles";
            NavigationViewModel.Instance.Breadcrumbs = "Inmuebles ";

            service = new ServiceClient();

            inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion + 1);
            
            if (inmuebles.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion);
            
            PaginacionRetrocederEnabled = false;
        }

        public InmueblesViewModel(InmobiliariaDTO inmobiliaria, string breadcrumb)
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_inmobiliaria = inmobiliaria.Id;
            p_descripcion = null;
            p_metrosCuadrados = -1;
            p_precio = -1;
            p_filtro = -1;
            p_direccion = null;
            p_poblacion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión los inmuebles de la inmobiliaria " + inmobiliaria.Nombre;
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            service = new ServiceClient();

            inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion + 1);

            if (inmuebles.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion);

            PaginacionRetrocederEnabled = false;
        }

        #region Validation

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region Properties

        public IList<InmuebleDTO> Inmuebles
        {
            get { return inmuebles; }
            set
            {
                if (inmuebles != value)
                {
                    inmuebles = value;
                    RaisePropertyChanged("Inmuebles");
                }
            }
        }

        public InmuebleDTO SelectedItem
        {
            get { return selectedInmueble; }
            set
            {
                selectedInmueble = value;
                geolocalizacion = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(selectedInmueble.Geolocalizacion_oid);
                RaisePropertyChanged("SelectedItem");
                RaisePropertyChanged("Direccion");
                RaisePropertyChanged("Poblacion");
                RaisePropertyChanged("Habitaciones");
                RaisePropertyChanged("Inquilinos");
            }
        }

        public string Direccion
        {
            get
            {
                string retorno = "";
                
                if (geolocalizacion != null)
                    retorno = geolocalizacion.Direccion;

                return retorno;
            }
        }

        public string Poblacion
        {
            get
            {
                string retorno = "";

                if (geolocalizacion != null)
                    retorno = geolocalizacion.Poblacion;

                return retorno;
            }
        }

        public int Habitaciones
        {
            get 
            {
                int retorno = 0;
                if(selectedInmueble != null)
                    retorno = selectedInmueble.Habitaciones_oid.Count();
                return retorno;
            }
        }

        public int Inquilinos
        {
            get
            {
                int retorno = 0;
                if (selectedInmueble != null)
                    retorno = selectedInmueble.Inquilinos_oid.Count();
                return retorno;
            }
        }

        public bool PaginacionRetrocederEnabled
        {
            get { return paginacionRetrocederEnabled; }
            set { paginacionRetrocederEnabled = value; RaisePropertyChanged("PaginacionRetrocederEnabled"); }
        }

        public bool PaginacionAvanzarEnabled
        {
            get { return paginacionAvanzarEnabled; }
            set { paginacionAvanzarEnabled = value; RaisePropertyChanged("PaginacionAvanzarEnabled"); }
        }

        public string DescripcionFiltro
        {
            get { return descripcionFiltro; }
            set { descripcionFiltro = value; RaisePropertyChanged("DescripcionFiltro"); }
        }

        public string MetrosCuadradosFiltro
        {
            get { return metrosCuadradosFiltro; }
            set { metrosCuadradosFiltro = value; RaisePropertyChanged("MetrosCuadradosFiltro"); }
        }

        public string PrecioFiltro
        {
            get { return precioFiltro; }
            set { precioFiltro = value; RaisePropertyChanged("PrecioFiltro"); }
        }

        public string[] Tipos
        {
            get { 
                IList<string> listaTipos = new List<string>();
                listaTipos.Add("Todas");
                foreach (string Tipo in Enum.GetNames(typeof(ServiceReference1.TipoInmuebleEnum)))
                    listaTipos.Add(Tipo);
                return listaTipos.ToArray();
            }
            set { }
        }

        public string TipoFiltroString
        {
            get { return tipoFiltroString; }
            set { tipoFiltroString = value; RaisePropertyChanged("TipoFiltroString"); }
        }

        public string DireccionFiltro
        {
            get { return direccionFiltro; }
            set { direccionFiltro = value; RaisePropertyChanged("DireccionFiltro"); }
        }

        public string PoblacionFiltro
        {
            get { return poblacionFiltro; }
            set { poblacionFiltro = value; RaisePropertyChanged("PoblacionFiltro"); }
        }

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;
            
            if (tipoFiltroString != null && tipoFiltroString != "Todas")
                p_filtro = (int)(ServiceReference1.TipoInmuebleEnum)Enum.Parse(typeof(ServiceReference1.TipoInmuebleEnum), tipoFiltroString);
            else
                p_filtro = -1;

            p_descripcion = descripcionFiltro;

            if (metrosCuadradosFiltro == null || metrosCuadradosFiltro == "")
                p_metrosCuadrados = -1;
            else
            {
                try
                {
                    p_metrosCuadrados = Convert.ToInt32(metrosCuadradosFiltro);
                }
                catch (Exception)
                {
                    MetrosCuadradosFiltro = "";
                    p_metrosCuadrados = -1;
                }
            }

            if (precioFiltro == null || precioFiltro == "")
                p_precio = -1;
            else
            {
                try { p_precio = Convert.ToInt32(precioFiltro); }
                catch (Exception) { PrecioFiltro = ""; p_precio = -1; }
            }
            
            p_direccion = direccionFiltro;
            p_poblacion = poblacionFiltro;

            Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion + 1);
            
            PaginacionRetrocederEnabled = false;

            if (inmuebles.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion);
        }

        public void SelectionChangedCommandExecute()
        {
            if (selectedInmueble != null)
            {
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Inmueble.InmuebleDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmuebleDetalleViewModel(selectedInmueble, "> Detalles del inmueble con ID: " + selectedInmueble.Id + " ");
            }
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (inmuebles.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion + 1);

                if (inmuebles.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Inmuebles = service.NuevoInmueblate_Inmueble_DameInmuebleFiltro(p_inmobiliaria, p_descripcion, p_filtro, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, inicioPaginacion);
                
                PaginacionAvanzarEnabled = true;

                if (inicioPaginacion == 0)
                {
                    PaginacionRetrocederEnabled = false;
                }
            }
        }

        #endregion
    }
}
