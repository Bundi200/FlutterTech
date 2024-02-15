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

namespace MiniProjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateLabel();
        }
        //test hogy le ment e?
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
    }
}
