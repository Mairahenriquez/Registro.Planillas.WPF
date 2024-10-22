using Registro.Planillas.Entities;
using Registro.Planillas.WPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro.Planillas.WPF
{
    /// <summary>
    /// Lógica de interacción para EditarEmpleado.xaml
    /// </summary>
    public partial class EditarEmpleado : Page
    {
        contexto contexto = new contexto();
        int tipoBusqueda = 0;

        public EditarEmpleado()
        {
            InitializeComponent();
        }

        public void page_Loaded(object sender, RoutedEventArgs e)
        {
            Empleado empleado = (Empleado) Application.Current.Properties["empleado_editar"];
            if (empleado != null)
            {
                duiTxtbox.Text = empleado.dui;
                nombresTxtBox.Text = empleado.nombres;
                apellidosTxtbox.Text = empleado.apellidos;
                //issTextBox.Text ;
                salarioInput.Value = empleado.salario_base;
                residenciaTxtbox.Text = empleado.residencia;
                telefonoTxtbox.Text = empleado.telefono;
            }
        }

        private void cargoCmbBox_Loaded(object sender, RoutedEventArgs e)
        {
            contexto.cargos.Load();
            List<String> cargosTexto = new List<String>();
            foreach (var item in contexto.cargos.Local.ToList())
            {
                cargosTexto.Add(item.cargo_id + "- " + item.nombre);
            }
            cargoCmbBox.ItemsSource = cargosTexto;
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Validando formulario esté lleno
            if (nombresTxtBox.Text != "" && apellidosTxtbox.Text != "" && duiTxtbox.Text != "" && cargoCmbBox.Text != "" &&
                salarioInput.Value.ToString() != "" && residenciaTxtbox.Text != "" && telefonoTxtbox.Text != "")
            {
                string nombres = nombresTxtBox.Text;
                string apellidos = apellidosTxtbox.Text;
                string dui = duiTxtbox.Text;
                string cargo = cargoCmbBox.Text;
                Regex regex = new Regex("\\d+(?=-)", RegexOptions.IgnoreCase);//obtiene el numero de cargo seleccionado
                cargo = regex.Match(cargo).Value;
                float salario = float.Parse(salarioInput.Value.ToString());
                string isss = issTextBox.Text;
                string residencia = residenciaTxtbox.Text;
                string telefono = telefonoTxtbox.Text;

                Empleado empleado = contexto.empleados.First(emp => emp.dui == dui);
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
                
                if (contexto.SaveChanges() > 0)//cambios guardados en la bd
                {
                    string messageBoxText = "Se guardó correctamente el empleado";
                    string caption = "Mensaje de confirmación";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                }
                else//no se guardó nada en la bd
                {
                    string messageBoxText = "Ocurrió un error";
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

        private void buscarBtn_Click(object sender, RoutedEventArgs e)
        {
            string dui = txtboxSearch.Text;
            Empleado empleado = contexto.empleados.Where(emp => emp.dui == dui).FirstOrDefault();
            if (empleado != null)
            {
                duiTxtbox.Text = empleado.dui;
                nombresTxtBox.Text = empleado.nombres;
                apellidosTxtbox.Text = empleado.apellidos;
                cargoCmbBox.IsEnabled = true;
                salarioInput.Value = empleado.salario_base;
                issTextBox.Text = empleado.isss == null? "": empleado.isss;
                residenciaTxtbox.Text = empleado.residencia;
                telefonoTxtbox.Text = empleado.telefono;

                //Cargo a seleccionar por defecto en el Combobox
                Regex regex = new Regex("\\d+(?=-)", RegexOptions.IgnoreCase);//obtiene el numero de cargo seleccionado
                int indiceCmbox = 0;
                int cont = 0;
                foreach(var c in cargoCmbBox.ItemsSource)
                {
                    if(regex.Match(c.ToString()).Value == empleado.cargo_id.ToString())
                    {
                        indiceCmbox = cont;//indice del item a mostrar
                    }
                    cont++;
                }
                cargoCmbBox.SelectedIndex = indiceCmbox;
            }
            else
            {
                string messageBoxText = "No se encontró ningún empleado con ese DUI";
                string caption = "Mensaje de error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
