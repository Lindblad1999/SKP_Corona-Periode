﻿using System;
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
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            nums.Add(Convert.ToDouble(currentString));
            for (int i = 0; i < op.Count; i++)
            {
                switch (op[i])
                {
                    case '+':
                        result += nums[i];
                        break;
                    case '-':
                        result -= nums[i];
                        break;
                    case '*':
                        result *= nums[i];
                        break;


                }
            }
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            nums.Add(Convert.ToDouble(currentString));
            op.Add('+');
            currentString = String.Empty;
        }
    }
}
