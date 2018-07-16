using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LGS
{
    public partial class Form32 : Form
    {
        public Form32()
        {
            InitializeComponent();
        }

        int i = 0;

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class4.variabila);

            con.Open();
            /*string querry = @"SELECT * FROM Accounts WHERE Email = ' " + textBox2.Text + " ' AND Password = ' " + textBox1.Text + " ' ";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            if(reader.HasRows == true)
            {
                this.Hide();
                Form33 f33 = new Form33();
                f33.Show();
            }
            else
            {
                if (Class1.Limba == 0)
                    MessageBox.Show("Eroare de autentificare!");
                else if (Class1.Limba == 1)
                    MessageBox.Show(Class3.Titlu[49]);
            }*/
            
            string querry = @"SELECT * FROM Accounts WHERE Email = '" + textBox2.Text + "' ";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.HasRows == true)
            {
                textBox2.BackColor = System.Drawing.Color.White;
                textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Regular);

                con.Close();
                con.Open();
                querry = @"SELECT * FROM Accounts WHERE Email = '" + textBox2.Text + "' AND Password = '" + textBox1.Text + "' ";

                SqlCommand com1 = new SqlCommand(querry, con);
                reader = com1.ExecuteReader();

                if (reader.HasRows == true)
                {
                    reader.Close();

                    string querry1 = @"UPDATE Accounts SET Connection = @connection WHERE Email = '" + textBox2.Text + "' AND Password = '" + textBox1.Text + "' ";
                    SqlCommand com2 = new SqlCommand(querry1, con);
                    com2.Parameters.AddWithValue("connection", "1");
                    com2.ExecuteNonQuery();


                    Class4.conectat = textBox2.Text;
                    textBox1.BackColor = System.Drawing.Color.White;
                    textBox1.ForeColor = System.Drawing.Color.Black;
                    this.Hide();
                    Form35 f35 = new Form35();
                    f35.Show();
                }
                else
                {
                    textBox1.BackColor = System.Drawing.Color.DarkOrange;
                    textBox1.ForeColor = System.Drawing.Color.White;
                    textBox2.BackColor = System.Drawing.Color.White;
                    textBox2.ForeColor = System.Drawing.Color.Black;
                    textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Regular);

                    if (Class1.Limba == 0)
                        MessageBox.Show("Parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else MessageBox.Show(Class3.Titlu[48], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBox2.BackColor = System.Drawing.Color.DarkOrange;
                textBox2.ForeColor = System.Drawing.Color.White;
                textBox2.Font = new Font(textBox2.Font.FontFamily, textBox2.Font.Size, FontStyle.Bold);

                if (Class1.Limba == 0)
                    MessageBox.Show("Email invalid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(Class1.Limba == 1)
                    MessageBox.Show(Class3.Titlu[47], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void Form32_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            if (Class1.Limba == 1)
            {
                label3.Text = Class3.Titlu[42];
                label1.Text = Class3.Titlu[43];
                label5.Text = Class3.Titlu[44];
                label4.Text = Class3.Titlu[45];
                button1.Text = Class3.Titlu[46];
                label6.Text = Class3.Titlu[97];
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form34 f34 = new Form34();
            f34.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                button5.Image = imageList2.Images[1];
                textBox1.UseSystemPasswordChar = false;
                i = 1;
            }
            else if (i == 1)
            {
                button5.Image = imageList2.Images[0];
                textBox1.UseSystemPasswordChar = true;
                i = 0;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form37 f37 = new Form37();
            f37.Show();
        }

        /*
         1, 25, 2, 3, 4, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31

//închiderea aplicației
//trecerea la Form-ul cu descrierea jocului Ultima Underworld

//informații suplimentare legate de butoane
ToolTip tip = new ToolTip();

 if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înainte.", button2);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[125], button2);
            }


if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce înapoi.", button3);
            }
            else if(Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[124], button3);
            }


if (Class1.Limba == 0)
            {
                tip.Show("Apasă pentru a te duce la cuprins.", button1);
            }
            else if (Class1.Limba == 1)
            {
                tip.Show(Class3.Titlu[121], button1);
            }


//căutarea și memorarea locului unde se află coloana sonoră corespunzătoare Form-ului curent

//găsirea fișierului de tip .txt, unde se află secvențele de text în engleză

//stabilirea limbii pentru acest Form și înlocuirea cu textul tradus, în cazul în care limba selectată este engleză

//pornirea, respectiv oprirea muzicii în funcție de setarea sonorului din cuprins

//trecerea la Form-ul cuprinsului, respectiv oprirea coloanei sonore

//trecerea la următorul Form, respectiv oprirea coloanei sonore

//trecerea la Form-ul precedent, respectiv oprirea coloanei sonore
          */
    }
}
