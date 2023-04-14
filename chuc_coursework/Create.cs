using Google.Protobuf.WellKnownTypes;
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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            Toll();
            Po();
            Vo();
        }
        public void Toll()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT name FROM Provider";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader[0].ToString());
            conn.Close();
            reader.Close();
        }

        public void Po()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT name FROM Product";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader[0].ToString());
            conn.Close();
            reader.Close();
        }

        public void Vo()
        {
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            string sql = "SELECT nds FROM NDS";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox3.Items.Add(reader[0].ToString());
            conn.Close();
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(authorization.connStr);
            conn.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO ReceiptInvoice (date,number,dateShipment,provider,retailSum,incomingSum,quantity,totalSum) values (@date,@number,@dateShipment,@provider,@retailSum,@incomingSum,@quantity,@totalSum)");
            command.Connection = conn;
            command.Parameters.AddWithValue("date", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("number", textBox3.Text);
            command.Parameters.AddWithValue("dateShipment", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("provider", comboBox1.SelectedItem);
            command.Parameters.AddWithValue("incomingSum", textBox4.Text);
            command.Parameters.AddWithValue("retailSum", Convert.ToDecimal(textBox6.Text));
            command.Parameters.AddWithValue("quantity", textBox3.Text);
            command.Parameters.AddWithValue("totalSum", Convert.ToDecimal(textBox2.Text));
            command.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add($"номер: {textBox1.Text}, контрагент: {comboBox1.Text}, название: {comboBox2.Text}, количество: {textBox3.Text}");
            decimal colich = Convert.ToDecimal(textBox3.Text);
            decimal prih = Convert.ToDecimal(textBox4.Text);
            decimal nd = Convert.ToDecimal(comboBox3.Text);
            switch (nd)
            {
                case 10:
                    decimal nan = colich * (prih * 1.1m);
                    textBox2.Text = ($"{Convert.ToString(nan)} руб.");

                    decimal nazen = Convert.ToDecimal(textBox5.Text);
                    decimal m = nan + nazen;
                    textBox6.Text = ($"{Convert.ToString(m)} руб.");
                    break;
                case 20:
                    decimal na = colich * (prih * 1.2m);
                    textBox2.Text = ($"{Convert.ToString(na)} руб.");

                    decimal naze = Convert.ToDecimal(textBox5.Text);
                    decimal mm = na + naze;
                    textBox6.Text =($"{Convert.ToString(mm)} руб.");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Createe2 createe2 = new Createe2();
            this.Hide();
            createe2.Show();
        }
    }
}
