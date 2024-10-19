using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Registro.Planillas.Entities;
using Registro.Planillas.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        contexto db = new contexto();
        usuarios _usuario = new usuarios();
        private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        public Login()
        {
            InitializeComponent();
        }
                
        private void Proceso()
        {
            BarraProgreso.Minimum = 0;
            BarraProgreso.Maximum = short.MaxValue;
            BarraProgreso.Value = 0;
            double value = 0;
            UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(BarraProgreso.SetValue);
            do
            {
                value += 3;
                Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background, new object[] { ProgressBar.ValueProperty, value });
            }
            while (BarraProgreso.Value != BarraProgreso.Maximum);
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //Asignar valores.
            _usuario.usuario = txtUsuario.Text;
            _usuario.clave = txtPass.Password;
            Menu _menu = new Menu();

            txtUsuario.Visibility = Visibility.Hidden;
            txtPass.Visibility = Visibility.Hidden;
            image.Visibility = Visibility.Hidden;
            btnAceptar.Visibility = Visibility.Hidden;
            BarraProgreso.Visibility = Visibility.Visible;
            txtmensaje1.Visibility = Visibility.Visible;
            
            //Mostrar progreso.
            Proceso();

            //Validar usuario.
            if (_usuario.usuario == null || _usuario.usuario == "" || _usuario.clave == null || _usuario.clave == "")
            {
                BarraProgreso.Visibility = Visibility.Hidden;
                txtmensaje1.Visibility = Visibility.Hidden;
                btnAceptar.Visibility = Visibility.Hidden;
                var mensaje = await this.ShowMessageAsync("Los campos están vacios", "Complete los datos");
                txtUsuario.Text = string.Empty;
                txtPass.Password = string.Empty;
                //progres.IsActive = true;
                txtUsuario.Focus();
            }
            else
            {
                try
                {
                    //Obtener registro.
                    usuarios getUsuario = db.usuarios.FirstOrDefault(u => u.usuario == _usuario.usuario);

                    //Si registro es diferente de null.
                    if (getUsuario != null)
                    {
                        // password match
                        if (getUsuario.clave == ConvertirSha256(_usuario.clave))
                        {
                            _menu.Show();
                            this.Close();
                        }
                        else
                        {
                            BarraProgreso.Visibility = Visibility.Hidden;
                            txtmensaje1.Visibility = Visibility.Hidden;
                            var mensaje = await this.ShowMessageAsync("La contraseña  es incorrecta", "Revisar datos");
                            txtUsuario.Text = string.Empty;
                            txtPass.Password = string.Empty;
                            txtUsuario.Focus();
                        }
                    }
                    else
                    {
                        BarraProgreso.Visibility = Visibility.Hidden;
                        txtmensaje1.Visibility = Visibility.Hidden;
                        var mensaje = await this.ShowMessageAsync("El usuario es incorrecto", "Revisar datos");
                        txtUsuario.Text = string.Empty;
                        txtPass.Password = string.Empty;
                        txtUsuario.Focus();
                    }
                }
                catch (Exception ex)
                {
                    BarraProgreso.Visibility = Visibility.Hidden;
                    txtmensaje1.Visibility = Visibility.Hidden;
                    var mensaje = await this.ShowMessageAsync("Usuario o Contraseña Incorrecto", "Error");
                    txtUsuario.Text = string.Empty;
                    txtPass.Password = string.Empty;
                    txtUsuario.Focus();
                }
            }
            txtUsuario.Visibility = Visibility.Visible;
            txtPass.Visibility = Visibility.Visible;
            image.Visibility = Visibility.Visible;
            btnAceptar.Visibility = Visibility.Visible;
            BarraProgreso.Visibility = Visibility.Hidden;
            txtmensaje1.Visibility = Visibility.Hidden;
        }

        public static string ConvertirSha256(string texto)
        {

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

    }
}
