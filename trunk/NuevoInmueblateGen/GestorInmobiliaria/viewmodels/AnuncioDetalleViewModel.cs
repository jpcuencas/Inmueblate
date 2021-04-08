using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonMvvm;
using System.ComponentModel;
using GestorInmobiliaria.ServiceReference1;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace GestorInmobiliaria.viewmodels
{
    class AnuncioDetalleViewModel : ObservableObject, IDataErrorInfo
    {
        AnuncioDTO itemAnuncio = null;

        public AnuncioDetalleViewModel(string breadcrumb)
        {
            itemAnuncio = new AnuncioDTO();
            NavigationViewModel.Instance.Cabecera = "Creación de un nuevo anuncio";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
        }
        
        public AnuncioDetalleViewModel(AnuncioDTO anuncio, string breadcrumb)
        {
            itemAnuncio = anuncio;
            NavigationViewModel.Instance.Cabecera = "Detalle de un anuncio";
            NavigationViewModel.Instance.Breadcrumbs += breadcrumb;
        }

        #region Validation

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get 
            { 
                string result = null;

                if (columnName == "URL")
                {
                    if (URL == null)
                    {
                        result = "El campo URL está vacío";
                    }
                    else
                    {
                        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^((http|ftp|https|www)://)?([\w+?\.\w+])+‌​([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$");
                        
                        //bool isValid = (System.Text.RegularExpressions.Regex.IsMatch(URL, "|^http(s)?://[a-z0-9-]+(.[a-z0-9-]+)*(:[0-9]+)?(/.*)?$|"));

                        if (!regex.IsMatch(URL))
                        {
                            result = "La URL que ha introducido no es válida";
                        }
                    }
                }

                return result;
            }
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return itemAnuncio.Id; }
            set { itemAnuncio.Id = value; }
        }

        public string Imagen
        {
            get { return itemAnuncio.Imagen; }
            set { itemAnuncio.Imagen = value; RaisePropertyChanged("Imagen"); }
        }

        public string Descripcion
        {
            get { return itemAnuncio.Descripcion; }
            set { itemAnuncio.Descripcion = value; }
        }

        public Nullable<DateTime> FechaCaducidad
        {
            get { return itemAnuncio.FechaCaducidad; }
            set { itemAnuncio.FechaCaducidad = value; }
        }

        public ServiceReference1.TipoAnuncioEnum Tipo
        {
            get { return itemAnuncio.Tipo; }
            set { itemAnuncio.Tipo = value; }
        }

        public string URL
        {
            get { return itemAnuncio.URL; }
            set { itemAnuncio.URL = value; RaisePropertyChanged("URL"); }
        }

        public string[] Tipos
        {
            get { return Enum.GetNames(typeof(ServiceReference1.TipoAnuncioEnum)); }
            set { }
        }

        public string TipoString
        {
            get { return Enum.GetName(typeof(ServiceReference1.TipoAnuncioEnum), itemAnuncio.Tipo); }
            set { itemAnuncio.Tipo = (ServiceReference1.TipoAnuncioEnum)Enum.Parse(typeof(ServiceReference1.TipoAnuncioEnum), value); }
        }

        #endregion

        #region Commands

        
        public RelayCommand AnuncioBorrarCommand { get { return new RelayCommand(AnuncioBorrarCommandExecute); } }
        public RelayCommand AnuncioCrearCommand { get { return new RelayCommand(AnuncioCrearCommandExecute); } }
        public RelayCommand AnuncioModificarCommand { get { return new RelayCommand(AnuncioModificarCommandExecute); } }
        public RelayCommand AnuncioGuardarCommand { get { return new RelayCommand(AnuncioGuardarCommandExecute); } }
        public RelayCommand AnuncioExaminar { get { return new RelayCommand(AnuncioExaminarExecute); } }

        

        public void AnuncioBorrarCommandExecute()
        {
            // TODO: No se borra la imagen al eliminar un anuncio
            
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar este anuncio?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ServiceClient service = new ServiceClient();
                service.NuevoInmueblate_Anuncio_BorrarAnuncio(itemAnuncio.Id);
                NavigationViewModel.Instance.cleanBack();
                NavigationViewModel.Instance.CurrentPage = new views.Anuncio.Anuncios();
                NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
            }
        }

        public void AnuncioCrearCommandExecute()
        {
            if (itemAnuncio.Imagen == "" ||
                itemAnuncio.Descripcion == "" ||
                itemAnuncio.URL == "" ||
                itemAnuncio.FechaCaducidad == null ||
                itemAnuncio.Tipo == 0)
            {
                MessageBox.Show("No ha introducido todos los datos", "Error");
            }
            else
            {
                ServiceClient service = new ServiceClient();
                
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea crear este anuncio?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Creamos la imagen y obtenemos su ID
                    int id = service.NuevoInmueblate_Anuncio_CrearAnuncio(itemAnuncio.Imagen, itemAnuncio.Descripcion, itemAnuncio.FechaCaducidad, itemAnuncio.Tipo, itemAnuncio.URL);

                    // Con ese ID, subimos la imagen con el nombre del ID y actualizamos la imagen con la nueva dirección y la ID

                    #region subirImagen

                    // Creo una la imagen con la ruta enviada
                    Image imagen = Image.FromFile(itemAnuncio.Imagen);

                    // Hago el stream para enviarla al servicio WCF
                    MemoryStream ms = new MemoryStream();
                    imagen.Save(ms, imagen.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Envio al servicio la imagen en un stream de datos y el nombre que se le va a asignar (idealmente sería el ID del anuncio)
                    string direccion = service.subirAnuncio(base64String, id, itemAnuncio.Imagen.Substring(itemAnuncio.Imagen.LastIndexOf('.')));

                    // Leo la dirección IP del servicio, que será donde se va a almacenar la imagen
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    ServiceModelSectionGroup serviceModelSectionGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
                    ClientSection clientSection = serviceModelSectionGroup.Client;
                    var el = clientSection.Endpoints[0];
                    string ip = el.Address.ToString();
                    ip = ip.Substring(0, ip.LastIndexOf('/'));

                    itemAnuncio.Imagen = ip + direccion;
                    #endregion

                    service.NuevoInmueblate_Anuncio_ModificarAnuncio(id, itemAnuncio.Imagen, itemAnuncio.Descripcion, itemAnuncio.FechaCaducidad, itemAnuncio.Tipo, itemAnuncio.URL);

                    NavigationViewModel.Instance.cleanBack();
                    NavigationViewModel.Instance.CurrentPage = new views.Anuncio.Anuncios();
                    NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
                }
            }
        }

        public void AnuncioModificarCommandExecute()
        {
            NavigationViewModel.Instance.Back.Push(NavigationViewModel.Instance.CurrentPage);
            NavigationViewModel.Instance.CurrentPage = new views.Anuncio.AnuncioModificar();
            NavigationViewModel.Instance.CurrentPage.DataContext = new AnuncioDetalleViewModel(itemAnuncio, "> Modificación del anuncio con ID: " + itemAnuncio.Id + " ");
        }

        public void AnuncioGuardarCommandExecute()
        {
            if (itemAnuncio.Imagen == "" ||
                itemAnuncio.Descripcion == "" ||
                itemAnuncio.URL == "" ||
                itemAnuncio.FechaCaducidad == null ||
                itemAnuncio.Tipo == 0)
            {
                MessageBox.Show("No ha introducido todos los datos", "Error");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar este anuncio?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ServiceClient service = new ServiceClient();
                    service.NuevoInmueblate_Anuncio_ModificarAnuncio(itemAnuncio.Id, itemAnuncio.Imagen, itemAnuncio.Descripcion, itemAnuncio.FechaCaducidad, itemAnuncio.Tipo, itemAnuncio.URL);
                    NavigationViewModel.Instance.cleanBack();
                    NavigationViewModel.Instance.CurrentPage = new views.Anuncio.Anuncios();
                    NavigationViewModel.Instance.CurrentPage.DataContext = new AnunciosViewModel();
                }
            }
        }

        public void AnuncioExaminarExecute()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                Imagen = dlg.FileName;
            }
        }

        #endregion
    }
}
