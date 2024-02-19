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

namespace MiniProjects.MVVM.View
{
    /// <summary>
    /// Interaction logic for DrawingBoard.xaml
    /// </summary>
    public partial class DrawingBoard : UserControl
    {
        public DrawingBoard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btn_add_tabitem != null) 
            {
                TabItem tabItem = new TabItem();

                InkCanvas inkCanvas = new InkCanvas();

                tabItem.Content = inkCanvas;

                tabcontrol.Items.Add(tabItem);

                
            }
        }

        private void btn_remove_tabitem_Click(object sender, RoutedEventArgs e)
        {
            List<TabControl> controlsToRemove = new List<TabControl>();
            if (btn_remove_tabitem != null)
            {
                foreach(var item in tabcontrol.Items)
                { 
                    if (item is TabControl tabControl)
                    {
                        TabItem tabItem = tabcontrol.Items.OfType<TabItem>().FirstOrDefault();
                        if (tabItem != null) 
                        {
                            controlsToRemove.Add(tabControl);
                        }
                    }
                }
                foreach (Control controlToRemove in controlsToRemove)
                {
                    tabcontrol.Items.Remove(controlToRemove);
                }
            }
        }
    }
}
