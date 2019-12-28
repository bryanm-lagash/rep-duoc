using OnTourWPF2._0.rutas;
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

namespace OnTourWPF2._0.Apoderados
{
    /// <summary>
    /// Lógica de interacción para Apoderados.xaml
    /// </summary>
    public partial class Apoderados : Window
    {
       
        bool MenuClosed = false;
        public Apoderados()
        {
            InitializeComponent();
            instance = this;
            this.tabcontrol1.SelectedIndex = 3;
            rec1.Visibility = Visibility.Visible;

            CargarComboNumeroContrato();
            CargarComboCursos();

        }

        public void CargarComboNumeroContrato()
        {
            cboNumeroContrato.ItemsSource = new ContratoBLL().ListContratos();
            cboNumeroContrato.DisplayMemberPath = "NumContrato";
            cboNumeroContrato.SelectedValuePath = "NumContrato";
        }

        public void CargarComboCursos()
        {
            cbo_curso_dc.ItemsSource = new CursoBLL().ListaCursos();
            cbo_curso_dc.DisplayMemberPath = "IdCurso";
            cbo_curso_dc.SelectedValuePath = "IdCurso";
        }

        public static Apoderados instance = null;

        public static Apoderados _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Apoderados();
                }
                return instance;
            }
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        
        

        private void MoveCursorMenu(int index)
        {

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

     

      

       
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                  
                    this.tabcontrol1.SelectedIndex = 3;
                    rec1.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                   
                    break;
                case 1:
                  
                    this.tabcontrol1.SelectedIndex = 0;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                   
                    break;
                case 2:
                  
                    this.tabcontrol1.SelectedIndex = 1;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Visible;
                    rec4.Visibility = Visibility.Hidden;
                   
                    break;
                case 3:
                  
                    this.tabcontrol1.SelectedIndex = 2;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Visible;
                    
                    break;
              



            }
          
        }
        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._instance.Show();
            this.Hide();
            instance = null;
        }

        private void Btn_descargar_Click(object sender, RoutedEventArgs e)
        {
            RutaContrato r = new RutaContrato();
            r.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RutaSeguro r = new RutaSeguro();
            r.Show();
        }

        private void CboNumeroContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = Convert.ToInt32(cboNumeroContrato.SelectedValue);

            var buscado = new ContratoBLL().ListaContratos().Where(c => c.NumContrato == v).FirstOrDefault();
            var buscarCurso = new CursoBLL().ListaCursos().Where(c => c.IdCurso == buscado.IdCurso).FirstOrDefault();
            var buscarColegio = new ColegioBLL().ListaColegios().Where(c => c.CodColegio == buscarCurso.CodColegio).FirstOrDefault();
            var buscarCiudad = new CiudadBLL().Lista().Where(c => c.CodCiudad == buscado.CodCiudad).FirstOrDefault();
            var buscarPais = new PaisBLL().ListaPaises().Where(c => c.CodPais == buscarCiudad.CodPais).FirstOrDefault();
            var buscarActividad = new TipoActividadesBLL().ListaTipoActividades().Where(C => C.IdTipoact == buscado.IdTipoAct).FirstOrDefault();
            var buscarMod = new ModalidadAportesBLL().ListaModalidadAportes().Where(c => c.IdMod == buscarActividad.Modaporte_Idmod).FirstOrDefault();

            txt_fechaCreacion_dc.Text = buscado.FechaCreacion.ToString();
            txt_fechaTermino_dc.Text = buscado.FechaTermino.ToString();
            txt_fechaInicioViaje_dc.Text = buscado.FechaIniViaje.ToString();
            txt_fechaTerminoViaje_dc.Text = buscado.FechaTerViaje.ToString();
            txt_destino_dc.Text = buscarPais.Nombre;
            txt_ciudadDestino_dc.Text = buscarCiudad.Nombre;
            txt_duracionDias_dc.Text = buscado.DuracionDias.ToString();
            txt_rutEjecutivo_dc.Text = buscado.RutUsuario;
            txt_tipoColegio_dc.Text = buscarColegio.Nombre;
            txt_actividad_dc.Text = buscarActividad.Nombre;
            txt_fechaPagos_dc.Text = buscado.FechaPagos;
            txt_costoSeguros_dc.Text = buscado.CostosSeguros.ToString();
            txt_modalidad_dc.Text = buscarMod.Nombre;
            txt_costoServicio_dc.Text = buscado.CostosServicios.ToString();
            txt_porcBeneficios_dc.Text = buscado.PorcBeneficios.ToString();
            txt_costoActividades_dc.Text = buscado.CostosActividades.ToString();
            txt_meta_dc.Text = buscado.Meta.ToString();
            txt_codColegio_dc.Text = buscarColegio.CodColegio;
            txt_nombreColegio_dc.Text = buscarColegio.Nombre;
            cbo_curso_dc.SelectedValue = buscado.IdCurso;




        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                AlumnoBLL a = new AlumnoBLL();
                if (a.BuscarAlumno(txt_rutAlumno_s.Text))
                {
                    var buscado = a.ListaAlumnos().Where(p => p.rutalumno == txt_rutAlumno_s.Text).FirstOrDefault();
                    var buscarCurso = new CursoBLL().ListaCursos().Where(q => q.IdCurso == buscado.curso_idcurso).FirstOrDefault();
                    var buscarContrato = new ContratoBLL().ListaContratos().Where(q => q.IdCurso == buscarCurso.IdCurso).FirstOrDefault();
                    var buscarDetalleSeguro = new DetalleSeguro().ListaDetalles().Where(q => q.NumContrato == buscarContrato.NumContrato).FirstOrDefault();
                    var buscarSeguro = new SeguroBLL().ListaSeguros().Where(q => q.IdSeguro == buscarDetalleSeguro.IdSeguro).FirstOrDefault();
                    var buscarEmpresa = new AseguradoraBLL().ListaAseguradora().Where(q => q.RutEmp == buscarSeguro.RutEmp).FirstOrDefault();
                    txt_nombreAlumno_s.Text = buscado.nombre + " " + buscado.apaterno;
                    txt_rutEmpresa_s.Text = buscarEmpresa.RutEmp;
                    txt_nombreEmpresa_s.Text = buscarEmpresa.Nombre;
                    txt_direccion_s.Text = buscarEmpresa.Direccion;
                    txt_telefono_s.Text = buscarEmpresa.Telefono.ToString();
                    txt_nombreSeguro_s.Text = buscarSeguro.Nombre;
                    txt_descripcion_s.Text = buscarSeguro.Descripcion;
                    txt_costoSeguros_dc.Text = buscarSeguro.Costo.ToString();
                }
                else
                {
                    throw new Exception("No es posible encontrar el alumno");
                }
                
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }
    }
}
