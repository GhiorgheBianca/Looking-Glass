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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\file1.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 9);
            text = text + @"file2.txt";
            string text2 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form
            if (Class1.Limba == 1)
            {
                label1.Text = Class3.Titlu[0];
                richTextBox1.Text = text1;
                label2.Text = Class3.Titlu[1];
                richTextBox2.Text = text2;
            }
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //trecerea la Form-ul cuprinsului
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
            //
        }

        //închiderea aplicației
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button2_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înainte.", button2);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[125], button2);
            }
        }
        //
    }
}
