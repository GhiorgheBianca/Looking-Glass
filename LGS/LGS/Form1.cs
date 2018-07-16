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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //stabilirea locație bazei de date pentru întreaga aplicație
            string a = Application.StartupPath;
            a = a.Substring(0, a.Length - 10);
            a = a + @"\Database1.mdf";

            string b = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + a + "; Integrated Security = True";

            Class4.variabila = b;
            //


            //stabilirea contului care era înregistrat ultima dată
            SqlConnection con = new SqlConnection(Class4.variabila);
            con.Open();
            string querry = @"SELECT * FROM Accounts WHERE Connection = '" + 1 + "' ";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();

            Class4.conectat = "";

            while(reader.Read())
            if(reader.HasRows == true)
            {
                Class4.conectat = reader["Email"].ToString();
            }
            //

            //începerea timer-ului
            timer1.Enabled = true;
            //
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //creșterea valorii progressBar-ului
            progressBar1.Value++;
            if (progressBar1.Value == 50)
            {
                //grăbirea procesului când progressBar-ul ajunge la valoarea 50
                timer1.Interval = 20;
            }
            else if (progressBar1.Value == 100)
            {
                //oprirea progressBar-ului când acesta ajunge la valoarea 100 și trecerea la următorul Form
                timer1.Enabled = false;
                this.Hide();
                Form25 f25 = new Form25();
                f25.Show();
            }
            //
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
