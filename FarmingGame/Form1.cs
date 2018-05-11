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
            int value = 10;
            JustALoop(value);

        }

        public static void JustALoop(int value)
        {
            for (int i = 0; i < value; i++)
            {
                if (i > 5)
                {
                    Console.WriteLine("I need to test a test");
                }
            }
        }
    }
}
