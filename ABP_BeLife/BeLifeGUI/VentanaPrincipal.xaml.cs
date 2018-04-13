using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeLifeGUI
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListadoContratos ventanaListadoContratos = new ListadoContratos();
            ventanaListadoContratos.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Contratos ventanaContratos = new Contratos();
            ventanaContratos.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegistroClientes registroClientes = new RegistroClientes();
            registroClientes.Show();
        }
    }
}
