using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace chuc_coursework
{
    public partial class Createe2 : Form
    {
        Create ww;
        
        public Createe2(Create qq)
        {
            InitializeComponent();
            this.ww = qq;
        }

        private void Createe2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO Provider (name, address, telephone, score, mail, INN, OGRN, KPP) values (@name, @address, @telephone, @score, @mail, @INN, @OGRN, @KPP)");
            command.Connection = conn;
            command.Parameters.AddWithValue("name", textBox2.Text);
            command.Parameters.AddWithValue("address", textBox3.Text);
            command.Parameters.AddWithValue("telephone", textBox4.Text);
            command.Parameters.AddWithValue("score", textBox5.Text);
            command.Parameters.AddWithValue("mail", textBox6.Text);
            command.Parameters.AddWithValue("INN", textBox7.Text);
            command.Parameters.AddWithValue("OGRN", textBox8.Text);
            command.Parameters.AddWithValue("KPP", textBox9.Text);
            command.ExecuteNonQuery();
            conn.Close();
            ww.comboBox1.Items.Clear();
            ww.Toll();
            this.Hide();
             

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
