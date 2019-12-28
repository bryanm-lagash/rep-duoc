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

namespace OnTourWPF2._0.Dueño
{
    /// <summary>
    /// Lógica de interacción para Dueño.xaml
    /// </summary>
    public partial class Dueño : Window
    {
        bool MenuClosed = false;
        public Dueño()
        {
            InitializeComponent();
            instance = this;
            this.tabcontrol1.SelectedIndex = 3;
            rec1.Visibility = Visibility.Visible;
        }
        public static Dueño instance = null;

        public static Dueño _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dueño();
                }
                return instance;
            }
        }

        private void Close_Windows(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximized(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
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
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        private void MoveCursorMenu(int index)
        {

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

    }
}
