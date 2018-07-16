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
    public partial class Form36 : Form
    {
        public Form36()
        {
            InitializeComponent();
        }

        private void Form36_Load(object sender, EventArgs e)
        {
            if (Class1.Limba == 1)
                label1.Text = Class3.Titlu[83] + ", " + Class4.nume_utilizator;
            else if (Class1.Limba == 0)
                label1.Text = label1.Text + ", " + Class4.nume_utilizator;
            label1.Text = label1.Text + "!";
        }

        private void Form36_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
