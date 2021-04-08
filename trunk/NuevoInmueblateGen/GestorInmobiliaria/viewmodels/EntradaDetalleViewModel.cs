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
    class EntradaDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        
        EntradaDTO itemEntrada = null;
        InmobiliariaDTO inmobiliariaCreador = null;
        UsuarioDTO usuarioCreador = null;


        public EntradaDetalleViewModel()
        {
            itemEntrada = new EntradaDTO();
            NavigationViewModel.Instance.Cabecera = "Creación de un nueva entrada";
        }

        public EntradaDetalleViewModel(EntradaDTO entrada, string breadcrumb)
        {
            service = new ServiceClient();
            
            itemEntrada = entrada;
            NavigationViewModel.Instance.Cabecera = "Detalle de una entrada";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            inmobiliariaCreador = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemEntrada.Creador_oid);
            usuarioCreador = service.NuevoInmueblate_Usuario_DameUsuarioPorOID(itemEntrada.Creador_oid);
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
            get { return itemEntrada.Id; }
            set { itemEntrada.Id = value; }
        }

        public string Titulo
        {
            get { return itemEntrada.Titulo; }
            set { itemEntrada.Titulo = value; }
        }

        public string Cuerpo
        {
            get { return itemEntrada.Cuerpo; }
            set { itemEntrada.Cuerpo = value; }
        }

        public Nullable<DateTime> FechaPublicacion
        {
            get { return itemEntrada.FechaPublicacion; }
            set { itemEntrada.FechaPublicacion = value; }
        }

        public bool PendienteModeracion
        {
            get { return itemEntrada.PendienteModeracion; }
            set { itemEntrada.PendienteModeracion = value; }
        }

        public int UsuariosMeGusta
        {
            get { return itemEntrada.UsuariosMeGusta_oid.Count(); }
        }

        public String Creador
        {
            get
            {
                string retorno;

                if (usuarioCreador != null)
                    retorno = usuarioCreador.Nombre + " (Usuario)";
                else
                    retorno = inmobiliariaCreador.Nombre + " (Inmobiliaria)";

                return retorno;
            }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand EntradaBorrarCommand { get { return new RelayCommand(EntradaBorrarCommandExecute); } }
        public RelayCommand EntradaCrearCommand { get { return new RelayCommand(EntradaCrearCommandExecute); } }
        //public RelayCommand EntradaModificarCommand { get { return new RelayCommand(EntradaModificarCommandExecute); } }
        public RelayCommand EntradaGuardarCommand { get { return new RelayCommand(EntradaGuardarCommandExecute); } }
        public RelayCommand NavegarCreadorCommand { get { return new RelayCommand(NavegarCreadorCommandExecute); } }

        public void NavegarCreadorCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);

            if (usuarioCreador != null)
            {
                NavigationViewModel.Instance.CurrentPage = new views.Usuario.UsuarioDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new UsuarioDetalleViewModel(usuarioCreador, "> Detalles del usuario creador con Id: " + usuarioCreador.Id + " ");
            }
            else
            {
                NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.InmobiliariaDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariaDetalleViewModel(inmobiliariaCreador, "> Detalles de la inmobiliaria creadora con Id: " + inmobiliariaCreador.Id + " ");
            }
        }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel();
        }

        public void EntradaBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta entrada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Entrada_BorrarEntrada(itemEntrada.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel();
            }
        }

        public void EntradaCrearCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea crear esta entrada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Entrada_CrearEntrada(itemEntrada.FechaPublicacion, itemEntrada.Titulo, itemEntrada.Cuerpo,itemEntrada.PendienteModeracion,itemEntrada.Muro,itemEntrada.Creador);
                NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel();
            }
        }
        /*
        public void EntradaModificarCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.EntradaModificar();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradaDetalleViewModel(itemEntrada);
        }
        */
        public void EntradaGuardarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar esta entrada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Entrada_ModificarEntrada(itemEntrada.Id, itemEntrada.FechaPublicacion, itemEntrada.Titulo, itemEntrada.Cuerpo, itemEntrada.PendienteModeracion);
                NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
                NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel();
            }
        }
        /*
        public void EntradaExaminarExecute()
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
