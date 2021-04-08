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
    class MuroViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<EntradaDTO> entradas = null;
        EntradaDTO selectedEntrada;
        MuroDTO muro;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        bool enableFiltro;

        public MuroViewModel(MuroDTO m, string breadcrumb)
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            muro = m;
            enableFiltro = false;

            NavigationViewModel.Instance.Cabecera = "Gestión de Muro";
            NavigationViewModel.Instance.Breadcrumbs +=  breadcrumb;
            service = new ServiceClient();
            
            entradas = service.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(muro.Id, inicioPaginacion + 1);
            
            if (entradas.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Entradas = service.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(muro.Id, inicioPaginacion);

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

        public bool EnableFiltro
        {
            get { return enableFiltro; }
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

        public IList<EntradaDTO> Entradas
        {
            get { return entradas; }
            set
            {
                if (entradas != value)
                {
                    entradas = value;
                    RaisePropertyChanged("Entradas");
                }
            }
        }

        public EntradaDTO SelectedItem
        {
            get { return selectedEntrada; }
            set
            {
                selectedEntrada = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.EntradaDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradaDetalleViewModel(selectedEntrada, "> Detalles de la entrada con ID: " + selectedEntrada.Id + " ");
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (entradas.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;

                entradas = service.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(muro.Id, inicioPaginacion + 1);

                if (entradas.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Entradas = service.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(muro.Id, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;

                Entradas = service.NuevoInmueblate_Entrada_ObtenerEntradasPorMuro(muro.Id, inicioPaginacion);

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
