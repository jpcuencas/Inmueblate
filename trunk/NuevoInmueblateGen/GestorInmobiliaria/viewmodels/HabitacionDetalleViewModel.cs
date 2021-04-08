using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;

namespace GestorInmobiliaria.viewmodels
{
    class HabitacionDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        HabitacionDTO itemHabitacion = null;
        InmuebleDTO inmueble = null;
        IList<CaracteristicaDTO> listaCaracteristicas = new List<CaracteristicaDTO>();

        GeolocalizacionDTO geolocalizacion;

        public HabitacionDetalleViewModel(HabitacionDTO habitacion, string breadcrumb)
        {
            service = new ServiceClient();
            itemHabitacion = habitacion;

            NavigationViewModel.Instance.Cabecera = "Detalle de la habitación";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            inmueble = service.NuevoInmueblate_Inmueble_DameInmueblePorOID(habitacion.Inmueble_oid);
            geolocalizacion = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(inmueble.Geolocalizacion_oid);

            foreach (int i in habitacion.Caracteristicas_oid)
            {
                listaCaracteristicas.Add(service.NuevoInmueblate_Caracteristica_DameCaracteristicaPorOID(i));
            }
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

        public IList<CaracteristicaDTO> Caracteristicas
        {
            get { return listaCaracteristicas; }
        }

        public GeolocalizacionDTO Geolocalizacion
        {
            get { return geolocalizacion; }
        }

        public InmuebleDTO Inmueble
        {
            get { return inmueble; }
        }

        public HabitacionDTO Habitacion
        {
            get { return itemHabitacion; }
        }

        public int Inquilinos
        {
            get
            {
                return itemHabitacion.Inquilinos_oid.Count();
            }
        }

        #endregion

        #region Commands

        public RelayCommand NavegarInmobiliariaCommand { get { return new RelayCommand(NavegarInmobiliariaCommandExecute); } }
        public RelayCommand NavegarInquilinoCommand { get { return new RelayCommand(NavegarInquilinoCommandExecute); } }

        public void NavegarInquilinoCommandExecute()
        {
            if (itemHabitacion.Inquilinos_oid != null && itemHabitacion.Inquilinos_oid.Count() > 0)
            {
                UsuarioDTO inquilino = service.NuevoInmueblate_Usuario_DameUsuarioPorOID(itemHabitacion.Inquilinos_oid[0]);
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(inquilino, "> Detalles del inquilino con Id " + inquilino.Id + " ");
            }
        }

        public void NavegarInmobiliariaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Inmueble.InmuebleDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmuebleDetalleViewModel(inmueble, "> Detalles del inmueble con Id " + inmueble.Id + " ");
        }
        #endregion
    }
}
