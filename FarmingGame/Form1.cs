using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BusinessLogicLayer;

namespace FarmingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            User user = new User();
            bool userCheck = user.UserLogin(username, password);
            if (userCheck)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect", "Login error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void llblRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser frmRegisterUser = new RegisterUser();
            frmRegisterUser.Show();
            this.Hide();
        }
    }
}
