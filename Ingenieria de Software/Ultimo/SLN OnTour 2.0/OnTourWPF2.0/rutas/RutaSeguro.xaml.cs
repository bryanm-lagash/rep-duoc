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

namespace OnTourWPF2._0.rutas
{
    /// <summary>
    /// Lógica de interacción para RutaSeguro.xaml
    /// </summary>
    public partial class RutaSeguro : Window
    {
        public RutaSeguro()
        {
            InitializeComponent();
        }
        private void Btn_selecCarpeta_Click(object sender, RoutedEventArgs e)
        {
            var resultado = fbd.ShowDialog();

            if (resultado.ToString() == "OK")
            {
                ruta.Text = fbd.SelectedPath + @"\DetallePolisaSeguro" + DateTime.Now.ToString(@"hhmmss") + ".pdf";
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
            doc.AddTitle("Detalle seguro PDF");
            doc.AddCreator("Abraham Vidal");

            // Abrimos el archivo
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _title = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);



            // Escribimos el encabezamiento en el documento
            doc.Add(new iTextSharp.text.Paragraph("                  Detalle poliza de seguro On-Tour", _standardFont));
            doc.Add(Chunk.NEWLINE);


            var headerTable = new PdfPTable(new[] { .75f, 2f })
            {

                HorizontalAlignment = 0,
                WidthPercentage = 75,
                DefaultCell = { MinimumHeight = 22f }
            };


            headerTable.AddCell("Rut alumno");
            headerTable.AddCell(Apoderados.Apoderados._instance.txt_rutAlumno_s.Text);
            headerTable.AddCell("Nombre alumno");
            headerTable.AddCell(Apoderados.Apoderados._instance.txt_nombreAlumno_s.Text);
            headerTable.AddCell("Fecha");
            headerTable.AddCell(DateTime.Now.ToString());

            doc.Add(headerTable);
            doc.Add(Chunk.NEWLINE);

            var botoomTable = new PdfPTable(new[] { 0.75f, 2f })
            {
                HorizontalAlignment = 0,
                WidthPercentage = 100,
                DefaultCell = { MinimumHeight = 22f }
            };

            botoomTable.AddCell("Rut empresa");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_rutEmpresa_s.Text);
            botoomTable.AddCell("Nombre empresa");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_nombreEmpresa_s.Text);
            botoomTable.AddCell("Dirección");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_direccion_s.Text);
            botoomTable.AddCell("Telefonó");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_telefono_s.Text);
            botoomTable.AddCell("Nombre seguro");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_nombreSeguro_s.Text);
            botoomTable.AddCell("Descripción");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_descripcion_s.Text);
            botoomTable.AddCell("Costo seguro");
            botoomTable.AddCell(Apoderados.Apoderados._instance.txt_costo_s.Text);


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
