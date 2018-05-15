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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            CheckCredentials(username, password);
        }

        private void CheckCredentials(string username, string password )
        {
            if (username == "admin" && password == "password" || username == "administrator" && password == "administratorPassword")
            {
                ShowMessageAndForm(username);
            }
            else
            {
                MessageBox.Show("Login failed, try again u useless potato");
            }
        }

        private void ShowMessageAndForm(string username)
        {
            MessageBox.Show(string.Format("you are now logged in as admin. Welcome {0}", username));
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
