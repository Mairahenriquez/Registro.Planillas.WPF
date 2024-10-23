using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Registro.Planillas.Entities;
using Registro.Planillas.WPF.Models;
using Registro.Planillas.WPF.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro.Planillas.WPF
{
    /// <summary>
    /// Lógica de interacción para AgregarEmpleado.xaml
    /// </summary>
    public partial class AgregarEmpleado : Window
    {
        contexto contexto = new contexto();
        Window ventanaAnterior;

        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        public AgregarEmpleado(Window ventanaAnterior)
        {
            InitializeComponent();
            this.ventanaAnterior = ventanaAnterior;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Validando formulario esté lleno
            if(nombresTxtBox.Text != "" && apellidosTxtbox.Text != "" && duiTxtbox.Text != "" && cargoCmbBox.Text != "" &&
                salarioInput.Value.ToString() != "" && residenciaTxtbox.Text != "" && telefonoTxtbox.Text != ""){
                string nombres = nombresTxtBox.Text;
                string apellidos = apellidosTxtbox.Text;
                string dui = duiTxtbox.Text;
                string cargo = cargoCmbBox.Text;
                Regex regex = new Regex("\\d+(?=-)", RegexOptions.IgnoreCase);//obtiene el numero de cargo seleccionado
                cargo = regex.Match(cargo).Value;
                float salario = float.Parse(salarioInput.Value.ToString());
                string isss = isssTxtbox.Text;
                string residencia = residenciaTxtbox.Text;
                string telefono = telefonoTxtbox.Text;

                Empleado empleado = new Empleado();
                empleado.nombres = nombres;
                empleado.apellidos = apellidos;
                empleado.dui = dui;
                empleado.isss = isss;
                empleado.cargo_id = int.Parse(cargo);
                empleado.salario_base = salario;
                empleado.residencia = residencia;
                empleado.telefono = telefono;
                empleado.fecha_contrato = DateTime.Now.Date;//fecha actual
                empleado.empresa_id = 2;
                contexto.empleados.Add(empleado);
                if (contexto.SaveChanges() > 0)//cambios guardados en la bd
                {
                    string messageBoxText = "Se guardó correctamente el empleado";
                    string caption = "Mensaje de confirmación";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    btnGuardar.IsEnabled = false;
                    btnCancelar.Content = "CERRAR";

                }
                else//no se guardó nada en la bd
                {
                    string messageBoxText = "ocurrió un error";
                    string caption = "Mensaje de confirmación";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                }

            }
            else//formulario vacío
            {
                string messageBoxText = "Llene todos los campos";
                string caption = "Formulario incompleto";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }

        }

        private void cmbBox_Loaded(object sender, RoutedEventArgs e)
        {
            contexto.cargos.Load();
            List<String> cargosTexto = new List<String>(); 
            foreach (var item in contexto.cargos.Local.ToList())
            {
                cargosTexto.Add(item.cargo_id + "- " + item.nombre);
            }
            cargoCmbBox.ItemsSource = cargosTexto;
            Application.Current.Properties["cargosTexto"] = cargosTexto;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (ventanaAnterior != null)
                ventanaAnterior.Show();
        }

        private void ventana_Closed(object sender, EventArgs e)
        {
            if (ventanaAnterior != null)
                ventanaAnterior.Show();
        }
    }
}
