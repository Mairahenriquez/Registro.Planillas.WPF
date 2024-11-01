using Registro.Planillas.Entities;
using Registro.Planillas.WPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.Planillas.WPF
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        contexto db = new contexto();

        public Empleados()
        {
            InitializeComponent();
        }

        private void cargarTabla()
        {
            //var empleados = db.Set<Empleado>().Select(emp => new { emp.empleado_id, emp.dui, emp.isss, emp.nombres, emp.apellidos, emp.salario_base, emp.residencia, emp.telefono, emp.fecha_contrato });
            try
            {
                var resultado = (from empleados in db.empleados
                                 join cargos in db.cargos
                                 on empleados.cargo_id equals cargos.cargo_id
                                 select new
                                 {
                                     ID = empleados.empresa_id,
                                     Nombres = empleados.nombres,
                                     Apellidos = empleados.apellidos,
                                     Cargo = cargos.nombre,
                                     Salario = empleados.salario_base,
                                     Telefono = empleados.telefono,
                                     Residencia = empleados.residencia
                                 });
                empleadosDataGrid.ItemsSource = resultado.ToList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }
        private void empleadosDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTabla();
        }

        private void agregarEmpleado(object sender, RoutedEventArgs e)
        {
            AgregarEmpleado agregarEmpleado_ventana = new AgregarEmpleado(this);
            agregarEmpleado_ventana.Show();
            this.Hide();
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            EditarEmpleado editarEmpleado_ventana = new EditarEmpleado(this);
            editarEmpleado_ventana.Show();
            this.Hide();

        }

        private void eliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("(?!\\s*=\\s*)(\\d)+", RegexOptions.IgnoreCase);
            var itemString = empleadosDataGrid.SelectedItem;
            if(itemString != null)
            {
                string empleadoid = regex.Match(itemString.ToString()).Value;
                Empleado empleado = db.empleados.Find(int.Parse(empleadoid));
                string messageBoxText = "¿Está seguro de eliminar el empleado N°: " + empleado.empleado_id + ", con nombre " + empleado.nombres + " " + empleado.apellidos;
                string caption = "Mensaje de confirmación";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    db.empleados.Remove(empleado);
                    if(db.SaveChanges() > 0)
                    {
                        messageBoxText = "¡¡¡Dato familiar eliminado exitosamente!!";
                        caption = "Mensaje de eliminación";
                        button = MessageBoxButton.OK;
                        icon = MessageBoxImage.Information;
                        MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                        cargarTabla();
                    }
                    else
                    {
                        messageBoxText = "No se pudo eliminar el dato familiar";
                        caption = "Error";
                        button = MessageBoxButton.OK;
                        icon = MessageBoxImage.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                    }
                }
            }
            else
            {
                string messageBoxText = "Debe seleccionar una fila de la tabla";
                string caption = "Aviso";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }

        }

        private void ventana_Activated(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}
