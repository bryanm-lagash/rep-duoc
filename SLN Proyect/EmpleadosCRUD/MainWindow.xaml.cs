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

namespace EmpleadosCRUD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarDatos();
        }
        #region Empleado
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpleadoBLL em = new EmpleadoBLL();
                if (!em.BuscarEmpleado(txtRutEmpleado.Text)) 
                {
                    em.Rut = txtRutEmpleado.Text;
                    em.Nombres = txtNombres.Text;
                    em.Apellidos = txtApellidos.Text;
                    em.Genero = txtGenero.Text;
                    em.FechaNacimiento = DateTime.Parse(FechaNacimiento.SelectedDate.ToString());
                    em.Direccion = txtDireccion.Text;
                    em.Telefono = txtTelefono.Text;
                    em.Profesion = txtProfesion.Text;
                    em.Email = txtEmail.Text;
                    em.ImagePath = null;
                    em.CargasFamiliares = int.Parse(txtCargasFamiliares.Text);

                    var result = MessageBox.Show("¿Está seguro que desea agregar?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        em.Agregar();
                        MessageBox.Show("Empleado agregado corretamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                        GrillaEmpleados.ItemsSource = em.ListaEmpleados();
                        Limpiar();
                    }
                }
                else
                {
                    throw new Exception("El empleado ya se encuentra registrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpleadoBLL em = new EmpleadoBLL();
                var Empleado = em.ListaEmpleados().Where(a => a.Rut == txtRutEmpleado.Text).FirstOrDefault();
                if (Empleado != null)
                {
                    txtRutEmpleado.Text = Empleado.Rut;
                    txtNombres.Text = Empleado.Nombres;
                    txtApellidos.Text = Empleado.Apellidos;
                    txtGenero.Text = Empleado.Genero;
                    FechaNacimiento.SelectedDate = Empleado.FechaNacimiento;
                    txtDireccion.Text = Empleado.Direccion;
                    txtTelefono.Text = Empleado.Telefono.ToString();
                    txtProfesion.Text = Empleado.Profesion;
                    txtEmail.Text = Empleado.Email;
                    txtCargasFamiliares.Text = Empleado.CargasFamiliares.ToString();
                }
                else { throw new Exception("No es posible encontrar el empleado"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpleadoBLL em = new EmpleadoBLL();
                if (em.BuscarEmpleado(txtRutEmpleado.Text))
                {
                    em.Rut = txtRutEmpleado.Text;
                    em.Nombres = txtNombres.Text;
                    em.Apellidos = txtApellidos.Text;
                    em.Genero = txtGenero.Text;
                    em.FechaNacimiento = DateTime.Parse(FechaNacimiento.SelectedDate.ToString());
                    em.Direccion = txtDireccion.Text;
                    em.Telefono = txtTelefono.Text;
                    em.Profesion = txtProfesion.Text;
                    em.Email = txtEmail.Text;
                    em.CargasFamiliares = int.Parse(txtCargasFamiliares.Text);

                    var result = MessageBox.Show("¿Está seguro que desea actualizar?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        em.Actualizar();
                        MessageBox.Show("Empleado actualizado corretamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                        GrillaEmpleados.ItemsSource = em.ListaEmpleados();
                        Limpiar();
                    }
                }
                else
                {
                    throw new Exception("No se a encontrado empleado ha actualizar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpleadoBLL em = new EmpleadoBLL();
                if (em.BuscarEmpleado(txtRutEmpleado.Text))
                {
                    em.Rut = txtRutEmpleado.Text;
                    var result = MessageBox.Show("¿Está seguro que desea eliminar?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        em.Eliminar();
                        MessageBox.Show("Empleado eliminado corretamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                        GrillaEmpleados.ItemsSource = em.ListaEmpleados();
                        Limpiar();
                    }
                }
                else
                {
                    throw new Exception("No se a encontrado empleado a eliminar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        #endregion Empleado

        #region MetodosSecundarios
        public void CargarDatos()
        {
            GrillaEmpleados.ItemsSource = new EmpleadoBLL().ListaEmpleados();
        }

        public void Limpiar()
        {
            txtRutEmpleado.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtGenero.Text = string.Empty;
            FechaNacimiento.SelectedDate = null;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtProfesion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCargasFamiliares.Text = string.Empty;
        }
        #endregion MetodosSecundarios

        private void txtFiltrarPorRut_TextInput(object sender, TextCompositionEventArgs e)
        {
            //GrillaEmpleados.
        }

        private void txtFiltrarPorRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            GrillaEmpleados.ItemsSource = new EmpleadoBLL().ListaEmpleados().Where(a => a.Rut.Contains(txtRutEmpleado.Text)).ToList();
        }
    }
}
