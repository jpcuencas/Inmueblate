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
    class EntradasViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<EntradaDTO> entradas = null;
        EntradaDTO selectedEntrada;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string tituloFiltro;
        string cuerpoFiltro;
        Nullable<DateTime> fechaFiltro;
        string moderacionFiltroString;

        string p_titulo;
        string p_cuerpo;
        Nullable<DateTime> p_fecha;
        bool p_pendienteModeracion;
        bool p_moderacion;

        int p_usuario = -1;

        public EntradasViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            ModeracionFiltroString = "Todos";
            
            p_titulo = null;
            p_cuerpo = null;
            p_fecha = null;
            p_moderacion = false;
            p_pendienteModeracion = false;
            
            NavigationViewModel.Instance.Cabecera = "Gestión de todas las entradas";
            NavigationViewModel.Instance.Breadcrumbs = "Entradas ";
            service = new ServiceClient();
            entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion + 1, tamPaginacion);

            if (entradas.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion, tamPaginacion);

            PaginacionRetrocederEnabled = false;
        }

        public EntradasViewModel(int usuario, string breadcrumb)
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            ModeracionFiltroString = "Todos";

            p_usuario = usuario;

            p_titulo = null;
            p_cuerpo = null;
            p_fecha = null;
            p_moderacion = false;
            p_pendienteModeracion = false;

            NavigationViewModel.Instance.Cabecera = "Gestión de todas las entradas";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            service = new ServiceClient();
            entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion + 1, tamPaginacion);

            if (entradas.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion, tamPaginacion);

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

        public string TituloFiltro
        {
            get { return tituloFiltro; }
            set { tituloFiltro = value; RaisePropertyChanged("TituloFiltro"); }
        }

        public string CuerpoFiltro
        {
            get { return cuerpoFiltro; }
            set { cuerpoFiltro = value; RaisePropertyChanged("CuerpoFiltro"); }
        }

        public string[] Moderacion
        {
            get 
            {
                IList<string> listaModeracion = new List<string>();
                listaModeracion.Add("Todos");
                listaModeracion.Add("Moderados");
                listaModeracion.Add("Pendientes");
                return listaModeracion.ToArray();
            }
        }

        public string ModeracionFiltroString
        {
            get { return moderacionFiltroString; }
            set { moderacionFiltroString = value; RaisePropertyChanged("ModeracionFiltroString"); }
        }

        public Nullable<DateTime> FechaFiltro
        {
            get { return fechaFiltro; }
            set { fechaFiltro = value; RaisePropertyChanged("FechaFiltro"); }
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
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.EntradaDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradaDetalleViewModel(selectedEntrada, "> Detalles de la entrada con ID: " + selectedEntrada.Id + " ");
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            if (moderacionFiltroString != null && moderacionFiltroString == "Todos")
            {
                p_moderacion = false;
                p_pendienteModeracion = false;
            }
            if (moderacionFiltroString != null && moderacionFiltroString == "Moderados")
            {
                p_moderacion = true;
                p_pendienteModeracion = false;
            }
            if (moderacionFiltroString != null && moderacionFiltroString == "Pendientes")
            {
                p_moderacion = true;
                p_pendienteModeracion = true;
            }
            
            p_titulo = tituloFiltro;
            p_cuerpo = cuerpoFiltro;
            p_fecha = fechaFiltro;

            entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion + 1, tamPaginacion);

            PaginacionRetrocederEnabled = false;

            if (entradas.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion, tamPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (entradas.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion + 1, tamPaginacion);

                if (entradas.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion, tamPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Entradas = service.NuevoInmueblate_Entrada_DameEntradasFiltro(p_titulo, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_usuario, inicioPaginacion, tamPaginacion);

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
