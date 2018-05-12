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
            if (username == "admin" && password == "password")
            {
                MessageBox.Show(string.Format("you are now logged in as admin. Welcome {0}",username));
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();

            }
            else if (username == "administrator" && password == "administratorPassword") {
                MessageBox.Show(string.Format("you are now logged in as administrator. Welcome {0}", username));
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed, please try again");
            }



        }

      
    }
}
