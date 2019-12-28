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

namespace OnTourWPF2._0
{
    /// <summary>
    /// Lógica de interacción para MessBoxes.xaml
    /// </summary>
    public partial class MessBoxes : Window
    {
        public string ReturnString { get; set; }

        public MessBoxes(string ex, string Text, SystemException.Buttons buttons)
        {
            InitializeComponent();


            txbText.Text = ex;
            messBarra.Text = Text;



            switch (buttons)
            {
                case SystemException.Buttons.OK:
                    btnOK.Visibility = Visibility.Visible;
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("iconos/iconoErrorTransparent.png", UriKind.Relative);
                    bi3.EndInit();
                    imgMB.Stretch = Stretch.UniformToFill;
                    imgMB.Source = bi3;
                    break;
                case SystemException.Buttons.Si_No:
                    btnYes.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    BitmapImage bi4 = new BitmapImage();
                    bi4.BeginInit();
                    bi4.UriSource = new Uri("iconos/iconoAdverTrans.png", UriKind.Relative);
                    bi4.EndInit();
                    imgMB.Stretch = Stretch.Fill;
                    imgMB.Source = bi4;
                    break;
                case SystemException.Buttons.OK2:
                    btnOK2.Visibility = Visibility.Visible;
                    BitmapImage bi5 = new BitmapImage();
                    bi5.BeginInit();
                    bi5.UriSource = new Uri("iconos/correcto2.png", UriKind.Relative);
                    bi5.EndInit();
                    imgMB.Stretch = Stretch.UniformToFill;
                    imgMB.Source = bi5;

                    break;
            }

        }



        private void gBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ReturnString = "-1";
            Close();
        }

        DoubleAnimation anim;


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Height = (txbText.LineCount * 27) + gBar.Height + 60;
        }

        public void btnReturnValue_Click(object sender, RoutedEventArgs e)
        {
            ReturnString = ((Button)sender).Uid.ToString();
            Close();
        }


    }
}

