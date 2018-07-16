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
    public partial class Form5 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form5()
        {
            InitializeComponent();
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\03 Thief Gold OST - Lord Bafford's Mannor.mp3";
            player.URL = url1;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\t1.txt";

            string text1 = System.IO.File.ReadAllText(text);
            if (Class1.Limba == 1)
            {
                richTextBox1.Text = text1;
                label1.Text = Class3.Titlu[11];
                button1.Text = Class3.Titlu[13];
            }

            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form23 f23 = new Form23();
            f23.Show();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
