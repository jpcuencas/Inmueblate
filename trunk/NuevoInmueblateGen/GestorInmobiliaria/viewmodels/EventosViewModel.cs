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
    class EventosViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<EventoDTO> eventos = null;
        EventoDTO selectedEvento;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string nombreFiltro;
        string descripcionFiltro;
        string categoriaFiltroString = "Todas";
        Nullable<DateTime> fechaFiltro;

        string p_nombre;
        string p_descripcion;
        int p_categoria;
        Nullable<DateTime> p_fecha;

        public EventosViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;

            p_nombre = null;
            p_descripcion = null;
            p_categoria = -1; // TODO: Categoria no filtra
            fechaFiltro = null;
            
            NavigationViewModel.Instance.Cabecera = "Gestión de todos los eventos";
            NavigationViewModel.Instance.Breadcrumbs = "Eventos ";

            service = new ServiceClient();

            eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion + 1);
            if (eventos.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion);

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

        public IList<EventoDTO> Eventos
        {
            get { return eventos; }
            set
            {
                if (eventos != value)
                {
                    eventos = value;
                    RaisePropertyChanged("Eventos");
                }
            }
        }

        public EventoDTO SelectedItem
        {
            get { return selectedEvento; }
            set
            {
                selectedEvento = value;
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
            get{return descripcionFiltro;}
            set { descripcionFiltro = value; RaisePropertyChanged("DescripcionFiltro"); }

        }

        public string[] Categorias
        {
            get 
            {
                IList<string> listaCategorias = new List<string>();
                listaCategorias.Add(categoriaFiltroString);
                foreach (string Categoria in Enum.GetNames(typeof(ServiceReference1.TipoEventoEnum)))
                {
                    listaCategorias.Add(Categoria);
                }
                return listaCategorias.ToArray();
            }
            set { }
        }

        public string CategoriaFiltroString
        {
            get { return categoriaFiltroString; }
            set { categoriaFiltroString = value; RaisePropertyChanged("CategoriaFiltroString"); }
        }

        public Nullable<DateTime> FechaFiltro
        {
            get { return fechaFiltro; }
            set { fechaFiltro = value; RaisePropertyChanged("FechaFiltro"); }
        }
        
        #endregion

        #region Commands

        public RelayCommand EventoBorrarCommand { get { return new RelayCommand(EventoBorrarCommandExecute); } }
        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Eventos.EventoDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EventoDetalleViewModel(selectedEvento, "> Detalles del evento con ID: " + selectedEvento.Id + " ");
        }

        public void EventoBorrarCommandExecute()
        {
            if (selectedEvento != null && selectedEvento.Id != 0)
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este evento?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ServiceClient service = new ServiceClient();
                    service.NuevoInmueblate_Evento_BorrarEvento(selectedEvento.Id);
                    NavigationViewModel.Instance.CurrentPage = new views.Eventos.Eventos();
                    NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();

                    //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                    // Error al modificar el dataContext aquí, deja de navegar
                    // NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
                }
            }
            else
                MessageBox.Show("Debes selecionar un elemento", "Información");
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            if (categoriaFiltroString != null && categoriaFiltroString != "Todas")
                p_categoria = (int)(ServiceReference1.TipoEventoEnum)Enum.Parse(typeof(ServiceReference1.TipoEventoEnum), categoriaFiltroString);
            else
                p_categoria = -1;

            p_descripcion = descripcionFiltro;
            p_fecha = fechaFiltro;
            p_nombre = nombreFiltro;

            Eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion + 1);

            PaginacionRetrocederEnabled = false;

            if (eventos.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (eventos.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion + 1);

                if (eventos.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion + 1);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Eventos = service.NuevoInmueblate_Evento_DameEventosFiltro(p_nombre, p_descripcion, p_fecha, p_categoria, inicioPaginacion + 1);

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
