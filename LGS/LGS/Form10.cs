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
    public partial class Form10 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form10()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\05 Thief 2 OST - Shipping and Receiving.mp3";
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

        private void Form10_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvența de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\t21.txt";

            string text1 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Class1.Limba == 1)
            {
                richTextBox2.Text = text1;
                label2.Text = Class3.Titlu[11];
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
            Form11 f11 = new Form11();
            f11.Show();
        }
        //

        //trecerea la Form-ul jocului precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
        //

        //închiderea aplicației
        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
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
        //
    }
}
