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

            User userLogin = new User(username, password);
            List<User> userLoginCredentials = userLogin.GetLoginCredentials();
            foreach (User item in userLoginCredentials)
            {
                if (item.Equals(userLogin))
                {
                    MessageBox.Show("Welcome to the Farming Game", "Welcome", MessageBoxButtons.OK);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
