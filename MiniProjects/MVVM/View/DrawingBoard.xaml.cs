using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
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
using System.Xml;

[Serializable]
public class DynamicTabControl
{
    
    public InkCanvas InkCanvas { get; set; }
    public string TabItemHeader { get; set; } // Assuming the header is a string
    public bool CheckBoxChecked { get; set; }
    public byte[] InkCanvasData { get; set; } // Serialized data for InkCanvas
}

[Serializable]
public class WindowState1
{
    public List<DynamicTabControl> dynamicTabControl { get; set; }
    public List<object> TabItems { get; set; }


    // Add more properties as needed for your form data
}

namespace MiniProjects.MVVM.View
{
    /// <summary>
    /// Interaction logic for DrawingBoard.xaml
    /// </summary>
    public partial class DrawingBoard : UserControl
    {

        int Width_number;
        int Height_number;

        

        public WindowState windowstate = new WindowState();

        public DrawingBoard()
        {
            InitializeComponent();
        }
        public DrawingBoard(int width_number, int height_number)
        {
            this.Width_number = width_number;
            this.Height_number = height_number;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btn_add_tabitem != null) 
            {
                TabItem tabItem = new TabItem();
                tabItem.Height = 30;
                tabItem.Width = 100;

                

                InkCanvas inkCanvas = new InkCanvas();
                inkCanvas.Width = this.Width_number;


                tabItem.Content = inkCanvas;
                

                tabcontrol.Items.Add(tabItem);                
            }
        }

        private void btn_remove_tabitem_Click(object sender, RoutedEventArgs e)
        {
            List<TabItem> controlsToRemove = new List<TabItem>();
            if (btn_remove_tabitem != null && tabcontrol.SelectedItem is TabItem focusedTabItem)
            {
                foreach (var item in tabcontrol.Items)
                {
                    if (item is TabItem tabItem)
                    {
                        if (tabItem == focusedTabItem)
                        {
                            controlsToRemove.Add(tabItem);
                            break;
                        }
                    }
                }
                foreach (Control controlToRemove in controlsToRemove)
                {
                    tabcontrol.Items.Remove(controlToRemove);
                }
            }
        }

        private void txt_Height(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            string textBoxValue = textBox.Text;
            int number = int.Parse(textBoxValue);

            this.Height_number = number;
        }
        private void txt_Width(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            string textBoxValue = textBox.Text;
            int number = int.Parse(textBoxValue);

            this.Width_number = number;
        }
        

        //private void Window_Save()
        //{
        //    try
        //    {
        //        // Save dynamic panel states
        //        windowstate.DynamicTabControl = new List<DynamicTabControl>();
        //        foreach (Control control in tabcontrol.Items)
        //        {
        //            if (control is TabControl Tabs)
        //            {
        //                DynamicTabControl dynamicTabControl = new DynamicTabControl
        //                {
        //                    TabItems = Tabs.Items.OfType<TabItem>().FirstOrDefault()?.Content,
        //                    InkCanvas = Tabs.Items.OfType<InkCanvas>().FirstOrDefault(),
        //                    //LabelText = panel.Items.OfType<Label>().FirstOrDefault().Content

        //                };
        //                windowstate.DynamicTabControl.Add(dynamicTabControl);
        //            }
        //        }

        //        // Save to a file
        //        string filePath = "DrawingBoardData.dat";
        //        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            IFormatter formatter = new BinaryFormatter();
        //            formatter.Serialize(fileStream, windowstate);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to save form state: " + ex.Message);
        //    }
        //}

        private void Window_Save()
        {
            
        }

        
        public void Load()
        {
            
        }
        private void Window_Load(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Window_Save();
        }
    }
}
