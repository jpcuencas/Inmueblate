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
    class HabitacionesViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<HabitacionDTO> habitaciones = null;
        HabitacionDTO selectedHabitacion = null;
        InmuebleDTO selectedInmueble = null;
        GeolocalizacionDTO selectedGeolocalizacion = null;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string descripcionFiltro;
        string metrosCuadradosFiltro;
        string direccionFiltro;
        string poblacionFiltro;

        int p_inmueble;
        string p_descripcion;
        int p_metrosCuadrados;
        string p_direccion;
        string p_poblacion;

        public HabitacionesViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            
            p_inmueble = -1;
            p_descripcion = null;
            p_metrosCuadrados = -1;
            p_direccion = null;
            p_poblacion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión de todas las habitaciones";
            NavigationViewModel.Instance.Breadcrumbs = "Habitaciones ";

            service = new ServiceClient();

            habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion + 1);

            if (habitaciones.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion);
            
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

        public GeolocalizacionDTO SelectedGeolocalizacion
        {
            get
            {
                return selectedGeolocalizacion;
            }
        }
        
        public int Inquilinos
        {
            get 
            {
                int retorno = 0;
                if(selectedHabitacion != null)
                    retorno = selectedHabitacion.Inquilinos_oid.Count();

                return retorno;
            }
        }

        public HabitacionDTO SelectedItem
        {
            get { return selectedHabitacion; }
            set 
            { 
                selectedHabitacion = value;
                selectedInmueble = service.NuevoInmueblate_Inmueble_DameInmueblePorOID(selectedHabitacion.Inmueble_oid);
                selectedGeolocalizacion = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(selectedInmueble.Geolocalizacion_oid);
                RaisePropertyChanged("SelectedItem");
                RaisePropertyChanged("Inquilinos");
                RaisePropertyChanged("SelectedInmueble");
                RaisePropertyChanged("SelectedGeolocalizacion");
            }
        }

        public IList<HabitacionDTO> Habitaciones
        {
            get { return habitaciones; }
            set
            {
                if (habitaciones != value)
                {
                    habitaciones = value;
                    RaisePropertyChanged("Habitaciones");
                }
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

        public InmuebleDTO SelectedInmueble
        {
            get
            {
                return selectedInmueble;
            }
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

            p_direccion = direccionFiltro;
            p_poblacion = poblacionFiltro;

            habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion + 1);

            PaginacionRetrocederEnabled = false;

            if (habitaciones.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion);
        }

        public void SelectionChangedCommandExecute()
        {
            if (selectedHabitacion != null)
            {
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Habitacion.HabitacionDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new HabitacionDetalleViewModel(selectedHabitacion, "> Detalles de la habitación con ID: " + selectedHabitacion.Id + " ");
            }
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (habitaciones.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion + 1);

                if (habitaciones.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Habitaciones = service.NuevoInmueblate_Habitacion_DameHabitacionFiltro(p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, inicioPaginacion);

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
