using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmingGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtEmailVer.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                FileHandler fh = new FileHandler(fileName);
                List<string> li = new List<string>();
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;
                string emailVer = txtEmailVer.Text;

                li.Add(string.Format("{0} {1} {2} {3}", username, password, email, emailVer));


                fh.WriteData(li);
                MessageBox.Show("Registration Complete!", "Congratulations", MessageBoxButtons.OK);

            }
            finally
            {
                
            }
        }
    }
}
