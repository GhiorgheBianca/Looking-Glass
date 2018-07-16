﻿using System;
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
    public partial class Form19 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form19()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\fs1.mp3";
            player.URL = url1;
            //
        }

        //trecerea la Form-ul cuprinsului, respectiv oprirea coloanei sonore
        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
        //

        //afișarea Form-urilor cu imaginile reprezentative jocului selectat prin apăsarea label-ului corespunzător
        private void label1_Click(object sender, EventArgs e)
        {
            Form31 f31 = new Form31();
            f31.Show();
        }
        //

        private void Form19_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\fu.txt";

            string text1 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Class1.Limba == 1)
            {
                label2.Text = Class3.Titlu[19];
                label3.Text = Class3.Titlu[12];
                richTextBox2.Text = text1;
                button1.Text = Class3.Titlu[13];
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
            Form20 f20 = new Form20();
            f20.Show();
        }
        //

        //trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form18 f18 = new Form18();
            f18.Show();
        }
        //

        //închiderea aplicației
        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la cuprins.", button1);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[121], button1);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a afișa imagini cu Su-27 Flanker.", label1);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[136], label1);
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
