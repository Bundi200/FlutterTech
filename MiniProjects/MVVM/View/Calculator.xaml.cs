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
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : UserControl
    {
        float num1, ans;
        int count;
        public Calculator()
        {
            InitializeComponent();
        }
        
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Clear();
        }

        private void btn_Num7_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 7;
        }

        private void btn_Num8_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 8;
        }

        private void btn_Num9_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 9;
        }

        private void btn_Num4_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 4;
        }

        private void btn_Num5_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 5;
        }

        private void btn_Num6_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 6;
        }

        private void btn_Num1_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 1;
        }

        private void btn_Num2_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 2;
        }

        private void btn_Num3_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 3;
        }

        private void btn_Num0_Click(object sender, RoutedEventArgs e)
        {
            txt_formula.Text = txt_formula.Text + 0;
        }

        private void btn_Dot_Click(object sender, RoutedEventArgs e)
        {
            int c = txt_formula.Text.Length;
            int flag = 0;
            string text = txt_formula.Text;
            for (int i = 0; i < c; i++)
            {
                if (text[i].ToString() == ".")
                {
                    flag = 1; break;
                }
                else
                {
                    flag = 0;
                }
            }
            if (flag == 0)
            {
                txt_formula.Text = txt_formula.Text + ".";
            }
        }
        private void btn_Brackets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Minus_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(txt_formula.Text);
            txt_formula.Clear();
            txt_formula.Focus();
            count = 1;
        }

        private void btn_Plus_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(txt_formula.Text);
            txt_formula.Clear();
            txt_formula.Focus();
            count = 2;
        }
        private void btn_Multiple_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(txt_formula.Text);
            txt_formula.Clear();
            txt_formula.Focus();
            count = 3;
        }
        private void btn_Divide_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(txt_formula.Text);
            txt_formula.Clear();
            txt_formula.Focus();
            count = 4;
        }

        private void btn_Equal_Click(object sender, RoutedEventArgs e)
        {
            compute(count);
        }

        public void compute(int count)
        {
            switch (count)
            {
                case 1:
                    ans = num1 - float.Parse(txt_formula.Text);
                    txt_formula.Text = ans.ToString();
                    break;
                case 2:
                    ans = num1 + float.Parse(txt_formula.Text);
                    txt_formula.Text = ans.ToString();
                    break;
                case 3:
                    ans = num1 * float.Parse(txt_formula.Text);
                    txt_formula.Text = ans.ToString();
                    break;
                case 4:
                    ans = num1 / float.Parse(txt_formula.Text);
                    txt_formula.Text = ans.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
