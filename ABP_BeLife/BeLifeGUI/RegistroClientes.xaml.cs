using Belife;
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
    /// Lógica de interacción para RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        public RegistroClientes()
        {
            InitializeComponent();
            LlenarCB();
        }

        public string[] tipoSexo = new string[2] {"Masculino","Femenino"};
        private string[] tipoEstadoCivil = new string[4] {"Soltero","Casado","Divorciado","Viudo"};
        

        private void Limpiar()
        {
            TxtApellidos.Text = string.Empty;
            TxtNombres.Text = string.Empty;
            TxtRut.Text = string.Empty;
            DPFechaNacimiento.Text = DateTime.Now.ToString();
            CbEstadoCivil.SelectedIndex = -1;
            CbSexo.SelectedIndex = -1;

        }
        private void LlenarCB()
        {
            foreach (string tipo in tipoSexo)
            {
                CbSexo.Items.Add(tipo);

            }
            foreach(string tipo in tipoEstadoCivil)
            {
                CbEstadoCivil.Items.Add(tipo);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente
            {
                Rut = TxtRut.Text,
                Nombre = TxtNombres.Text,
                Apellidos = TxtNombres.Text,
                FechaNacimiento = (DateTime)DPFechaNacimiento.SelectedDate,
                Sexo = new Sexo(CbSexo.SelectedIndex),
                EstadoCivil = new EstadoCivil(CbEstadoCivil.SelectedIndex)
            };

            try
            {
                if (cli.AgregaCliente())
                {
                    MessageBox.Show("Cliente Agregado");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Cliente No Agregado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
