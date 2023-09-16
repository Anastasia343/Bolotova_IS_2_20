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

namespace chuc_coursework
{
    public partial class Create3 : Form
    {
        public Create3()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            this.Hide();
        }
    }
}
