using Registro.Planillas.Entities;
using Registro.Planillas.WPF.Models;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para DatosFamiliares.xaml
    /// </summary>
    public partial class DatosFamiliares : Window
    {
        contexto db = new contexto();
        public DatosFamiliares()
        {
            InitializeComponent();
        }

        public void cargarTabla()
        {
            try
            {
                var resultado = (from familiares in db.familiares
                                 join empleados in db.empleados
                                 on familiares.empleado_id equals empleados.empleado_id
                                 select new
                                 {
                                     ID = familiares.familiar_id,
                                     Nombres = familiares.nombres,
                                     Apellidos = familiares.apellidos,
                                     Residencia = familiares.residencia,
                                     Teléfono = familiares.telefono,
                                     ID_Empleado = empleados.empleado_id,
                                     Nombre_Empleado = empleados.nombres + " "+ empleados.apellidos
                                 });
                familiaresDataGrid.ItemsSource = resultado.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void empleadosDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTabla();
        }

        private void agregarBtn_Click(object sender, RoutedEventArgs e)
        {
            AgregarFamiliar agregarFamiliar_ventana = new AgregarFamiliar(this);
            agregarFamiliar_ventana.Show();
            this.Hide();
        }

        private void editarBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic itemSelected = familiaresDataGrid.SelectedItem;
            int familiarId = itemSelected.ID;
            Familiares familiar = db.familiares.First(fam => fam.familiar_id == familiarId);
            EditarFamiliar editarEmpleado_ventana = new EditarFamiliar(this, familiar, db);
            editarEmpleado_ventana.Show();
            this.Hide();

        }

        private void eliminarBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("(?!\\s*=\\s*)(\\d)+", RegexOptions.IgnoreCase);
            var itemString = familiaresDataGrid.SelectedItem;
            if (itemString != null)
            {
                string familiarid = regex.Match(itemString.ToString()).Value;
                Familiares familiar = db.familiares.Find(int.Parse(familiarid));
                string messageBoxText = "¿Está seguro de eliminar el registro N°: " + familiar.familiar_id + ", con nombre " + familiar.nombres + " " + familiar.apellidos;
                string caption = "Mensaje de confirmación";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    db.familiares.Remove(familiar);
                    if (db.SaveChanges() > 0)
                    {
                        messageBoxText = "¡¡¡Familiar eliminado exitosamente!!";
                        caption = "Mensaje de eliminación";
                        button = MessageBoxButton.OK;
                        icon = MessageBoxImage.Information;
                        MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                        cargarTabla();
                    }
                    else
                    {
                        messageBoxText = "No se pudo eliminar el registro";
                        caption = "Error";
                        button = MessageBoxButton.OK;
                        icon = MessageBoxImage.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                    }
                }
            }
            else
            {
                string messageBoxText = "Debe seleccionar un registro de la tabla";
                string caption = "Aviso";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }

        }

        private void window_Activated(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}
