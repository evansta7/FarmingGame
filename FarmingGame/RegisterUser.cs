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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;
            string confirm = txtPassword2.Text;
 
            if (password == confirm && password != null)
            {
                User user = new User(username, password);
                user.RegisterUser(user);
            }   
        }
    }
}
