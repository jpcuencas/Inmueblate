using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CommonMvvm;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;

namespace GestorInmobiliaria.viewmodels
{
    class GrupoDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        GrupoDTO itemGrupo = null;
        ServiceClient service = null;
        MuroDTO muroGrupo = null;

        PreferenciasBusquedaDTO selectedPreferenciasBusqueda;
        GeolocalizacionDTO selectedGeolocalizacion;

        public GrupoDetalleViewModel(GrupoDTO grupo, string breadcrumb)
        {
            itemGrupo = grupo;
            NavigationViewModel.Instance.Cabecera = "Detalle de un grupo";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            
            service = new ServiceClient();

            muroGrupo = service.NuevoInmueblate_Muro_DameMuroPorOID(itemGrupo.Muro_oid);

            selectedPreferenciasBusqueda = service.NuevoInmueblate_PreferenciasBusqueda_DamePreferenciasBusquedaPorOID(itemGrupo.PreferenciasBusqueda_oid);
            if (selectedPreferenciasBusqueda != null)
                selectedGeolocalizacion = service.NuevoInmueblate_Geolocalizacion_DameGeolocalizacionPorOID(selectedPreferenciasBusqueda.Geolocalizacion_oid);
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

        public PreferenciasBusquedaDTO PreferenciasBusqueda
        {
            get { return selectedPreferenciasBusqueda; }
        }

        public GeolocalizacionDTO Geolocalizacion
        {
            get { return selectedGeolocalizacion; }
        }

        public string Nombre
        {
            get { return itemGrupo.Nombre; }
            set { }
        }

        public TipoGrupoEnum Tipo
        {
            get { return itemGrupo.Tipo; }
            set { }
        }

        public string Descripcion
        {
            get { return itemGrupo.Descripcion; }
            set { }
        }

        public int Miembros
        {
            get { return itemGrupo.Miembros_oid.Count(); }
        }

        public int Entradas
        {
            get 
            {
                return muroGrupo.Entradas_oid.Count();
            }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand GrupoBorrarCommand { get { return new RelayCommand(GrupoBorrarCommandExecute); } }
        public RelayCommand EnviarMensajeCommand { get { return new RelayCommand(EnviarMensajeCommandExecute); } }
        public RelayCommand NavegarMuroCommand { get { return new RelayCommand(NavegarMuroCommandExecute); } }
        public RelayCommand NavegarMiembrosCommand { get { return new RelayCommand(NavegarMiembrosCommandExecute); } }

        public void NavegarMiembrosCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.Usuarios();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MiembrosGrupoViewModel(itemGrupo, "> Miembros del grupo con Id: " + itemGrupo.Id + " ");
        }

        public void NavegarMuroCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MuroViewModel(muroGrupo, "> Entradas del muro con Id: " + muroGrupo.Id + " ");
        }

        public void EnviarMensajeCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensaje.EnviarMensaje();
            NavigationViewModel.Instance.CurrentPage.DataContext = new CrearMensajeViewModel(itemGrupo, "", "", "> Mensaje al usuario con Id: " + itemGrupo.Id + " ");
        }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Grupo.Grupos();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.GruposViewModel();
        }

        public void GrupoBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar grupo?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                service.NuevoInmueblate_Grupo_BorrarGrupo(itemGrupo.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Grupo.Grupos();
                NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.GruposViewModel();
            }
        }

        #endregion
    }
}
