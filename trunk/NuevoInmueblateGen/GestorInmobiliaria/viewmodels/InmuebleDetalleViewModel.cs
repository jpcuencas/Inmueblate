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
    class InmuebleDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        InmuebleDTO itemInmueble = null;
        InmobiliariaDTO inmobiliaria = null;
        IList<CaracteristicaDTO> listaCaracteristicas = new List<CaracteristicaDTO>();

        GeolocalizacionDTO geolocalizacion;

        public InmuebleDetalleViewModel(InmuebleDTO inmueble, string breadcrumb)
        {
            service = new ServiceClient();
            itemInmueble = inmueble;
            
            NavigationViewModel.Instance.Cabecera = "Detalle de inmueble";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            
            geolocalizacion = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(itemInmueble.Geolocalizacion_oid);
            inmobiliaria = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemInmueble.Inmobiliaria_oid);

            foreach (int i in itemInmueble.Caracteristicas_oid)
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
            get { return itemInmueble; }
        }

        public int Habitaciones
        {
            get { return itemInmueble.Habitaciones_oid.Count(); }
        }

        public string Inmobiliaria
        {
            get
            {
                string retorno = "";
                if (inmobiliaria != null)
                {
                    retorno = inmobiliaria.Nombre;
                }
                return retorno;
            }
        }

        public int Inquilinos
        {
            get
            {
                return itemInmueble.Inquilinos_oid.Count();
            }
        }

        #endregion

        #region Commands

        public RelayCommand NavegarInmobiliariaCommand { get { return new RelayCommand(NavegarInmobiliariaCommandExecute); } }

        public void NavegarInmobiliariaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.InmobiliariaDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariaDetalleViewModel(inmobiliaria, "> Detalles de la inmobiliaria propietaria con Id: " + inmobiliaria.Id + " ");
        }

        #endregion
    }
}
