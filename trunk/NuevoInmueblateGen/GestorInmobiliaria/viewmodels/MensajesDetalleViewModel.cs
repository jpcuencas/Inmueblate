using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;
// using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;

namespace GestorInmobiliaria.viewmodels
{
    class MensajesDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        MensajeDTO itemMensaje = null;
        InmobiliariaDTO inmobiliariaEmisor = null;
        InmobiliariaDTO inmobiliariaReceptor = null;
        UsuarioDTO usuarioEmisor = null;
        UsuarioDTO usuarioReceptor = null;
        ServiceClient service = null;

        public MensajesDetalleViewModel()
        {
            itemMensaje = new MensajeDTO();
            NavigationViewModel.Instance.Cabecera = "Creación de un nuevo mensaje";
        }
        
        public MensajesDetalleViewModel(MensajeDTO mensaje, string breadcrumb)
        {
            itemMensaje = mensaje;
            NavigationViewModel.Instance.Cabecera = "Detalle de un mensaje";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            service = new ServiceClient();

            inmobiliariaEmisor = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemMensaje.Emisor_oid);
            usuarioEmisor = service.NuevoInmueblate_Usuario_DameUsuarioPorOID(itemMensaje.Emisor_oid);

            inmobiliariaReceptor = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemMensaje.Receptor_oid);
            usuarioReceptor = service.NuevoInmueblate_Usuario_DameUsuarioPorOID(itemMensaje.Receptor_oid);
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

        public String Emisor
        {
            get 
            {
                string retorno;

                if (usuarioEmisor != null)
                {
                    retorno = usuarioEmisor.Nombre + " (Usuario)";
                }
                else
                {
                    retorno = inmobiliariaEmisor.Nombre + " (Inmobiliaria)";
                }
                
                return retorno; 
            }
        }

        public String Receptor
        {
            get
            {
                string retorno;

                if (usuarioReceptor != null)
                {
                    retorno = usuarioReceptor.Nombre + " (Usuario)";
                }
                else
                {
                    retorno = inmobiliariaReceptor.Nombre + " (Inmobiliaria)";
                }

                return retorno;
            }
        }

        public int Id
        {
            get { return itemMensaje.Id; }
            set { itemMensaje.Id = value; }
        }

        public string Asunto
        {
            get { return itemMensaje.Asunto; }
            set { itemMensaje.Asunto = value; }
        }

        public string Cuerpo
        {
            get { return itemMensaje.Cuerpo; }
            set { itemMensaje.Cuerpo = value; }
        }

        public Nullable<DateTime> FechaEnvio
        {
            get { return itemMensaje.FechaEnvio; }
            set { itemMensaje.FechaEnvio = value; }
        }


        public bool leido
        {
            get { return itemMensaje.Leido; }
            set { itemMensaje.Leido = value; }
        }

        public bool PendienteModeracion
        {
            get { return itemMensaje.PendienteModeracion; }
            set { itemMensaje.PendienteModeracion = value; }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand MensajeBorrarCommand { get { return new RelayCommand(MensajeBorrarCommandExecute); } }
        //public RelayCommand MensajeCrearCommand { get { return new RelayCommand(MensajeCrearCommandExecute); } }
        //public RelayCommand MensajeModificarCommand { get { return new RelayCommand(MensajeModificarCommandExecute); } }
        public RelayCommand MensajeGuardarCommand { get { return new RelayCommand(MensajeGuardarCommandExecute); } }
        public RelayCommand NavegarEmisorCommand { get { return new RelayCommand(NavegarEmisorCommandExecute); } }
        public RelayCommand NavegarReceptorCommand { get { return new RelayCommand(NavegarReceptorCommandExecute); } }

        public void NavegarReceptorCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);

            if (usuarioEmisor != null)
            {
                NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(usuarioReceptor, "> Detalles del usuario receptor con Id: " + usuarioReceptor.Id + " ");
            }
            else
            {
                NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.InmobiliariaDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariaDetalleViewModel(inmobiliariaReceptor, "> Detalles de la inmobiliaria receptora con Id: " + inmobiliariaReceptor.Id + " ");
            }
        }

        public void NavegarEmisorCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);

            if (usuarioEmisor != null)
            {
                NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(usuarioEmisor, "> Detalles del usuario emisor con Id: " + usuarioEmisor.Id + " ");
            }
            else
            {
                NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.InmobiliariaDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariaDetalleViewModel(inmobiliariaEmisor, "> Detalles de la inmobiliaria emisora con Id: " + inmobiliariaEmisor.Id + " ");
            }
        }
        
        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
        }

        public void MensajeBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este mensaje?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Mensaje_BorrarMensaje(itemMensaje.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
                NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel();
                
                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel();
            }
        }
       /*
        public void MensajeCrearCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea crear este mensaje?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Mensaje_CrearMensaje(itemMensaje.PendienteModeracion, itemMensaje.FechaEnvio, itemMensaje.Asunto, itemMensaje.Cuerpo, itemMensaje.Leido,itemMensaje.Emisor, itemMensaje.Receptor);
                NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
                NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel();
            }
        }
        */

        /*
        public void MensajeModificarCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.MensajeModificar();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajeDetalleViewModel(itemMensaje);
        }
        */

        public void MensajeGuardarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar este mensaje?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Mensaje_ModificarMensaje(itemMensaje.Id,itemMensaje.PendienteModeracion, itemMensaje.FechaEnvio, itemMensaje.Asunto, itemMensaje.Cuerpo, itemMensaje.Leido);
                NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
                NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel();
            }
        }
        /*
        public void MensajeExaminarExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                Imagen = dlg.FileName;
            }
        }
        */
        #endregion
    }
}
