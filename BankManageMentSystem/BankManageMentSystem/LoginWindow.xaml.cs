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
using BankManageMentSystem.SQLTools;

namespace BankManageMentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            ConnectToSQL.ConnectionStringServerAuthentication();
            //ConnectToSQL.ConnectionStringWindowsAuthentication();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (SQLLogin.CheckLogin(txtBoxUsername.Text, passwordBoxPassword.Password))
            {
                MessageBox.Show("Success");
            }
            else
                MessageBox.Show("Failure");
        }

        private void lblNewUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("dads");
        }
    }
}
