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

namespace Lommeregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<double> nums = new List<double>();
        public List<char> op = new List<char>();
        public string currentString = String.Empty;
        public double result = 0;
        public int count = 0;
        public string textBoxString = String.Empty;

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            createNum('1');
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            createNum('2');
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            createNum('3');
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            createNum('4');
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            createNum('5');
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            createNum('6');
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            createNum('7');
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            createNum('8');
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            createNum('9');
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            createNum('0');
        }

        private void createNum(char c)
        {
            currentString += c;
            textBoxString += c;
            txtBox_Result.Clear();
            txtBox_Result.Text = textBoxString;
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (nums.Count != 0)
            {
                if (!OpSwitchCheck())
                    nums.Add(Convert.ToDouble(currentString));
                result = nums[count];
                count++;
                for (int i = 0; i < op.Count; i++)
                {
                    switch (op[i])
                    {
                        case '+':
                            result += nums[count];
                            count++;
                            break;
                        case '-':
                            result -= nums[count];
                            count++;
                            break;
                        case '*':
                            result *= nums[count];
                            count++;
                            break;
                        case '/':
                            result /= nums[count];
                            count++;
                            break;
                    }
                }

                txtBox_Result.Text = result.ToString();
                op.Clear();
                nums.Clear();
                textBoxString = String.Empty;
                currentString = String.Empty;
                result = 0;
            }
        }

        private void AddToTextBox(char c)
        {
            textBoxString += c;
            txtBox_Result.Clear();
            txtBox_Result.Text = textBoxString;
        }

        private bool OpSwitchCheck()
        {
            if (textBoxString[textBoxString.Length - 1] == '+' || textBoxString[textBoxString.Length - 1] == '-' ||
                textBoxString[textBoxString.Length - 1] == '/' || textBoxString[textBoxString.Length - 1] == '*')
            {
                op.RemoveAt(op.Count - 1);
                textBoxString = textBoxString.Substring(0, textBoxString.Length - 1);
                return true;
            }
            return false;
        }

        private bool FirstOpCheck()
        {
            if (currentString == String.Empty)
            {
                return true;
            }
            return false;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (!FirstOpCheck())
            {
                if (!OpSwitchCheck())
                    nums.Add(Convert.ToDouble(currentString));
                op.Add('+');
                AddToTextBox('+');
                currentString = String.Empty;
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!FirstOpCheck())
            {
                if (!OpSwitchCheck())
                    nums.Add(Convert.ToDouble(currentString));
                op.Add('-');
                AddToTextBox('-');
                currentString = String.Empty;
            }
        }

        private void btnDivider_Click(object sender, RoutedEventArgs e)
        {
            if (!FirstOpCheck())
            {
                if (!OpSwitchCheck())
                    nums.Add(Convert.ToDouble(currentString));
                op.Add('/');
                AddToTextBox('/');
                currentString = String.Empty;
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (!FirstOpCheck())
            {
                if (!OpSwitchCheck())
                    nums.Add(Convert.ToDouble(currentString));
                op.Add('*');
                AddToTextBox('*');
                currentString = String.Empty;
            }
        }

        private void btnNegative_Click(object sender, RoutedEventArgs e)
        {
            createNum('-');
        }
    }
}
