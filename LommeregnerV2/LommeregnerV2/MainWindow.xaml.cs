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

namespace LommeregnerV2
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

        #region numbers
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
        #endregion

        private void createNum(char c)
        {
            currentString += c;
            textBoxString += c;
            txtBox_Result.Clear();
            txtBox_Result.Text = textBoxString;
        }

        /// <summary>
        /// Goes through all the numers and operators in the list, and calculates the result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                count = 0;
                textBoxString = String.Empty;
                currentString = String.Empty;
                result = 0;
            }
        }

        /// <summary>
        /// Adds the current pressed char to the text box
        /// </summary>
        /// <param name="c"></param>
        private void AddToTextBox(char c)
        {
            textBoxString += c;
            txtBox_Result.Clear();
            txtBox_Result.Text = textBoxString;
        }

        /// <summary>
        /// Checks if two or more operators has been pressed in a row
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if the current string is empty or not
        /// </summary>
        /// <returns>returnns a blooean based on the result</returns>
        private bool FirstOpCheck()
        {
            if (currentString == String.Empty)
            {
                return true;
            }
            return false;
        }

        #region op Buttons
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

        #endregion
        
        /// <summary>
        /// Draws the circle on the canvas
        /// </summary>
        private void canvasCircle_Loaded(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            ell.Width = 200;
            ell.Height = 200;
            ell.Stroke = Brushes.Black;
            ell.StrokeThickness = 4;
            ell.Margin = new Thickness(canvasCircle.Width / 5, canvasCircle.Height / 5, 0, 0);
            canvasCircle.Children.Add(ell);
        }

        /// <summary>
        /// Calculates the area of the circle using the user input
        /// </summary>
        private void btnCalculateRadius_Click(object sender, RoutedEventArgs e)
        {
            if(txtBox_Radius.Text != String.Empty && int.TryParse(txtBox_Radius.Text, out int radius))
            {
                double result = Math.Pow(Convert.ToDouble(radius), 2) * Math.PI;
                lblCircleArea.Content = $"Area: {result.ToString()}";
            }
        }

        /// <summary>
        /// Draws the square on the canvas
        /// </summary>
        private void canvasSquare_Loaded(object sender, RoutedEventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect.Height = 200;
            rect.Width = 200;
            rect.Stroke = Brushes.Black;
            rect.StrokeThickness = 4;
            rect.Margin = new Thickness(canvasSquare.Width / 5, canvasSquare.Height / 5, 0, 0);
            canvasSquare.Children.Add(rect);
        }

        /// <summary>
        /// Button that takes the input from the text boxes, and uses it in the formula, to calculate the area of the square
        /// </summary>
        private void btnCalculateSquare_Click(object sender, RoutedEventArgs e)
        {
            if(txtBox_SquareHeight.Text != String.Empty && txtBox_SquareWidth.Text != String.Empty &&
                int.TryParse(txtBox_SquareHeight.Text, out int height) && int.TryParse(txtBox_SquareWidth.Text, out int width))
            {
                double result = height * width;
                lblSquareArea.Content = $"Area: {result.ToString()}";
            }
        }

        /// <summary>
        /// Event handler that is called when the canvas is loaded. It draws the trapez on he canvas
        /// </summary>
        private void canvasTrapez_Loaded(object sender, RoutedEventArgs e)
        {
            Line l1 = new Line();
            l1.X1 = 50;
            l1.Y1 = 250;
            l1.X2 = 300;
            l1.Y2 = 250;
            l1.Stroke = Brushes.Black;
            l1.StrokeThickness = 4;
            canvasTrapez.Children.Add(l1);

            Line l2 = new Line();
            l2.X1 = 50;
            l2.Y1 = 250;
            l2.X2 = 150;
            l2.Y2 = 150;
            l2.Stroke = Brushes.Black;
            l2.StrokeThickness = 4;
            canvasTrapez.Children.Add(l2);

            Line l3 = new Line();
            l3.X1 = 300;
            l3.Y1 = 250;
            l3.X2 = 200;
            l3.Y2 = 150;
            l3.Stroke = Brushes.Black;
            l3.StrokeThickness = 4;
            canvasTrapez.Children.Add(l3);

            Line l4 = new Line();
            l4.X1 = 150;
            l4.Y1 = 150;
            l4.X2 = 200;
            l4.Y2 = 150;
            l4.Stroke = Brushes.Black;
            l4.StrokeThickness = 4;
            canvasTrapez.Children.Add(l4);
        }

        /// <summary>
        /// Button click that takes the numbers from the text box and uses them in the formula
        /// to calculate and display the area of the trapez
        /// </summary>
        private void btnCalculateTrapez_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_TrapezHeight.Text != String.Empty && txtBox_TrapezBot.Text != String.Empty && txtBox_TrapezTop.Text != String.Empty &&
                double.TryParse(txtBox_TrapezHeight.Text, out double height) && double.TryParse(txtBox_TrapezBot.Text, out double bot) &&
                double.TryParse(txtBox_TrapezTop.Text, out double top))
            {
                double result = ((top + bot) / 2) * Convert.ToDouble(height);
                lblTrapezArea.Content = $"Area: {result.ToString()}";
            }
        }
    }
}
