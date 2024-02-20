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

[Serializable]
public class DynamicTabControl
{
    public InkCanvas InkCanvas { get; set; }
    public object TabItems { get; set; }
    public bool CheckBoxChecked { get; set; }
    // Add more properties as needed for your dynamic panel data
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

        public WindowState windowstate = new WindowState();
        public DrawingBoard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btn_add_tabitem != null) 
            {
                TabItem tabItem = new TabItem();
                tabItem.Height = 30;
                tabItem.Width = 100;

                InkCanvas inkCanvas = new InkCanvas();

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
            try
            {
                windowstate.dynamicTabControl = new List<DynamicTabControl>();

                foreach (TabControl tabControl in tabcontrol.Items.OfType<TabControl>())
                {
                    TabItem tabItem = tabControl.SelectedItem as TabItem;

                    if (tabItem != null)
                    {
                        DynamicTabControl dynamicTabControl = new DynamicTabControl
                        {
                            TabItemHeader = tabItem.Header.ToString(),
                            // Add other relevant properties of TabItem

                            // Serialize the relevant information about InkCanvas
                            InkCanvasData = SerializeInkCanvas(tabItem.Content as InkCanvas)
                        };

                        windowstate.dynamicTabControl.Add(dynamicTabControl);
                    }
                }

                // Save to a file
                string filePath = "DrawingBoardData.dat";
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, windowstate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save form state: " + ex.Message);
            }
        }

        private byte[] SerializeInkCanvas(InkCanvas inkCanvas)
        {
            // Implement your serialization logic for InkCanvas here
            // Convert relevant information to a byte array
            // Example: using MemoryStream and BinaryWriter
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Write relevant information to the stream
                    // Example: writer.Write(inkCanvas.SomeProperty);
                }

                return stream.ToArray();
            }
        }
        public void Load()
        {
            try
            {
                string filePath = "DrawingBoardData.dat";
                if (File.Exists(filePath))
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        windowstate = (WindowState1)formatter.Deserialize(fileStream);

                        foreach (var dynamicTabControl in windowstate.dynamicTabControl)
                        {
                            TabItem tabItem = new TabItem();
                            tabItem.Height = 30;
                            tabItem.Width = 100;

                            InkCanvas inkCanvas = new InkCanvas();

                            tabItem.Content = inkCanvas;

                            tabcontrol.Items.Add(tabItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form state: " + ex.Message);
            }
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
