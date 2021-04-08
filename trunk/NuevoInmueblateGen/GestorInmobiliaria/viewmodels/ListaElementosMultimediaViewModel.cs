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
    class ListaElementosMultimediaViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        ElementoMultimediaDTO selectedElemento;
        IList<ElementoMultimediaDTO> lista_em = null;
        string tipo;

        public ListaElementosMultimediaViewModel(string tipo)
        {
            
            service = new ServiceClient();
            // variable de clase y parametro con el mismo nombre? a alguien le corto las manos
            switch (tipo)
            {
                case "Fotos": lista_em = service.NuevoInmueblate_Fotografia_ObtenerTodasFotografiasPorModerar(); 
                              this.tipo = "Fotos";
                              NavigationViewModel.Instance.Cabecera = "Fotos"; break;
                default: lista_em = service.NuevoInmueblate_Video_ObtenerTodosVideosPorModerar();
                         this.tipo = "Videos";
                         NavigationViewModel.Instance.Cabecera = "Videos"; break;
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

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public IList<ElementoMultimediaDTO> Elementos
        {
            get { return lista_em; }
            set
            {
                if (lista_em != value)
                {
                    lista_em = value;
                    RaisePropertyChanged("Elementos");
                }
            }
        }

        public ElementoMultimediaDTO SelectedItem
        {
            get { return selectedElemento; }
            set
            {
                selectedElemento = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region Commands

        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ElementosMultimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ElementosMultimediaViewModel();
        }
        public void SelectionChangedCommandExecute()
        {
            //NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ElementosMultimediaDetalles();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ElementosMultimediaDetallesViewModel(NavigationViewModel.Instance.Cabecera,selectedElemento);

            //NavigationViewModel.Instance.CenterWindowOnScreen();
        }

        #endregion
    }
}
