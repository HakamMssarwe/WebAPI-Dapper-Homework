using DapperDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            RefreshUsersList();
            usersFoundList.DisplayMember = "Username"; 
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (DataAccess.UserIsValid(usernameInput.Text, passwordInput.Text))
                MessageBox.Show("True");
            else
                MessageBox.Show("False");

        }

        private void signupBtn_Click(object sender, EventArgs e)
        {

            if (DataAccess.CreateUser(usernameInput.Text, passwordInput.Text))
            {
                MessageBox.Show("User was created successfully");
                RefreshUsersList();
            }
            else
                MessageBox.Show("User already exist");

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DataAccess.DeleteUser(usernameInput.Text,passwordInput.Text);
            RefreshUsersList();
        }



        private void RefreshUsersList()
        {
            usersFoundList.DataSource = DataAccess.GetUsers();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            if (DataAccess.ChangePassword(usernameInput.Text, passwordInput.Text))
                MessageBox.Show("Password updated successfully");

            else
                MessageBox.Show("Invalid credintials");
            
        }
    }
}
