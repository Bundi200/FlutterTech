using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MiniProjects.MVVM.View
{
    /// <summary>
    /// Interaction logic for EmployeePromotion.xaml
    /// </summary>
    public partial class EmployeePromotion : UserControl
    {
        public EmployeePromotion()
        {
            InitializeComponent();
        }
        string Textbox1Constuctors;
        string Textbox2Constuctors;
        string Textbox3Constuctors;
        string Textbox4Constuctors;
        public EmployeePromotion(string textbox1Constuctors, string textbox2Constuctors, string textbox3Constuctors, string textbox4Constuctors)
        {
            //"this" refers to an instance of this class, to an object of this class for more read ability
            this.Textbox1Constuctors = textbox1Constuctors;
            this.Textbox2Constuctors = textbox2Constuctors;
            this.Textbox3Constuctors = textbox3Constuctors;
            this.Textbox4Constuctors = textbox4Constuctors;
        }

        private void btn_New_Employee_Click(object sender, RoutedEventArgs e/* ,string textbox1Constuctors*/)
        {
            List<Employee> list = new List<Employee>();

            if (btn_New_Employee != null)
            {
                ListBox dynamicPanel = new ListBox();
                dynamicPanel.Margin = new Thickness(1);
                dynamicPanel.Visibility = Visibility.Visible;
                dynamicPanel.Background = new SolidColorBrush(Colors.Yellow);
                dynamicPanel.Width = 770;


                CheckBox checkBox = new CheckBox();
                checkBox.Visibility = Visibility.Visible;
                checkBox.Margin = new Thickness(2);

                TextBox textbox1 = new TextBox();
                textbox1.Name = "btn_Text1";
                textbox1.Visibility = Visibility.Visible;
                textbox1.Margin = new Thickness(1);
                textbox1.BorderBrush = new SolidColorBrush(Colors.White);
                textbox1.AcceptsReturn = true;
                textbox1.AcceptsTab = true;
                textbox1.AutoWordSelection = true;
                textbox1.TextAlignment = TextAlignment.Left;
                textbox1.TextWrapping = TextWrapping.Wrap; textbox1.SelectionStart = 1;
                textbox1.SelectionLength = 0;
                textbox1.SelectionStart = 1;
                textbox1.Focusable = true;
                textbox1.UseLayoutRounding = true;
                textbox1.UndoLimit = 0;
                textbox1.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox1.Background = new SolidColorBrush(Colors.Azure);
                textbox1.HorizontalAlignment = HorizontalAlignment.Center;
                textbox1.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox1.VerticalAlignment = VerticalAlignment.Top;
                textbox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox1.Padding = new Thickness(1);
                textbox1.MaxHeight = 50;
                textbox1.MinHeight = 20;
                textbox1.Width = 134;

                TextBox textbox2 = new TextBox();
                textbox2.Name = "btn_Text2";
                textbox2.Visibility = Visibility.Visible;
                textbox2.Margin = new Thickness(1);
                textbox2.BorderBrush = new SolidColorBrush(Colors.White);
                textbox2.AcceptsReturn = true;
                textbox2.AcceptsTab = true;
                textbox2.AutoWordSelection = true;
                textbox2.TextAlignment = TextAlignment.Left;
                textbox2.TextWrapping = TextWrapping.Wrap; textbox2.SelectionStart = 1;
                textbox2.SelectionLength = 0;
                textbox2.SelectionStart = 1;
                textbox2.Focusable = true;
                textbox2.UseLayoutRounding = true;
                textbox2.UndoLimit = 0;
                textbox2.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox2.Background = new SolidColorBrush(Colors.Azure);
                textbox2.HorizontalAlignment = HorizontalAlignment.Left;
                textbox2.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox2.VerticalAlignment = VerticalAlignment.Top;
                textbox2.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox2.Padding = new Thickness(1);
                textbox2.MaxHeight = 50;
                textbox2.MinHeight = 20;
                textbox2.Width = 134;

                TextBox textbox3 = new TextBox();
                textbox3.Name = "btn_Text3";
                textbox3.Visibility = Visibility.Visible;
                textbox3.Margin = new Thickness(1);
                textbox3.BorderBrush = new SolidColorBrush(Colors.White);
                textbox3.AcceptsReturn = true;
                textbox3.AcceptsTab = true;
                textbox3.AutoWordSelection = true;
                textbox3.TextAlignment = TextAlignment.Left;
                textbox3.TextWrapping = TextWrapping.Wrap; textbox3.SelectionStart = 1;
                textbox3.SelectionLength = 0;
                textbox3.SelectionStart = 1;
                textbox3.Focusable = true;
                textbox3.UseLayoutRounding = true;
                textbox3.UndoLimit = 0;
                textbox3.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox3.Background = new SolidColorBrush(Colors.Azure);
                textbox3.HorizontalAlignment = HorizontalAlignment.Left;
                textbox3.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox3.VerticalAlignment = VerticalAlignment.Top;
                textbox3.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox3.Padding = new Thickness(1);
                textbox3.MaxHeight = 50;
                textbox3.MinHeight = 20;
                textbox3.Width = 134;

                TextBox textbox4 = new TextBox();
                textbox4.Name = "btn_Text4";
                textbox4.Visibility = Visibility.Visible;
                textbox4.Margin = new Thickness(1);
                textbox4.BorderBrush = new SolidColorBrush(Colors.White);
                textbox4.AcceptsReturn = true;
                textbox4.AcceptsTab = true;
                textbox4.AutoWordSelection = true;
                textbox4.TextAlignment = TextAlignment.Left;
                textbox4.TextWrapping = TextWrapping.Wrap; textbox4.SelectionStart = 1;
                textbox4.SelectionLength = 0;
                textbox4.SelectionStart = 1;
                textbox4.Focusable = true;
                textbox4.UseLayoutRounding = true;
                textbox4.UndoLimit = 0;
                textbox4.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox4.Background = new SolidColorBrush(Colors.Azure);
                textbox4.HorizontalAlignment = HorizontalAlignment.Left;
                textbox4.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox4.VerticalAlignment = VerticalAlignment.Top;
                textbox4.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                textbox4.Padding = new Thickness(1);
                textbox4.MaxHeight = 50;
                textbox4.MinHeight = 20;
                textbox4.Width = 134;


                Label label1 = new Label();
                label1.Name = "lbl_ID";
                label1.Content = "ID";
                label1.Visibility = Visibility.Visible;
                label1.Margin = new Thickness(1);
                label1.BorderBrush = new SolidColorBrush(Colors.White);
                label1.Focusable = true;
                label1.UseLayoutRounding = true;
                label1.Background = new SolidColorBrush(Colors.Azure);
                label1.HorizontalAlignment = HorizontalAlignment.Left;
                label1.VerticalAlignment = VerticalAlignment.Top;
                label1.Padding = new Thickness(1);
                label1.MaxHeight = 50;
                label1.MinHeight = 20;
                label1.Width = 134;

                Label label2 = new Label();
                label2.Name = "lbl_Name";
                label2.Content = "Name";
                label2.Visibility = Visibility.Visible;
                label2.Margin = new Thickness(1);
                label2.BorderBrush = new SolidColorBrush(Colors.White);
                label2.Focusable = true;
                label2.UseLayoutRounding = true;
                label2.Background = new SolidColorBrush(Colors.Azure);
                label2.HorizontalAlignment = HorizontalAlignment.Left;
                label2.VerticalAlignment = VerticalAlignment.Top;
                label2.Padding = new Thickness(1);
                label2.MaxHeight = 50;
                label2.MinHeight = 20;
                label2.Width = 134;

                Label label3 = new Label();
                label3.Name = "lbl_Salary";
                label3.Content = "Salary";
                label3.Visibility = Visibility.Visible;
                label3.Margin = new Thickness(1);
                label3.BorderBrush = new SolidColorBrush(Colors.White);
                label3.Focusable = true;
                label3.UseLayoutRounding = true;
                label3.Background = new SolidColorBrush(Colors.Azure);
                label3.HorizontalAlignment = HorizontalAlignment.Left;
                label3.VerticalAlignment = VerticalAlignment.Top;
                label3.Padding = new Thickness(1);
                label3.MaxHeight = 50;
                label3.MinHeight = 20;
                label3.Width = 134;

                Label label4 = new Label();
                label4.Name = "lbl_Experience";
                label4.Content = "Experinece";
                label4.Visibility = Visibility.Visible;
                label4.Margin = new Thickness(1);
                label4.BorderBrush = new SolidColorBrush(Colors.White);
                label4.Focusable = true;
                label4.UseLayoutRounding = true;
                label4.Background = new SolidColorBrush(Colors.Azure);
                label4.HorizontalAlignment = HorizontalAlignment.Left;
                label4.VerticalAlignment = VerticalAlignment.Top;
                label4.Padding = new Thickness(1);
                label4.MaxHeight = 50;
                label4.MinHeight = 20;
                label4.Width = 134;

                Grid grid = new Grid();


                RowDefinition rowDefinition1 = new RowDefinition();
                RowDefinition rowDefinition2 = new RowDefinition();

                //rowDefinition1.Height = new GridLength(50, GridUnitType.Pixel);
                //rowDefinition2.Height = new GridLength(50, GridUnitType.Pixel);

                grid.RowDefinitions.Add(rowDefinition1);
                grid.RowDefinitions.Add(rowDefinition2);

                Grid.SetRow(label1, 0);
                Grid.SetRow(label2, 0);
                Grid.SetRow(label3, 0);
                Grid.SetRow(label4, 0);

                Grid.SetRow(textbox1, 1);
                Grid.SetRow(textbox2, 1);
                Grid.SetRow(textbox3, 1);
                Grid.SetRow(textbox4, 1);

                // Define RowDefinitions
                ColumnDefinition ColumnDef1 = new ColumnDefinition();
                ColumnDefinition ColumnDef2 = new ColumnDefinition();
                ColumnDefinition ColumnDef3 = new ColumnDefinition();
                ColumnDefinition ColumnDef4 = new ColumnDefinition();

                ColumnDef1.Width = new GridLength(134, GridUnitType.Pixel);
                ColumnDef2.Width = new GridLength(134, GridUnitType.Pixel);
                ColumnDef3.Width = new GridLength(134, GridUnitType.Pixel);
                ColumnDef4.Width = new GridLength(134, GridUnitType.Pixel);

                // Add RowDefinitions to the Grid
                grid.ColumnDefinitions.Add(ColumnDef1);
                grid.ColumnDefinitions.Add(ColumnDef2);
                grid.ColumnDefinitions.Add(ColumnDef3);
                grid.ColumnDefinitions.Add(ColumnDef4);

                Grid.SetColumn(textbox1, 0);
                Grid.SetColumn(textbox2, 1);
                Grid.SetColumn(textbox3, 2);
                Grid.SetColumn(textbox4, 3);

                Grid.SetColumn(label1, 0);
                Grid.SetColumn(label2, 1);
                Grid.SetColumn(label3, 2);
                Grid.SetColumn(label4, 3);
                // Add TextBox controls to the Grid
                grid.Children.Add(textbox1);
                grid.Children.Add(textbox2);
                grid.Children.Add(textbox3);
                grid.Children.Add(textbox4);
                grid.Children.Add(label1);
                grid.Children.Add(label2);
                grid.Children.Add(label3);
                grid.Children.Add(label4);

                dynamicPanel.Items.Add(grid);

                lst_Employees.Items.Add(dynamicPanel);


                List<EmployeePromotion> empList1 = new List<EmployeePromotion>();
                empList1.Add(new EmployeePromotion() { });
            }
        }

        public static void EmployeeLogic()
        {
            EmployeePromotion employeePromotion = new EmployeePromotion();

            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee() { ID = 1, Name = "Mark", Salary = 5000, Experience = 5 });
            empList.Add(new Employee() { ID = 1, Name = "Pat", Salary = 7000, Experience = 1 });
            empList.Add(new Employee() { ID = 1, Name = "Gab", Salary = 1000, Experience = 4 });
            empList.Add(new Employee() { ID = 1, Name = "Abel", Salary = 60000, Experience = 20 });
            empList.Add(new Employee() { });


            List<EmployeePromotion> empList1 = new List<EmployeePromotion>();
            empList1.Add(new EmployeePromotion() { });

            IsPromotable isPromotable = new IsPromotable(IsPromotoable);

            Employee.Promotion(empList, isPromotable);

            List<ListBox> controlsToRemove = new List<ListBox>();

            //foreach (var item in lst_Employees(employeePromotion).Items)
            //{
            //    if (item is ListBox listbox)
            //    {
            //        TextBox associatedCheckBox = listbox.Items.OfType<TextBox>().FirstOrDefault();
            //        empList.Add(new Employee() { associatedCheckBox.Text });
            //    }
            //}
        }
        public static bool IsPromotoable(Employee emp)
        {
            if (emp.Experience >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public delegate bool IsPromotable(Employee PromoteEmployee);

    public class Employee : EmployeePromotion
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void Promotion(List<Employee> emplist, IsPromotable IsEligiableToPromote)
        {
            foreach (Employee employee in emplist)
            {
                if (IsEligiableToPromote(employee))
                {
                    MessageBox.Show(employee.Name + " promoted");
                }
            }
        }
    }
}
