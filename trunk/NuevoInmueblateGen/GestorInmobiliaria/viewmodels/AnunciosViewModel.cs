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
    class AnunciosViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<AnuncioDTO> anuncios = null;
        AnuncioDTO selectedAnuncio;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string tipoFiltroString = "Todas";
        Nullable<DateTime> fechaFiltro;
        string urlFiltro;
        string descripcionFiltro;

        int p_filtro;
        Nullable<DateTime> p_fechaCaducidad;
        string p_url;
        string p_descripcion;

        public AnunciosViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 3;
            
            p_filtro = -1;
            p_fechaCaducidad = null;
            p_url = null;
            p_descripcion = null;

            NavigationViewModel.Instance.Cabecera = "Gestión de todos los anuncios";
            NavigationViewModel.Instance.Breadcrumbs = "Anuncios ";

            service = new ServiceClient();

            // Así puedo comprobar si hay más páginas, para habilitar o deshabilitar el botón de paginación

            anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion + 1);
            
            if (anuncios.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion);
            
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

        public IList<AnuncioDTO> Anuncios
        {
            get { return anuncios; }
            set
            {
                if (anuncios != value)
                {
                    anuncios = value;
                    RaisePropertyChanged("Anuncios");
                }
            }
        }

        public AnuncioDTO SelectedItem
        {
            get { return selectedAnuncio; }
            set
            {
                selectedAnuncio = value;
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

        public string UrlFiltro
        {
            get { return urlFiltro; }
            set { urlFiltro = value; RaisePropertyChanged("UrlFiltro"); }
        }

        public string DescripcionFiltro
        {
            get { return descripcionFiltro; }
            set { descripcionFiltro = value; RaisePropertyChanged("DescripcionFiltro"); }
        }

        public string[] Tipos
        {
            get { 
                IList<string> listaTipos = new List<string>();
                listaTipos.Add("Todas");
                foreach (string Tipo in Enum.GetNames(typeof(ServiceReference1.TipoAnuncioEnum)))
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

        public Nullable<DateTime> FechaFiltro
        {
            get { return fechaFiltro; }
            set { fechaFiltro = value; RaisePropertyChanged("FechaFiltro"); }
        }

        #endregion

        #region Commands

        public RelayCommand NuevoAnuncioCommand { get { return new RelayCommand(NuevoAnuncioCommandExecute); } }
        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }
        public RelayCommand AnuncioBorrarCommand { get { return new RelayCommand(AnuncioBorrarCommandExecute); } }
        public RelayCommand AnuncioModificarCommand { get { return new RelayCommand(AnuncioModificarCommandExecute); } }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            if (tipoFiltroString != null && tipoFiltroString != "Todas")
                p_filtro = (int)(ServiceReference1.TipoAnuncioEnum)Enum.Parse(typeof(ServiceReference1.TipoAnuncioEnum), tipoFiltroString);
            else
                p_filtro = -1;

            p_fechaCaducidad = fechaFiltro;
            p_url = urlFiltro;
            p_descripcion = descripcionFiltro;

            Anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion + 1);
            
            PaginacionRetrocederEnabled = false;

            if (anuncios.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion);
        }

        public void SelectionChangedCommandExecute()
        {
            if (selectedAnuncio != null)
            {
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Anuncio.AnuncioDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new AnuncioDetalleViewModel(selectedAnuncio, "> Detalles del anuncio con ID: " + selectedAnuncio.Id + " ");
            }
        }

        public void NuevoAnuncioCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Anuncio.AnuncioNuevo();
            NavigationViewModel.Instance.CurrentPage.DataContext = new AnuncioDetalleViewModel("> Creación de un nuevo anuncio ");
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (anuncios.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion + 1);

                if (anuncios.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Anuncios = service.NuevoInmueblate_Anuncio_DameAnunciosFiltro(p_filtro, p_fechaCaducidad, p_url, p_descripcion, inicioPaginacion);
                
                PaginacionAvanzarEnabled = true;

                if (inicioPaginacion == 0)
                {
                    PaginacionRetrocederEnabled = false;
                }
            }
        }

        public void AnuncioBorrarCommandExecute()
        {
            // TODO: No se borra la imagen al eliminar un anuncio
            if (selectedAnuncio != null)
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este anuncio?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ServiceClient service = new ServiceClient();
                    service.NuevoInmueblate_Anuncio_BorrarAnuncio(selectedAnuncio.Id);
                    NavigationViewModel.Instance.cleanBack();
                    NavigationViewModel.Instance.CurrentPage = new views.Anuncio.Anuncios();
                    NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado un anuncio que borrar", "Información");
            }
        }

        public void AnuncioModificarCommandExecute()
        {
            if (selectedAnuncio != null)
            {
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Anuncio.AnuncioModificar();
                NavigationViewModel.Instance.CurrentPage.DataContext = new AnuncioDetalleViewModel(selectedAnuncio, "> Modificación del anuncio con ID: " + selectedAnuncio.Id + " ");
            }
            else
            {
                MessageBox.Show("No ha seleccionado un anuncio que modificar", "Información");
            }
        }

        #endregion
    }
}
