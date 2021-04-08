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
    class CrearMensajeViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        List<SuperUsuarioDTO> receptores = new List<SuperUsuarioDTO>();
        GrupoDTO grupoReceptor = null;
        InmobiliariaDTO inmobiliariaReceptor = null;

        string asunto;
        string mensaje;

        public CrearMensajeViewModel(SuperUsuarioDTO usuario, string p_asunto, string p_mensaje, string breadcrumb)
        {
            receptores.Add(usuario);
            Asunto = p_asunto;
            Mensaje = p_mensaje;

            service = new ServiceClient();

            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
            inmobiliariaReceptor = service.NuevoInmueblate_Inmobiliaria_DameInmobiliariaPorOID(usuario.Id);
        }

        public CrearMensajeViewModel(GrupoDTO grupo, string p_asunto, string p_mensaje, string breadcrumb)
        {
            service = new ServiceClient();

            grupoReceptor = grupo;
            foreach (int id in grupo.Miembros_oid)
            {
                receptores.Add(service.NuevoInmueblate_SuperUsuario_DameSuperUsuarioPorOID(id));
            }
            
            Asunto = p_asunto;
            Mensaje = p_mensaje;

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

        public String Receptor
        {
            get 
            {
                string retorno = String.Empty;

                if (grupoReceptor != null)
                    retorno = "Grupo: " + grupoReceptor.Nombre;
                else if (inmobiliariaReceptor != null)
                    retorno = "Inmobiliaria: " + inmobiliariaReceptor.Nombre;
                else
                    retorno = "Usuario: " + receptores[0].Nombre + " (" + receptores[0].Email + ")";

                return retorno; 
            }
        }

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; RaisePropertyChanged("Asunto"); }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; RaisePropertyChanged("Mensaje"); }
        }

        #endregion

        #region Commands

        public RelayCommand EnviarMensajeCommand { get { return new RelayCommand(EnviarMensajeCommandExecute); } }

        public void EnviarMensajeCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea enviar el mensaje?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                foreach (SuperUsuarioDTO usuario in receptores)
                {
                    service.NuevoInmueblate_Mensaje_CrearMensajeDeModerador(11, usuario.Id, false, DateTime.Today, asunto, mensaje, false);
                }
                NavigationViewModel.Instance.popBackStack();
            }
            
            
        }

        #endregion
    }
}
