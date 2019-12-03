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
using ClasesBLL;

namespace PruebaUno
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonaBLL p = new PersonaBLL();
            p.Rut = txtRut.ToString();
            p.Nombre = txtNombre.ToString();
            p.Apellidos = txtApellido.ToString();
            p.Genero = txtGenero.ToString();
            p.Salario = int.Parse(txtSalario.Text);
            DateTime fecha = Convert.ToDateTime(string.Format("{0:yyyy-MM-dd}", txtFechaNacimiento));
            p.FechaNacimiento = fecha;

            p.Crear();
        }
    }
}
