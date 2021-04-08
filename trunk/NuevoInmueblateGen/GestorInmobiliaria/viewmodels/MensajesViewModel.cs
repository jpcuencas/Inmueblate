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
    class MensajesViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        IList<MensajeDTO> mensajes = null;
        MensajeDTO selectedMensaje;

        int inicioPaginacion;
        int tamPaginacion;

        bool paginacionRetrocederEnabled;
        bool paginacionAvanzarEnabled;

        string asuntoFiltro;
        string cuerpoFiltro;
        Nullable<DateTime> fechaFiltro;
        string moderacionFiltroString;

        string p_asunto;
        string p_cuerpo;
        Nullable<DateTime> p_fecha;
        bool p_pendienteModeracion;
        bool p_moderacion;

        int p_emisor = -1;
        int p_receptor = -1;

        public MensajesViewModel()
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            ModeracionFiltroString = "Todos";

            p_asunto = null;
            p_cuerpo = null;
            p_fecha = null;
            p_moderacion = false;
            p_pendienteModeracion = false;

            NavigationViewModel.Instance.Cabecera = "Gestión de todos los mensajes";
            NavigationViewModel.Instance.Breadcrumbs = "Mensajes ";

            service = new ServiceClient();
            mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion + 1, tamPaginacion);

            if (mensajes.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion, tamPaginacion);

            PaginacionRetrocederEnabled = false;
        }

        public MensajesViewModel(SuperUsuarioDTO usuario, bool emisor ,string breadcrumb)
        {
            inicioPaginacion = 0;
            tamPaginacion = 10;
            ModeracionFiltroString = "Todos";

            if (emisor)
                p_emisor = usuario.Id;
            else
                p_receptor = usuario.Id;

            p_asunto = null;
            p_cuerpo = null;
            p_fecha = null;
            p_moderacion = false;
            p_pendienteModeracion = false;

            NavigationViewModel.Instance.Cabecera = "Gestión de todos los mensajes";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            service = new ServiceClient();
            mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion + 1, tamPaginacion);

            if (mensajes.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion, tamPaginacion);

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

        public string AsuntoFiltro
        {
            get { return asuntoFiltro; }
            set { asuntoFiltro = value; RaisePropertyChanged("AsuntoFiltro"); }
        }

        public string CuerpoFiltro
        {
            get { return cuerpoFiltro; }
            set { cuerpoFiltro = value; RaisePropertyChanged("CuerpoFiltro"); }
        }

        public string[] Moderacion
        {
            get
            {
                IList<string> listaModeracion = new List<string>();
                listaModeracion.Add("Todos");
                listaModeracion.Add("Moderados");
                listaModeracion.Add("Pendientes");
                return listaModeracion.ToArray();
            }
        }

        public string ModeracionFiltroString
        {
            get { return moderacionFiltroString; }
            set { moderacionFiltroString = value; RaisePropertyChanged("ModeracionFiltroString"); }
        }

        public Nullable<DateTime> FechaFiltro
        {
            get { return fechaFiltro; }
            set { fechaFiltro = value; RaisePropertyChanged("FechaFiltro"); }
        }

        public IList<MensajeDTO> Mensajes
        {
            get { return mensajes; }
            set
            {
                if (mensajes != value)
                {
                    mensajes = value;
                    RaisePropertyChanged("Mensajes");
                }
            }
        }

        public MensajeDTO SelectedItem
        {
            get { return selectedMensaje; }
            set
            {
                selectedMensaje = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region Commands

        public RelayCommand SelectionChangedCommand { get { return new RelayCommand(SelectionChangedCommandExecute); } }
        public RelayCommand PaginacionAvanzarCommand { get { return new RelayCommand(PaginacionAvanzarCommandExecute); } }
        public RelayCommand PaginacionRetrocederCommand { get { return new RelayCommand(PaginacionRetrocederCommandExecute); } }
        public RelayCommand FiltrarCommand { get { return new RelayCommand(FiltrarCommandExecute); } }

        // public RelayCommand EnviarMensajesCommand { get { return new RelayCommand(EnviarMensajesCommandExecute); } }

        public void SelectionChangedCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.MensajeDetalle();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesDetalleViewModel(selectedMensaje, "> Detalles del mensaje con Id: " + selectedMensaje.Id + " ");
        }

        public void FiltrarCommandExecute()
        {
            inicioPaginacion = 0;

            if (moderacionFiltroString != null && moderacionFiltroString == "Todos")
            {
                p_moderacion = false;
                p_pendienteModeracion = false;
            }
            if (moderacionFiltroString != null && moderacionFiltroString == "Moderados")
            {
                p_moderacion = true;
                p_pendienteModeracion = false;
            }
            if (moderacionFiltroString != null && moderacionFiltroString == "Pendientes")
            {
                p_moderacion = true;
                p_pendienteModeracion = true;
            }

            p_asunto = asuntoFiltro;
            p_cuerpo = cuerpoFiltro;
            p_fecha = fechaFiltro;

            mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion + 1, tamPaginacion);

            PaginacionRetrocederEnabled = false;

            if (mensajes.Count == tamPaginacion)
            {
                PaginacionAvanzarEnabled = true;
            }
            else
            {
                PaginacionAvanzarEnabled = false;
            }

            Mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion, tamPaginacion);
        }

        public void PaginacionAvanzarCommandExecute()
        {
            if (mensajes.Count == tamPaginacion)
            {
                inicioPaginacion += tamPaginacion;
                PaginacionRetrocederEnabled = true;
                mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion + 1, tamPaginacion);

                if (mensajes.Count == tamPaginacion)
                {
                    PaginacionAvanzarEnabled = true;
                }
                else
                {
                    PaginacionAvanzarEnabled = false;
                }

                Mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion, tamPaginacion);
            }
        }

        public void PaginacionRetrocederCommandExecute()
        {
            if (inicioPaginacion > 0)
            {
                inicioPaginacion -= tamPaginacion;
                Mensajes = service.NuevoInmueblate_Mensaje_DameMensajeFiltro(p_asunto, p_cuerpo, p_fecha, p_moderacion, p_pendienteModeracion, p_emisor, p_receptor, inicioPaginacion, tamPaginacion);

                PaginacionAvanzarEnabled = true;

                if (inicioPaginacion == 0)
                {
                    PaginacionRetrocederEnabled = false;
                }
            }
        }

        /*
        public void NuevoMensajeCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.MensajeNuevo();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesDetalleViewModel();
        }
        

        public void EnviarMensajesCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = new views.Mensaje.EnviarMensaje();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EnviarMensajeViewModel();
        }*/

        #endregion
    }
}
