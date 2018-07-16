﻿using System;
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
    public partial class Form38 : Form
    {
        public Form38()
        {
            InitializeComponent();
        }

        int i = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                button5.Image = imageList2.Images[1];
                textBox3.UseSystemPasswordChar = false;
                i = 1;
            }
            else if (i == 1)
            {
                button5.Image = imageList2.Images[0];
                textBox3.UseSystemPasswordChar = true;
                i = 0;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            Class3.Adevarat = false;
            if(e.KeyCode == Keys.Enter)
            {
                if (Class3.Parola == textBox3.Text)
                {
                    Class3.Adevarat = true;
                    this.Close();
                }
                else
                {
                    if (Class1.Limba == 0)
                        MessageBox.Show("Parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(Class3.Titlu[48], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form38_Load(object sender, EventArgs e)
        {
            if (Class1.Limba == 1)
            {
                label3.Text = Class3.Titlu[78];
                label1.Text = Class3.Titlu[104];
                label2.Text = Class3.Titlu[119];
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
