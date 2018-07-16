using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGS
{
    public partial class Form33 : Form
    {
        public Form33()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form24 f24 = new Form24();
            f24.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form33_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form33_Load(object sender, EventArgs e)
        {
            if(Class1.Limba == 1)
            {
                label1.Text = Class3.Titlu[50];
                button1.Text = Class3.Titlu[51];
                button2.Text = Class3.Titlu[52];
            }
        }
    }
}
