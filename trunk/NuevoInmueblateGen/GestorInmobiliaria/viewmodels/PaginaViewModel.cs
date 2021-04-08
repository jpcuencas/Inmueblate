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
    class PaginasViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<PaginaCorporativaDTO> paginas = null;
        PaginaCorporativaDTO selectedPagina;

        public PaginasViewModel()
        {
            NavigationViewModel.Instance.Cabecera = "Gestión de todos las paginas";
            service = new ServiceClient();
            paginas = service.NuevoInmueblate_PaginaCorporativa_DameTodasLasPaginas();
            //paginas = service.NuevoInmueblate_Moderador_GetAllPaginaCorporativa();
            
            
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

        public IList<PaginaCorporativaDTO> Paginas
        {
            get { return paginas; }
            set
            {
                if (paginas != value)
                {
                    paginas = value;
                    RaisePropertyChanged("Paginas");
                }
            }
        }

        public PaginaCorporativaDTO SelectedItem
        {
            get { return selectedPagina; }
            set
            {
                selectedPagina = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region Commands

        //public RelayCommand NuevoPaginaCommand { get { return new RelayCommand(NuevoPaginaCommandExecute); } }
        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Paginas.PaginaDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new PaginaDetalleViewModel(selectedPagina, "> Detalle de la página (no debería salir)");

            //NavigationViewModel.Instance.CenterWindowOnScreen();
        }
        /*
        public void NuevoPaginaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Pagina.PaginaNuevo();
            NavigationViewModel.Instance.CurrentPage.DataContext = new PaginaDetalleViewModel();
        }
        */
        #endregion
    }
}
