using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorInmobiliaria.ServiceReference1;

namespace GestorInmobiliaria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceClient servicio = new ServiceClient();
            System.Windows.Data.CollectionViewSource anuncioDTOViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("anuncioDTOViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            anuncioDTOViewSource.Source = servicio.NuevoInmueblate_Moderador_GetAllAnuncio();
            

            
        }
    }
}
