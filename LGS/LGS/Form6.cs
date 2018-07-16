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
    public partial class Form6 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form6()
        {
            InitializeComponent();
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\05 Thief Gold OST - Break from Cragscleft Prison.mp3";
            player.URL = url1;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\t2.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 6);
            text = text + @"t3.txt";
            string text2 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 6);
            text = text + @"t4.txt";
            string text3 = System.IO.File.ReadAllText(text);
            if (Class1.Limba == 1)
            {
                richTextBox1.Text = text1;
                richTextBox2.Text = text2;
                richTextBox3.Text = text3;
                label1.Text = Class3.Titlu[55];
                label2.Text = Class3.Titlu[14];
                label3.Text = Class3.Titlu[16];
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
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
