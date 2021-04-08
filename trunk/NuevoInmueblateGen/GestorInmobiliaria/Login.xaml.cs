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
using GestorInmobiliaria.ServiceReference1;

namespace GestorInmobiliaria
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            ServiceClient servicio = new ServiceClient();

            // Ahora mismo devuelve un bool, pero debe devolver un enumerado.
            // TODO : La invocación del método falla
            
            int retorno = (int)servicio.NuevoInmueblate_Moderador_Anonimo_Login(1, txtUsuario.Text, pwdContrasena.Password);

            // Aquí hay que comprobar que todo ese correcto, ahora simplemente con el botón ya funciona
            if (retorno == 2)
            {
                Window w = new VentanaPrincipal();
                this.Close();
                w.Show();
            }
            else
            {
                lblError.Content = "Error, moderardor no encontrado";
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
