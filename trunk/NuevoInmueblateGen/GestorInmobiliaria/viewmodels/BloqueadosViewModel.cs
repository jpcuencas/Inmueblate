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
    class BloqueadosViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<UsuarioDTO> usuarios = null;
        UsuarioDTO selectedUsuario;
        UsuarioDTO usuarioBloqueados;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        bool enableFiltro;

        public BloqueadosViewModel(UsuarioDTO usuario, string breadcrumb)
        {
            usuarioBloqueados = usuario;

            inicioPaginacion = 0;
            tamPaginacion = 10;

            enableFiltro = false;

            NavigationViewModel.Instance.Cabecera = "Gestión de Usuarios";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            service = new ServiceClient();
            Usuarios = service.NuevoInmueblate_Usuario_ObtenerBloqueados(usuarioBloqueados.Id, inicioPaginacion + 1);

            if (usuarios.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Usuarios = service.NuevoInmueblate_Usuario_ObtenerBloqueados(usuarioBloqueados.Id, inicioPaginacion);

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

        public IList<UsuarioDTO> Usuarios
        {
            get { return usuarios; }
            set
            {
                if (usuarios != value)
                {
                    usuarios = value;
                    RaisePropertyChanged("Usuarios");
                }
            }
        }

        public UsuarioDTO SelectedItem
        {
            get { return selectedUsuario; }
            set
            {
                selectedUsuario = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

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

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(selectedUsuario, "> Detalles del usuario con Id: " + selectedUsuario.Id + " ");
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (usuarios.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                usuarios = service.NuevoInmueblate_Usuario_ObtenerBloqueados(usuarioBloqueados.Id, inicioPaginacion + 1);

                if (usuarios.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Usuarios = service.NuevoInmueblate_Usuario_ObtenerBloqueados(usuarioBloqueados.Id, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Usuarios = service.NuevoInmueblate_Usuario_ObtenerBloqueados(usuarioBloqueados.Id, inicioPaginacion);

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
