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
    class UsuariosViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<UsuarioDTO> usuarios = null;
        UsuarioDTO selectedUsuario;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string apellidosFiltro;
        string nifFiltro;
        string emailFiltro;
        Nullable<DateTime> fechaNacimientoFiltro;
        string direccionFiltro;
        string poblacionFiltro;

        string p_apellidos;
        string p_nif;
        string p_email;
        Nullable<DateTime> p_fechaNacimiento;
        string p_direccion;
        string p_poblacion;

        public UsuariosViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_apellidos = null;
            p_nif = null;
            p_email = null;
            p_fechaNacimiento = null;
            p_direccion = null;
            p_poblacion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión de Usuarios";
            NavigationViewModel.Instance.Breadcrumbs = "Usuarios ";

            service = new ServiceClient();
            Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(null, null, null, null, null, null, inicioPaginacion + 1);

            if (usuarios.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(null, null, null, null, null, null, inicioPaginacion);

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

        public string ApellidosFiltro
        {
            get { return apellidosFiltro; }
            set { apellidosFiltro = value; RaisePropertyChanged("ApellidosFiltro"); }
        }

        public string NifFiltro
        {
            get { return nifFiltro;}
            set { nifFiltro = value; RaisePropertyChanged("NifFiltro"); }
        }

        public string EmailFiltro
        {
            get { return emailFiltro; }
            set { emailFiltro = value; RaisePropertyChanged("EmailFiltro"); }
        }

        public Nullable<DateTime> FechaNacimientoFiltro
        {
            get { return fechaNacimientoFiltro; }
            set { fechaNacimientoFiltro = value; RaisePropertyChanged("FechaNacimientoFiltro"); }
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
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(selectedUsuario, "> Detalles del usuario con Id: " + selectedUsuario.Id + " ");
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            p_nif = nifFiltro;
            p_email = emailFiltro; 
            p_apellidos = apellidosFiltro;
            p_fechaNacimiento = fechaNacimientoFiltro;
            p_direccion = direccionFiltro;
            p_poblacion = poblacionFiltro;

            Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, inicioPaginacion + 1);

            PaginacionRetrocederEnabled = false;

            if (usuarios.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, inicioPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (usuarios.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, inicioPaginacion + 1);

                if (usuarios.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Usuarios = service.NuevoInmueblate_Usuario_DameUsuariosFiltro(p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, inicioPaginacion);

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
