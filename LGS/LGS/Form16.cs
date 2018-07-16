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
    public partial class Form16 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form16()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\UW2 08_[Jon Blackley & Dan Schmidt] - UW2 - Sewers.mp3";
            player.URL = url1;
            //
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\uw22.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 8);
            text = text + @"uw23.txt";
            string text2 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 8);
            text = text + @"uw24.txt";
            string text3 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Class1.Limba == 1)
            {
                label2.Text = Class3.Titlu[15];
                label3.Text = Class3.Titlu[17];
                label1.Text = Class3.Titlu[16];
                richTextBox2.Text = text1;
                richTextBox3.Text = text2;
                richTextBox1.Text = text3;
            }
            //

            //pornirea, respectiv oprirea muzicii în funcție de setarea sonorului din cuprins
            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
            //
        }

        //trecerea la următorul Form, respectiv oprirea coloanei sonore
        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form17 f17 = new Form17();
            f17.Show();
        }
        //

        //trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }
        //

        //închiderea aplicației
        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        //informații suplimentare legate de butoane
        ToolTip tip = new ToolTip();
        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button3);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button3);
            }
        }

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
