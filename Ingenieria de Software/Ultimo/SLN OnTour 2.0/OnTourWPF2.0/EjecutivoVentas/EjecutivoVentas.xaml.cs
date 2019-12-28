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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using OnTourWPF2._0.Ventanas;

namespace OnTourWPF2._0
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class EjecutivoVentas : Window
    {
        bool MenuClosed = false;
        public EjecutivoVentas()
        {

            InitializeComponent();

            instance = this;
            rec1.Visibility = Visibility.Visible;
            ListViewMenu.SelectedIndex = 0;
            DatosMainWindow();

        }

        #region DatosMainWindow 
        public void DatosMainWindow()
        {
            //Administrar Cliente/Colegio
            CargarComboTipoColegio();
            AdmClientes_DataGridColegio.ItemsSource = new ColegioBLL().DataGridColegio();

            //Administrar Cliente/Curso
            CargarComboTipoColegioCurso();
            AdmCliente_DatagGridCurso.ItemsSource = new CursoBLL().DataGridCurso();

            AdmSeguros_DataGridAseguradora.ItemsSource = new AseguradoraBLL().ListaAseguradora();

            //Administracion de contrato
            CargarComboDestinos();
            CargarComboModalidadAportes();
            CargarComboAdmContratoSeguros();
            CargarComboAdmContratoBeneficios();
            CargarComboAdmContratoActividades();
            CargarComboAdmContratoCurso();
            CargarComboAdmContratoTipoColegio();

            //Administracion Seguros
            AdmSeguros_DataGridSeguros.ItemsSource = new SeguroBLL().ListaSeguros();

            //Adminstracion Depositos
            CargarComboCursoDesposito();
            CargarComboTipoColegioDepositos();
            AdmDeposito_DataGridDepositos.ItemsSource = new DepositoBLL().ListaDepositos();

            //Consulta Saldo
            DataGridDepositos.ItemsSource = new ContratoBLL().DataGridDepositos();
            CargarComboDepositoCurso();
            CargarComboDepositoTipoColegio();

        }
        #endregion DatosMainWindow

        #region MetodosSecundarios
        public static EjecutivoVentas instance = null;
        public static EjecutivoVentas _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EjecutivoVentas();
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

        private void AdmContrato_RutUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmContrato_RutUsuario.Text = formatear(AdmContrato_RutUsuario.Text);
        }

        private void AdmSeguros_txtRutAseguradoraSeguro_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmSeguros_txtRutAseguradoraSeguro.Text = formatear(AdmSeguros_txtRutAseguradoraSeguro.Text);
        }

        private void AdmSeguros_txtRutAseguradora_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmSeguros_txtRutAseguradora.Text = formatear(AdmSeguros_txtRutAseguradora.Text);
        }

        private void AdmDeposito_txtRutDepositante_LostFocus(object sender, RoutedEventArgs e)
        {
            AdmDeposito_txtRutDepositante.Text = formatear(AdmDeposito_txtRutDepositante.Text);
        }

        public void CargarComboTipoColegio()
        {
            AdmClientes_cboTipoColegio.ItemsSource = new TipoColegioBLL().ListaTipoColegio();
            AdmClientes_cboTipoColegio.DisplayMemberPath = "Nombre";
            AdmClientes_cboTipoColegio.SelectedValuePath = "IdTipoColegio";
        }

        public void CargarComboTipoColegioCurso()
        {
            AdmCliente_cboTipoColegio.ItemsSource = new TipoColegioBLL().ListaTipoColegio();
            AdmCliente_cboTipoColegio.DisplayMemberPath = "Nombre";
            AdmCliente_cboTipoColegio.SelectedValuePath = "IdTipoColegio";
        }

        public void CargarComboDestinos()
        {
            AdmContrato_cboPaisDestino.ItemsSource = new PaisBLL().ListaPaises();
            AdmContrato_cboPaisDestino.DisplayMemberPath = "Nombre";
            AdmContrato_cboPaisDestino.SelectedValuePath = "CodPais";

        }

        public void CargarComboAdmContratoTipoColegio()
        {
            AdmContrato_cboTipoColegio.ItemsSource = new TipoColegioBLL().ListaTipoColegio();
            AdmContrato_cboTipoColegio.DisplayMemberPath = "Nombre";
            AdmContrato_cboTipoColegio.SelectedValuePath = "IdTipoColegio";
        }

        public void CargarComboAdmContratoCurso()
        {
            AdmContrato_cboCurso.ItemsSource = new CursoBLL().ListaCursos();
            AdmContrato_cboCurso.DisplayMemberPath = "IdCurso";
            AdmContrato_cboCurso.SelectedValuePath = "IdCurso";
        }

        public void CargarComboModalidadAportes()
        {
            AdmContrato_cboModalidadAportes.ItemsSource = new ModalidadAportesBLL().ListaModalidadAportes();
            AdmContrato_cboModalidadAportes.DisplayMemberPath = "Nombre";
            AdmContrato_cboModalidadAportes.SelectedValuePath = "IdMod";
        }

        private void AdmContrato_cboModalidadAportes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = Convert.ToInt32(AdmContrato_cboModalidadAportes.SelectedValue);

            TipoActividadesBLL t = new TipoActividadesBLL();
            foreach (var item in t.ListaTipoActividades())
            {
                var ex = t.ListaTipoActividades().Where(p => p.Modaporte_Idmod == v).ToList();

                AdmContrato_cboTipoActividades.ItemsSource = ex;
                AdmContrato_cboTipoActividades.DisplayMemberPath = "Nombre";
                AdmContrato_cboTipoActividades.SelectedValuePath = "IdTipoact";
            }
        }

        public void CargarComboAdmContratoSeguros()
        {
            AdmContrato_cboSeguros.ItemsSource = new SeguroBLL().ComboSeguros();
            AdmContrato_cboSeguros.DisplayMemberPath = "Nombre";
            AdmContrato_cboSeguros.SelectedValuePath = "IdSeguro";
        }

        public void CargarComboCursoDesposito()
        {
            AdmDeposito_cboCurso.ItemsSource = new CursoBLL().ComboCurso();
            AdmDeposito_cboCurso.DisplayMemberPath = "IdCurso";
            AdmDeposito_cboCurso.SelectedValuePath = "IdCurso";
        }

        public void CargarComboTipoColegioDepositos()
        {
            AdmDeposito_cboTipoColegio.ItemsSource = new TipoColegioBLL().ListaTipoColegio();
            AdmDeposito_cboTipoColegio.DisplayMemberPath = "Nombre";
            AdmDeposito_cboTipoColegio.SelectedValuePath = "IdTipoColegio";
        }

        public void CargarComboAdmContratoBeneficios()
        {
            AdmContrato_cboBeneficios.ItemsSource = new BeneficioBLL().ComboBeneficios();
            AdmContrato_cboBeneficios.DisplayMemberPath = "Nombre";
            AdmContrato_cboBeneficios.SelectedValuePath = "IdBeneficio";
        }

        public void CargarComboAdmContratoActividades()
        {
            AdmContrato_cboActividades.ItemsSource = new ActividadBLL().ListaActividad();
            AdmContrato_cboActividades.DisplayMemberPath = "Nombre";
            AdmContrato_cboActividades.SelectedValuePath = "IdActividad";
        }

        public void CargarComboDepositoCurso()
        {
            RegDeposito_cboCurso.ItemsSource = new CursoBLL().ListaCursos();
            RegDeposito_cboCurso.DisplayMemberPath = "IdCurso";
            RegDeposito_cboCurso.SelectedValuePath = "IdCurso";
        }

        public void CargarComboDepositoTipoColegio()
        {
            RegDeposito_cboTipoColegio.ItemsSource = new TipoColegioBLL().ListaTipoColegio();
            RegDeposito_cboTipoColegio.DisplayMemberPath = "Nombre";
            RegDeposito_cboTipoColegio.SelectedValuePath = "IdTipoColegio";
        }

        public void LimpiarColegio()
        {
            AdmClientes_txtCodColegio.Text = string.Empty;
            AdmClientes_txtNombreColegio.Text = string.Empty;
            AdmClientes_txtDireccionColegio.Text = string.Empty;
            AdmClientes_cboTipoColegio.SelectedValue = null;
        }

        public void LimpiarCurso()
        {
            AdmCliente_txtCodColegio2.Text = string.Empty;
            AdmCliente_txtNombreColegio2.Text = string.Empty;
            AdmCliente_cboTipoColegio.SelectedValue = null;
            AdmCliente_txtDireccionColegio2.Text = string.Empty;
            AdmCliente_txtCodCurso.Text = string.Empty;
            AdmCliente_txtNumeroAlumnos.Text = string.Empty;
        }

        public void LimpiarAseguradora()
        {
            AdmSeguros_txtRutAseguradora.Text = string.Empty;
            AdmSeguros_txtNombreAseguradora.Text = string.Empty;
            AdmSeguros_txtDireccionAseguradora.Text = string.Empty;
            AdmSeguros_txtTelefonoAseguradora.Text = string.Empty;
        }

        public void LimpiarSeguro()
        {
            AdmSeguros_txtCodSeguro.Text = string.Empty;
            AdmSeguros_txtNombreAseguradoraSeguro.Text = string.Empty;
            AdmSeguros_txtRutAseguradoraSeguro.Text = string.Empty;
            AdmSeguros_txtDescripcionSeguros.Text = string.Empty;
            AdmSeguros_txtCostoSeguro.Text = string.Empty;
            AdmSeguros_txtTipoSeguro.Text = string.Empty;
        }

        public void LimpiarDeposito()
        {
            AdmDeposito_txtCodigoColegio.Text = string.Empty;
            AdmDeposito_txtNombreColegio.Text = string.Empty;
            AdmDeposito_cboTipoColegio.SelectedValue = null;
            AdmDeposito_cboCurso.SelectedValue = null;
            AdmDeposito_txtRutDepositante.Text = string.Empty;
            AdmDeposito_txtNombreDepositante.Text = string.Empty;
            AdmDeposito_FechaDeposito.SelectedDate = null;
            AdmDeposito_txtMontoDepositado.Text = string.Empty;
        }

        public void LimpiarContrato()
        {
            AdmContrato_txtNumeroContrato.Text = string.Empty;
            AdmContrato_FechaCreacion.SelectedDate = null;
            AdmContrato_FechaTermino.SelectedDate = null;
            AdmContrato_RutUsuario.Text = string.Empty;
            AdmContrato_NombreUsuario.Text = string.Empty;
            AdmContrato_cboPaisDestino.SelectedValue = null;
            AdmContrato_cboCiudadDestino.SelectedValue = null;
            AdmContrato_DuracionDiasViaje.Text = string.Empty;
            AdmContrato_FechaInicioViaje.SelectedDate = null;
            AdmContrato_FechaTerminoViaje.SelectedDate = null;
            AdmContrato_cboSeguros.SelectedValue = null;
            AdmContrato_DataGridSeguros.ItemsSource = null;
            AdmContrato_cboBeneficios.SelectedValue = null;
            AdmContrato_DataGridBeneficios.ItemsSource = null;
            AdmContrato_cboActividades.SelectedValue = null;
            AdmContrato_DataGridActividades.ItemsSource = null;
            AdmContrato_cboModalidadAportes.SelectedValue = null;
            AdmContrato_cboTipoActividades.SelectedValue = null;
            AdmContrato_FechaDePagos.Text = string.Empty;
            AdmContrato_txtTasaInteres.Text = string.Empty;
            AdmContrato_txtCostoTotalSeguros.Text = string.Empty;
            AdmContrato_txtCostoTotalActividades.Text = string.Empty;
            AdmContrato_txtMeta.Text = string.Empty;
            AdmContrato_txtCostoServicios.Text = string.Empty;
            AdmContrato_txtPorcDesctBeneficios.Text = string.Empty;
            AdmContrato_cboTipoColegio.SelectedValue = null;
            AdmContrato_cboCurso.SelectedValue = null;

        }

        #endregion MetodosSecundarios

        #region DiseñoInterfaz
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

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
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 9;
                    rec1.Visibility = Visibility.Visible;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Hidden;

                    break;
                case 1:
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Visible;
                    btnDatosCurso.Visibility = Visibility.Visible;
                    this.tabcontrol1.SelectedIndex = 0;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Visible;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Hidden;

                    break;
                case 2:
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 2;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Visible;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Hidden;

                    break;
                case 3:
                    btnSeguro.Visibility = Visibility.Visible;
                    btnSeguro2.Visibility = Visibility.Visible;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 4;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Visible;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Hidden;

                    break;
                case 4:
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 6;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Visible;
                    rec6.Visibility = Visibility.Hidden;

                    break;
                case 5:
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 7;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Visible;

                    break;
                case 6:
                    btnSeguro.Visibility = Visibility.Hidden;
                    btnSeguro2.Visibility = Visibility.Hidden;
                    btnregistroColegio.Visibility = Visibility.Hidden;
                    btnDatosCurso.Visibility = Visibility.Hidden;
                    this.tabcontrol1.SelectedIndex = 8;
                    rec1.Visibility = Visibility.Hidden;
                    rec2.Visibility = Visibility.Hidden;
                    rec3.Visibility = Visibility.Hidden;
                    rec4.Visibility = Visibility.Hidden;
                    rec5.Visibility = Visibility.Hidden;
                    rec6.Visibility = Visibility.Hidden;

                    break;



            }
        }





        private void BtnregistroColegio_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 0;
            rec1.Visibility = Visibility.Hidden;
            rec2.Visibility = Visibility.Visible;
            rec3.Visibility = Visibility.Hidden;
            rec4.Visibility = Visibility.Hidden;
            rec5.Visibility = Visibility.Hidden;
            rec6.Visibility = Visibility.Hidden;

        }

        private void BtnDatosCurso_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 1;
            rec1.Visibility = Visibility.Hidden;
            rec2.Visibility = Visibility.Visible;
            rec3.Visibility = Visibility.Hidden;
            rec4.Visibility = Visibility.Hidden;
            rec5.Visibility = Visibility.Hidden;
            rec6.Visibility = Visibility.Hidden;

        }

        private void BtnSeguro_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 4;
            rec1.Visibility = Visibility.Hidden;
            rec2.Visibility = Visibility.Hidden;
            rec3.Visibility = Visibility.Hidden;
            rec4.Visibility = Visibility.Visible;
            rec5.Visibility = Visibility.Hidden;
            rec6.Visibility = Visibility.Hidden;

        }

        private void BtnSeguro2_Click(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 5;
            rec1.Visibility = Visibility.Hidden;
            rec2.Visibility = Visibility.Hidden;
            rec3.Visibility = Visibility.Hidden;
            rec4.Visibility = Visibility.Visible;
            rec5.Visibility = Visibility.Hidden;
            rec6.Visibility = Visibility.Hidden;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 3;
            rec1.Visibility = Visibility.Hidden;
            rec2.Visibility = Visibility.Hidden;
            rec3.Visibility = Visibility.Visible;
            rec4.Visibility = Visibility.Hidden;
            rec5.Visibility = Visibility.Hidden;
            rec6.Visibility = Visibility.Hidden;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 10;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 3;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.tabcontrol1.SelectedIndex = 2;
        }
        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._instance.Show();
            this.Hide();
            instance = null;
        }
        #endregion

        #region BotonesAdminColegio
        private void EjecutivoVentas_btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                c.CodColegio = AdmClientes_txtCodColegio.Text;
                c.Nombre = AdmClientes_txtNombreColegio.Text;
                c.Direccion = AdmClientes_txtDireccionColegio.Text;
                c.tipcole_idtipo = Convert.ToInt32(AdmClientes_cboTipoColegio.SelectedValue);

                var result = SystemException.ShowDialog("Esta seguro que desea agregar", "Advertencia", SystemException.Buttons.Si_No);
                if (result.ToString() == "1")
                {
                    c.Agregar();
                    LimpiarColegio();
                    SystemException.ShowDialog("Colegio creado correctamente", "Correcto", SystemException.Buttons.OK2);
                    AdmClientes_DataGridColegio.ItemsSource = new ColegioBLL().DataGridColegio();
                    CargarComboAdmContratoCurso();
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCliente_btnActualizarColegio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                if (c.BuscarColegio(AdmClientes_txtCodColegio.Text))
                {
                    c.CodColegio = AdmClientes_txtCodColegio.Text;
                    c.Nombre = AdmClientes_txtNombreColegio.Text;
                    c.Direccion = AdmClientes_txtDireccionColegio.Text;
                    c.tipcole_idtipo = Convert.ToInt32(AdmClientes_cboTipoColegio.SelectedValue);

                    var result = SystemException.ShowDialog("¿Está seguro que desea actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        c.Actualizar();
                        LimpiarColegio();
                        SystemException.ShowDialog("Colegio actualizado correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmClientes_DataGridColegio.ItemsSource = new ColegioBLL().DataGridColegio();
                        CargarComboAdmContratoCurso();
                    }
                }
                else
                {
                    throw new Exception("No es posible actualizar");
                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCliente_btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                if (c.BuscarColegio(AdmClientes_txtCodColegio.Text))
                {
                    var result = SystemException.ShowDialog("¿Está seguro que desea Eliminar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        c.Eliminar(AdmClientes_txtCodColegio.Text);
                        LimpiarColegio();
                        SystemException.ShowDialog("Colegio Eliminado Correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmCliente_DatagGridCurso.ItemsSource = new ColegioBLL().DataGridColegio();
                        CargarComboAdmContratoCurso();
                    }
                }
                else
                {
                    throw new Exception("No es posible eliminar");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }

        }

        //boton que se puso weon
        private void EjecutivoVentas_btnBuscarColegio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                if (c.BuscarColegio(AdmClientes_txtCodColegio.Text))
                {
                    foreach (var item in c.ListaColegios())
                    {
                        if (item.CodColegio == AdmClientes_txtCodColegio.Text)
                        {
                            AdmClientes_txtNombreColegio.Text = item.Nombre;
                            AdmClientes_txtDireccionColegio.Text = item.Direccion;
                            AdmClientes_cboTipoColegio.SelectedValue = item.tipcole_idtipo;

                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el colegio");
                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        #endregion BotonesAdminColegio

        #region BotonesAdminClienteCurso
        private void AdmCliente_btnAgregarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CursoBLL c = new CursoBLL();
                if (c.BuscarCurso(AdmCliente_txtCodCurso.Text) == false)
                {
                    c.IdCurso = AdmCliente_txtCodCurso.Text;
                    c.NumAlumnos = int.Parse(AdmCliente_txtNumeroAlumnos.Text);
                    c.CodColegio = AdmCliente_txtCodColegio2.Text;

                    var result = SystemException.ShowDialog("¿Está seguro que desea Agregar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        c.Agregar();
                        LimpiarCurso();
                        SystemException.ShowDialog("Curso Agregado Correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmCliente_DatagGridCurso.ItemsSource = c.DataGridCurso();
                        CargarComboCursoDesposito();
                        CargarComboAdmContratoCurso();
                    }
                }
                else
                {
                    throw new Exception("Curso ya registrado");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCliente_btnActualizarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CursoBLL c = new CursoBLL();
                c.IdCurso = AdmCliente_txtCodCurso.Text;
                c.NumAlumnos = int.Parse(AdmCliente_txtNumeroAlumnos.Text);
                c.CodColegio = AdmCliente_txtCodColegio2.Text;

                var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                if (result.ToString() == "1")
                {
                    c.Actualizar();
                    LimpiarCurso();
                    SystemException.ShowDialog("Curso Actualizado Correctamente", "Correcto", SystemException.Buttons.OK2);
                    AdmCliente_DatagGridCurso.ItemsSource = c.DataGridCurso();
                    CargarComboCursoDesposito();
                    CargarComboAdmContratoCurso();
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCliente_btnEliminarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CursoBLL c = new CursoBLL();
                var result = SystemException.ShowDialog("¿Está seguro que desea Eliminar?", "Advertencia", SystemException.Buttons.Si_No);

                if (result.ToString() == "1")
                {
                    c.Eliminar(AdmCliente_txtCodCurso.Text);
                    LimpiarCurso();
                    SystemException.ShowDialog("Curso Eliminado Correctamente", "Correcto", SystemException.Buttons.OK2);
                    AdmCliente_DatagGridCurso.ItemsSource = c.DataGridCurso();
                    CargarComboCursoDesposito();
                    CargarComboAdmContratoCurso();
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmCliente_btnBuscarCurso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CursoBLL c = new CursoBLL();
                if (c.BuscarCurso(AdmCliente_txtCodCurso.Text))
                {
                    foreach (var item in c.ListaCursos())
                    {
                        if (item.IdCurso == AdmCliente_txtCodCurso.Text)
                        {
                            AdmCliente_txtCodColegio2.Text = item.CodColegio;
                            AdmCliente_txtNombreColegio2.Text = new ColegioBLL().ListaColegios().Where(p => p.CodColegio == item.CodColegio).FirstOrDefault().Nombre;
                            AdmCliente_cboTipoColegio.SelectedValue = new ColegioBLL().ListaColegios().Where(w => w.CodColegio == item.CodColegio).FirstOrDefault().tipcole_idtipo;
                            AdmCliente_txtDireccionColegio2.Text = new ColegioBLL().ListaColegios().Where(q => q.CodColegio == item.CodColegio).FirstOrDefault().Direccion;
                            AdmCliente_txtNumeroAlumnos.Text = item.NumAlumnos.ToString();


                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el curso");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        //Boton que no se puso weon
        private void AdmCliente_btnBuscarColegio2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                if (c.BuscarColegio(AdmCliente_txtCodColegio2.Text))
                {
                    foreach (var item in c.ListaColegios())
                    {
                        if (item.CodColegio == AdmCliente_txtCodColegio2.Text)
                        {
                            AdmCliente_txtNombreColegio2.Text = item.Nombre;
                            AdmCliente_txtDireccionColegio2.Text = item.Direccion;
                            AdmCliente_cboTipoColegio.SelectedValue = item.tipcole_idtipo;

                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar al colegio");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        #endregion BotonesAdminClienteCurso

        #region BotonesAdminSeguros

        private void AdmSeguros_btnAgregarSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SeguroBLL s = new SeguroBLL();
                if (s.BuscarSeguro(int.Parse(AdmSeguros_txtCodSeguro.Text)) == false)
                {
                    s.IdSeguro = int.Parse(AdmSeguros_txtCodSeguro.Text);
                    s.Nombre = AdmSeguros_txtTipoSeguro.Text;
                    s.Descripcion = AdmSeguros_txtDescripcionSeguros.Text;
                    s.Costo = int.Parse(AdmSeguros_txtCostoSeguro.Text);
                    s.RutEmp = new AseguradoraBLL().ListaAseguradora().Where(a => a.RutEmp == Herramientas.formatearRut(AdmSeguros_txtRutAseguradoraSeguro.Text)).FirstOrDefault().RutEmp;

                    var result = SystemException.ShowDialog("¿Está seguro que desea Agregar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        s.Agregar();
                        LimpiarSeguro();
                        SystemException.ShowDialog("Seguro agregado correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridSeguros.ItemsSource = s.ListaSeguros();
                        AdmContrato_cboSeguros.ItemsSource = s.ListaSeguros();
                    }
                }
                else
                {
                    throw new Exception("Seguro ya registrado");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnActualizarSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SeguroBLL s = new SeguroBLL();
                if (s.BuscarSeguro(int.Parse(AdmSeguros_txtCodSeguro.Text)))
                {
                    s.IdSeguro = int.Parse(AdmSeguros_txtCodSeguro.Text);
                    s.Nombre = AdmSeguros_txtTipoSeguro.Text;
                    s.Descripcion = AdmSeguros_txtDescripcionSeguros.Text;
                    s.Costo = int.Parse(AdmSeguros_txtCostoSeguro.Text);
                    s.RutEmp = new AseguradoraBLL().ListaAseguradora().Where(a => a.RutEmp == AdmSeguros_txtRutAseguradoraSeguro.Text).FirstOrDefault().RutEmp;

                    var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        s.Actualizar();
                        LimpiarSeguro();
                        SystemException.ShowDialog("Seguro actualizado correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridSeguros.ItemsSource = s.ListaSeguros();
                    }
                }
                else
                {
                    throw new Exception("No se encontró ningun seguro, no es posible actualizar");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnEliminarSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SeguroBLL s = new SeguroBLL();
                if (s.BuscarSeguro(int.Parse(AdmSeguros_txtCodSeguro.Text)))
                {
                    var result = SystemException.ShowDialog("¿Está seguro que desea Eliminar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        s.Eliminar(int.Parse(AdmSeguros_txtCodSeguro.Text));
                        LimpiarSeguro();
                        SystemException.ShowDialog("Seguro eliminado correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridSeguros.ItemsSource = s.ListaSeguros();
                    }
                }
                else
                {
                    throw new Exception("No se encontro ningún seguro, no es posible eliminar");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnBuscarSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SeguroBLL s = new SeguroBLL();
                if (s.BuscarSeguro(int.Parse(AdmSeguros_txtCodSeguro.Text)))
                {
                    foreach (var item in s.ListaSeguros())
                    {
                        if (item.IdSeguro == int.Parse(AdmSeguros_txtCodSeguro.Text))
                        {
                            AdmSeguros_txtRutAseguradoraSeguro.Text = item.RutEmp;
                            AdmSeguros_txtNombreAseguradoraSeguro.Text = new AseguradoraBLL().ListaAseguradora().Where(a => a.RutEmp == item.RutEmp).FirstOrDefault().Nombre;
                            AdmSeguros_txtCostoSeguro.Text = item.Costo.ToString();
                            AdmSeguros_txtDescripcionSeguros.Text = item.Descripcion;
                            AdmSeguros_txtTipoSeguro.Text = item.Nombre;

                            return;

                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el seguro");
                }


            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnBuscarAseguradoraSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AseguradoraBLL a = new AseguradoraBLL();
                if (a.BuscarAseguradora(Herramientas.formatearRut(AdmSeguros_txtRutAseguradoraSeguro.Text)))
                {
                    foreach (var item in a.ListaAseguradora())
                    {
                        if (Herramientas.formatearRut(AdmSeguros_txtRutAseguradoraSeguro.Text) == item.RutEmp)
                        {
                            AdmSeguros_txtNombreAseguradoraSeguro.Text = item.Nombre;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar a Empresa Aseguradora");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }


        private void AdmSeguros_btnAgregarAseguradora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AseguradoraBLL a = new AseguradoraBLL();
                if (a.BuscarAseguradora(Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text)) == false)
                {
                    a.RutEmp = Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text);
                    a.Nombre = AdmSeguros_txtNombreAseguradora.Text;
                    a.Direccion = AdmSeguros_txtDireccionAseguradora.Text;
                    a.Telefono = int.Parse(AdmSeguros_txtTelefonoAseguradora.Text);

                    var result = SystemException.ShowDialog("¿Está seguro que desea Agregar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        a.Agregar();
                        LimpiarAseguradora();
                        SystemException.ShowDialog("Empresa aseguradora agregada correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridAseguradora.ItemsSource = a.ListaAseguradora();
                    }
                }
                else
                {
                    throw new Exception("Empresa aseguradora ya registrada");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnActualizarAseguradora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AseguradoraBLL a = new AseguradoraBLL();
                if (a.BuscarAseguradora(Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text)))
                {
                    a.RutEmp = Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text);
                    a.Nombre = AdmSeguros_txtNombreAseguradora.Text;
                    a.Direccion = AdmSeguros_txtDireccionAseguradora.Text;
                    a.Telefono = int.Parse(AdmSeguros_txtTelefonoAseguradora.Text);

                    var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        a.Actualizar();
                        LimpiarAseguradora();
                        SystemException.ShowDialog("Empresa aseguradora actualizada correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridAseguradora.ItemsSource = a.ListaAseguradora();
                    }
                }
                else
                {
                    throw new Exception("No se encontro a empresa aseguradora, no es posible actualizar");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnEliminarAseguradora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AseguradoraBLL a = new AseguradoraBLL();
                if (a.BuscarAseguradora(Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text)))
                {
                    var result = SystemException.ShowDialog("¿Está seguro que desea Eliminar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        a.Eliminar(Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text));
                        LimpiarAseguradora();
                        SystemException.ShowDialog("Empresa aseguradora eliminada correctamente", "Correcto", SystemException.Buttons.OK2);
                        AdmSeguros_DataGridAseguradora.ItemsSource = a.ListaAseguradora();
                    }
                }
                else
                {
                    throw new Exception("No se encontro a empresa aseguradora, no es posible eliminar");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmSeguros_btnBuscarAseguradora_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AseguradoraBLL a = new AseguradoraBLL();
                if (a.BuscarAseguradora(Herramientas.formatearRut(AdmSeguros_txtRutAseguradora.Text)))
                {
                    foreach (var item in a.ListaAseguradora())
                    {
                        AdmSeguros_txtNombreAseguradora.Text = item.Nombre;
                        AdmSeguros_txtTelefonoAseguradora.Text = item.Telefono.ToString();
                        AdmSeguros_txtDireccionAseguradora.Text = item.Direccion;

                        return;
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar a empresa aseguradora");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        #endregion BotonesAdminSeguros

        #region BotonesAdminContrato
        private void AdmContrato_btnAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContratoBLL c = new ContratoBLL();
                if (c.BuscarContrato(int.Parse(AdmContrato_txtNumeroContrato.Text)) == false)
                {
                    c.NumContrato = int.Parse(AdmContrato_txtNumeroContrato.Text);
                    c.FechaCreacion = (DateTime)AdmContrato_FechaCreacion.SelectedDate;
                    c.FechaTermino = (DateTime)AdmContrato_FechaTermino.SelectedDate;
                    c.DuracionDias = int.Parse(AdmContrato_DuracionDiasViaje.Text);
                    c.FechaIniViaje = (DateTime)AdmContrato_FechaInicioViaje.SelectedDate;
                    c.FechaTerViaje = (DateTime)AdmContrato_FechaTerminoViaje.SelectedDate;
                    c.FechaPagos = AdmContrato_FechaDePagos.Text;
                    c.CostosSeguros = int.Parse(AdmContrato_txtCostoTotalSeguros.Text);
                    c.CostosActividades = int.Parse(AdmContrato_txtCostoTotalActividades.Text);
                    c.PorcBeneficios = int.Parse(AdmContrato_txtPorcDesctBeneficios.Text);
                    c.CostosServicios = int.Parse(AdmContrato_txtCostoServicios.Text);
                    c.Meta = int.Parse(AdmContrato_txtMeta.Text);
                    c.IdTipoAct = Convert.ToInt32(AdmContrato_cboTipoActividades.SelectedValue);
                    c.IdCurso = AdmContrato_cboCurso.SelectedValue.ToString();
                    c.CodCiudad = Convert.ToInt32(AdmContrato_cboCiudadDestino.SelectedValue);
                    var rut = new UsuarioBLL().ListaUsuarios().Where(u => u.Rut == Herramientas.formatearRut(AdmContrato_RutUsuario.Text)).FirstOrDefault();
                    if (rut != null)
                    {
                        c.RutUsuario = Herramientas.formatearRut(AdmContrato_RutUsuario.Text);
                    }
                    else
                    {
                        throw new Exception("El rut no se encuentra registrado");
                    }

                    var result = SystemException.ShowDialog("¿Está seguro que desea agregar?", "Advertencia", SystemException.Buttons.Si_No);
                    if (result.ToString() == "1")
                    {
                        c.Agregar();
                        LimpiarContrato();
                        SystemException.ShowDialog("Contrato agregado correctamente", "Correcto", SystemException.Buttons.OK2);
                    }
                }
                else
                {
                    throw new Exception("Contrato ya registrado");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmContrato_btnActualizarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContratoBLL c = new ContratoBLL();
                if (c.BuscarContrato(int.Parse(AdmContrato_txtNumeroContrato.Text)) == false)
                {
                    c.NumContrato = int.Parse(AdmContrato_txtNumeroContrato.Text);
                    c.FechaCreacion = (DateTime)AdmContrato_FechaCreacion.SelectedDate;
                    c.FechaTermino = (DateTime)AdmContrato_FechaTermino.SelectedDate;
                    c.DuracionDias = int.Parse(AdmContrato_DuracionDiasViaje.Text);
                    c.FechaIniViaje = (DateTime)AdmContrato_FechaInicioViaje.SelectedDate;
                    c.FechaTerViaje = (DateTime)AdmContrato_FechaTerminoViaje.SelectedDate;
                    c.FechaPagos = AdmContrato_FechaDePagos.Text;
                    c.CostosSeguros = int.Parse(AdmContrato_txtCostoTotalSeguros.Text);
                    c.CostosActividades = int.Parse(AdmContrato_txtCostoTotalActividades.Text);
                    c.PorcBeneficios = int.Parse(AdmContrato_txtPorcDesctBeneficios.Text);
                    c.CostosServicios = int.Parse(AdmContrato_txtCostoServicios.Text);
                    c.Meta = int.Parse(AdmContrato_txtMeta.Text);
                    c.IdTipoAct = Convert.ToInt32(AdmContrato_cboTipoActividades.SelectedValue);
                    c.IdCurso = AdmContrato_cboCurso.SelectedValue.ToString();
                    c.CodCiudad = Convert.ToInt32(AdmContrato_cboCiudadDestino.SelectedValue);
                    var rut = new UsuarioBLL().ListaUsuarios().Where(u => u.Rut == Herramientas.formatearRut(AdmContrato_RutUsuario.Text)).FirstOrDefault();
                    if (rut != null)
                    {
                        c.RutUsuario = Herramientas.formatearRut(AdmContrato_RutUsuario.Text);
                    }
                    else
                    {
                        throw new Exception("El rut no se encuentra registrado");
                    }

                    var result = SystemException.ShowDialog("¿Está seguro que desea actualizar?", "Advertencia", SystemException.Buttons.Si_No);
                    if (result.ToString() == "1")
                    {
                        c.Agregar();
                        LimpiarContrato();
                        SystemException.ShowDialog("Contrato actualizado correctamente", "Correcto", SystemException.Buttons.OK2);
                    }
                }
                else
                {
                    throw new Exception("Contrato ya registrado");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmContrato_btnBuscarRutEjecutivo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                if (u.BuscarUsuario(Herramientas.formatearRut(AdmContrato_RutUsuario.Text)))
                {
                    foreach (var item in u.ListaUsuarios())
                    {
                        if (item.Rut == Herramientas.formatearRut(AdmContrato_RutUsuario.Text))
                        {
                            AdmContrato_NombreUsuario.Text = item.Nombre + " " + item.Apaterno;

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

        private void EjecutivoVentas_cboPaisDestino_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = Convert.ToInt32(AdmContrato_cboPaisDestino.SelectedValue);

            CiudadBLL c = new CiudadBLL();
            foreach (var item in c.Lista())
            {
                var ex = c.Lista().Where(a => a.CodPais == v).ToList();

                AdmContrato_cboCiudadDestino.ItemsSource = ex;
                AdmContrato_cboCiudadDestino.DisplayMemberPath = "Nombre";
                AdmContrato_cboCiudadDestino.SelectedValuePath = "CodCiudad";
            }
        }

        private void AdmContrato_btnAgregarSeguro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DetalleSeguro d = new DetalleSeguro();

                SeguroBLL s = new SeguroBLL();
                if (s.BuscarSeguro(Convert.ToInt32(AdmContrato_cboSeguros.SelectedValue)))
                {
                    foreach (var item in d.ListaDetalles())
                    {
                        d.IdDetSeg = item.IdDetSeg + 1;
                    }
                    d.IdSeguro = Convert.ToInt32(AdmContrato_cboSeguros.SelectedValue);
                    d.NumContrato = int.Parse(AdmContrato_txtNumeroContrato.Text);

                    d.Agregar();
                    var buscado = s.ListaSeguros().Where(a => a.IdSeguro == d.IdSeguro).FirstOrDefault();
                    var buscarDetalleSeguro = d.DataGridSeguro().Where(c => c.NumContrato == d.NumContrato).ToList();
                    AdmContrato_txtCostoTotalSeguros.Text = AdmContrato_txtCostoTotalSeguros.
                    AdmContrato_DataGridSeguros.ItemsSource = buscarDetalleSeguro;

                }
                else
                {
                    throw new Exception("No es posible agregar seguro");
                }

            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmContrato_btnAgregarBeneficio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdmContrato_btnAgregarActividad_Click(object sender, RoutedEventArgs e)
        {

        }


        #endregion BotonesAdminContrato

        #region BotonesAdmDeposito
        private void AdmDeposito_btnBuscarColegio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ColegioBLL c = new ColegioBLL();
                if (c.BuscarColegio(AdmDeposito_txtCodigoColegio.Text))
                {
                    foreach (var item in c.ListaColegios())
                    {
                        if (item.CodColegio == AdmDeposito_txtCodigoColegio.Text)
                        {
                            AdmDeposito_txtNombreColegio.Text = item.Nombre;
                            AdmDeposito_cboTipoColegio.SelectedValue = item.tipcole_idtipo;

                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el colegio");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmDeposito_btnBuscarApoderado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                if (u.BuscarUsuario(Herramientas.formatearRut(AdmDeposito_txtRutDepositante.Text)))
                {
                    foreach (var item in u.ListaUsuarios())
                    {
                        if (item.Rut == Herramientas.formatearRut(AdmDeposito_txtRutDepositante.Text))
                        {
                            AdmContrato_NombreUsuario.Text = item.Nombre + " " + item.Apaterno;

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

        private void AdmDeposito_btnBuscarDeposito_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DepositoBLL d = new DepositoBLL();
                if (d.BuscarDeposito(int.Parse(AdmDeposito_txtIdDeposito.Text)))
                {
                    foreach (var item in d.ListaDepositos())
                    {
                        if (item.IdDeposito == int.Parse(AdmDeposito_txtIdDeposito.Text))
                        {
                            AdmDeposito_txtCodigoColegio.Text = item.CodColegio;
                            AdmDeposito_txtNombreColegio.Text = new ColegioBLL().ListaColegios().Where(p => p.CodColegio == item.CodColegio).FirstOrDefault().Nombre;
                            AdmDeposito_cboTipoColegio.SelectedValue = item.IdTipColegio;
                            AdmDeposito_cboCurso.SelectedValue = item.IdCurso;

                            return;
                        }
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el deposito");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }

        private void AdmDeposito_btnAgregarDeposito_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioBLL u = new UsuarioBLL();
                if (u.BuscarUsuario(Herramientas.formatearRut(AdmDeposito_txtRutDepositante.Text)))
                {
                    foreach (var item in u.ListaUsuarios())
                    {
                        if (item.Rut == Herramientas.formatearRut(AdmDeposito_txtRutDepositante.Text))
                        {
                            AdmContrato_NombreUsuario.Text = item.Nombre + " " + item.Apaterno;

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

        private void AdmDeposito_btnActualizarDeposito_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DepositoBLL d = new DepositoBLL();
                if (d.BuscarDeposito(int.Parse(AdmDeposito_txtIdDeposito.Text)))
                {
                    d.IdDeposito = int.Parse(AdmDeposito_txtIdDeposito.Text);
                    d.FechaDeposito = (DateTime)AdmDeposito_FechaDeposito.SelectedDate;
                    d.Monto = int.Parse(AdmDeposito_txtMontoDepositado.Text);
                    d.IdCurso = AdmDeposito_cboCurso.SelectedValue.ToString();
                    d.Rut = Herramientas.formatearRut(AdmDeposito_txtRutDepositante.Text);
                    d.NombreDep = AdmDeposito_txtNombreDepositante.Text;

                    var result = SystemException.ShowDialog("¿Está seguro que desea Actualizar?", "Advertencia", SystemException.Buttons.Si_No);

                    if (result.ToString() == "1")
                    {
                        d.Actualizar();
                        AdmDeposito_DataGridDepositos.ItemsSource = d.ListaDepositos();
                        SystemException.ShowDialog("Deposito actualizado correctamente", "Correcto", SystemException.Buttons.OK2);
                        LimpiarDeposito();
                    }
                }
                else
                {
                    throw new Exception("No es posible encontrar el deposito");
                }
            }
            catch (Exception ex)
            {
                SystemException.ShowDialog(ex.Message, "Error", SystemException.Buttons.OK);
            }
        }
        #endregion BotonesAdmDeposito

        #region ConsultaSaldo
        private void RegDeposito_txtCodigoColegio_TextChanged(object sender, TextChangedEventArgs e)
        {
            //    DataGridDepositos.ItemsSource = new ContratoBLL().DataGridDepositos().Where(c => c.CodColegio.Contains(RegDeposito_txtCodigoColegio.Text)).ToList();
        }

        private void RegDeposito_cboCurso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //    DataGridDepositos.ItemsSource = new ContratoBLL().DataGridDepositos().Where(b => b.IdCurso == RegDeposito_cboCurso.SelectedValue.ToString()).ToList();
        }

        private void RegDeposito_cboTipoColegio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //    DataGridDepositos.ItemsSource = new ContratoBLL().DataGridDepositos().Where(c => c.IdTipoColegio == Convert.ToInt32(RegDeposito_cboTipoColegio.SelectedValue)).ToList();
        }



        #endregion ConsultaSaldo

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Alumnos al = new Alumnos();
            al.Show();
        }
    }
}
