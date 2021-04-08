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
    class PaginaDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        PaginaCorporativaDTO itemPagina = null;

        public PaginaDetalleViewModel()
        {
            itemPagina = new PaginaCorporativaDTO();
            NavigationViewModel.Instance.Cabecera = "Creación de una nueva pagina";
        }

        public PaginaDetalleViewModel(PaginaCorporativaDTO pagina, string breadcrumb)
        {
            itemPagina = pagina;
            NavigationViewModel.Instance.Cabecera = "Detalle de una pagina";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
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
            get { return itemPagina.Id; }
            set { itemPagina.Id = value; }
        }

        public int Inmobiliaria
        {
            get { return itemPagina.Inmobiliaria; }
            set { itemPagina.Inmobiliaria = value; }
        }

        public string Contenido
        {
            get { return itemPagina.Contenido; }
            set { itemPagina.Contenido = value; }
        }

        public string URL
        {
            get { return itemPagina.URL; }
            set { itemPagina.URL = value; }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand PaginaBorrarCommand { get { return new RelayCommand(PaginaBorrarCommandExecute); } }
        //public RelayCommand PaginaCrearCommand { get { return new RelayCommand(PaginaCrearCommandExecute); } }
        public RelayCommand PaginaModificarCommand { get { return new RelayCommand(PaginaModificarCommandExecute); } }
        public RelayCommand PaginaGuardarCommand { get { return new RelayCommand(PaginaGuardarCommandExecute); } }
        //public RelayCommand PaginaExaminar { get { return new RelayCommand(PaginaExaminarExecute); } }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
        }

        public void PaginaBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta pagina?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_PaginaCorporativa_BorrarPaginaCorporativa(itemPagina.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.Inmobiliarias();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariasViewModel();
                
                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new PaginasViewModel();
            }
        }
        /*
        public void PaginaCrearCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea crear esta pagina?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_PaginaCorporativa_CrearPaginaCorporativa(itemPagina.Contenido, itemPagina.URL,itemPagina.Inmobiliaria);
                NavigationViewModel.Instance.CurrentPage = new views.Paginas.Paginas();
                NavigationViewModel.Instance.CurrentPage.DataContext = new PaginasViewModel();
            }
        }
        */
        public void PaginaModificarCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Paginas.ModificarPagina();
            NavigationViewModel.Instance.CurrentPage.DataContext = new PaginaDetalleViewModel(itemPagina, "> Modificar pagina (No debería de salir)");
        }

        public void PaginaGuardarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar esta pagina?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_PaginaCorporativa_ModificarPaginaCorporativa(itemPagina.Id, itemPagina.Contenido, itemPagina.URL);
                NavigationViewModel.Instance.CurrentPage = new views.Paginas.Paginas();
                NavigationViewModel.Instance.CurrentPage.DataContext = new PaginasViewModel();
            }
        }
        /*
        public void PaginaExaminarExecute()
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

