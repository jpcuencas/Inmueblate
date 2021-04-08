using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;
using System.Globalization;
// using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;

namespace GestorInmobiliaria.viewmodels
{
    class EventoDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        EventoDTO itemEvento = null;
        InmobiliariaDTO inmobiliariaEvento = null;
        GeolocalizacionDTO geolocalizacionEvento = null;

        public EventoDetalleViewModel()
        {
            itemEvento = new EventoDTO();
            NavigationViewModel.Instance.Cabecera = "Creación de un nuevo evento";
        }

        public EventoDetalleViewModel(EventoDTO evento, string breadcrumb)
        {
            itemEvento = evento;
            NavigationViewModel.Instance.Cabecera = "Detalle de un evento";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            service = new ServiceClient();
            inmobiliariaEvento = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemEvento.Inmobiliaria_oid);
            geolocalizacionEvento = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(itemEvento.Geolocalizacion_oid);
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

        public int Id
        {
            get { return itemEvento.Id; }
            set { itemEvento.Id = value; }
        }

        public string Nombre
        {
            get { return itemEvento.Nombre; }
            set { itemEvento.Nombre = value; }
        }

        public string Descripcion
        {
            get { return itemEvento.Descripcion; }
            set { itemEvento.Descripcion = value; }
        }

        public Nullable<DateTime> Fecha
        {
            get { return itemEvento.Fecha; }
            set { itemEvento.Fecha = value; }
        }

        
        public ServiceReference1.TipoEventoEnum Categoria
        {
            get { return itemEvento.Categoria; }
        }

        public GeolocalizacionDTO Geolocalizacion
        {
            get { return geolocalizacionEvento; }
        }

        public InmobiliariaDTO Inmobiliaria
        {
            get { return inmobiliariaEvento; }
        }

        public string Mapa
        {
            get
            {
                string retorno = "http://maps.google.com/maps?q=" + geolocalizacionEvento.Longitud.ToString("F9", CultureInfo.InvariantCulture) + "," + geolocalizacionEvento.Latitud.ToString("F9", CultureInfo.InvariantCulture);
                return retorno;
            }
        }

        /*
        public string URL
        {
            get { return itemEvento.URL; }
            set { itemEvento.URL = value; }
        }
        */
        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand EventoBorrarCommand { get { return new RelayCommand(EventoBorrarCommandExecute); } }
        //public RelayCommand EventoCrearCommand { get { return new RelayCommand(EventoCrearCommandExecute); } }
        public RelayCommand EventoModificarCommand { get { return new RelayCommand(EventoModificarCommandExecute); } }
        public RelayCommand EventoGuardarCommand { get { return new RelayCommand(EventoGuardarCommandExecute); } }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
        }

        public void EventoBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este evento?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Evento_BorrarEvento(itemEvento.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Eventos.Eventos();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
                
                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
            }
        }
        /*
        public void EventoCrearCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea crear este evento?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Evento_CrearEvento(
                    NuevoInmueblate_Evento_CrearEvento(itemEvento.Nombre, itemEvento.Descripcion, itemEvento.Fecha, itemEvento.Categoria);
                NavigationViewModel.Instance.CurrentPage = new views.Eventos.Eventos();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
            }
        }
        */
        public void EventoModificarCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Eventos.EventoModificar();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EventoDetalleViewModel();
        }

        public void EventoGuardarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar este evento?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Evento_ModificarEvento(itemEvento.Id, itemEvento.Nombre, itemEvento.Descripcion, itemEvento.Fecha, itemEvento.Categoria);
                NavigationViewModel.Instance.CurrentPage = new views.Eventos.Eventos();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
            }
        }

        #endregion
    }
}
