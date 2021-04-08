using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;
//using NuevoInmueblateCP.InmueblateCP;

namespace GestorInmobiliaria.viewmodels
{
    class EnviarMensajeViewModel : ObservableObject, IDataErrorInfo
    {
        ServiceClient service = null;
        MensajeDTO nuevoMensaje = null;
        private IList<SuperUsuarioDTO> lista_a_enviar = null;
        IList<UsuarioDTO> lista_usuarios = null;
        IList<SuperUsuarioDTO> aux_lista_usuarios = null;
        IList<InmobiliariaDTO> lista_inmobiliaria = null;
        UsuarioDTO selectedItemListaUsuarios;
        //MensajeCP menCP;

        public EnviarMensajeViewModel()
        {
            service = new ServiceClient();
            //menCP = new MensajeCP();
            nuevoMensaje = new MensajeDTO();
            lista_a_enviar = new List<SuperUsuarioDTO>();
            aux_lista_usuarios = new List<SuperUsuarioDTO>();
            //lista_a_enviar = service.NuevoInmueblate_Moderador_GetAllUsuario();
            lista_usuarios = service.NuevoInmueblate_Moderador_GetAllUsuario();
            lista_inmobiliaria = service.NuevoInmueblate_Moderador_GetAllInmobiliaria();

            NavigationViewModel.Instance.Cabecera = "Envio de mensajes";
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

        public string Asunto
        {
            get { return nuevoMensaje.Asunto; }
            set { nuevoMensaje.Asunto = value; }
        }

        public string Cuerpo
        {
            get { return nuevoMensaje.Cuerpo; }
            set { nuevoMensaje.Cuerpo = value; }
        }

        public Nullable<DateTime> FechaEnvio
        {
            get { return nuevoMensaje.FechaEnvio; }
            set { nuevoMensaje.FechaEnvio = value; }
        }

        public bool PendienteModeracion
        {
            get { return nuevoMensaje.PendienteModeracion; }
            set { nuevoMensaje.PendienteModeracion = value; }
        }

        public bool Leido
        {
            get { return nuevoMensaje.Leido; }
            set { nuevoMensaje.Leido = value; }
        }

        public IList<SuperUsuarioDTO> ListaAEnviar
        {
            get { return lista_a_enviar; }
            set
            {
                if (lista_a_enviar != value)
                {
                    lista_a_enviar = value;
                    RaisePropertyChanged("ListaAEnviar");
                }
            }
        }

        public IList<UsuarioDTO> ListaUsuarios
        {
            get { return lista_usuarios; }
            set
            {
                if (lista_usuarios != value)
                {
                    lista_usuarios = value;
                    RaisePropertyChanged("ListaUsuarios");
                }
            }
        }
        public UsuarioDTO SelectedItemListaUsuarios
        {
            get { return selectedItemListaUsuarios; }
            set
            {
                selectedItemListaUsuarios = value;
                RaisePropertyChanged("SelectedItemListaUsuarios");
            }
        }

        public IList<InmobiliariaDTO> ListaInmobiliarias
        {
            get { return lista_inmobiliaria; }
            set
            {
                if (lista_inmobiliaria != value)
                {
                    lista_inmobiliaria = value;
                    RaisePropertyChanged("ListaInmobiliarias");
                }
            }
        }

        #endregion

        #region Events
        #endregion

        #region Commands

        public RelayCommand EnviarCommand { get { return new RelayCommand(EnviarCommandExecute); } }
        public RelayCommand AddDestinatariosCommand { get { return new RelayCommand(AddDestinatariosCommandExecute); } }
        public RelayCommand SelectionChangedListaUsuariosCommand { get { return new RelayCommand(SelectionChangedListaUsuariosCommandExecute); } }
        public RelayCommand CheckedListaUsuariosCommand { get { return new RelayCommand(CheckedListaUsuariosCommandExecute); } }
        public RelayCommand UnCheckedListaUsuariosCommandCommand { get { return new RelayCommand(UnCheckedListaUsuariosCommandExecute); } }


        public void EnviarCommandExecute()
        {
            if (ListaAEnviar.Count < 1)
            {
                MessageBox.Show("Debes seleccionar al menos un usuario al que enviar el mensaje.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return ;
            }
            MessageBoxResult w_result = MessageBox.Show("¿Enviar mensaje a los usuarios seleccionados? (" + ListaAEnviar.Count + ")", "Confrimación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (w_result == MessageBoxResult.Yes)
            {
                //recorro la lista de usuarios y creo los nuevos mensajes
                //TODO ver si podemos saber el id del moderador logeado y pasarlo como emisor
                foreach (SuperUsuarioDTO su in ListaAEnviar)
                {
                    service.NuevoInmueblate_Mensaje_CrearMensaje(true, DateTime.Today, nuevoMensaje.Asunto, nuevoMensaje.Cuerpo, false, 10, su.Id);
                    //menCP.CrearMensaje(true, DateTime.Today, nuevoMensaje.Asunto, nuevoMensaje.Cuerpo, false, 10, su.Id);
                }

                MessageBox.Show("Mensajes enviados correctamente", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void AddDestinatariosCommandExecute()
        {
            var addDestinatarios = new views.Mensaje.TodosUsuarios();
            addDestinatarios.DataContext = this;
            addDestinatarios.ShowDialog();
        }

        public void SelectionChangedListaUsuariosCommandExecute()
        {
            aux_lista_usuarios = ListaAEnviar;
            if (!aux_lista_usuarios.Contains(selectedItemListaUsuarios))
            {
                MessageBox.Show("Usuario: " + selectedItemListaUsuarios.Nombre, "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                aux_lista_usuarios.Add((SuperUsuarioDTO)selectedItemListaUsuarios);
            }
            
            ListaAEnviar = aux_lista_usuarios;
        }

        public void CheckedListaUsuariosCommandExecute()
        {
            aux_lista_usuarios = ListaAEnviar;
            if (aux_lista_usuarios.Count > 0)
            {
                aux_lista_usuarios.Clear();
            }
            foreach (UsuarioDTO us in lista_usuarios)
            {
                aux_lista_usuarios.Add(us);
            }
            ListaAEnviar = aux_lista_usuarios;
        }

        public void UnCheckedListaUsuariosCommandExecute()
        {
            ListaAEnviar.Clear();
        }

        #endregion
    }
}
