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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeLifeGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Contratos : Window
    {
        private Cliente _clienteCargado;

        public Contratos()
        {
            InitializeComponent();
            cajaContrato.IsHitTestVisible = false;
            cajaContrato.Focusable = false;
            textTerminoContrato.IsReadOnly = true;
            textoNombreCliente.IsReadOnly = true;
            textoApellidoCliente.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Fijar fecha de termino de contrato
            //TODO: Aplicar al contrato de verdad
            textTerminoContrato.Text = DateTime.Today.ToString("d");
        }

        private void dateInicioVigencia_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime sel = (DateTime)dateInicioVigencia.SelectedDate;

                //Comparar primero si es menor a hoy, luego revisar si es mayor a un mes mas de hoy
                //En caso de encontrar un error, se lanza una excepción
                if (DateTime.Compare(sel, DateTime.Today.Date) < 0)
                {
                    MessageBox.Show("La fecha no puede ser de vigencia no puede ser menor que ayer.", "Error de fecha", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentOutOfRangeException("Fecha", "La fecha es menor que hoy.");
                } else if (sel.Subtract(DateTime.Today.Date).Days > 30)
                {
                    MessageBox.Show("La fecha de vigencia no puede ser mayor a un mes de hoy.", "Error de fecha de vigencia", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentOutOfRangeException("Fecha", "La fecha es mayor a un mes de hoy.");
                }

                textFinVigencia.Text = CalcularFinVigencia().ToString("d");
            }
            catch (ArgumentOutOfRangeException)
            {
                dateInicioVigencia.SelectedDate = DateTime.Today;
            }
        }

        /// <summary>
        /// Calcula la prima anual de acuerdo a los requerimientos del negocio.
        /// </summary>
        /// <returns>La prima anual en pesos</returns>
        private int CalcularPrimaAnual()
        {
            //TODO: Actualizar en caso de actualización de librería
            Tarificador tar = new Tarificador();
            tar.Cliente = _clienteCargado;
            int a = 0;
            //hay que modificar esto
            int resultado = (int)Math.Round(tar.CalcularPrima(a));
            return resultado;
        }

        private int CalcularPrimaMensual()
        {
            int resultado;
            double primaAnual = CalcularPrimaAnual();
            resultado = (int)Math.Round(primaAnual / 12);
            return resultado;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Actualizar los datos
            Plan plan = new Plan();
            textoPoliza.Content = plan.PolizaActual;
            if(_clienteCargado is  null)
            {

            } else
            {
                MostrarPrimas();
            }

        }

        private void MostrarPrimas()
        {
            textoPrimaAnual.Content = CalcularPrimaAnual();
            textoPrimaMensual.Content = CalcularPrimaMensual();
        }

        /// <summary>
        /// Crea un contrato con los datos ingresados a través de la interfaz
        /// sin el número de contrato
        /// </summary>
        /// <returns>Retorna objeto de tipo Contrato sin número.</returns>
        private Contrato CrearContratoDeInterfaz()
        {

            Contrato contrato = new Contrato();
            contrato.Creacion = DateTime.Today;
            contrato.Titular = _clienteCargado;
            //contrato.PlanAsociado = Plan??
            //contrato.Poliza = contrato.PlanAsociado.PolizaActual;
            contrato.IniVigencia = (DateTime) dateInicioVigencia.SelectedDate;
            contrato.FinVigencia = CalcularFinVigencia();
            contrato.EstaVigente = true;
            contrato.ConDeclaracionDeSalud = (bool)checkConDeclaracionSalud.IsChecked;
            contrato.PrimaAnual = CalcularPrimaAnual();
            contrato.PrimaMensual = CalcularPrimaMensual();
            contrato.Obsevaciones = textoObservaciones.Text;
            return contrato;

        }

        private DateTime CalcularFinVigencia()
        {
            DateTime fecha = (DateTime) dateInicioVigencia.SelectedDate;
            return fecha.AddYears(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime hoy = DateTime.Today;
            Contrato contrato;
            try
            {
                contrato = CrearContratoDeInterfaz();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al captar la informacion.");
                return;
            }
            long numeroContrato = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            contrato.NumContrato = (int)numeroContrato;
            MessageBox.Show("Estos son los datos: Numero contrato = " + numeroContrato);
        }

        private void CargarContratoAInterfaz(Contrato contrato)
        {
            numeroContrato.Content = contrato.NumContrato;
            textoObservaciones.Text = contrato.Obsevaciones;
            dateCreacion.Text = contrato.Creacion.ToString("d");
            dateInicioVigencia.SelectedDate = contrato.IniVigencia;
            _clienteCargado = contrato.Titular;
            comboBoxPlan.SelectedIndex = contrato.PlanAsociado.ID;
            textFinVigencia.Text = contrato.FinVigencia.ToString("d");
            textoPrimaAnual.Content = contrato.PrimaAnual;
            textoPrimaMensual.Content = contrato.PrimaMensual;
            textoPoliza.Content = contrato.Poliza;

        }

        private void LlenarDatosClientes(Cliente cliente)
        {
            textoNombreCliente.Text = cliente.Nombre;
            textoApellidoCliente.Text = cliente.Apellidos;
        }
    }
}
