using MahApps.Metro.Controls;
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

namespace Registro.Planillas.WPF
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        Empleados _empleadosVentana;
        DatosFamiliares datosFamiliares;
        public Menu()
        {
            InitializeComponent();
        }

        //Service1Client servicio = new Service1Client();
        public string pUsuario { get; set; }

        private void btnProceso_MouseLeave(object sender, MouseEventArgs e)
        {
            btnProceso.BorderBrush = Brushes.Transparent;
            btnProceso.Opacity = 0.9;
        }

        private void btnProceso_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProceso_MouseEnter(object sender, MouseEventArgs e)
        {
            btnProceso.BorderBrush = Brushes.White;
            btnProceso.Opacity = 1;
        }

        private void btnUsuarios_MouseLeave(object sender, MouseEventArgs e)
        {
            btnUsuarios.BorderBrush = Brushes.Transparent;
            btnUsuarios.Opacity = 0.9;
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsuarios_MouseEnter(object sender, MouseEventArgs e)
        {
            btnUsuarios.BorderBrush = Brushes.White;
            btnUsuarios.Opacity = 1;
        }

        private void btnEmpleados_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            if (_empleadosVentana == null || !_empleadosVentana.IsLoaded)
            {
                _empleadosVentana = new Empleados();
                _empleadosVentana.Show();
            }
            else
            {
                _empleadosVentana.Focus();
            }
        }

        private void btnEmpleados_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnEmpresa_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnEmpresa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmpresa_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnConfig_MouseLeave(object sender, MouseEventArgs e)
        {
            btnConfig.BorderBrush = Brushes.Transparent;
            btnConfig.Opacity = 0.9;
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConfig_MouseEnter(object sender, MouseEventArgs e)
        {
            btnConfig.BorderBrush = Brushes.White;
            btnConfig.Opacity = 1;
        }

        private void btnPlanillas_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnPlanillas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlanillas_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnCargo_MouseLeave(object sender, MouseEventArgs e)
        {
            btnCargo.BorderBrush = Brushes.Transparent;
            btnCargo.Opacity = 0.9;
        }

        private void btnCargo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCargo_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCargo.BorderBrush = Brushes.White;
            btnCargo.Opacity = 1;
        }

        private void btnAccionPersonal_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnAccionPersonal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccionPersonal_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnRoles_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }

        private void btnRoles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRoles_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnReporte_MouseLeave(object sender, MouseEventArgs e)
        {
            btnReporte.BorderBrush = Brushes.Transparent;
            btnReporte.Opacity = 0.9;
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        { 

        }

        private void btnReporte_MouseEnter(object sender, MouseEventArgs e)
        {
            btnReporte.BorderBrush = Brushes.White;
            btnReporte.Opacity = 1;
        }

        private void btnDatosF_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDatosF.BorderBrush = Brushes.Transparent;
            btnDatosF.Opacity = 0.9;
        }

        private void btnDatosF_Click(object sender, RoutedEventArgs e)
        {
            if (datosFamiliares == null || !datosFamiliares.IsLoaded)
            {
                datosFamiliares = new DatosFamiliares();
                datosFamiliares.Show();
            }
            else
            {
                datosFamiliares.Focus();
            }
        }

        private void btnDatosF_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDatosF.BorderBrush = Brushes.White;
            btnDatosF.Opacity = 1;
        }

        private void btnRepor1_MouseLeave(object sender, MouseEventArgs e)
        {
            btnReporte.BorderBrush = Brushes.Transparent;
            btnReporte.Opacity = 0.9;
        }

        private void btnRepor1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRepor1_MouseEnter(object sender, MouseEventArgs e)
        {
            btnReporte.BorderBrush = Brushes.White;
            btnReporte.Opacity = 1;
        }
        //
        private void btnMateria_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnMateria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMateria_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnGrado_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnGrado_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGrado_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btnSeccion_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSeccion.BorderBrush = Brushes.Transparent;
            btnSeccion.Opacity = 0.9;
        }

        private void btnSeccion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSeccion_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSeccion.BorderBrush = Brushes.White;
            btnSeccion.Opacity = 1;
        }

        private void MenuVentana_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuVentana_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer digitalClock = new System.Windows.Threading.DispatcherTimer();
            digitalClock.Interval = new System.TimeSpan(0, 0, 1);
            digitalClock.Tick += digitalClock_Tick;
            digitalClock.Start();
        }
        private void digitalClock_Tick(object sender, EventArgs e)
        {
            this.Reloj.Content = string.Format("{0} : {1} : {2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            this.Fecha.Content = string.Format(DateTime.Now.ToLongDateString());
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            FlyoutMenu.IsOpen = true;
        }

        private void Inicio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Menu _ver = new Menu();
            _ver.Show();
            this.Close();
        }

        private void Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _ver = new Login();
            //_ver.Show();
            this.Close();
        }

        private void btnBuscar_MouseLeave(object sender, MouseEventArgs e)
        {
            btnBuscar.BorderBrush = Brushes.Transparent;
            btnBuscar.Opacity = 0.9;
        }

        private void btnBuscar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnBuscar.BorderBrush = Brushes.White;
            btnBuscar.Opacity = 1;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOtros_MouseLeave(object sender, MouseEventArgs e)
        {
            btnBuscar.BorderBrush = Brushes.Transparent;
            btnBuscar.Opacity = 0.9;
        }

        private void btnOtros_MouseEnter(object sender, MouseEventArgs e)
        {
            btnBuscar.BorderBrush = Brushes.White;
            btnBuscar.Opacity = 1;
        }

        private void btnOtros_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
