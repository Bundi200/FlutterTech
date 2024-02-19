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

//[Serializable]
//public class DynamicListState
//{
//    public string LabelText { get; set; }
//    public string TextBoxText { get; set; }
//    public bool CheckBoxChecked { get; set; }
//    // Add more properties as needed for your dynamic panel data
//}

//[Serializable]
//public class WindowState
//{
//    public List<DynamicListState> DynamicListsStates { get; set; }
//    public List<string> TextBoxTexts { get; set; }
//    public bool CheckBoxChecked { get; set; }

//    // Add more properties as needed for your form data
//}

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
        //        windowstate.DynamicListsStates = new List<DynamicListState>();
        //        foreach (Control control in TC_DrawingBoard.Items)
        //        {
        //            if (control is ListBox panel)
        //            {
        //                DynamicListState dynamicPanelState = new DynamicListState
        //                {
        //                    TextBoxText = panel.Items.OfType<TextBox>().FirstOrDefault()?.Text,
        //                    CheckBoxChecked = panel.Items.OfType<CheckBox>().FirstOrDefault()?.IsChecked ?? false,
        //                    //LabelText = panel.Items.OfType<Label>().FirstOrDefault().Content

        //                };
        //                windowstate.DynamicListsStates.Add(dynamicPanelState);
        //            }
        //        }

        //        // Save to a file
        //        string filePath = "formState.dat";
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
    }
}
