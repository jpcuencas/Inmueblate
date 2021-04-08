using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using GestorInmobiliaria.views;

namespace GestorInmobiliaria.viewmodels
{
    class MenuLateralViewModel : ObservableObject, IDataErrorInfo
    {
        
        
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

        #endregion

        #region Commands

        public RelayCommand AnunciosCommand { get { return new RelayCommand(AnunciosCommandExecute); } }
        public RelayCommand UsuariosCommand { get { return new RelayCommand(UsuariosCommandExecute); } }
        public RelayCommand GruposCommand { get { return new RelayCommand(GruposCommandExecute); } }
        public RelayCommand EventosCommand { get { return new RelayCommand(EventosCommandExecute); } }
        public RelayCommand PaginasCommand { get { return new RelayCommand(PaginasCommandExecute); } }
        public RelayCommand MensajesCommand { get { return new RelayCommand(MensajesCommandExecute); } }
        public RelayCommand InmobiliariasCommand { get { return new RelayCommand(InmobiliariasCommandExecute); } }
        public RelayCommand InmueblesCommand { get { return new RelayCommand(InmueblesCommandExecute); } }
        public RelayCommand PruebasCommand { get { return new RelayCommand(PruebasCommandExecute); } }
        public RelayCommand EntradasCommand { get { return new RelayCommand(EntradasCommandExecute); } }
        public RelayCommand HabitacionesCommand { get { return new RelayCommand(HabitacionesCommandExecute); } }
        public RelayCommand MultimediaCommand { get { return new RelayCommand(MultimediaCommandExecute); } }

        public void MultimediaCommandExecute()
        {
            /*
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Multimedia.Multimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new ElementosMultimediaViewModel();*/
        }

        public void HabitacionesCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Habitacion.Habitaciones();
            NavigationViewModel.Instance.CurrentPage.DataContext = new HabitacionesViewModel();
        }

        public void InmueblesCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Inmueble.Inmuebles();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmueblesViewModel();
        }


        public void AnunciosCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Anuncio.Anuncios();
            NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
        }

        public void UsuariosCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Usuario.Usuarios();
            NavigationViewModel.Instance.CurrentPage.DataContext = new UsuariosViewModel();
        }

        public void GruposCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Grupo.Grupos();
            NavigationViewModel.Instance.CurrentPage.DataContext = new GruposViewModel();
        }

        public void EventosCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Eventos.Eventos();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EventosViewModel();
        }

        public void PaginasCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Paginas.Paginas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new PaginasViewModel();
        }

        public void MensajesCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel();
        }

        public void InmobiliariasCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.Inmobiliarias();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariasViewModel();
        }

        public void PruebasCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ElementosMultimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new ElementosMultimediaViewModel() ;
        }

        public void EntradasCommandExecute()
        {
            NavigationViewModel.Instance.cleanBack();
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel();
        }

        #endregion
    }
}
