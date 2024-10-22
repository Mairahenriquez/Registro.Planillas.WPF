using Registro.Planillas.WPF.Models;
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
using Registro.Planillas.Entities;
using System.Data.Entity;

namespace Registro.Planillas.WPF
{
    /// <summary>
    /// Lógica de interacción para ListaEmpleados.xaml
    /// </summary>
    public partial class ListaEmpleados : Page
    {
        contexto db = new contexto();

        public ListaEmpleados()
        {
            InitializeComponent();
        }

        private void cargarTabla(object sender, RoutedEventArgs e)
        {
            var empleados = db.Set<Empleado>().Select(emp => new { emp.empleado_id, emp.dui, emp.nombres, emp.apellidos, emp.residencia, emp.telefono, emp.fecha_contrato });
            empleadosDataGrid.ItemsSource = empleados.ToList();
        }

        private void agregarEmpleado(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AgregarEmpleado.xaml", UriKind.Relative));
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        { 
                this.NavigationService.Navigate(new Uri("EditarEmpleado.xaml", UriKind.Relative));

        }
    }
}
