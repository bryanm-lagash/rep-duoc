using System;
using System.Collections.Generic;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using OnTourWPF2._0.Apoderados;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace OnTourWPF2._0.rutas
{
    /// <summary>
    /// Lógica de interacción para RutaContrato.xaml
    /// </summary>
    public partial class RutaContrato : Window
    {
        public RutaContrato()
        {
            InitializeComponent();

        }


        private void Btn_selecCarpeta_Click(object sender, RoutedEventArgs e)
        {
            var resultado = fbd.ShowDialog();

            if (resultado.ToString() == "OK")
            {
                ruta.Text = fbd.SelectedPath + @"\DetalleContrato" + DateTime.Now.ToString(@"hhmmss") + ".pdf";
            }
        }
        System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
        private void Btn_descargar_Click2(object sender, RoutedEventArgs e)
        {

            Document doc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);



            //// Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(ruta.Text, FileMode.Create)); ;

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Detalle Contrato PDF");
            doc.AddCreator("Abraham Vidal");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _title = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);



            // Escribimos el encabezamiento en el documento
            doc.Add(new iTextSharp.text.Paragraph("                       Detalle Contrato On-Tour", _standardFont));
            doc.Add(Chunk.NEWLINE);


            var headerTable = new PdfPTable(new[] { .75f, 2f })
            {

                HorizontalAlignment = 0,
                WidthPercentage = 75,
                DefaultCell = { MinimumHeight = 22f }
            };


            headerTable.AddCell("Codigo colegio");
            headerTable.AddCell(Apoderados.Apoderados._instance.txt_codColegio_dc.Text);
            headerTable.AddCell("Nombre Colegio");
            headerTable.AddCell(Apoderados.Apoderados._instance.txt_nombreColegio_dc.Text);
            headerTable.AddCell("Curso");
            headerTable.AddCell(Apoderados.Apoderados._instance.cbo_curso_dc.Text);
            headerTable.AddCell("Numero contrato");
            headerTable.AddCell(Apoderados.Apoderados._instance.cboNumeroContrato.SelectedValue.ToString());
            headerTable.AddCell("Fecha");
            headerTable.AddCell(DateTime.Now.ToString());

            doc.Add(headerTable);
            doc.Add(Chunk.NEWLINE);

            var botoomTable = new PdfPTable(new[] { 1f, 2f, 1f, 2f })
            {
                HorizontalAlignment = 0,
                WidthPercentage = 100,
                DefaultCell = { MinimumHeight = 22f }
            };

            botoomTable.AddCell("Fecha cracion contrato");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_fechaCreacion_dc.Text);
            botoomTable.AddCell("Fecha termino contrato");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_fechaTermino_dc.Text);
            botoomTable.AddCell("Destino");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_destino_dc.Text);
            botoomTable.AddCell("Fecha inicio viaje");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_fechaInicioViaje_dc.Text);
            botoomTable.AddCell("Fecha termino viaje");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_fechaTerminoViaje_dc.Text);
            botoomTable.AddCell("Duracion en dias");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_duracionDias_dc.Text);
            botoomTable.AddCell("Rut ejecutivo");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_rutEjecutivo_dc.Text);
            botoomTable.AddCell("Ciudad de destino");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_ciudadDestino_dc.Text);
            botoomTable.AddCell("Tipo de colegio");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_tipoColegio_dc.Text);
            botoomTable.AddCell("Actividad");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_actividad_dc.Text);
            botoomTable.AddCell("Fecha de pagos");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_fechaPagos_dc.Text);
            botoomTable.AddCell("Costo seguros");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_costoSeguros_dc.Text);
            botoomTable.AddCell("Modalidad");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_modalidad_dc.Text);
            botoomTable.AddCell("Costo servicios");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_costoServicio_dc.Text);
            botoomTable.AddCell("Porc. Bonificacion");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_porcBeneficios_dc.Text);
            botoomTable.AddCell("Costo actividades");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_costoActividades_dc.Text);
            botoomTable.AddCell("Meta");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_meta_dc.Text);

            doc.Add(botoomTable);

            doc.Close();
            writer.Close();


            SystemException.ShowDialog("Contrato descargado correctamente", "Correcto", SystemException.Buttons.OK2);

            this.Close();

        }

        private void Btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Btn_minimizar_Click(object sender, RoutedEventArgs e)
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
    }


}
