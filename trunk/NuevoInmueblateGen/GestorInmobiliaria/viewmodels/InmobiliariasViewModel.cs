using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using GestorInmobiliaria.views;

namespace GestorInmobiliaria.viewmodels
{
    class InmobiliariasViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<InmobiliariaDTO> inmobiliarias = null;
        InmobiliariaDTO selectedInmobiliaria;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string nombreFiltro;
        string cifFiltro;
        string emailFiltro;
        string descripcionFiltro;
        string direccionFiltro;
        string poblacionFiltro;

        string p_nombre;
        string p_cif;
        string p_email;
        string p_descripcion;
        string p_direccion;
        string p_poblacion;

        public InmobiliariasViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_nombre = null;
            p_cif = null;
            p_email = null;
            p_descripcion = null;
            p_direccion = null;
            p_poblacion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión de Inmobiliarias";
            NavigationViewModel.Instance.Breadcrumbs = "Inmobiliarias ";

            service = new ServiceClient();
            inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion + 1);

            if (inmobiliarias.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion);

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

        public string NombreFiltro
        {
            get { return nombreFiltro; }
            set { nombreFiltro = value; RaisePropertyChanged("NombreFiltro"); }
        }

        public string CifFiltro
        {
            get { return cifFiltro; }
            set { cifFiltro = value; RaisePropertyChanged("CifFiltro"); }
        }

        public string EmailFiltro
        {
            get { return emailFiltro; }
            set { emailFiltro = value; RaisePropertyChanged("EmailFiltro"); }
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

        public string DescripcionFiltro
        {
            get { return descripcionFiltro; }
            set { descripcionFiltro = value; RaisePropertyChanged("DescripcionFiltro"); }
        }
        
        public IList<InmobiliariaDTO> Inmobiliarias
        {
            get { return inmobiliarias; }
            set
            {
                if (inmobiliarias != value)
                {
                    inmobiliarias = value;
                    RaisePropertyChanged("Inmobiliarias");
                }
            }
        }

        public InmobiliariaDTO SelectedItem
        {
            get { return selectedInmobiliaria; }
            set
            {
                selectedInmobiliaria = value;
                RaisePropertyChanged("SelectedItem");
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

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.InmobiliariaDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariaDetalleViewModel(selectedInmobiliaria, "> Detalles de la inmobiliaria con Id: " + selectedInmobiliaria.Id + " ");

            //NavigationViewModel.Instance.CenterWindowOnScreen();
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            p_cif = cifFiltro;
            p_email = emailFiltro;
            p_descripcion = descripcionFiltro;
            p_nombre = nombreFiltro;
            p_direccion = direccionFiltro;
            p_poblacion = poblacionFiltro;

            inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion + 1);

            PaginacionRetrocederEnabled = false;

            if (inmobiliarias.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (inmobiliarias.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion + 1);

                if (inmobiliarias.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Inmobiliarias = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaFiltro(p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, inicioPaginacion);

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
