using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManageMentSystem
{
    public class User
    {
        private string firstname;
        private string lastname;
        private string city;
        private string address;
        private string username;
        private string password;
        private DateTime dob;

        public string Firstname { get { return this.firstname; } set { this.firstname = value; } }
        public string Lastname { get { return this.lastname; } set { this.lastname = value; } }
        public string City { get { return this.city; } set { this.city = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Username { get => this.username; set => this.Address = value; }
        public string Password { get => this.password; set => this.password = value; }
        public DateTime Dob { get => this.dob; set => this.dob = value; }
    }
}
