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
using static System.Net.Mime.MediaTypeNames;

namespace MiniProjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point offset;
        public MainWindow()
        {
            InitializeComponent();
            UpdateLabel();
            

            MouseLeftButtonDown += Window_MouseLeftButtonDown;
            MouseMove += Window_MouseMove;
            MouseLeftButtonUp += Window_MouseLeftButtonUp;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point point = e.GetPosition(this);
                double newLeft = point.X - offset.X + Left;
                double newTop = point.Y - offset.Y + Top;
                Left = newLeft;
                Top = newTop;
            }
        }

        //private void test2(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ClickCount == 5) 
        //    {
        //        this.Close();
        //    }
        //}



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = true;
                offset = e.GetPosition(this);
            }
        }
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                isDragging = false;
            }
        }

        
        public void UpdateLabel()
        {
            int i = 0;
            if (i == 0)
            {
                Label label = new Label();
                label.Content = DateTime.Now.ToShortDateString();
                label.VerticalAlignment = VerticalAlignment.Center;
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.Foreground = new SolidColorBrush(Colors.White);

                lbl_date.Content = label;
            }
        }

        public void Buttons()
        {
            Button btnClose = new Button();
            Button btnRestoreDown = new Button();
            Button btnMinimise = new Button();
        }

        private void btn_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn_Minimise(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }
        private void btn_restore_down(object sender, RoutedEventArgs e)
        {
            

            if (btn_restore != null)
            {
                if (WindowState != System.Windows.WindowState.Maximized)
                {
                    WindowState = System.Windows.WindowState.Maximized;
                }
                else
                {
                    WindowState = System.Windows.WindowState.Normal;
                }                
            }
        }


        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ImageSource imageSource = new BitmapImage(new Uri("test1.png", UriKind.Relative));

            
        }
    }
}
