using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using GestorInmobiliaria.views;
using System.Windows;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace GestorInmobiliaria.viewmodels
{
    class ElementosMultimediaViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<ElementoMultimediaDTO> lem = null;
        ElementoMultimediaDTO selectedElemento = null;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        private void formatearURL()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            ServiceModelSectionGroup serviceModelSectionGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
            ClientSection clientSection = serviceModelSectionGroup.Client;
            var el = clientSection.Endpoints[0];
            string ip = el.Address.ToString();
            ip = ip.Substring(0, ip.LastIndexOf('/'));

            ip = "http://masterwebua.cloudapp.net:54022/img";
            
            foreach (ElementoMultimediaDTO e in lem)
            {
                e.URL = ip + e.URL;
            }
            RaisePropertyChanged("Multimedia");
        }

        public ElementosMultimediaViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            
            NavigationViewModel.Instance.Cabecera = "Gestión de los elementos multimedia";
            NavigationViewModel.Instance.Breadcrumbs = "Multimedia ";
            service = new ServiceClient();
            lem = service.NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP(inicioPaginacion + 1, tamPaginacion);

            if (lem.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Multimedia = service.NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP(inicioPaginacion, tamPaginacion);
            formatearURL();
            PaginacionRetrocederEnabled = false;
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

        public IList<ElementoMultimediaDTO> Multimedia
        {
            get
            {
                return lem;
            }
            set
            {
                lem = value;
                RaisePropertyChanged("Multimedia");
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

        public bool PaginacionRetrocederEnabled
        {
            get { return paginacionRetrocederEnabled; }
            set { paginacionRetrocederEnabled = value; RaisePropertyChanged("PaginacionRetrocederEnabled"); }
        }

        public bool PaginacionAvanzarEnabled
        {
            get { return paginacionAvanzarEnabled; }
            set { paginacionAvanzarEnabled = value; RaisePropertyChanged("PaginacionAvanzarEnabled"); }
        }

        #endregion

        #region Commands
        public RelayCommand VideosCommand { get { return new RelayCommand(VideosCommandExecute); } }
        public RelayCommand FotosCommand { get { return new RelayCommand(FotosCommandExecute); } }

        public void VideosCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ListaElementosMultimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ListaElementosMultimediaViewModel("Videos");
        }

        public void FotosCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.ElementoMultimedia.ListaElementosMultimedia();
            NavigationViewModel.Instance.CurrentPage.DataContext = new viewmodels.ListaElementosMultimediaViewModel("Fotos");
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (lem.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                lem = service.NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP(inicioPaginacion + 1, tamPaginacion); ;

                if (lem.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Multimedia = service.NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP(inicioPaginacion, tamPaginacion);
                formatearURL();
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Multimedia = service.NuevoInmueblate_ElementoMultimedia_DameTodosElementosMultimediaP(inicioPaginacion, tamPaginacion);
                formatearURL();
                PaginacionAvanzarEnabled = true;

                if (inicioPaginacion == 0)
                {
                    PaginacionRetrocederEnabled = false;
                }
            }
        }

        #endregion
    }
}
