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
    class UsuarioDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        UsuarioDTO itemUsuario = null;

        EntradaDTO selectedEntrada;
        PreferenciasBusquedaDTO selectedPreferenciasBusqueda;
        GeolocalizacionDTO selectedGeolocalizacion;
        

        public UsuarioDetalleViewModel(UsuarioDTO usuario, string breadcrumb)
        {
            service = new ServiceClient();
            itemUsuario = usuario;
            NavigationViewModel.Instance.Cabecera = "Detalle del usuario";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            selectedPreferenciasBusqueda = service.NuevoInmueblate_PreferenciasBusqueda_DamePreferenciasBusquedaPorOID(itemUsuario.PreferenciasBusqueda_oid);
            if(selectedPreferenciasBusqueda != null)
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

        public int Id
        {
            get { return itemUsuario.Id; }
            set { itemUsuario.Id = value; }
        }

        public string Nombre
        {
            get { return itemUsuario.Nombre; }
            set { itemUsuario.Nombre = value; }
        }

        public string Apellidos
        {
            get { return itemUsuario.Apellidos; }
            set { itemUsuario.Apellidos = value; }
        }

        public string NombreCompleto
        {
            get { return itemUsuario.Nombre + " " + itemUsuario.Apellidos; }
        }

        public Nullable<DateTime> FechaNacimiento
        {
            get { return itemUsuario.FechaNacimiento; }
            set { itemUsuario.FechaNacimiento = value; }
        }

        public string Email
        {
            get { return itemUsuario.Email; }
            set { itemUsuario.Email = value; }
        }

        public string Nif
        {
            get { return itemUsuario.Nif; }
            set { itemUsuario.Nif = value; }
        }

        public ServiceReference1.TipoPrivacidadEnum Privacidad
        {
            get { return itemUsuario.Privacidad; }
            set { itemUsuario.Privacidad = value; }
        }

        public string Telefono
        {
            get { return itemUsuario.Telefono; }
            set { itemUsuario.Telefono = value; }
        }

        public string Pais
        {
            get { return itemUsuario.Pais; }
            set { itemUsuario.Pais = value; }
        }

        public float ValoracionMedia
        {
            get { return itemUsuario.ValoracionMedia; }
            set { itemUsuario.ValoracionMedia = value; }
        }

        public string Poblacion
        {
            get { return itemUsuario.Poblacion; }
            set { itemUsuario.Poblacion = value; }
        }

        public string CodigoPostal
        {
            get { return itemUsuario.CodigoPostal; }
            set { itemUsuario.CodigoPostal = value; }
        }

        public string Direccion
        {
            get { return itemUsuario.Direccion; }
            set { itemUsuario.Direccion = value; }
        }

        public EntradaDTO SelectedItem
        {
            get { return selectedEntrada; }
            set { selectedEntrada = value; RaisePropertyChanged("SelectedItem"); }
        }

        public int Amigos
        {
            get { return itemUsuario.ListaAmigos_oid.Count(); }
        }

        public int BandejaEntrada
        {
            get { return itemUsuario.MensajesRecibidos_oid.Count(); }
        }

        public int BandejaSalida
        {
            get { return itemUsuario.MensajesEnviados_oid.Count(); }
        }

        public int Bloqueados
        {
            get { return itemUsuario.ListaBloqueados_oid.Count(); }
        }

        public int Grupos
        {
            get { return itemUsuario.Grupos_oid.Count(); }
        }

        public int Habitaciones
        {
            get { return itemUsuario.Habitaciones_oid.Count(); }
        }

        public int Inmuebles
        {
            get { return itemUsuario.Inmuebles_oid.Count(); }
        }

        public int Muro
        {
            get { return itemUsuario.Entradas_oid.Count(); }
        }

        #endregion

        #region Commands
        public RelayCommand UsuarioBorrarCommand { get { return new RelayCommand(UsuarioBorrarCommandExecute); } }
        public RelayCommand NavegarAmigosCommand { get { return new RelayCommand(NavegarAmigosCommandExecute); } }
        public RelayCommand NavegarBloqueadosCommand { get { return new RelayCommand(NavegarBloqueadosCommandExecute); } }
        public RelayCommand NavegarMuroCommand { get { return new RelayCommand(NavegarMuroCommandExecute); } }
        public RelayCommand NavegarBandejaSalidaCommand { get { return new RelayCommand(NavegarBandejaSalidaCommandExecute); } }
        public RelayCommand NavegarBandejaEntradaCommand { get { return new RelayCommand(NavegarBandejaEntradaCommandExecute); } }
        public RelayCommand EnviarMensajeCommand { get { return new RelayCommand(EnviarMensajeCommandExecute); } }
        public RelayCommand NavegarInmuebleCommand { get { return new RelayCommand(NavegarInmuebleCommandExecute); } }
        public RelayCommand NavegarHabitacionCommand { get { return new RelayCommand(NavegarHabitacionCommandExecute); } }

        public void NavegarHabitacionCommandExecute()
        {
            if (itemUsuario.Habitaciones_oid != null && itemUsuario.Habitaciones_oid.Count() > 0)
            {
                HabitacionDTO habitacion = service.NuevoInmueblate_Habitacion_DameHabitacionPorOID(itemUsuario.Habitaciones_oid[0]);

                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Habitacion.HabitacionDetalle();

                NavigationViewModel.Instance.CurrentPage.DataContext = new HabitacionDetalleViewModel(habitacion, "> Detalles de la habitación con Id " + habitacion.Id + " ");
            }
        }

        public void NavegarInmuebleCommandExecute()
        {
            if (itemUsuario.Inmuebles_oid != null && itemUsuario.Inmuebles_oid.Count() > 0)
            {
                InmuebleDTO inmueble = service.NuevoInmueblate_Inmueble_DameInmueblePorOID(itemUsuario.Inmuebles_oid[0]);

                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Inmueble.InmuebleDetalle();

                NavigationViewModel.Instance.CurrentPage.DataContext = new InmuebleDetalleViewModel(inmueble, "> Detalles del inmueble con Id " + inmueble.Id + " ");
            }
        }

        public void EnviarMensajeCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensaje.EnviarMensaje();
            NavigationViewModel.Instance.CurrentPage.DataContext = new CrearMensajeViewModel(itemUsuario,"","","> Mensaje al usuario con Id: " + itemUsuario.Id + " ");
        }

        public void NavegarBandejaSalidaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel(itemUsuario, true ,"> Bandeja de salida del Id: " + itemUsuario.Id + " ");
        }

        public void NavegarBandejaEntradaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel(itemUsuario, false, "> Bandeja de entrada del Id: " + itemUsuario.Id + " ");
        }

        public void NavegarAmigosCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.Usuarios();
            NavigationViewModel.Instance.CurrentPage.DataContext = new AmigosViewModel(itemUsuario, "> Lista de amigos del Id: " + itemUsuario.Id + " ");
        }

        public void NavegarBloqueadosCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.Usuarios();
            NavigationViewModel.Instance.CurrentPage.DataContext = new BloqueadosViewModel(itemUsuario, "> Lista de bloqueados del Id: " + itemUsuario.Id + " ");
        }

        public void NavegarMuroCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel(itemUsuario.Id, "> Muro del usuario con Id: " + itemUsuario.Id + " ");
        }

        public void UsuarioBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar a " + itemUsuario.Nombre + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Usuario_BorrarUsuario(itemUsuario.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Usuario.Usuarios();
                NavigationViewModel.Instance.CurrentPage.DataContext = new UsuariosViewModel();

                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
            }
        }
        #endregion

    }
}
