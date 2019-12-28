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
using System.Windows.Shapes;
using BLL;

namespace OnTourWPF2._0.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Alumnos.xaml
    /// </summary>
    public partial class Alumnos : Window
    {
        public Alumnos()
        {
            InitializeComponent();
            CargarComboCurso();
        }

        public void CargarComboCurso()
        {
            cboCursoAlumno.ItemsSource = new CursoBLL().ListaCursos();
            cboCursoAlumno.DisplayMemberPath = "IdCurso";
            cboCursoAlumno.SelectedValuePath = "IdCurso";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void BtnAgregarAlumno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AlumnoBLL a = new AlumnoBLL();
                a.rutalumno = txtRutAlumno.Text;
                a.nombre = txtNombreAlumno.Text;
                a.apaterno = txtApaternoAlumno.Text;
                a.amaterno = txtAmaternoAlumno.Text;
                a.direccion = txtDireccionAlumno.Text;
                a.curso_idcurso = cboCursoAlumno.SelectedValue.ToString();

                a.Agregar();
                SystemException.ShowDialog("Alumno agregado correctamente", "Correcto", SystemException.Buttons.OK2);
                DataGridAlumno.ItemsSource = a.ListaAlumnos();
            }
            catch(Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void BtnActualizarAlumno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AlumnoBLL a = new AlumnoBLL();
                a.rutalumno = txtRutAlumno.Text;
                a.nombre = txtNombreAlumno.Text;
                a.apaterno = txtApaternoAlumno.Text;
                a.amaterno = txtAmaternoAlumno.Text;
                a.direccion = txtDireccionAlumno.Text;
                a.curso_idcurso = cboCursoAlumno.SelectedValue.ToString();

                a.Actualizar();
                SystemException.ShowDialog("Alumno actualizado correctamente", "Correcto", SystemException.Buttons.OK2);
                DataGridAlumno.ItemsSource = a.ListaAlumnos();
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void BtnEliminarAlumno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AlumnoBLL a = new AlumnoBLL();
                a.rutalumno = txtRutAlumno.Text;

                a.Eliminar();
                SystemException.ShowDialog("Alumno eliminado correctamente", "Correcto", SystemException.Buttons.OK2);
                DataGridAlumno.ItemsSource = a.ListaAlumnos();
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }
    }
}
