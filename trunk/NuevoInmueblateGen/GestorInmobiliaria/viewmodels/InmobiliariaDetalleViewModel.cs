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
    class InmobiliariaDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        InmobiliariaDTO itemInmobilaria;
        MuroDTO muroInmobiliaria;
        PaginaCorporativaDTO paginaInmobiliaria = null;

        public InmobiliariaDetalleViewModel(InmobiliariaDTO inm, string breadcrumb)
        {
            service = new ServiceClient();
            itemInmobilaria = inm;
            NavigationViewModel.Instance.Cabecera = "Detalle de la inmobiliaria";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;

            muroInmobiliaria = service.NuevoInmueblate_Muro_DameMuroPorOID(itemInmobilaria.Muro_oid);
            if(itemInmobilaria.PaginaCorporativa_oid.Count() > 0)
                paginaInmobiliaria = service.NuevoInmueblate_PaginaCorporativa_DamePaginaCorporativaPorOID(itemInmobilaria.PaginaCorporativa_oid[0]);
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
            get { return itemInmobilaria.Id; }
            set { itemInmobilaria.Id = value; }
        }

        public string Nombre
        {
            get { return itemInmobilaria.Nombre; }
            set { itemInmobilaria.Nombre = value; }
        }

        public string Descripcion
        {
            get { return itemInmobilaria.Descripcion; }
            set { itemInmobilaria.Descripcion = value; }
        }

        public string Email
        {
            get { return itemInmobilaria.Email; }
            set { itemInmobilaria.Email = value; }
        }

        public string Cif
        {
            get { return itemInmobilaria.Cif; }
            set { itemInmobilaria.Cif = value; }
        }

        public string Telefono
        {
            get { return itemInmobilaria.Telefono; }
            set { itemInmobilaria.Telefono = value; }
        }

        public string Direccion
        {
            get { return itemInmobilaria.Direccion; }
            set { itemInmobilaria.Direccion = value; }
        }

        public string Poblacion
        {
            get { return itemInmobilaria.Poblacion; }
        }

        public string CodigoPostal
        {
            get { return itemInmobilaria.CodigoPostal; }
        }

        public float ValoracionMedia
        {
            get { return itemInmobilaria.ValoracionMedia; }
            set { itemInmobilaria.ValoracionMedia = value; }
        }

        public int Inmuebles
        {
            get { return itemInmobilaria.Inmuebles_oid.Count(); }
        }

        public string PaginaCorporativa
        {
            get 
            {
                string retorno;
                if (itemInmobilaria.PaginaCorporativa_oid.Count() > 0)
                    retorno = "Ver";
                else
                    retorno = "Crear";

                return retorno;
            }
        }

        public int Muro
        {
            get 
            {
                int retorno = 0;
                if (muroInmobiliaria != null)
                    retorno = muroInmobiliaria.Entradas_oid.Count();

                return retorno;
            }
        }

        public int Eventos
        {
            get 
            {
                int retorno = 0;
                if(itemInmobilaria.Eventos_oid != null)
                    retorno = itemInmobilaria.Eventos_oid.Count();

                return retorno;
            }
        }

        public int Grupos
        {
            get 
            {
                int retorno = 0;
                if(itemInmobilaria.Grupos_oid != null)
                    retorno = itemInmobilaria.Grupos_oid.Count();

                return retorno;
            }
        }

        public int BandejaSalida
        {
            get
            {
                int retorno = 0;
                if (itemInmobilaria.MensajesEnviados_oid != null)
                    retorno = itemInmobilaria.MensajesEnviados_oid.Count();

                return retorno;
            }
        }

        public int BandejaEntrada
        {
            get
            {
                int retorno = 0;
                if (itemInmobilaria.MensajesRecibidos_oid != null)
                    retorno = itemInmobilaria.MensajesRecibidos_oid.Count();

                return retorno;
            }
        }

        #endregion

        #region Commands
        public RelayCommand VolverCommand { get { return new RelayCommand(VolverCommandExecute); } }
        public RelayCommand InmobiliariaBorrarCommand { get { return new RelayCommand(InmobiliariaBorrarCommandExecute); } }
        public RelayCommand NavegarPaginaCommand { get { return new RelayCommand(NavegarPaginaCommandExecute); } }
        public RelayCommand NavegarInmueblesCommand { get { return new RelayCommand(NavegarInmueblesCommandExecute); } }
        public RelayCommand EnviarMensajeCommand { get { return new RelayCommand(EnviarMensajeCommandExecute); } }
        public RelayCommand NavegarBandejaSalidaCommand { get { return new RelayCommand(NavegarBandejaSalidaCommandExecute); } }
        public RelayCommand NavegarBandejaEntradaCommand { get { return new RelayCommand(NavegarBandejaEntradaCommandExecute); } }
        public RelayCommand NavegarEntradasCommand { get { return new RelayCommand(NavegarEntradasCommandExecute); } }

        public void NavegarEntradasCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Entradas.Entradas();
            NavigationViewModel.Instance.CurrentPage.DataContext = new EntradasViewModel(itemInmobilaria.Id, "> Muro de la inmobiliaria con Id: " + itemInmobilaria.Id + " ");
        }

        public void NavegarBandejaSalidaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel(itemInmobilaria, true, "> Bandeja de salida del Id: " + itemInmobilaria.Id + " ");
        }

        public void NavegarBandejaEntradaCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensajes.Mensajes();
            NavigationViewModel.Instance.CurrentPage.DataContext = new MensajesViewModel(itemInmobilaria, false, "> Bandeja de entrada del Id: " + itemInmobilaria.Id + " ");
        }

        public void EnviarMensajeCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Mensaje.EnviarMensaje();
            NavigationViewModel.Instance.CurrentPage.DataContext = new CrearMensajeViewModel(itemInmobilaria, "", "", "> Mensaje al usuario con Id: " + itemInmobilaria.Id + " ");
        }

        public void NavegarInmueblesCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Inmueble.Inmuebles();
            NavigationViewModel.Instance.CurrentPage.DataContext = new InmueblesViewModel(itemInmobilaria, "> Inmuebles de la inmobiliaria con Id:" + itemInmobilaria.Id + " ");
        }

        public void NavegarPaginaCommandExecute()
        {
            if (paginaInmobiliaria != null)
            {
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Paginas.PaginaDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new PaginaDetalleViewModel(paginaInmobiliaria, "> Página de la inmobiliaria con Id:" + itemInmobilaria.Id + " ");
            }
            else
            {
                service.NuevoInmueblate_PaginaCorporativa_CrearPaginaCorporativa("<html><head><link rel='stylesheet' href='http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css'></head><body><div class='container'><div class='jumbotron'><h1>Inicio</h1></div><div class='well'>Hola</div></div></body></html>", "", itemInmobilaria.Id);
                itemInmobilaria = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(itemInmobilaria.Id);
                paginaInmobiliaria = service.NuevoInmueblate_PaginaCorporativa_DamePaginaCorporativaPorOID(itemInmobilaria.PaginaCorporativa_oid[0]);
                RaisePropertyChanged("PaginaCorporativa");
                NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
                NavigationViewModel.Instance.CurrentPage = new views.Paginas.PaginaDetalle();
                NavigationViewModel.Instance.CurrentPage.DataContext = new PaginaDetalleViewModel(paginaInmobiliaria, "> Página de la inmobiliaria con Id:" + itemInmobilaria.Id + " ");
            }
        }

        public void VolverCommandExecute()
        {
            NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
        }

        public void InmobiliariaBorrarCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar a " + itemInmobilaria.Nombre + "?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Inmobiliaria_BorrarInmobiliaria(itemInmobilaria.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Inmobiliaria.Inmobiliarias();
                NavigationViewModel.Instance.CurrentPage.DataContext = new InmobiliariasViewModel();

                //NavigationViewModel.Instance.CurrentPage = NavigationViewModel.Instance.Back.Pop();
                // Error al modificar el dataContext aquí, deja de navegar
                // NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
            }
        }
        #endregion


    }
}
