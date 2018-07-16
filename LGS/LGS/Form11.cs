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
    public partial class Form11 : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form11()
        {
            InitializeComponent();

            //căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent
            string url1 = Application.StartupPath;
            url1 = url1.Substring(0, url1.Length - 10);
            url1 = url1 + @"\Muzica\07 Thief 2 OST - Ambush.mp3";
            player.URL = url1;
            //
        }

        //trecerea la Form-ul cu întrebări, respectiv oprirea coloanei sonore
        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }
        //

        //trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
        private void button3_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }
        //

        //închiderea aplicației
        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //

        private void Form11_Load(object sender, EventArgs e)
        {
            //găsirea fișierului de tip .txt, unde se află secvențele de text în engleză
            string text = Application.StartupPath;
            text = text.Substring(0, text.Length - 10);
            text = text + @"\texte_EN\t22.txt";
            string text1 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 7);
            text = text + @"t23.txt";
            string text2 = System.IO.File.ReadAllText(text);

            text = text.Substring(0, text.Length - 7);
            text = text + @"t24.txt";
            string text3 = System.IO.File.ReadAllText(text);
            //

            //stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză
            if (Class1.Limba == 1)
            {
                richTextBox1.Text = text1;
                richTextBox3.Text = text2;
                richTextBox2.Text = text3;
                label1.Text = Class3.Titlu[14];
                label3.Text = Class3.Titlu[53];
                label2.Text = Class3.Titlu[16];
                button1.Text = Class3.Titlu[54];
            }
            //

            //pornirea, respectiv oprirea muzicii în funcție de setarea sonorului din cuprins
            if (Class2.Muzica == 0)
                player.controls.play();
            else if (Class2.Muzica == 1)
                player.controls.stop();
            //
        }

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
                tip.Show("Apasă pentru a te duce la chestionar.", button1);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[126], button1);
            }
        }
        //
    }
}
