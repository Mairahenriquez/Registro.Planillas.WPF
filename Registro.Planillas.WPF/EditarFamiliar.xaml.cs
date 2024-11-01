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
    /// Lógica de interacción para EditarFamiliar.xaml
    /// </summary>
    public partial class EditarFamiliar : Window
    {
        Window ventanaAnterior;
        contexto contexto;
        Familiares familiar;
        public EditarFamiliar()
        {
            InitializeComponent();
        }

        public EditarFamiliar(Window ventanaAnterior, Familiares familiar, contexto contexto)
        {
            InitializeComponent();
            this.ventanaAnterior = ventanaAnterior;
            this.familiar = familiar;
            this.contexto = contexto;
        }

        private void cmbBox_Loaded(object sender, RoutedEventArgs e)
        {
            contexto.empleados.Load();
            List<String> empleadosTexto = new List<String>();
            int selectedIndex = 0;
            int index = 0;
            foreach (var item in contexto.empleados.Local.ToList())
            {
                empleadosTexto.Add(item.empleado_id + "- " + item.nombres + " " + item.apellidos);
                if (item.empleado_id == familiar.empleado_id)
                    selectedIndex = index;
                index++;
            }
            empleadoCmbBox.ItemsSource = empleadosTexto;
            empleadoCmbBox.SelectedIndex = selectedIndex;
            Application.Current.Properties["empleadossTexto"] = empleadosTexto;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Validando formulario esté lleno
            if (nombresTxtBox.Text != "" && apellidosTxtBox.Text != "" && empleadoCmbBox.Text != ""
                && residenciaTxtBox.Text != "" && telefonoTxtBox.Text != "")
            {
                string empleado = empleadoCmbBox.Text;
                Regex regex = new Regex("\\d+(?=-)", RegexOptions.IgnoreCase);//obtiene el ID de empleado seleccionado
                empleado = regex.Match(empleado).Value;

                //Familiares nuevoFamiliar = contexto.familiares.First(fam => fam.familiar_id == familiar.familiar_id);
                familiar.nombres = nombresTxtBox.Text;
                familiar.apellidos = apellidosTxtBox.Text;
                familiar.empleado_id = int.Parse(empleado);
                familiar.residencia = residenciaTxtBox.Text;
                familiar.telefono = telefonoTxtBox.Text;

                if (contexto.SaveChanges() > 0)//cambios guardados en la bd
                {
                    string messageBoxText = "Se guardó correctamente el Dato Familiar";
                    string caption = "Mensaje de confirmación";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    empleadoCmbBox.SelectedIndex = 0;
                    nombresTxtBox.Text = "";
                    apellidosTxtBox.Text = "";
                    residenciaTxtBox.Text = "";
                    telefonoTxtBox.Text = ""; ;

                }
                else//no se guardó nada en la bd
                {
                    string messageBoxText = "Ocurrió un error al guardar el registro";
                    string caption = "Error";
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaAnterior != null)
            {
                string messageBoxText = "¿Seguro que desea cerrar esta ventana? Todos los datos ingresados no se guardarán";
                string caption = "Mensaje de confirmación";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    ventanaAnterior.Show();
                }
            }
        }

        private void window_OnLoaded(object sender, RoutedEventArgs e)
        {
            nombresTxtBox.Text = familiar.nombres;
            apellidosTxtBox.Text = familiar.apellidos;
            telefonoTxtBox.Text = familiar.telefono;
            residenciaTxtBox.Text = familiar.residencia;
        }

        private void window_OnClosed(object sender, EventArgs e)
        {
            if (ventanaAnterior != null)
                ventanaAnterior.Show();
        }
    }
}
