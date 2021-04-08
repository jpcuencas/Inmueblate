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
using System.Windows.Shapes;

namespace GestorInmobiliaria.views.Mensaje
{
    /// <summary>
    /// Lógica de interacción para TodosUsuarios.xaml
    /// </summary>
    public partial class TodosUsuarios : Window
    {
        public TodosUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
