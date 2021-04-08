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
    class ElementosMultimediaDetallesViewModel : ObservableObject, IDataErrorInfo
    {
        ElementoMultimediaDTO elemento;

        public ElementosMultimediaDetallesViewModel(string tipo, ElementoMultimediaDTO item)
        {
            NavigationViewModel.Instance.Cabecera = tipo;

            elemento = item;
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
            get { return elemento.Id; }
            set { elemento.Id = value; }
        }

        public string Nombre
        {
            get { return elemento.Nombre; }
            set { elemento.Nombre = value; }
        }

        public string Descripcion
        {
            get { return elemento.Descripcion; }
            set { elemento.Descripcion = value; }
        }

        public string URL
        {
            get { return elemento.URL; }
            set { elemento.URL = value; }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand ElementoBorrarCommand { get { return new RelayCommand(ElementoBorrarCommandExecute); } }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ListaElementosMultimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ListaElementosMultimediaViewModel(NavigationViewModel.Instance.Cabecera) ;
        }

        public void ElementoBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este elemento?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                switch(NavigationViewModel.Instance.Cabecera)
                {
                    case "Fotos": service.NuevoInmueblate_Fotografia_BorrarFotografia(elemento.Id); break;
                    default: service.NuevoInmueblate_Video_BorrarVideo(elemento.Id); break;
                }
                NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ListaElementosMultimedia();
                NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ListaElementosMultimediaViewModel(NavigationViewModel.Instance.Cabecera);

                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
            }
        }

        #endregion
    }
}
