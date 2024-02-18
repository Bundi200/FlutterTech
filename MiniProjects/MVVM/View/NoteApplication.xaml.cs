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
public class DynamicListState
{
    public string LabelText { get; set; }
    public string TextBoxText { get; set; }
    public bool CheckBoxChecked { get; set; }
    // Add more properties as needed for your dynamic panel data
}

[Serializable]
public class WindowState
{
    public List<DynamicListState> DynamicListsStates { get; set; }
    public List<string> TextBoxTexts { get; set; }
    public bool CheckBoxChecked { get; set; }

    // Add more properties as needed for your form data
}

namespace MiniProjects.MVVM.View
{
    /// <summary>
    /// Interaction logic for NoteApplication.xaml
    /// </summary>
    public partial class NoteApplication : UserControl
    {
        private WindowState windowstate = new WindowState();
        public NoteApplication()
        {
            InitializeComponent();
        }

        private void chk_CheckAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var checkboxs in lst_Notes.Items)
            {
                if (chk_CheckAll.IsChecked == true)
                {
                    if (checkboxs is ListBox listbox)
                    {
                        CheckBox associatedCheckBox = listbox.Items.OfType<CheckBox>().FirstOrDefault();
                        if (associatedCheckBox != null)
                        {
                            associatedCheckBox.IsChecked = true;
                        }
                    }
                }

                if (!chk_CheckAll.IsChecked == true)
                {
                    if (checkboxs is ListBox listbox)
                    {
                        CheckBox associatedCheckBox = listbox.Items.OfType<CheckBox>().FirstOrDefault();
                        if (associatedCheckBox.IsChecked == true)
                        {
                            associatedCheckBox.IsChecked = false;
                        }
                    }
                }
            }
        }

        private void btn_AddPanel_Click(object sender, RoutedEventArgs e)
        {
            if (btn_AddPanel != null)
            {
                DateTime currentDate = DateTime.Now;

                ListBox dynamicPanel = new ListBox();
                dynamicPanel.Margin = new Thickness(1);
                dynamicPanel.Visibility = Visibility.Visible;
                dynamicPanel.Background = new SolidColorBrush(Colors.Silver);
                dynamicPanel.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 252, 206, 24));
                dynamicPanel.BorderThickness = new Thickness(3);

                CheckBox checkBox = new CheckBox();
                checkBox.Visibility = Visibility.Visible;
                checkBox.Margin = new Thickness(2);

                TextBox textbox = new TextBox();
                textbox.Name = "btn_Text";
                textbox.Visibility = Visibility.Visible;
                textbox.Margin = new Thickness(4);
                textbox.Text = currentDate.ToString();
                textbox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                textbox.AcceptsReturn = true;
                textbox.AcceptsTab = true;
                textbox.AutoWordSelection = true;
                textbox.TextAlignment = TextAlignment.Left;
                textbox.TextWrapping = TextWrapping.Wrap; textbox.SelectionStart = 1;
                textbox.SelectionLength = 0;
                textbox.SelectionStart = 1;
                textbox.Focusable = true;
                textbox.UseLayoutRounding = true;
                textbox.UndoLimit = 0;
                textbox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox.Background = new SolidColorBrush(Colors.Azure);
                textbox.HorizontalAlignment = HorizontalAlignment.Left;
                textbox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox.VerticalAlignment = VerticalAlignment.Top;
                textbox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox.Padding = new Thickness(2);
                textbox.MaxHeight = 500;
                textbox.MinHeight = 200;
                textbox.Width = 1235;

                dynamicPanel.Items.Add(textbox);
                dynamicPanel.Items.Add(checkBox);

                lst_Notes.Items.Add(dynamicPanel);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            List<ListBox> controlsToRemove = new List<ListBox>();

            foreach (var item in lst_Notes.Items)
            {
                if (item is ListBox listbox)
                {
                    CheckBox associatedCheckBox = listbox.Items.OfType<CheckBox>().FirstOrDefault();
                    if (associatedCheckBox != null && associatedCheckBox.IsChecked == true)
                    {
                        controlsToRemove.Add(listbox);
                    }
                }
            }

            foreach (Control controlToRemove in controlsToRemove)
            {
                lst_Notes.Items.Remove(controlToRemove);
            }
        }

        private void grd_DataGridForTexts_LayoutUpdated(object sender, EventArgs e)
        {
            //List<TextBox> controlsToAdd = new List<TextBox>();

            //foreach (var items in lst_Notes.Items)
            //{
            //    if (items is ListBox listbox)
            //    {
            //        CheckBox checkBox = listbox.Items.OfType<CheckBox>().FirstOrDefault();
            //        if (checkBox.IsChecked != null && checkBox.IsChecked == true)
            //        {
            //            TextBox textBox = new TextBox();
            //            textBox.Visibility = Visibility.Visible;
            //            textBox.Margin = new Thickness(2);
            //            textBox.Background = new SolidColorBrush(Colors.Black);
            //            // Check if a height value is non-negative before setting it
            //            double height = 200; // Set your desired height value
            //            if (height >= 0)
            //            {
            //                textBox.Height = height;
            //                lst_DataPanelForTexts.Items.Add(textBox);
            //            }
            //        }
            //    }
            //}

            //foreach (TextBox controlToAdd in controlsToAdd)
            //{
            //    lst_DataPanelForTexts.Items.Add(controlToAdd);
            //}
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Window_Save();
        }

        private void Window_Closing_Save(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Save();
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            Load_Window_State();
        }

        private void Window_Save()
        {
            try
            {
                // Save dynamic panel states
                windowstate.DynamicListsStates = new List<DynamicListState>();
                foreach (Control control in lst_Notes.Items)
                {
                    if (control is ListBox panel)
                    {
                        DynamicListState dynamicPanelState = new DynamicListState
                        {
                            TextBoxText = panel.Items.OfType<TextBox>().FirstOrDefault()?.Text,
                            CheckBoxChecked = panel.Items.OfType<CheckBox>().FirstOrDefault()?.IsChecked ?? false,
                            //LabelText = panel.Items.OfType<Label>().FirstOrDefault().Content

                        };
                        windowstate.DynamicListsStates.Add(dynamicPanelState);
                    }
                }

                // Save to a file
                string filePath = "formState.dat";
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

        private void Load_Window_State()
        {
            try
            {
                // Load from a file
                string filePath = "formState.dat";
                if (File.Exists(filePath))
                {
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        windowstate = (WindowState)formatter.Deserialize(fileStream);

                        // Apply the loaded state to your form controls

                        // Recreate dynamic panels
                        foreach (var dynamicPanelState in windowstate.DynamicListsStates)
                        {
                            DateTime currentDate = DateTime.Now;

                            ListBox dynamicPanel = new ListBox();
                            dynamicPanel.Margin = new Thickness(1);
                            dynamicPanel.Visibility = Visibility.Visible;
                            dynamicPanel.Background = new SolidColorBrush(Colors.Silver);
                            dynamicPanel.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 252, 206, 24));
                            dynamicPanel.BorderThickness = new Thickness(3);


                            CheckBox checkBox = new CheckBox();
                            checkBox.Visibility = Visibility.Visible;
                            checkBox.Margin = new Thickness(2);

                            TextBox textbox = new TextBox();
                            textbox.Name = "pnl_test";
                            textbox.Visibility = Visibility.Visible;
                            textbox.Margin = new Thickness(4);
                            textbox.Text = dynamicPanelState.TextBoxText; // Set the text based on the loaded state
                            textbox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                            textbox.AcceptsReturn = true;
                            textbox.AcceptsTab = true;
                            textbox.AutoWordSelection = true;
                            textbox.TextAlignment = TextAlignment.Left;
                            textbox.TextWrapping = TextWrapping.Wrap; textbox.SelectionStart = 1;
                            textbox.SelectionLength = 0;
                            textbox.SelectionStart = 1;
                            textbox.Focusable = true;
                            textbox.UseLayoutRounding = true;
                            textbox.UndoLimit = 0;
                            textbox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                            textbox.Background = new SolidColorBrush(Colors.Azure);
                            textbox.HorizontalAlignment = HorizontalAlignment.Left;
                            textbox.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                            textbox.VerticalAlignment = VerticalAlignment.Top;
                            textbox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                            textbox.Padding = new Thickness(2);
                            textbox.MaxHeight = 500;
                            textbox.MinHeight = 200;
                            textbox.Width = 1235;

                            dynamicPanel.Items.Add(textbox);
                            dynamicPanel.Items.Add(checkBox);

                            lst_Notes.Items.Add(dynamicPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load form state: " + ex.Message);
            }
        }


    }
}
