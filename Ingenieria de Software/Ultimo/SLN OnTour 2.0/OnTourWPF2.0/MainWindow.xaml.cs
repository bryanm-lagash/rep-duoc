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
using BLL;

namespace OnTourWPF2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            instance = this;

            
            
        }

        public static MainWindow instance = null;

        public static MainWindow _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }

        

        private  void Window_MouseDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

       

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                CuentaUsuario c = new CuentaUsuario();
                if (c.BuscarUsuario(txtUsuario.Text))
                {
                    var Usuario = c.ListaCuentas().Where(ap => ap.Usuario == txtUsuario.Text).FirstOrDefault();
                    if (Usuario.Contraseña == txtContraseña.Password.ToString())
                    {
                        if (Usuario.IdTipoCta == 1)
                        {
                            Apoderados.Apoderados._instance.Show();
                            Apoderados.Apoderados._instance.txt_usuario_apoderados.Text = Usuario.Nombre;

                            this.Hide();
                            instance = null;
                        }
                        if (Usuario.IdTipoCta == 2)
                        {
                            AdminSistemas.AdminSistemas._instance.Show();
                            AdminSistemas.AdminSistemas._instance.txt_usuario_adminSistemas.Text = Usuario.Nombre;
                            this.Hide();
                            instance = null;
                        }
                        if (Usuario.IdTipoCta == 3)
                        {
                            EjecutivoVentas._instance.Show();
                            EjecutivoVentas._instance.txt_usuario_ejecutivoVentas.Text = Usuario.Nombre;
                            this.Hide();
                            instance = null;
                        }
                        if (Usuario.IdTipoCta == 4)
                        {
                            Dueño.Dueño._instance.Show();
                            Dueño.Dueño._instance.txt_usuario_dueño.Text = Usuario.Nombre;
                            this.Hide();
                            instance = null;
                        }
                    }
                    else
                    {
                        throw new Exception("Contraseña incorrecta");
                    }

                }
                else
                {
                    throw new Exception("No es posible encontrar el usuario");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Apoderados.Apoderados._instance.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AdminSistemas.AdminSistemas._instance.Show();
            this.Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Dueño.Dueño._instance.Show();
            this.Hide();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            EjecutivoVentas._instance.Show();
            this.Hide();
           
        }

        private void TxtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    CuentaUsuario c = new CuentaUsuario();
                    if (c.BuscarUsuario(txtUsuario.Text))
                    {
                        var Usuario = c.ListaCuentas().Where(ap => ap.Usuario == txtUsuario.Text).FirstOrDefault();
                        if (Usuario.Contraseña == txtContraseña.Password.ToString())
                        {
                            if (Usuario.IdTipoCta == 1)
                            {
                                Apoderados.Apoderados._instance.Show();
                                Apoderados.Apoderados._instance.txt_usuario_apoderados.Text = Usuario.Nombre;

                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 2)
                            {
                                AdminSistemas.AdminSistemas._instance.Show();
                                AdminSistemas.AdminSistemas._instance.txt_usuario_adminSistemas.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 3)
                            {
                                EjecutivoVentas._instance.Show();
                                EjecutivoVentas._instance.txt_usuario_ejecutivoVentas.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 4)
                            {
                                Dueño.Dueño._instance.Show();
                                Dueño.Dueño._instance.txt_usuario_dueño.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                        }
                        else
                        {
                            throw new Exception("Contraseña incorrecta");
                        }

                    }
                    else
                    {
                        throw new Exception("No es posible encontrar el usuario");
                    }
                }
                catch (Exception ex)
                {
                    SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
                }
            }
        }

        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    CuentaUsuario c = new CuentaUsuario();
                    if (c.BuscarUsuario(txtUsuario.Text))
                    {
                        var Usuario = c.ListaCuentas().Where(ap => ap.Usuario == txtUsuario.Text).FirstOrDefault();
                        if (Usuario.Contraseña == txtContraseña.Password.ToString())
                        {
                            if (Usuario.IdTipoCta == 1)
                            {
                                Apoderados.Apoderados._instance.Show();
                                Apoderados.Apoderados._instance.txt_usuario_apoderados.Text = Usuario.Nombre;

                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 2)
                            {
                                AdminSistemas.AdminSistemas._instance.Show();
                                AdminSistemas.AdminSistemas._instance.txt_usuario_adminSistemas.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 3)
                            {
                                EjecutivoVentas._instance.Show();
                                EjecutivoVentas._instance.txt_usuario_ejecutivoVentas.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                            if (Usuario.IdTipoCta == 4)
                            {
                                Dueño.Dueño._instance.Show();
                                Dueño.Dueño._instance.txt_usuario_dueño.Text = Usuario.Nombre;
                                this.Hide();
                                instance = null;
                            }
                        }
                        else
                        {
                            throw new Exception("Contraseña incorrecta");
                        }

                    }
                    else
                    {
                        throw new Exception("No es posible encontrar el usuario");
                    }
                }
                catch (Exception ex)
                {
                    SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
                }
            }
        }
    }
}
