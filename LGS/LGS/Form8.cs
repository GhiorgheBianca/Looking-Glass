using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace LGS
{
    public partial class Form8 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form8()
        {
            InitializeComponent();
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\SS2 Eric Brosius - 02 - Med Sci 1.mp3";
            player.URL = url1;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\ss23.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 8);
            text = text + @"ss24.txt";
            string text2 = System.IO.File.ReadAllText(text);
            if (Class1.Limba == 1)
            {
                richTextBox1.Text = text1;
                richTextBox2.Text = text2;
                label1.Text = Class3.Titlu[14];
                label2.Text = Class3.Titlu[16];
            }

            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
