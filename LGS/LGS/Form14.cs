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
    public partial class Form14 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form14()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\UW The Fat Man - 05 - Maps & Legends.mp3";
            player.URL = url1;
            //
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\uw2.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 7);
            text = text + @"uw3.txt";
            string text2 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 7);
            text = text + @"uw4.txt";
            string text3 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Class1.Limba == 1)
            {
                richTextBox1.Text = text1;
                richTextBox2.Text = text2;
                richTextBox3.Text = text3;
                label2.Text = Class3.Titlu[14];
                label1.Text = Class3.Titlu[15];
                label3.Text = Class3.Titlu[16];
                label5.Text = Class3.Titlu[12];
            }
            //

            //pornirea, respectiv oprirea muzicii în funcție de setarea sonorului din cuprins
            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
            //
        }

        //afișarea Form-urilor cu imaginile reprezentative jocului selectat prin apăsarea label-ului corespunzător
        private void label6_Click(object sender, EventArgs e)
        {
            Form28 f28 = new Form28();
            f28.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form29 f29 = new Form29();
            f29.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form30 f30 = new Form30();
            f30.Show();
        }
        //

        //trecerea la următorul Form cu descrierea jocului Ultima Underworld II, respectiv oprirea coloanei sonore
        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }
        //

        //trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
        }
        //

        //închiderea aplicației
        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label6_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Wizardry.", label6);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[131], label6);
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Dungeon Master.", label4);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[132], label4);
            }
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Wolfenstein 3D.", label7);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[133], label7);
            }
        }
        //
    }
}
