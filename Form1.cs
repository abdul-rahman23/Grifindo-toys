using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "tommy";
            string password = "tommy";

            if (textBox1.Text == username && textBox2.Text == password)
            {
                this.Hide();
                Form2 form = new Form2();
                form.Show();

            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
        }
    }
}
