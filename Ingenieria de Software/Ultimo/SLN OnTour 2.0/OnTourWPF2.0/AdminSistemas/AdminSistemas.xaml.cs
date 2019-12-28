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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;

namespace OnTourWPF2._0.AdminSistemas
{
    /// <summary>
    /// Lógica de interacción para AdminSistemas.xaml
    /// </summary>
    public partial class AdminSistemas : Window
    {
        bool MenuClosed = false;

        public AdminSistemas()
        {
            InitializeComponent();

            DatosMain();
        }

        public void DatosMain()
        {
            instance = this;
            this.tabcontrol1.SelectedIndex = 2;
            rec1.Visibility = Visibility.Visible;
            //----------------------------------//
            //Usuarios
            AdmUsuarios_DataGridUsuarios.ItemsSource = new UsuarioBLL().ListaUsuarios();

            //Cuentas
            AdmCuentas_DataGridUsuario.ItemsSource = new CuentaUsuario().ListaCuentas();

            CargarComboTipoCuenta();
            AdmCuentas_DataGridUsuario.ItemsSource = new CuentaUsuario().ListaCuentas();

        }

        #region MetodosSecundarios
        public static AdminSistemas instance = null;
        public static AdminSistemas _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminSistemas();
                }
                return instance;
            }
        }

        public String formatear(String rut)
        {

            int cont = 0;
            String format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {

                    format = rut.Substring(i, 1) + format;

                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        private void AdmCuentas_txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmCuentas_txtRut.Text = formatear(AdmCuentas_txtRut.Text);
        }

        private void AdmUsuarios_txtRutUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmUsuarios_txtRutUsuario.Text = formatear(AdmUsuarios_txtRutUsuario.Text);
        }

        public void CargarComboTipoCuenta()
        {
            AdmCuentas_cboTipoUsuario.ItemsSource = new TipoCuentaBLL().TipoCuenta();
            AdmCuentas_cboTipoUsuario.DisplayMemberPath = "Nombre";
            AdmCuentas_cboTipoUsuario.SelectedValuePath = "IdTipoCta";
        }

        public void LimpiarUsuario()
        {
            AdmUsuarios_txtRutUsuario.Text = string.Empty;
            AdmUsuarios_txtNombreUsuario.Text = string.Empty;
            AdmUsuarios_txtApPaternoUsuario.Text = string.Empty;
            AdmUsuarios_txtApMaternoUsuario.Text = string.Empty;
            AdmUsuarios_txtDireccionUsuario.Text = string.Empty;
            AdmUsuarios_txtEmailUsuario.Text = string.Empty;
        }

        public void LimpiarCuenta()
        {
            AdmCuentas_txtRut.Text = string.Empty;
            AdmCuentas_txtNombre.Text = string.Empty;
            AdmCuentas_txtApPaterno.Text = string.Empty;
            AdmCuentas_txtApMaterno.Text = string.Empty;
            AdmCuentas_cboTipoUsuario.SelectedValue = null;
            AdmCuentas_txtUsuario.Text = string.Empty;
            AdmCuentas_txtContraseña.Text = string.Empty;
            AdmCuentas_txtRepetirContraseña.Text = string.Empty;
        }

        #endregion MetodosSecundarios

        #region DiseñoInterfaz

        private void Btn_actividad_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 3;
        }

        private void Btn_ciudades_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 4;
        }

        private void Btn_paises_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 5;
        }

        private void MoveCursorMenu(int index)
        {

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }




        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:

                    this.tabcontrol1.SelectedIndex = 2;
                    rec1.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    btn_actividad.Visibility = Visibility.Hidden;
                    btn_ciudades.Visibility = Visibility.Hidden;
                    btn_paises.Visibility = Visibility.Hidden;
            
                    break;
                case 1:

                    this.tabcontrol1.SelectedIndex = 0;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    btn_actividad.Visibility = Visibility.Hidden;
                    btn_ciudades.Visibility = Visibility.Hidden;
                    btn_paises.Visibility = Visibility.Hidden;

                    break;
                case 2:

                    this.tabcontrol1.SelectedIndex = 1;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Visible;
                    rec4.Visibility = Visibility.Hidden;
                    btn_actividad.Visibility = Visibility.Hidden;
                    btn_ciudades.Visibility = Visibility.Hidden;
                    btn_paises.Visibility = Visibility.Hidden;

                    break;
                case 3:

                    this.tabcontrol1.SelectedIndex = 3;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Visible;
                    btn_actividad.Visibility = Visibility.Visible;
                    btn_ciudades.Visibility = Visibility.Visible;
                    btn_paises.Visibility = Visibility.Visible;

                    break;

            }
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard openMenu = (Storyboard)button.FindResource("OpenMenu");
                openMenu.Begin();
            }
            else
            {
                Storyboard closeMenu = (Storyboard)button.FindResource("CloseMenu");
                closeMenu.Begin();
            }

            MenuClosed = !MenuClosed;
        }
        private void Close_Windows(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Maximized(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;

            }
            else
            {
                this.WindowState = WindowState.Maximized;

            }
        }
        private void Minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

   
       
        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._instance.Show();
            this.Hide();
            instance = null;
        }



        #endregion DiseñoInterfaz

        #region AdmUsuarios
        private void AdmUsuarios_btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                UsuarioBLL u = new UsuarioBLL();
                u.Rut = Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text);
                u.Nombre = AdmUsuarios_txtNombreUsuario.Text;
                u.Apaterno = AdmUsuarios_txtApPaternoUsuario.Text;
                u.Amaterno = AdmUsuarios_txtApMaternoUsuario.Text;
                u.Direccion = AdmUsuarios_txtDireccionUsuario.Text;
                u.Email = AdmUsuarios_txtEmailUsuario.Text;

                var result = SystemException.ShowDialog("¿Está seguro que desea Agregar?", "Advertencia", SystemException.Buttons.Si_No);
                if (result.ToString() == "1")
                {
                    u.Agregar();
                    SystemException.ShowDialog("Usuario agregado corretamente", "Correcto", SystemException.Buttons.OK2);
                    AdmUsuarios_DataGridUsuarios.ItemsSource = u.ListaUsuarios();
                    LimpiarUsuario();

                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmUsuarios_btnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();

                u.Rut = Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text);
                u.Nombre = AdmUsuarios_txtNombreUsuario.Text;
                u.Apaterno = AdmUsuarios_txtApPaternoUsuario.Text;
                u.Amaterno = AdmUsuarios_txtApMaternoUsuario.Text;
                u.Direccion = AdmUsuarios_txtDireccionUsuario.Text;
                u.Email = AdmUsuarios_txtEmailUsuario.Text;

                var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);
                if (result.ToString() == "1")
                {
                    u.Actualizar();
                    SystemException.ShowDialog("Usuario actualizado corretamente", "Correcto", SystemException.Buttons.OK2);
                    AdmUsuarios_DataGridUsuarios.ItemsSource = u.ListaUsuarios();
                    LimpiarUsuario();
                }


            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmUsuarios_btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                u.Rut = Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text);

                var result = SystemException.ShowDialog("¿Está seguro que desea Eliminar?", "Advertencia", SystemException.Buttons.Si_No);
                if (result.ToString() == "1")
                {
                    u.Eliminar();
                    SystemException.ShowDialog("Usuario eliminado corretamente", "Correcto", SystemException.Buttons.OK2);
                    AdmUsuarios_DataGridUsuarios.ItemsSource = u.ListaUsuarios();
                    LimpiarUsuario();
                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmUsuarios_btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                if (u.BuscarUsuario(Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text)))
                {
                    foreach (var item in new UsuarioBLL().ListaUsuarios().Where(us => us.Rut == Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text)).ToList())
                    {
                        AdmUsuarios_txtNombreUsuario.Text = item.Nombre;
                        AdmUsuarios_txtApPaternoUsuario.Text = item.Apaterno;
                        AdmUsuarios_txtApMaternoUsuario.Text = item.Amaterno;
                        AdmUsuarios_txtDireccionUsuario.Text = item.Direccion;
                        AdmUsuarios_txtEmailUsuario.Text = item.Email;

                        return;
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

        #endregion AdmUsuarios

        #region AdmCuentas_RegistroUsuarios

        private void AdmCuentas_btnBuscarUsuario1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                if (u.BuscarUsuario(Herramientas.formatearRut(AdmCuentas_txtRut.Text)))
                {
                    foreach (var item in u.ListaUsuarios())
                    {
                        if (item.Rut == Herramientas.formatearRut(AdmUsuarios_txtRutUsuario.Text))
                        {
                            AdmCuentas_txtNombre.Text = item.Nombre;
                            AdmCuentas_txtApPaterno.Text = item.Apaterno;
                            AdmCuentas_txtApMaterno.Text = item.Amaterno;
                            AdmUsuarios_txtEmailUsuario.Text = item.Email;

                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el rut");
                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCuentas_btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CuentaUsuario c = new CuentaUsuario();
                if (c.BuscarUsuario(AdmCuentas_txtUsuario.Text) == false)
                {
                    c.Usuario = AdmCuentas_txtUsuario.Text;
                    c.Contraseña = AdmCuentas_txtContraseña.Text;
                    c.Rut = Herramientas.formatearRut(AdmCuentas_txtRut.Text);
                    c.Nombre = AdmCuentas_txtNombre.Text + " " + AdmCuentas_txtApPaterno.Text;
                    c.IdTipoCta = Convert.ToInt32(AdmCuentas_cboTipoUsuario.SelectedValue);

                    if (AdmCuentas_txtContraseña.Text == AdmCuentas_txtRepetirContraseña.Text)
                    {
                        var result = SystemException.ShowDialog("¿Está seguro que desea agregar?", "Advertencia", SystemException.Buttons.Si_No);

                        if (result.ToString() == "1")
                        {
                            c.Agregar();
                            LimpiarCuenta();
                            AdmCuentas_DataGridUsuario.ItemsSource = c.ListaCuentas();
                            SystemException.ShowDialog("Usuario agregado Correctamente", "Correcto", SystemException.Buttons.OK2);
                        }
                    }
                    else
                    {
                        throw new Exception("Contraseñas no son identicas");
                    }
                }
                else
                {
                    throw new Exception("Cuenta ya registrada");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCuentas_btnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CuentaUsuario c = new CuentaUsuario();
                if (c.BuscarUsuario(AdmCuentas_txtUsuario.Text))
                {
                    c.Usuario = AdmCuentas_txtUsuario.Text;
                    c.Contraseña = AdmCuentas_txtContraseña.Text;
                    c.Rut = Herramientas.formatearRut(AdmCuentas_txtRut.Text);
                    c.Nombre = AdmCuentas_txtNombre.Text + " " + AdmCuentas_txtApPaterno.Text;
                    c.IdTipoCta = Convert.ToInt32(AdmCuentas_cboTipoUsuario.SelectedValue);

                    if (AdmCuentas_txtContraseña.Text == AdmCuentas_txtRepetirContraseña.Text)
                    {
                        var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                        if (result.ToString() == "1")
                        {
                            c.Actualizar();
                            LimpiarCuenta();
                            AdmCuentas_DataGridUsuario.ItemsSource = c.ListaCuentas();
                            SystemException.ShowDialog("Usuario actualizado Correctamente", "Correcto", SystemException.Buttons.OK2);
                        }
                    }
                    else
                    {
                        throw new Exception("Contraseñas no son identicas");
                    }
                }
                else
                {
                    throw new Exception("Cuenta ya registrada");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCuentas_btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CuentaUsuario c = new CuentaUsuario();
                if (c.BuscarUsuario(AdmCuentas_txtUsuario.Text))
                {
                    c.Usuario = AdmCuentas_txtUsuario.Text;

                    var result = SystemException.ShowDialog("¿Está seguro que desea eliminar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        c.Eliminar();
                        LimpiarCuenta();
                        AdmCuentas_DataGridUsuario.ItemsSource = c.ListaCuentas();
                        SystemException.ShowDialog("Usuario eliminado Correctamente", "Correcto", SystemException.Buttons.OK2);
                    }
                }
                else
                {
                    throw new Exception("Cuenta ya registrada");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }
        private void AdmCuentas_btnBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CuentaUsuario c = new CuentaUsuario();
                if (c.BuscarUsuario(AdmCuentas_txtUsuario.Text))
                {
                    foreach (var item in c.ListaCuentas())
                    {
                        if (item.Usuario == AdmCuentas_txtUsuario.Text)
                        {
                            AdmCuentas_txtRut.Text = item.Rut;
                            AdmCuentas_txtNombre.Text = new UsuarioBLL().ListaUsuarios().Where(a => a.Rut == item.Rut).FirstOrDefault().Nombre;
                            AdmCuentas_txtApPaterno.Text = new UsuarioBLL().ListaUsuarios().Where(a => a.Rut == item.Rut).FirstOrDefault().Apaterno;
                            AdmCuentas_txtApMaterno.Text = new UsuarioBLL().ListaUsuarios().Where(a => a.Rut == item.Rut).FirstOrDefault().Amaterno;
                            AdmCuentas_cboTipoUsuario.SelectedValue = item.IdTipoCta;
                            AdmCuentas_txtContraseña.Text = item.Contraseña;
                            AdmCuentas_txtRepetirContraseña.Text = item.Contraseña;

                            return;
                        }
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

        #endregion AdmCuentas_RegistroUsuarios
    }
}
