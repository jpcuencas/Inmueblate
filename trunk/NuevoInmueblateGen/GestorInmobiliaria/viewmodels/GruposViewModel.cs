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
    class GruposViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<GrupoDTO> grupos = null;
        GrupoDTO selectedGrupo;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string nombreFiltro;
        string descripcionFiltro;
        string tipoFiltroString = "Todas";
        
        string p_nombre;
        string p_descripcion;
        int p_tipo;

        public GruposViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_nombre = null;
            p_descripcion = null;
            p_tipo = -1;

            NavigationViewModel.Instance.Cabecera = "Gestión de todos los grupos";
            NavigationViewModel.Instance.Breadcrumbs = "Grupos ";

            service = new ServiceClient();
            grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion + 1);

            if (grupos.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion);

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

        public IList<GrupoDTO> Grupos
        {
            get { return grupos; }
            set { grupos = value; RaisePropertyChanged("Grupos"); }
        }

        public GrupoDTO SelectedItem
        {
            get { return selectedGrupo; }
            set 
            { 
                selectedGrupo = value; 
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

        public string NombreFiltro
        {
            get { return nombreFiltro; }
            set { nombreFiltro = value; RaisePropertyChanged("NombreFiltro"); }
        }

        public string DescripcionFiltro
        {
            get { return descripcionFiltro; }
            set { descripcionFiltro = value; RaisePropertyChanged("DescripcionFiltro"); }
        }

        public string[] Tipos
        {
            get
            {
                IList<string> listaTipos = new List<string>();
                listaTipos.Add("Todas");
                foreach (string Tipo in Enum.GetNames(typeof(ServiceReference1.TipoGrupoEnum)))
                    listaTipos.Add(Tipo);
                return listaTipos.ToArray();
            }
        }

        public string TipoFiltroString
        {
            get { return tipoFiltroString; }
            set { tipoFiltroString = value; RaisePropertyChanged("TipoFiltroString"); }
        }

        public int Miembros
        {
            get 
            {
                int retorno = 0;
                if(selectedGrupo!=null) 
                    retorno = selectedGrupo.Miembros_oid.Count();
                return retorno;
            }
        }

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Grupo.GrupoDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.GrupoDetalleViewModel(selectedGrupo, "> Detalles del grupo con ID: " + selectedGrupo.Id + " ");
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            if (tipoFiltroString != null && tipoFiltroString != "Todas")
                p_tipo = (int)(ServiceReference1.TipoGrupoEnum)Enum.Parse(typeof(ServiceReference1.TipoGrupoEnum), tipoFiltroString);
            else
                p_tipo = -1;

            p_nombre = nombreFiltro;
            p_descripcion = descripcionFiltro;

            grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion + 1);

            PaginacionRetrocederEnabled = false;

            if (grupos.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (grupos.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion + 1);

                if (grupos.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Grupos = service.NuevoInmueblate_Grupo_DameGruposFiltro(p_tipo, p_nombre, p_descripcion, inicioPaginacion);

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
