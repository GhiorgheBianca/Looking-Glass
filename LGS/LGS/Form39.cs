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
    public partial class Form39 : Form
    {
        public Form39()
        {
            InitializeComponent();
        }

        bool bday = true;
        int id_nou;

        private void Form39_Load(object sender, EventArgs e)
        {
            if (Class1.Limba == 1)
            {
                label1.Text = Class3.Titlu[145];
                nameLabel.Text = Class3.Titlu[76];
                passwordLabel.Text = Class3.Titlu[78];
                birthdayLabel.Text = Class3.Titlu[79];
                genderLabel.Text = Class3.Titlu[141];
                connectionLabel.Text = Class3.Titlu[142];
                security_QuestionLabel.Text = Class3.Titlu[143];
                security_AnswerLabel.Text = Class3.Titlu[144];
                button1.Text = Class3.Titlu[81];
                button2.Text = Class3.Titlu[146];
                button3.Text = Class3.Titlu[60];
                button4.Text = Class3.Titlu[60];
                label2.Text = Class3.Titlu[141];
                label5.Text = Class3.Titlu[142];
                label10.Text = Class3.Titlu[143];
                label3.Text = Class3.Titlu[148];
                label4.Text = Class3.Titlu[149];
                label7.Text = Class3.Titlu[150];
                label6.Text = Class3.Titlu[151];
                label9.Text = Class3.Titlu[152];
                label8.Text = Class3.Titlu[153];
                label14.Text = Class3.Titlu[154];
                label12.Text = Class3.Titlu[155];
                label11.Text = Class3.Titlu[156];
                label13.Text = Class3.Titlu[157];
                label16.Text = Class3.Titlu[158];
                groupBox1.Text = Class3.Titlu[159];
                button6.Text = Class3.Titlu[34];
                button7.Text = Class3.Titlu[161];
                label19.Text = Class3.Titlu[162];
                textBox1.Text = Class3.Titlu[163];

                genderTextBox.Location = new Point(613, 166);
                connectionTextBox.Location = new Point(613, 192);
                security_QuestionTextBox.Location = new Point(613, 218);
                security_AnswerTextBox.Location = new Point(613, 244);
                statusTextBox.Location = new Point(613, 270);
                label12.Location = new Point(615, 58);
                label11.Location = new Point(615, 85);
                label13.Location = new Point(615, 111);
            }

            SqlConnection con = new SqlConnection(Class4.variabila);
            con.Open();
            string querry2 = @"SELECT * FROM Accounts";
            SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            DateTime date = DateTime.Now;
            if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
            }
            else
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                birthdayDateTimePicker.Visible = true;

            genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailTextBox.Text == Class4.conectat)
                Class4.conectat = "";

            SqlConnection con = new SqlConnection(Class4.variabila);
            con.Open();
            string querry = @"DELETE FROM Accounts WHERE Id = '" + idTextBox.Text + "' ";

            SqlCommand com = new SqlCommand(querry, con);

            com.ExecuteNonQuery();
            con.Close();

            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);


            idTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";

            DateTime date = DateTime.Now;
            birthdayDateTimePicker.Text = date.ToString();

            genderTextBox.Text = "";
            connectionTextBox.Text = "";
            security_QuestionTextBox.Text = "";
            security_AnswerTextBox.Text = "";
            statusTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Text != "" && genderTextBox.Text != "" && connectionTextBox.Text != "" && security_AnswerTextBox.Text != "" && security_QuestionTextBox.Text != "" && statusTextBox.Text != "")
            {

                button4.Visible = false;

                SqlConnection con = new SqlConnection(Class4.variabila);
                con.Open();

                string querry1 = @"SELECT * FROM Accounts WHERE Email = '" + emailTextBox.Text + "' ";

                SqlCommand com1 = new SqlCommand(querry1, con);
                SqlDataReader reader1 = com1.ExecuteReader();

                if (reader1.HasRows == true)
                {
                    reader1.Close();

                    if (Class1.Limba == 0)
                        MessageBox.Show("Email-ul există deja în baza de date.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Class1.Limba == 1)
                        MessageBox.Show(Class3.Titlu[72], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (reader1.HasRows == false)
                {
                    reader1.Close();

                    emailTextBox.BackColor = System.Drawing.Color.White;
                    emailTextBox.ForeColor = System.Drawing.Color.Black;

                    string Name, Email, Password, Security_Answer;
                    int Gender, Connection = 0, Security_Question, Status = 0;
                    Name = nameTextBox.Text;
                    Email = emailTextBox.Text;
                    Password = passwordTextBox.Text;
                    Gender = Int32.Parse(genderTextBox.Text);
                    Security_Question = Int32.Parse(security_QuestionTextBox.Text);
                    Security_Answer = security_AnswerTextBox.Text;

                    string querry;
                    if (bday == true)
                        querry = @"INSERT INTO Accounts (Name, Email, Password, Birthday, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + birthdayDateTimePicker.Text + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";
                    else
                    {
                        querry = @"INSERT INTO Accounts (Name, Email, Password, Gender, Connection, Security_Question, Security_Answer, Status) VALUES ('" + Name + "' , '" + Email + "' , '" + Password + "' , '" + Gender + "' , '" + Connection + "' , '" + Security_Question + "' , '" + Security_Answer + "' , '" + Status + "')";
                        birthdayDateTimePicker.Visible = false;
                    }

                    SqlCommand com = new SqlCommand(querry, con);
                    com.ExecuteNonQuery();


                    string querry2 = @"SELECT * FROM Accounts";
                    SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Close();

                    idTextBox.Text = dataGridView1.Rows[id_nou].Cells[0].Value.ToString();
                }
            }
            else
            {
                if (Class1.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Class1.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form39_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Fără" || button4.Text == "Without")
            {
                bday = false;
                birthdayDateTimePicker.Enabled = false;

                if (Class1.Limba == 0)
                    button4.Text = "Cu";
                else if (Class1.Limba == 1)
                    button4.Text = Class3.Titlu[139];
            }
            else if (button4.Text == "Cu" || button4.Text == "With")
            {
                bday = true;
                birthdayDateTimePicker.Enabled = true;

                if (Class1.Limba == 0)
                    button4.Text = "Fără";
                else if (Class1.Limba == 1)
                    button4.Text = Class3.Titlu[140];
            }

            if (button4.Text == "Modif." || button4.Text == "Add")
            {
                birthdayDateTimePicker.Visible = true;

                if (Class1.Limba == 0)
                    button4.Text = "Renunț";
                else if (Class1.Limba == 1)
                    button4.Text = Class3.Titlu[147];
            }
            else if (button4.Text == "Renunț" || button4.Text == "Cancel")
            {
                birthdayDateTimePicker.Visible = false;

                if (Class1.Limba == 0)
                    button4.Text = "Modif.";
                else if (Class1.Limba == 1)
                    button4.Text = Class3.Titlu[60];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Text != "" && genderTextBox.Text != "" && connectionTextBox.Text != "" && security_AnswerTextBox.Text != "" && security_QuestionTextBox.Text != "" && statusTextBox.Text != "")
            {
                SqlConnection con = new SqlConnection(Class4.variabila);
                con.Open();
                string querry;
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != "")
                    querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password , Birthday = @birthday , Gender = @gender , Connection = @connection , Security_Question = @question , Security_Answer = @answer , Status = @status WHERE Id = '" + idTextBox.Text + "' ";
                else querry = @"UPDATE Accounts SET Name = @name , Email = @email , Password = @password , Gender = @gender , Connection = @connection , Security_Question = @question , Security_Answer = @answer , Status = @status WHERE Id = '" + idTextBox.Text + "' ";

                SqlCommand com = new SqlCommand(querry, con);
                com.Parameters.AddWithValue("name", nameTextBox.Text);
                com.Parameters.AddWithValue("email", emailTextBox.Text);
                com.Parameters.AddWithValue("password", passwordTextBox.Text);
                com.Parameters.AddWithValue("gender", genderTextBox.Text);
                com.Parameters.AddWithValue("connection", connectionTextBox.Text);
                com.Parameters.AddWithValue("question", security_QuestionTextBox.Text);
                com.Parameters.AddWithValue("answer", security_AnswerTextBox.Text);
                com.Parameters.AddWithValue("status", statusTextBox.Text);

                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != "")
                    com.Parameters.AddWithValue("birthday", birthdayDateTimePicker.Text);

                com.ExecuteNonQuery();

                string querry2 = @"SELECT * FROM Accounts";
                SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

                button4.Visible = false;
            }
            else
            {
                if (Class1.Limba == 0)
                    MessageBox.Show("Există spații necompletate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Class1.Limba == 1)
                    MessageBox.Show(Class3.Titlu[77], Class3.Titlu[82], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();

            DateTime date = DateTime.Now;
            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
            }
            else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() == "")
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() == "")
            {
                birthdayDateTimePicker.Visible = true;
                button4.Visible = true;

                if (Class1.Limba == 0)
                {
                    button4.Text = "Fără";
                }
                else if (Class1.Limba == 1)
                {
                    button4.Text = Class3.Titlu[140];
                }
            }
            else if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() != "" && dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString() == "")
            {
                button4.Visible = true;

                if (Class1.Limba == 0)
                {
                    button4.Text = "Modif.";
                }
                else if (Class1.Limba == 1)
                {
                    button4.Text = Class3.Titlu[60];
                }
            }
            else button4.Visible = false;

            genderTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[9].Value.ToString();

            id_nou = dataGridView1.CurrentCell.RowIndex;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form35 f35 = new Form35();
            f35.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            passwordTextBox.Text = "";

            DateTime date = DateTime.Now;
            birthdayDateTimePicker.Text = date.ToString();

            genderTextBox.Text = "";
            connectionTextBox.Text = "";
            security_QuestionTextBox.Text = "";
            security_AnswerTextBox.Text = "";
            statusTextBox.Text = "";

            button7.Visible = true;

            int results = 0;
            DataTable tabel = new DataTable();

            tabel.Columns.Add("Id", typeof(int));
            tabel.Columns.Add("Name", typeof(string));
            tabel.Columns.Add("Email", typeof(string));
            tabel.Columns.Add("Password", typeof(string));
            tabel.Columns.Add("Birthday", typeof(DateTime));
            tabel.Columns.Add("Gender", typeof(int));
            tabel.Columns.Add("Connection", typeof(int));
            tabel.Columns.Add("Security_Question", typeof(int));
            tabel.Columns.Add("Security_Answer", typeof(string));
            tabel.Columns.Add("Status", typeof(int));

            SqlConnection con = new SqlConnection(Class4.variabila);
            con.Open();
            string querry = @"SELECT * FROM Accounts";

            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            string[] nume_prenume = new string[50];
            string[] nume_tabel = new string[50];
            while (reader.Read())
            {
                nume_prenume = textBox1.Text.Split(' ').Select(text => text.ToString()).ToArray();
                nume_tabel = reader["Name"].ToString().Split(' ').Select(text => text.ToString()).ToArray();
                if (nume_tabel[0] == nume_prenume[0] && nume_prenume.Length == 1)
                {
                    results++;

                    if(reader["Birthday"].ToString() == "")
                    tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                }
                else if (nume_tabel[1] == nume_prenume[0] && nume_prenume.Length == 1)
                {
                    results++;

                    if (reader["Birthday"].ToString() == "")
                        tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                }
                else if (nume_prenume.Length == 2)
                {
                    if (nume_tabel[0] + " " + nume_tabel[1] == nume_prenume[0] + " " + nume_prenume[1])
                    {
                        results++;

                        if (reader["Birthday"].ToString() == "")
                            tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    }
                }
                else if (nume_prenume.Length == 3 && nume_tabel.Length == 3)
                {
                    if (nume_tabel[0] + " " + nume_tabel[1] + " " + nume_tabel[2] == nume_prenume[0] + " " + nume_prenume[1] + " " + nume_prenume[2])
                    {
                        results++;

                        if (reader["Birthday"].ToString() == "")
                            tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                        else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    }
                }
                else if (reader["Email"].ToString() == textBox1.Text)
                {
                    results++;

                    if (reader["Birthday"].ToString() == "")
                        tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), null, reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                    else tabel.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Birthday"].ToString(), reader["Gender"].ToString(), reader["Connection"].ToString(), reader["Security_Question"].ToString(), reader["Security_Answer"].ToString(), reader["Status"].ToString());
                }
            }
            con.Close();

            dataGridView1.DataSource = tabel;

            if (results == 0)
            {
                label20.Visible = true;

                if (Class1.Limba == 0)
                    label20.Text = "Nu s-a găsit niciun cont cu datele menționate.";
                else if (Class1.Limba == 1)
                    label20.Text = Class3.Titlu[160];
            }
            else if (results == 1)
            {
                label20.Visible = true;

                if (Class1.Limba == 0)
                    label20.Text = "S-a găsit " + results.ToString() + " rezultat.";
                else if (Class1.Limba == 1)
                    label20.Text = "We found " + results.ToString() + " result.";
            }
            else if (results > 1)
            {
                label20.Visible = true;

                if (Class1.Limba == 0)
                    label20.Text = "S-au găsit " + results.ToString() + " rezultate.";
                else if (Class1.Limba == 1)
                    label20.Text = "We found " + results.ToString() + " results.";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class4.variabila);
            con.Open();
            string querry2 = @"SELECT * FROM Accounts";
            SqlDataAdapter sda = new SqlDataAdapter(querry2, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            label20.Visible = false;
            if (Class1.Limba == 0)
                textBox1.Text = "Nume/Prenume/Email";
            else if (Class1. Limba == 1)
                textBox1.Text = Class3.Titlu[163];

            textBox1.ForeColor = System.Drawing.Color.Gray;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Italic);

            button7.Visible = false;

            idTextBox.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            nameTextBox.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            emailTextBox.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            passwordTextBox.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            DateTime date = DateTime.Now;
            if (dataGridView1.Rows[0].Cells[4].Value.ToString() != "")
            {
                birthdayDateTimePicker.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                birthdayDateTimePicker.Visible = true;
            }
            else
            {
                birthdayDateTimePicker.Visible = false;
            }

            if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "")
                birthdayDateTimePicker.Visible = true;

            genderTextBox.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            connectionTextBox.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            security_QuestionTextBox.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            security_AnswerTextBox.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            statusTextBox.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nume/Prenume/Email" || textBox1.Text == "Surname/Name/Email")
                textBox1.Text = "";

            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size, FontStyle.Regular);
        }
    }
}
