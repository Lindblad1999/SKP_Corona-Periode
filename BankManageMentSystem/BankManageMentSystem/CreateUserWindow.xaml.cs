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
using System.Windows.Shapes;

namespace BankManageMentSystem
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private User currentUser;

        private bool passwordSuccess = false;
        private bool usernameSuccess = false;
        private bool firstnameSuccess = false;
        private bool lastnameSuccess = false;
        private bool citySuccess = false;
        private bool addressSuccess = false;
        private bool dobSuccess = false;

        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            currentUser = new User();
            currentUser.Firstname = txtBoxFirstname.Text;
            currentUser.Lastname = txtBoxLastname.Text;
            currentUser.City = txtBoxCity.Text;
            currentUser.Address = txtBoxAddress.Text;
            currentUser.Username = txtBoxUsername.Text;
            currentUser.Dob = (DateTime)DatePickerDate.SelectedDate;
            currentUser.Password = txtBoxPassword.Text;


            if (SQLTools.SQLCreateUser.CheckExistingUsername(currentUser.Username)) { MessageBox.Show("Username already exists"); }
            else
            {
                    SQLTools.SQLCreateUser.InsertNewUserInDB(currentUser);
                try
                {
                    LoginWindow newLoginWindow = new LoginWindow();
                    newLoginWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void FailMessage()
        {
            StringBuilder mes = new StringBuilder();
            mes.Append("Error!\n");
            if (!passwordSuccess) mes.Append("Passwords dont match!\n");
            if (!usernameSuccess) mes.Append("fail\n");

        }
    }
}
