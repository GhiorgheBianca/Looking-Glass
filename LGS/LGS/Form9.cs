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
    public partial class Form9 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form9()
        {
            InitializeComponent();
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\fs3.mp3";
            player.URL = url1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\fu3.txt";

            string text1 = System.IO.File.ReadAllText(text);
            if (Class1.Limba == 1)
            {
                label2.Text = Class3.Titlu[19];
                richTextBox2.Text = text1;
                button1.Text = Class3.Titlu[13];
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
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
